using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WordPressReader.Data;
using WordPressReader.Data.Entities;
using WordPressReader.Data.Models;
using WordPressReader.Helpers;

namespace WordPressReader
{


    public class CommentHandler : BaseHandler, ICommentHandler
    {
        private readonly HttpClient _commentsClient;

        public CommentHandler()
        {
            _commentsClient = SetupClient();
        }

        /// <summary>
        /// creates a new instance of PostsHandler with the specified parameters or default values
        /// </summary>
        public CommentHandler(DateTime? modifiedSince = null, string userAgent = null, string version = null, bool throwSerializationExceptions = true)
        {
            _throwSerializationExceptions = throwSerializationExceptions;
            _commentsClient = SetupClient(modifiedSince, userAgent, version);
        }

        /// <summary>
        /// gets a list of comments from the WordPress site, results can be controlled with the parameters.
        /// </summary>
        /// <param name="commentsUrl">the post's comment url (normally returned by the API)</param>
        /// <param name="perPage">how many items per page should be fetched</param>
        /// <param name="pageNr">used for paged requests</param>
        public async Task<WordPressEntitySet<Comment>> GetCommentsAsync(string commentsUrl, int perPage = 50, int pageNr = 1)
        {
            WordPressEntitySet<Comment> result = null;

            var response = await _commentsClient.GetAsync(commentsUrl.AddParametersToUrl(
                new Dictionary<string, string>()
                {
                    ["type"] = "comment",
                    ["per_page"] = perPage.ToString(),
                    ["page"] = pageNr.ToString()
                })).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntitySet<Comment>(responseJson, null, _throwSerializationExceptions);
            }
            else
            {
                var errorJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntitySet<Comment>(null, errorJson, _throwSerializationExceptions);
            }

            return result;
        }


        /// <summary>
        /// creates a new comment with an anonymous user. Requires the site to be set up for this
        /// </summary>
        /// <param name="baseUrl">the web site's address</param>
        /// <param name="authorName">name of the comment author</param>
        /// <param name="email">email of the comment authro</param>
        /// <param name="content">comment text</param>
        /// <param name="postId">the post id this comment should be posted to</param>
        /// <param name="parentId">id of the comment that receives the response</param>
        /// <returns></returns>
        public async Task<WordPressEntity<Comment>> CreateAnonymousComment(string baseUrl, string authorName, string email, string content, long postId, long parentId)
        {
            WordPressEntity<Comment> result = null;

            var postCommentUrl = baseUrl.GetPostApiUrl(Resource.Comments)
                .AddParameterToUrl("post", postId.ToString())
                .AddParameterToUrl("author_name", WebUtility.UrlEncode(authorName))
                .AddParameterToUrl("author_email", WebUtility.UrlEncode(email))
                .AddParameterToUrl("author_name", WebUtility.UrlEncode(authorName))
                .AddParameterToUrl("content", WebUtility.UrlEncode(content));

            if (parentId != 0)
            {
                postCommentUrl = postCommentUrl.AddParameterToUrl("parent", parentId.ToString());
            }

            var response = await _commentsClient.PostAsync(postCommentUrl, null).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntity<Comment>(responseJson, null, _throwSerializationExceptions);
            }
            else
            {
                var errorJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntity<Comment>(null, errorJson, _throwSerializationExceptions);
            }

            return result;
        }



    }
}
