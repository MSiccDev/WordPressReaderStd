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
        #region Public Constructors

        public CommentHandler()
        {
        }

        /// <summary>
        /// creates a new instance of PostsHandler with the specified parameters or default values
        /// </summary>
        public CommentHandler(DateTime? modifiedSince = null, string? userAgent = null, string? version = null, bool throwSerializationExceptions = true)
        {
            this.ThrowSerializationExceptions = throwSerializationExceptions;
            SetupClient(modifiedSince, userAgent, version);
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// creates a new comment with an anonymous user. Requires the site to be set up for this
        /// </summary>
        /// <param name="baseUrl">
        /// the web site's address
        /// </param>
        /// <param name="authorName">
        /// name of the comment author
        /// </param>
        /// <param name="email">
        /// email of the comment authro
        /// </param>
        /// <param name="content">
        /// comment text
        /// </param>
        /// <param name="postId">
        /// the post id this comment should be posted to
        /// </param>
        /// <param name="parentId">
        /// id of the comment that receives the response
        /// </param>
        /// <returns>
        /// </returns>
        public async Task<WordPressEntity<Comment>> CreateAnonymousCommentAsync(string baseUrl, string authorName, string email, string content, long postId, long parentId)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new NullReferenceException($"parameter {nameof(baseUrl)} MUST not be null or empty");

            if (string.IsNullOrWhiteSpace(authorName))
                throw new NullReferenceException($"parameter {nameof(authorName)} MUST not be null or empty");

            if (string.IsNullOrWhiteSpace(email))
                throw new NullReferenceException($"parameter {nameof(email)} MUST not be null or empty");

            if (string.IsNullOrWhiteSpace(content))
                throw new NullReferenceException($"parameter {nameof(content)} MUST not be null or empty");

            if (postId == -1 || postId == default)
                throw new ArgumentException($"parameter {nameof(postId)} MUST be a valid post id");

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

            var response = await HttpClientInstance.PostAsync(postCommentUrl, null).ConfigureAwait(false);

            WordPressEntity<Comment> result;
            if (response.IsSuccessStatusCode)
            {
                result = new WordPressEntity<Comment>(response.Content, false, this.ThrowSerializationExceptions);
            }
            else
            {
                result = new WordPressEntity<Comment>(response.Content, true, this.ThrowSerializationExceptions);
            }

            return result;
        }

        /// <summary>
        /// gets a list of comments from the WordPress site, results can be controlled with the parameters.
        /// </summary>
        /// <param name="commentsUrl">
        /// the post's comment url (normally returned by the API)
        /// </param>
        /// <param name="perPage">
        /// how many items per page should be fetched
        /// </param>
        /// <param name="pageNr">
        /// used for paged requests
        /// </param>
        public async Task<WordPressEntitySet<Comment>> GetCommentsAsync(string commentsUrl, int perPage = 50, int pageNr = 1)
        {
            if (string.IsNullOrWhiteSpace(commentsUrl))
                throw new NullReferenceException($"parameter {nameof(commentsUrl)} MUST not be null or empty");

            var response = await HttpClientInstance.GetAsync(commentsUrl.AddParametersToUrl(
                new Dictionary<string, string>()
                {
                    ["type"] = "comment",
                    ["per_page"] = perPage.ToString(),
                    ["page"] = pageNr.ToString()
                })).ConfigureAwait(false);

            WordPressEntitySet<Comment> result;
            if (response.IsSuccessStatusCode)
            {
                result = new WordPressEntitySet<Comment>(response.Content, false, this.ThrowSerializationExceptions);
            }
            else
            {
                result = new WordPressEntitySet<Comment>(response.Content, true, this.ThrowSerializationExceptions);
            }

            return result;
        }

        #endregion Public Methods
    }
}