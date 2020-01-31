using System;
using System.Net.Http;
using System.Threading.Tasks;
using WordPressReader.Data;
using WordPressReader.Data.Entities;
using WordPressReader.Data.Models;
using WordPressReader.Helpers;

namespace WordPressReader
{
    public interface IPostsHandler
    {
        #region Public Methods

        /// <summary>
        /// gets a single blog post from the WordPress site by Id
        /// </summary>
        /// <param name="baseUrl">
        /// the web site's address
        /// </param>
        /// <param name="postId">
        /// id of the post to fetch
        /// </param>
        Task<WordPressEntity<BlogPost>> GetPostAsync(string baseUrl, int postId);

        /// <summary>
        /// gets a single blog post by its slug - fetching a post by slug uses the post list API, so
        /// we are getting an EntitySet with one single entry
        /// </summary>
        /// <param name="baseUrl">
        /// the web site's address
        /// </param>
        /// <param name="slug">
        /// the slug of the post to fetch
        /// </param>
        Task<WordPressEntitySet<BlogPost>> GetPostBySlugAsync(string baseUrl, string slug);

        /// <summary>
        /// gets a list of posts from the WordPress site, results can be controlled with the parameters.
        /// </summary>
        /// <param name="baseUrl">
        /// the web site's address
        /// </param>
        /// <param name="perPage">
        /// how many items per page should be fetched
        /// </param>
        /// <param name="count">
        /// max items to be fetched
        /// </param>
        /// <param name="pageNr">
        /// used for paged requests
        /// </param>
        /// <param name="categories">
        /// array of category ids
        /// </param>
        /// <param name="order">
        /// option to sort the result
        /// </param>
        Task<WordPressEntitySet<BlogPost>> GetPostsAsync(string baseUrl, int perPage = 10, int count = 10, int pageNr = 1, int[]? categories = null, OrderBy order = OrderBy.Date);

        /// <summary>
        /// gets a list of posts with the specified tag ids from the WordPress site. results can be
        /// controlled with the parameters.
        /// </summary>
        /// <param name="tagIds">
        /// int array of tag ids
        /// </param>
        /// <param name="baseUrl">
        /// the web site's address
        /// </param>
        /// <param name="perPage">
        /// how many items per page should be fetched
        /// </param>
        /// <param name="count">
        /// max items to be fetched
        /// </param>
        /// <param name="pageNr">
        /// used for paged requests
        /// </param>
        /// <param name="categories">
        /// array of category ids
        /// </param>
        /// <param name="order">
        /// option to sort the result
        /// </param>
        Task<WordPressEntitySet<BlogPost>> GetPostsByTagsAsync(string baseUrl, int[] tagIds, int perPage = 10, int count = 10, int pageNr = 1, OrderBy order = OrderBy.Date);

        /// <summary>
        /// gets a list of posts with the specified search terms from the WordPress site. results
        /// can be controlled with the parameters.
        /// </summary>
        /// <param name="baseUrl">
        /// the web site's address
        /// </param>
        /// <param name="searchTerms">
        /// search terms for blog search
        /// </param>
        /// <param name="perPage">
        /// how many items per page should be fetched
        /// </param>
        /// <param name="count">
        /// max items to be fetched
        /// </param>
        /// <param name="pageNr">
        /// used for paged requests
        /// </param>
        /// <param name="categories">
        /// array of category ids
        /// </param>
        /// <param name="order">
        /// option to sort the result
        /// </param>
        Task<WordPressEntitySet<BlogPost>> SearchPostsAsync(string baseUrl, string searchTerms, int perPage = 10, int count = 10, int pageNr = 1, int[]? categories = null, OrderBy order = OrderBy.Date);

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