using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WordPressReader.Data;
using WordPressReader.Data.Entities;
using WordPressReader.Data.Models;
using WordPressReader.Helpers;

namespace WordPressReader
{
    public class TagHandler : BaseHandler, ITagHandler
    {
        private static HttpClient _tagClient;

        public TagHandler()
        {
            _tagClient = SetupClient();
        }

        /// <summary>
        /// creates a new instance of TagHandler with the specified parameters or default values
        /// </summary>
        public TagHandler(DateTime? modifiedSince = null, string userAgent = null, string version = null, bool throwSerializationExceptions = true)
        {
            _throwSerializationExceptions = throwSerializationExceptions;
            _tagClient = SetupClient(modifiedSince, userAgent, version);
        }


        //tag collection can be very very big (my personal blog has over 600...) 
        //just having this in place doesn't mean one should use it...
        //better using the SearchTags Method to obtain only a subset/one specific tag     

        /// <summary>
        /// gets a list of tags from the WordPress site, results can be controlled with the parameters.
        /// </summary>
        /// <param name="baseUrl">the web site's address</param>
        /// <param name="perPage">how many items per page should be fetched</param>
        /// <param name="count">max items to be fetched</param>
        /// <param name="pageNr">used for paged requests</param>
        public async Task<WordPressEntitySet<Tag>> GetTagsAsync(string baseUrl, int perPage = 100, int count = 100, int page = 1)
        {
            WordPressEntitySet<Tag> result = null;

            var response = await _tagClient.GetAsync(baseUrl.GetEntitySetApiUrl(Resource.Tags, perPage, count, page, OrderBy.Name));

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntitySet<Tag>(responseJson, null, _throwSerializationExceptions);
            }
            else
            {
                var errorJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntitySet<Tag>(null, errorJson, _throwSerializationExceptions);
            }

            return result;
        }

        /// <summary>
        /// gets a list of tags from the WordPress site by search terms, results can be controlled with the parameters.
        /// </summary>
        /// <param name="baseUrl">the web site's address</param>
        /// <param name="searchTerm">the terms for tag search</param>
        /// <param name="perPage">how many items per page should be fetched</param>
        /// <param name="count">max items to be fetched</param>
        /// <param name="page"></param>
        /// <param name="pageNr">used for paged requests</param>
        public async Task<WordPressEntitySet<Tag>> SearchTagsAsync(string baseUrl, string searchTerm, int perPage = 20, int count = 20, int page = 1)
        {
            WordPressEntitySet<Tag> result = null;


            var response = await _tagClient.GetAsync(
                baseUrl.GetEntitySetApiUrl(Resource.Tags, perPage, count, page, OrderBy.Name)
                .AddParameterToUrl("search", WebUtility.UrlEncode(searchTerm)))
                .ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntitySet<Tag>(responseJson, null, _throwSerializationExceptions);
            }
            else
            {
                var errorJson = await response.Content.ReadAsStringAsync();
                result = new WordPressEntitySet<Tag>(null, errorJson, _throwSerializationExceptions);
            }
            return result;
        }
    }
}
