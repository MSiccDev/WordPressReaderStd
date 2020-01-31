using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WordPressReader.Data;
using WordPressReader.Data.Entities;
using WordPressReader.Data.Models;
using WordPressReader.Helpers;

namespace WordPressReader
{
    public class PostsHandler : BaseHandler, IPostsHandler
    {
        #region Public Constructors

        public PostsHandler()
        {
        }

        /// <summary>
        /// creates a new instance of PostsHandler with the specified parameters or default values
        /// </summary>
        public PostsHandler(DateTime? modifiedSince = null, string? userAgent = null, string? version = null, bool throwSerializationExceptions = true)
        {
            this.ThrowSerializationExceptions = throwSerializationExceptions;
            SetupClient(modifiedSince, userAgent, version);
        }

        #endregion Public Constructors

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
        public async Task<WordPressEntity<BlogPost>> GetPostAsync(string baseUrl, int postId)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new NullReferenceException($"parameter {nameof(baseUrl)} MUST not be null or empty");

            if (postId == -1 || postId == default)
                throw new ArgumentException($"parameter {nameof(postId)} MUST be a valid post id");

            var response = await HttpClientInstance.GetAsync(baseUrl.GetEntityApiUrl(postId)).ConfigureAwait(false);

            WordPressEntity<BlogPost> result;
            if (response.IsSuccessStatusCode)
            {
                result = new WordPressEntity<BlogPost>(response.Content, false, this.ThrowSerializationExceptions);
            }
            else
            {
                result = new WordPressEntity<BlogPost>(response.Content, true, this.ThrowSerializationExceptions);
            }

            return result;
        }

        //fetching a post by slug uses the post list API, so we are getting an EntitySet with one single entry here...
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
        public async Task<WordPressEntitySet<BlogPost>> GetPostBySlugAsync(string baseUrl, string slug)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new NullReferenceException($"parameter {nameof(baseUrl)} MUST not be null or empty");

            if (string.IsNullOrWhiteSpace(slug))
                throw new NullReferenceException($"parameter {nameof(slug)} MUST not be null or empty");
            var response = await HttpClientInstance.GetAsync(
                baseUrl.GetEntitySetApiUrl(Resource.Posts, 1, 1)
                .AddParameterToUrl(nameof(slug), slug))
                .ConfigureAwait(false);

            WordPressEntitySet<BlogPost> result;
            if (response.IsSuccessStatusCode)
            {
                result = new WordPressEntitySet<BlogPost>(response.Content, false, this.ThrowSerializationExceptions);
            }
            else
            {
                result = new WordPressEntitySet<BlogPost>(response.Content, true, this.ThrowSerializationExceptions);
            }

            return result;
        }

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
        public async Task<WordPressEntitySet<BlogPost>> GetPostsAsync(string baseUrl, int perPage = 10, int count = 10, int pageNr = 1, int[]? categories = null, OrderBy order = OrderBy.Date)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new NullReferenceException($"parameter {nameof(baseUrl)} MUST not be null or empty");

            var additionalParams = new Dictionary<string, string>();
            if (categories != null)
                additionalParams.Add(Constants.ParameterCategories, categories.ToArrayString());

            var response = await HttpClientInstance
                .GetAsync(baseUrl.GetEntitySetApiUrl(Resource.Posts, perPage, count, pageNr, order)
                .AddParametersToUrl(additionalParams))
                .ConfigureAwait(false);

            WordPressEntitySet<BlogPost> result;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                result = new WordPressEntitySet<BlogPost>(response.Content, false, this.ThrowSerializationExceptions);
            }
            else
            {
                result = new WordPressEntitySet<BlogPost>(response.Content, true, this.ThrowSerializationExceptions);
            }

            return result;
        }

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
        public async Task<WordPressEntitySet<BlogPost>> GetPostsByTagsAsync(string baseUrl, int[] tagIds, int perPage = 10, int count = 10, int pageNr = 1, OrderBy order = OrderBy.Date)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new NullReferenceException($"parameter {nameof(baseUrl)} MUST not be null or empty");

            if (tagIds == null || tagIds.Count() == 0)
                throw new ArgumentException($"parameter {nameof(tagIds)} MUST not be null or empty and MUST have Count() > 0");

            var response = await HttpClientInstance.GetAsync(
                baseUrl.GetEntitySetApiUrl(Resource.Posts, perPage, count, pageNr, order)
                .AddParameterToUrl("tags", tagIds.ToArrayString()))
                .ConfigureAwait(false);

            WordPressEntitySet<BlogPost> result;
            if (response.IsSuccessStatusCode)
            {
                result = new WordPressEntitySet<BlogPost>(response.Content, false, this.ThrowSerializationExceptions);
            }
            else
            {
                result = new WordPressEntitySet<BlogPost>(response.Content, true, this.ThrowSerializationExceptions);
            }
            return result;
        }

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
        public async Task<WordPressEntitySet<BlogPost>> SearchPostsAsync(string baseUrl, string searchTerms, int perPage = 10, int count = 10, int pageNr = 1, int[]? categories = null, OrderBy order = OrderBy.Date)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new NullReferenceException($"parameter {nameof(baseUrl)} MUST not be null or empty");

            if (string.IsNullOrWhiteSpace(searchTerms))
                throw new NullReferenceException($"parameter {nameof(searchTerms)} MUST not be null or empty");

            var additionalParams = new Dictionary<string, string>()
            {
                ["search"] = WebUtility.UrlEncode(searchTerms),
            };

            if (categories != null)
                additionalParams.Add(Constants.ParameterCategories, categories.ToArrayString());

            var response = await HttpClientInstance.GetAsync(
                baseUrl.GetEntitySetApiUrl(Resource.Posts, perPage, count, pageNr, order)
                .AddParametersToUrl(additionalParams))
                .ConfigureAwait(false);

            WordPressEntitySet<BlogPost> result;
            if (response.IsSuccessStatusCode)
            {
                result = new WordPressEntitySet<BlogPost>(response.Content, false, this.ThrowSerializationExceptions);
            }
            else
            {
                result = new WordPressEntitySet<BlogPost>(response.Content, true, this.ThrowSerializationExceptions);
            }

            return result;
        }

        #endregion Public Methods
    }
}