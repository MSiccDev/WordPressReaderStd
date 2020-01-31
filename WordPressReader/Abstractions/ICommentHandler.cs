using System;
using System.Net.Http;
using System.Threading.Tasks;
using WordPressReader.Data.Entities;
using WordPressReader.Data.Models;

namespace WordPressReader
{
    public interface ICommentHandler
    {
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
        Task<WordPressEntity<Comment>> CreateAnonymousCommentAsync(string baseUrl, string authorName, string email, string content, long postId, long parentId = 0);

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
        Task<WordPressEntitySet<Comment>> GetCommentsAsync(string commentsUrl, int perPage = 50, int pageNr = 1);

        /// <summary>
        /// Allows to configure your own HttpClient and pass it in here; will be set as static
        /// instance internally as HttpClient is built for reuse
        /// </summary>
        /// <param name="client">
        /// The HttpClient instance to use for all requests
        /// </param>
        void SetCustomClient(HttpClient client);

        /// <summary>
        /// creates a new instance of HttpClient with the specified parameters or default values
        /// </summary>
        HttpClient SetupClient(DateTime? modifiedSince = null, string? userAgent = null, string? version = null, bool useCompression = true);

        /// <summary>
        /// setting the user agent of an already existing HttpClient
        /// </summary>
        /// <param name="modifiedSince">
        /// setting the if modified since parameter
        /// </param>
        /// <param name="userAgent">
        /// setting UserAgent
        /// </param>
        /// <param name="version">
        /// setting UserAgent version
        /// </param>
        void SetUserAgent(HttpClient client, string userAgent, string version);

        #endregion Public Methods
    }
}