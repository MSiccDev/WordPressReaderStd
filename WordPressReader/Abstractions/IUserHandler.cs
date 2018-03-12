using System;
using System.Net.Http;
using System.Threading.Tasks;
using WordPressReader.Data.Entities;
using WordPressReader.Data.Models;

namespace WordPressReader
{
    public interface IUserHandler
    {
        /// <summary>
        /// creates a new instance of HttpClient with the specified parameters or default values
        /// </summary>
        HttpClient SetupClient(DateTime? modifiedSince = null, string userAgent = null, string version = null);

        /// <summary>
        /// setting the user agent of an already existing HttpClient
        /// </summary>
        /// <param name="modifiedSince">setting the if modified since parameter</param>
        /// <param name="userAgent">setting UserAgent</param>
        /// <param name="version">setting UserAgent version</param>
        void SetUserAgent(HttpClient client, string userAgent, string version);

        /// <summary>
        /// gets a single user from the WordPress site by Id
        /// </summary>
        /// <param name="baseUrl">the web site's address</param>
        /// <param name="userId">id of the user to fetch</param>
        Task<WordPressEntity<User>> GetUserAsync(string baseUrl, long userId);
    }
}