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
        #region Public Constructors

        public TagHandler()
        {
        }

        /// <summary>
        /// creates a new instance of TagHandler with the specified parameters or default values
        /// </summary>
        public TagHandler(DateTime? modifiedSince = null, string? userAgent = null, string? version = null, bool throwSerializationExceptions = true)
        {
            this.ThrowSerializationExceptions = throwSerializationExceptions;
            SetupClient(modifiedSince, userAgent, version);
        }

        #endregion Public Constructors

        //tag collection can be very very big (my personal blog has over 600...)
        //just having this in place doesn't mean one should use it...
        //better using the SearchTags Method to obtain only a subset/one specific tag

        #region Public Methods

        /// <summary>
        /// gets a list of tags from the WordPress site, results can be controlled with the parameters.
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
        public async Task<WordPressEntitySet<Tag>> GetTagsAsync(string baseUrl, int perPage = 100, int count = 100, int page = 1)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new NullReferenceException($"parameter {nameof(baseUrl)} MUST not be null or empty");

            var response = await HttpClientInstance.GetAsync(baseUrl.GetEntitySetApiUrl(Resource.Tags, perPage, count, page, OrderBy.Name));

            WordPressEntitySet<Tag> result;
            if (response.IsSuccessStatusCode)
            {
                result = new WordPressEntitySet<Tag>(response.Content, false, this.ThrowSerializationExceptions);
            }
            else
            {
                result = new WordPressEntitySet<Tag>(response.Content, true, this.ThrowSerializationExceptions);
            }

            return result;
        }

        /// <summary>
        /// gets a list of tags from the WordPress site by search terms, results can be controlled
        /// with the parameters.
        /// </summary>
        /// <param name="baseUrl">
        /// the web site's address
        /// </param>
        /// <param name="searchTerm">
        /// the terms for tag search
        /// </param>
        /// <param name="perPage">
        /// how many items per page should be fetched
        /// </param>
        /// <param name="count">
        /// max items to be fetched
        /// </param>
        /// <param name="page">
        /// </param>
        /// <param name="pageNr">
        /// used for paged requests
        /// </param>
        public async Task<WordPressEntitySet<Tag>> SearchTagsAsync(string baseUrl, string searchTerm, int perPage = 20, int count = 20, int page = 1)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new NullReferenceException($"parameter {nameof(baseUrl)} MUST not be null or empty");

            if (string.IsNullOrWhiteSpace(searchTerm))
                throw new NullReferenceException($"parameter {nameof(searchTerm)} MUST not be null or empty");

            var response = await HttpClientInstance.GetAsync(
                baseUrl.GetEntitySetApiUrl(Resource.Tags, perPage, count, page, OrderBy.Name)
                .AddParameterToUrl("search", WebUtility.UrlEncode(searchTerm)))
                .ConfigureAwait(false);

            WordPressEntitySet<Tag> result;
            if (response.IsSuccessStatusCode)
            {
                result = new WordPressEntitySet<Tag>(response.Content, false, this.ThrowSerializationExceptions);
            }
            else
            {
                result = new WordPressEntitySet<Tag>(response.Content, true, this.ThrowSerializationExceptions);
            }
            return result;
        }

        #endregion Public Methods
    }
}