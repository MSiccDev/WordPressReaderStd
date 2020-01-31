using System;
using System.Net.Http;
using System.Threading.Tasks;
using WordPressReader.Data;
using WordPressReader.Data.Entities;
using WordPressReader.Data.Models;

namespace WordPressReader
{
    public interface IMediaHandler
    {
        #region Public Methods

        /// <summary>
        /// gets a list of media from the WordPress site, results can be controlled with the parameters.
        /// </summary>
        /// <param name="baseUrl">
        /// the web site's address
        /// </param>
        /// <param name="mediaType">
        /// the type of media to fetch
        /// </param>
        /// <param name="mimeType">
        /// the mime-type of media to fetch
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
        /// <param name="orderby">
        /// option to sort ascending or descending
        /// </param>
        /// <param name="order">
        /// option to sort the result
        /// </param>
        Task<WordPressEntitySet<Media>> GetMediaAsync(string baseUrl, MediaType mediaType = MediaType.All, string? mimeType = null, int perPage = 10, int count = 10, int pageNr = 1, OrderBy orderby = OrderBy.Date, Order order = Order.Desc);

        /// <summary>
        /// gets a medium by id
        /// </summary>
        /// <param name="baseUrl">
        /// the web site's address
        /// </param>
        /// <param name="mediaId">
        /// the id of the medium to fetch
        /// </param>
        Task<WordPressEntity<Media>> GetMediumAsync(string baseUrl, long mediaId);

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