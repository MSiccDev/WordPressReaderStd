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
        private readonly HttpClient _userClient;

        public UserHandler()
        {
            _userClient = SetupClient();
        }

        /// <summary>
        /// creates a new instance of UserHandler with the specified parameters or default values
        /// </summary>
        public UserHandler(DateTime? modifiedSince = null, string userAgent = null, string version = null, bool throwSerializationExceptions = true)
        {
            _throwSerializationExceptions = throwSerializationExceptions;
            _userClient = SetupClient(modifiedSince, userAgent, version);
        }

        /// <summary>
        /// gets a single user from the WordPress site by Id
        /// </summary>
        /// <param name="baseUrl">the web site's address</param>
        /// <param name="userId">id of the user to fetch</param>
        public async Task<WordPressEntity<User>> GetUserAsync(string baseUrl, long userId)
        {
            WordPressEntity<User> result = null;

            var response = await _userClient.GetAsync(baseUrl.GetEntityApiUrl(userId, Resource.User));

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntity<User>(responseJson, null, _throwSerializationExceptions);
            }
            else
            {
                var errorJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntity<User>(null, errorJson, _throwSerializationExceptions);
            }

            return result;
        }
    }
}
