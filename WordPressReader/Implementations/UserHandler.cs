using System;
using System.Net.Http;
using System.Threading.Tasks;
using WordPressReader.Data;
using WordPressReader.Data.Entities;
using WordPressReader.Data.Models;
using WordPressReader.Helpers;

namespace WordPressReader
{
    public class UserHandler : BaseHandler, IUserHandler
    {
        #region Public Constructors

        public UserHandler()
        {
        }

        /// <summary>
        /// creates a new instance of UserHandler with the specified parameters or default values
        /// </summary>
        public UserHandler(DateTime? modifiedSince = null, string? userAgent = null, string? version = null, bool throwSerializationExceptions = true)
        {
            this.ThrowSerializationExceptions = throwSerializationExceptions;
            SetupClient(modifiedSince, userAgent, version);
        }

        #endregion Public Constructors

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
        public async Task<WordPressEntity<User>> GetUserAsync(string baseUrl, long userId)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new NullReferenceException($"parameter {nameof(baseUrl)} MUST not be null or empty");

            if (userId == -1 || userId == default)
                throw new ArgumentException($"parameter {nameof(userId)} MUST be a valid post id");

            var response = await HttpClientInstance.GetAsync(baseUrl.GetEntityApiUrl(userId, Resource.User));

            WordPressEntity<User> result;
            if (response.IsSuccessStatusCode)
            {
                result = new WordPressEntity<User>(response.Content, false, this.ThrowSerializationExceptions);
            }
            else
            {
                result = new WordPressEntity<User>(response.Content, true, this.ThrowSerializationExceptions);
            }

            return result;
        }

        #endregion Public Methods
    }
}