using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WordPressReader.Data;
using WordPressReader.Data.Entities;
using WordPressReader.Data.Models;
using WordPressReader.Helpers;

namespace WordPressReader
{

    public class MediaHandler : BaseHandler, IMediaHandler
    {
        private static HttpClient _mediaClient;

        public MediaHandler()
        {
            _mediaClient = SetupClient();
        }

        /// <summary>
        /// creates a new instance of MediaHandler with the specified parameters or default values
        /// </summary>
        public MediaHandler(DateTime? modifiedSince = null, string userAgent = null, string version = null)
        {
            _mediaClient = SetupClient(modifiedSince, userAgent, version);
        }


        /// <summary>
        /// gets a medium by id
        /// </summary>
        /// <param name="baseUrl">the web site's address</param>
        /// <param name="mediaId">the id of the medium to fetch</param>
        public async Task<WordPressEntity<Media>> GetMediumAsync(string baseUrl, long mediaId)
        {
            WordPressEntity<Media> result = null;

            var response = await _mediaClient.GetAsync(baseUrl.GetEntityApiUrl(mediaId, Resource.Media));

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntity<Media>(responseJson);
            }
            else
            {
                var errorJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntity<Media>(null, errorJson);
            }

            return result;
        }

        /// <summary>
        /// gets a list of media from the WordPress site, results can be controlled with the parameters. 
        /// </summary>
        /// <param name="baseUrl">the web site's address</param>
        /// <param name="mediaType">the type of media to fetch</param>
        /// <param name="mimeType">the mime-type of media to fetch</param>
        /// <param name="perPage">how many items per page should be fetched</param>
        /// <param name="count">max items to be fetched</param>
        /// <param name="pageNr">used for paged requests</param>
        /// <param name="orderby">option to sort ascending or descending</param>
        /// <param name="order">option to sort the result</param>
        public async Task<WordPressEntitySet<Media>> GetMediaAsync(string baseUrl, MediaType mediaType = MediaType.All, string mimeType = null, int perPage = 10, int count = 10, int pageNr = 1, OrderBy orderby = OrderBy.Date, Order order = Order.Desc)
        {
            WordPressEntitySet<Media> result = null;

            var mediaParams = new Dictionary<string, string>();

            if (mediaType != MediaType.All)
                mediaParams.Add(Constants.MediaTypeParameter, mediaType.ToString().ToLower());

            if (!string.IsNullOrEmpty(mimeType))
                mediaParams.Add(Constants.MediaMimeTypeParameter, mimeType);

            var response = await _mediaClient.GetAsync(
                baseUrl.GetEntitySetApiUrl(Resource.Media, perPage, count, pageNr, orderby, order)
                .AddParametersToUrl(mediaParams))
                .ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntitySet<Media>(responseJson);
            }
            else
            {
                var errorJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntitySet<Media>(null, errorJson);
            }

            return result;
        }

    }
}
