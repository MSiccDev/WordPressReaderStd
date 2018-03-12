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

        private static HttpClient _pagesClient;

        public PageHandler()
        {
            _pagesClient = SetupClient();
        }


        /// <summary>
        /// creates a new instance of PageHandler with the specified parameters or default values
        /// </summary>
        public PageHandler(DateTime? modifiedSince = null, string userAgent = null, string version = null)
        {
            _pagesClient = SetupClient(modifiedSince, userAgent, version);
        }

        /// <summary>
        /// gets a list of pages from the WordPress site. results can be controlled with the parameters.
        /// </summary>
        /// <param name="baseUrl">the web site's address</param>
        /// <param name="perPage">how many items per page should be fetched</param>
        /// <param name="count">max items to be fetched</param>
        /// <param name="pageNr">used for paged requests</param>
        /// <param name="order">option to sort the result</param>
        public async Task<WordPressEntitySet<Page>> GetPagesAysnc(string baseUrl, int perPage = 10, int count = 10, int pageNr = 1, OrderBy order = OrderBy.Title)
        {
            WordPressEntitySet<Page> result = null;

            if (_pagesClient != null)
            {
                var response = await _pagesClient.GetAsync(baseUrl.GetEntitySetApiUrl(Resource.Pages, perPage, count, pageNr, OrderBy.Title));

                if (response.IsSuccessStatusCode)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    result = new WordPressEntitySet<Page>(responseJson);
                }
                else
                {
                    var errorJson = await response.Content.ReadAsStringAsync();
                    result = new WordPressEntitySet<Page>(null, errorJson);
                }
            }
            return result;
        }

        /// <summary>
        /// gets a single blog page from the WordPress site by Id
        /// </summary>
        /// <param name="baseUrl">the web site's address</param>
        /// <param name="postId">id of the page to fetch</param>
        public async Task<WordPressEntity<Page>> GetPageAsync(string baseUrl, int id)
        {
            WordPressEntity<Page> result = null;

            if (_pagesClient != null)
            {
                var response = await _pagesClient.GetAsync(baseUrl.GetEntityApiUrl(id, Resource.Pages));

                if (response.IsSuccessStatusCode)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    result = new WordPressEntity<Page>(responseJson);
                }
                else
                {
                    var errorJson = await response.Content.ReadAsStringAsync();
                    result = new WordPressEntity<Page>(null, errorJson);
                }
            }
            return result;
        }
    }
}
