using System;
using System.Net.Http;
using System.Threading.Tasks;
using WordPressReader.Data.Entities;
using WordPressReader.Data.Models;

namespace WordPressReader
{
    public interface ITagHandler
    {
        /// <summary>
        /// Allows to configure your own HttpClient and pass it in here;
        /// will be set as static instance internally as HttpClient is built for reuse
        /// </summary>
        /// <param name="client">The HttpClient instance to use for all requests</param>
        void SetCustomClient(HttpClient client);

        /// <summary>
        /// creates a new instance of HttpClient with the specified parameters or default values
        /// </summary>
        HttpClient SetupClient(DateTime? modifiedSince = null, string userAgent = null, string version = null, bool useCompression = true);

        /// <summary>
        /// setting the user agent of an already existing HttpClient
        /// </summary>
        /// <param name="modifiedSince">setting the if modified since parameter</param>
        /// <param name="userAgent">setting UserAgent</param>
        /// <param name="version">setting UserAgent version</param>
        void SetUserAgent(HttpClient client, string userAgent, string version);

        /// <summary>
        /// gets a list of tags from the WordPress site, results can be controlled with the parameters.
        /// </summary>
        /// <param name="baseUrl">the web site's address</param>
        /// <param name="perPage">how many items per page should be fetched</param>
        /// <param name="count">max items to be fetched</param>
        /// <param name="pageNr">used for paged requests</param>
        Task<WordPressEntitySet<Tag>> GetTagsAsync(string baseUrl, int perPage = 100, int count = 100, int page = 1);

        /// <summary>
        /// gets a list of tags from the WordPress site by search terms, results can be controlled with the parameters.
        /// </summary>
        /// <param name="baseUrl">the web site's address</param>
        /// <param name="searchTerm">the terms for tag search</param>
        /// <param name="perPage">how many items per page should be fetched</param>
        /// <param name="count">max items to be fetched</param>
        /// <param name="page"></param>
        /// <param name="pageNr">used for paged requests</param>
        Task<WordPressEntitySet<Tag>> SearchTagsAsync(string baseUrl, string searchTerm, int perPage = 20, int count = 20, int page = 1);
    }
}