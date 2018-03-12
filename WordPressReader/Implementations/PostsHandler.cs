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
       private static HttpClient _postsClient;


        public PostsHandler()
        {
            _postsClient = SetupClient();
        }


        /// <summary>
        /// creates a new instance of PostsHandler with the specified parameters or default values
        /// </summary>
        public PostsHandler(DateTime? modifiedSince = null, string userAgent = null, string version = null)
        {
            _postsClient = SetupClient(modifiedSince, userAgent, version);
        }

        /// <summary>
        /// gets a list of posts from the WordPress site, results can be controlled with the parameters.
        /// </summary>
        /// <param name="baseUrl">the web site's address</param>
        /// <param name="perPage">how many items per page should be fetched</param>
        /// <param name="count">max items to be fetched</param>
        /// <param name="pageNr">used for paged requests</param>
        /// <param name="categories">array of category ids</param>
        /// <param name="order">option to sort the result</param>
        public async Task<WordPressEntitySet<BlogPost>> GetPostsAsync(string baseUrl, int perPage = 10, int count = 10, int pageNr = 1, int[] categories = null, OrderBy order = OrderBy.Date)
        {
            WordPressEntitySet<BlogPost> result = null;

            var additionalParams = new Dictionary<string, string>();
            if (categories != null)
                additionalParams.Add(Constants.ParameterCategories, categories.ToArrayString());

            var response = await _postsClient
                .GetAsync(baseUrl.GetEntitySetApiUrl(Resource.Posts, perPage, count, pageNr, order)
                .AddParametersToUrl(additionalParams))
                .ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntitySet<BlogPost>(responseJson);
            }
            else
            {
                var errorJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntitySet<BlogPost>(null, errorJson);
            }

            return result;
        }

        /// <summary>
        /// gets a single blog post from the WordPress site by Id
        /// </summary>
        /// <param name="baseUrl">the web site's address</param>
        /// <param name="postId">id of the post to fetch</param>
        public async Task<WordPressEntity<BlogPost>> GetPostAsync(string baseUrl, int postId)
        {
            WordPressEntity<BlogPost> result = null;

            var response = await _postsClient.GetAsync(baseUrl.GetEntityApiUrl(postId)).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntity<BlogPost>(responseJson);
            }
            else
            {
                var errorJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntity<BlogPost>(null, errorJson);
            }

            return result;
        }


        //fetching a post by slug uses the post list API, so we are getting an EntitySet with one single entry here...
        /// <summary>
        /// gets a single blog post by its slug - fetching a post by slug uses the post list API, so we are getting an EntitySet with one single entry
        /// </summary>
        /// <param name="baseUrl">the web site's address</param>
        /// <param name="slug">the slug of the post to fetch</param>
        public async Task<WordPressEntitySet<BlogPost>> GetPostBySlugAsync(string baseUrl, string slug)
        {
            WordPressEntitySet<BlogPost> result = null;

            var response = await _postsClient.GetAsync(
                baseUrl.GetEntitySetApiUrl(Resource.Posts, 1, 1)
                .AddParameterToUrl(nameof(slug), slug))
                .ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntitySet<BlogPost>(responseJson);
            }
            else
            {
                var errorJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntitySet<BlogPost>(null, errorJson);
            }

            return result;
        }

        /// <summary>
        /// gets a list of posts with the specified tag ids from the WordPress site. results can be controlled with the parameters.
        /// </summary>
        /// <param name="tagIds">int array of tag ids</param>
        /// <param name="baseUrl">the web site's address</param>
        /// <param name="perPage">how many items per page should be fetched</param>
        /// <param name="count">max items to be fetched</param>
        /// <param name="pageNr">used for paged requests</param>
        /// <param name="categories">array of category ids</param>
        /// <param name="order">option to sort the result</param>
        public async Task<WordPressEntitySet<BlogPost>> GetPostsByTagsAsync(string baseUrl, int[] tagIds, int perPage = 10, int count = 10, int pageNr = 1, OrderBy order = OrderBy.Date)
        {
            WordPressEntitySet<BlogPost> result = null;

            var response = await _postsClient.GetAsync(
                baseUrl.GetEntitySetApiUrl(Resource.Posts, perPage, count, pageNr, order)
                .AddParameterToUrl("tags", tagIds.ToArrayString()))
                .ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntitySet<BlogPost>(responseJson);
            }
            else
            {
                var errorJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntitySet<BlogPost>(null, errorJson);
            }
            return result;
        }

        /// <summary>
        /// gets a list of posts with the specified search terms from the WordPress site. results can be controlled with the parameters.
        /// </summary>
        /// <param name="baseUrl">the web site's address</param>
        /// <param name="searchTerms">search terms for blog search</param>
        /// <param name="perPage">how many items per page should be fetched</param>
        /// <param name="count">max items to be fetched</param>
        /// <param name="pageNr">used for paged requests</param>
        /// <param name="categories">array of category ids</param>
        /// <param name="order">option to sort the result</param>
        public async Task<WordPressEntitySet<BlogPost>> SearchPostsAsync(string baseUrl, string searchTerms, int perPage = 10, int count = 10, int pageNr = 1, int[] categories = null, OrderBy order = OrderBy.Date)
        {
            WordPressEntitySet<BlogPost> result = null;

            var additionalParams = new Dictionary<string, string>()
            {
                ["search"] = WebUtility.UrlEncode(searchTerms),
            };

            if (categories != null)
                additionalParams.Add(Constants.ParameterCategories, categories.ToArrayString());


            var response = await _postsClient.GetAsync(
                baseUrl.GetEntitySetApiUrl(Resource.Posts, perPage, count, pageNr, order)
                .AddParametersToUrl(additionalParams))
                .ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntitySet<BlogPost>(responseJson);
            }
            else
            {
                var errorJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntitySet<BlogPost>(null, errorJson);

            }

            return result;
        }



    }
}
