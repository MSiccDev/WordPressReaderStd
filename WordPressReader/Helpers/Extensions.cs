using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using WordPressReader.Data.Entities;
using WordPressReader.Data.Models;

namespace WordPressReader.Helpers
{
    public static class Extensions
    {
        #region Public Methods

        /// <summary>
        /// orders the input list by parent and date
        /// </summary>
        public static IEnumerable<CommentWithChildLevel> OrderCommentsByParentAndDate(this WordPressEntitySet<Comment> comments)
        {
            List<CommentWithChildLevel> result = new List<CommentWithChildLevel>();

            var dictionary = new SortedDictionary<long, List<CommentWithChildLevel>>();

            if (comments?.Value?.Count > 0)
            {
                comments.Value.ForEach(c =>
                {
                    if (dictionary.ContainsKey(c.Parent))
                    {
                        dictionary[c.Parent].Add(new CommentWithChildLevel(c));
                    }
                    else
                    {
                        dictionary.Add(c.Parent, new List<CommentWithChildLevel> { new CommentWithChildLevel(c) });
                    }
                });

                result = dictionary.SingleOrDefault(c => c.Key == 0)
                    .Value.OrderBy(c => DateTime.Parse(c.Date))
                    .ToList();

                var commentsWithParent = dictionary.SkipWhile(l => l.Key == 0).OrderBy(l => l.Key);

                foreach (var list in commentsWithParent)
                {
                    var parent = result.SingleOrDefault(c => c.Id == list.Key);
                    if (parent != null)
                    {
                        list.Value.ForEach(c => c.ChildLevel = parent.ChildLevel + 1);
                        var orderedByDate = list.Value.OrderBy(c => DateTime.Parse(c.Date)).ToList();

                        if (result.Any(c => c.Id == parent.Id))
                        {
                            var indexOfParent = result.IndexOf(parent);
                            result.InsertRange(indexOfParent + 1, orderedByDate);
                        }
                    }
                    else
                    {
                        //fixing it in source
                        comments.Value.SingleOrDefault(c => c.Id == list.Value.First().Id).Parent = 0;
                        return comments.OrderCommentsByParentAndDate();
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// creates a string representation of an int[]
        /// </summary>
        public static string ToArrayString(this int[] array)
        {
            if (array.Length == 1)
                return array[0].ToString();

            if (array.Length > 1)
            {
                var sb = new StringBuilder();

                array.ToList().ForEach(i => sb
                    .Append(i)
                    .Append(","));

                var result = sb.ToString();

                return result.EndsWith(",") ? result.Substring(0, result.Length - 1) : result;
            }

            return string.Empty;
        }

        /// <summary>
        /// tries to extract the slug from an url
        /// </summary>
        public static string ToSlug(this string url)
        {
            var result = url.EndsWith("/") ? url.Substring(0, url.Length - 1) : url;

            result = result.Substring(result.LastIndexOf("/", StringComparison.OrdinalIgnoreCase) + 1);

            return result;
        }

        #endregion Public Methods
    }
}