using System;
using System.Net.Http;
using System.Threading.Tasks;
using WordPressReader.Data;
using WordPressReader.Data.Entities;
using WordPressReader.Data.Models;
using WordPressReader.Helpers;

namespace WordPressReader
{
    public class PageHandler : BaseHandler, IPageHandler
    {
        #region Public Constructors

        public PageHandler()
        {
        }

        /// <summary>
        /// creates a new instance of PageHandler with the specified parameters or default values
        /// </summary>
        public PageHandler(DateTime? modifiedSince = null, string? userAgent = null, string? version = null, bool throwSerializationExceptions = true)
        {
            this.ThrowSerializationExceptions = throwSerializationExceptions;
            SetupClient(modifiedSince, userAgent, version);
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// gets a single blog page from the WordPress site by Id
        /// </summary>
        /// <param name="baseUrl">
        /// the web site's address
        /// </param>
        /// <param name="postId">
        /// id of the page to fetch
        /// </param>
        public async Task<WordPressEntity<Page>> GetPageAsync(string baseUrl, int pageId)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new NullReferenceException($"parameter {nameof(baseUrl)} MUST not be null or empty");

            if (pageId == -1 || pageId == default)
                throw new ArgumentException($"parameter {nameof(pageId)} MUST be a valid post id");

            var response = await HttpClientInstance.GetAsync(baseUrl.GetEntityApiUrl(pageId, Resource.Pages));

            WordPressEntity<Page> result;
            if (response.IsSuccessStatusCode)
            {
                result = new WordPressEntity<Page>(response.Content, false, this.ThrowSerializationExceptions);
            }
            else
            {
                result = new WordPressEntity<Page>(response.Content, true, this.ThrowSerializationExceptions);
            }

            return result;
        }

        /// <summary>
        /// gets a list of pages from the WordPress site. results can be controlled with the parameters.
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
        public async Task<WordPressEntitySet<Page>> GetPagesAysnc(string baseUrl, int perPage = 10, int count = 10, int pageNr = 1, OrderBy order = OrderBy.Title)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new NullReferenceException($"parameter {nameof(baseUrl)} MUST not be null or empty");

            var response = await HttpClientInstance.GetAsync(baseUrl.GetEntitySetApiUrl(Resource.Pages, perPage, count, pageNr, OrderBy.Title));

            WordPressEntitySet<Page> result;
            if (response.IsSuccessStatusCode)
            {
                result = new WordPressEntitySet<Page>(response.Content, false, this.ThrowSerializationExceptions);
            }
            else
            {
                result = new WordPressEntitySet<Page>(response.Content, true, this.ThrowSerializationExceptions);
            }

            return result;
        }

        #endregion Public Methods
    }
}