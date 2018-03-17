using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WordPressReader.Data;
using WordPressReader.Data.Entities;
using WordPressReader.Data.Models;
using WordPressReader.Helpers;

namespace WordPressReader.Implementations
{
    public class CategoryHandler : BaseHandler, ICategoryHandler
    {
        private static HttpClient _categoriesClient;

        public CategoryHandler()
        {
            _categoriesClient = SetupClient();
        }

        /// <summary>
        /// creates a new instance of PostsHandler with the specified parameters or default values
        /// </summary>
        public CategoryHandler(DateTime? modifiedSince = null, string userAgent = null, string version = null, bool throwSerializationExceptions = true)
        {
            _throwSerializationExceptions = throwSerializationExceptions;
            _categoriesClient = SetupClient(modifiedSince, userAgent, version);
        }

        /// <summary>
        /// gets a list of categories from the WordPress site, results can be controlled with the parameters.
        /// </summary>
        /// <param name="baseUrl">the web site's address</param>
        /// <param name="perPage">how many items per page should be fetched</param>
        /// <param name="count">max items to be fetched</param>
        /// <param name="pageNr">used for paged requests</param>
        /// <param name="order">option to sort the result</param>
        public async Task<WordPressEntitySet<Category>> GetCategoriesAsync(string baseUrl, int perPage = 10, int count = 10, int pageNr = 1, OrderBy order = OrderBy.Date)
        {
            WordPressEntitySet<Category> result = null;

            var response = await _categoriesClient.GetAsync(baseUrl.GetEntitySetApiUrl(Resource.Categories, perPage, count, pageNr, order)).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntitySet<Category>(responseJson, null, _throwSerializationExceptions);
            }
            else
            {
                var errorJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntitySet<Category>(null, errorJson, _throwSerializationExceptions);
            }

            return result;
        }

        /// <summary>
        /// gets a single category from the WordPress site by Id
        /// </summary>
        /// <param name="baseUrl">the web site's address</param>
        /// <param name="postId">id of the post to fetch</param>
        public async Task<WordPressEntity<Category>> GetCategoryAsync(string baseUrl, int categoryId)
        {
            WordPressEntity<Category> result = null;

            var response = await _categoriesClient.GetAsync(baseUrl.GetEntityApiUrl(categoryId)).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntity<Category>(responseJson, null, _throwSerializationExceptions);
            }
            else
            {
                var errorJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntity<Category>(null, errorJson, _throwSerializationExceptions);
            }

            return result;
        }



    }
}
