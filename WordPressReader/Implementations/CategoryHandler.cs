using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WordPressReader.Data;
using WordPressReader.Data.Entities;
using WordPressReader.Data.Models;
using WordPressReader.Helpers;

namespace WordPressReader
{
    public class CategoryHandler : BaseHandler, ICategoryHandler
    {
        #region Public Constructors

        public CategoryHandler()
        {
        }

        /// <summary>
        /// creates a new instance of PostsHandler with the specified parameters or default values
        /// </summary>
        public CategoryHandler(DateTime? modifiedSince = null, string? userAgent = null, string? version = null, bool throwSerializationExceptions = true)
        {
            this.ThrowSerializationExceptions = throwSerializationExceptions;
            SetupClient(modifiedSince, userAgent, version);
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// gets a list of categories from the WordPress site, results can be controlled with the parameters.
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
        /// <param name="order">
        /// option to sort the result
        /// </param>
        public async Task<WordPressEntitySet<Category>> GetCategoriesAsync(string baseUrl, int perPage = 10, int count = 10, int pageNr = 1, OrderBy order = OrderBy.Date)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new NullReferenceException($"parameter {nameof(baseUrl)} MUST not be null or empty");

            var response = await HttpClientInstance.GetAsync(baseUrl.GetEntitySetApiUrl(Resource.Categories, perPage, count, pageNr, order)).ConfigureAwait(false);

            WordPressEntitySet<Category> result;
            if (response.IsSuccessStatusCode)
            {
                result = new WordPressEntitySet<Category>(response.Content, false, this.ThrowSerializationExceptions);
            }
            else
            {
                result = new WordPressEntitySet<Category>(response.Content, true, this.ThrowSerializationExceptions);
            }

            return result;
        }

        /// <summary>
        /// gets a single category from the WordPress site by Id
        /// </summary>
        /// <param name="baseUrl">
        /// the web site's address
        /// </param>
        /// <param name="postId">
        /// id of the post to fetch
        /// </param>
        public async Task<WordPressEntity<Category>> GetCategoryAsync(string baseUrl, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new NullReferenceException($"parameter {nameof(baseUrl)} MUST not be null or empty");

            if (categoryId == -1 || categoryId == default)
                throw new ArgumentException($"parameter {nameof(categoryId)} MUST be a valid post id");

            var response = await HttpClientInstance.GetAsync(baseUrl.GetEntityApiUrl(categoryId)).ConfigureAwait(false);

            WordPressEntity<Category> result;
            if (response.IsSuccessStatusCode)
            {
                _ = await response.Content.ReadAsStringAsync();
                result = new WordPressEntity<Category>(response.Content, false, this.ThrowSerializationExceptions);
            }
            else
            {
                _ = await response.Content.ReadAsStringAsync();
                result = new WordPressEntity<Category>(response.Content, true, this.ThrowSerializationExceptions);
            }

            return result;
        }

        #endregion Public Methods
    }
}