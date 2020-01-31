using System;
using System.Net.Http;
using System.Threading.Tasks;
using WordPressReader.Data.Entities;
using WordPressReader.Data.Models;

namespace WordPressReader
{
    public interface IUserHandler
    {
        #region Public Methods

        /// <summary>
        /// gets a single user from the WordPress site by Id
        /// </summary>
        /// <param name="baseUrl">
        /// the web site's address
        /// </param>
        /// <param name="userId">
        /// id of the user to fetch
        /// </param>
        Task<WordPressEntity<User>> GetUserAsync(string baseUrl, long userId);

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