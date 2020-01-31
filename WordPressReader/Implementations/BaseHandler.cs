using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WordPressReader
{
    public abstract class BaseHandler
    {
        #region Public Methods

        /// <summary>
        /// Allows to configure your own HttpClient and pass it in here; will be set as static
        /// instance internally as HttpClient is built for reuse
        /// </summary>
        /// <param name="client">
        /// The HttpClient instance to use for all requests
        /// </param>
        public void SetCustomClient(HttpClient client)
        {
            HttpClientInstance = client;
        }

        /// <summary>
        /// setting up the client with default values
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
        /// <param name="useCompression">
        /// if set to true (default), uses gzip/deflate compression for all requests
        /// </param>
        public HttpClient SetupClient(DateTime? modifiedSince = null, string? userAgent = null, string? version = null, bool useCompression = true)
        {
            var handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip
            };

            HttpClientInstance = useCompression ? new HttpClient(handler) : new HttpClient();

            HttpClientInstance.DefaultRequestHeaders.Clear();
            //WordPress returns way to often a 304 wenn using DateTime.Now, adding it only if defined
            if (modifiedSince.HasValue)
            {
                HttpClientInstance.DefaultRequestHeaders.IfModifiedSince = new DateTimeOffset(modifiedSince.Value);
            }

            HttpClientInstance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpClientInstance.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("UTF-8"));

            if (!string.IsNullOrEmpty(userAgent) && !string.IsNullOrEmpty(version))
            {
                HttpClientInstance.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(userAgent, version));
            }

            return HttpClientInstance;
        }

        /// <summary>
        /// setting the user agent of an already existing HttpClient
        /// </summary>
        /// <param name="client">
        /// HttpClient instance that gets the UserAgent set; if set to null, uses the internal
        /// static instance
        /// </param>
        /// <param name="userAgent">
        /// setting UserAgent
        /// </param>
        /// <param name="version">
        /// setting UserAgent version
        /// </param>
        public void SetUserAgent(HttpClient client, string userAgent, string version)
        {
            if (client == null)
                //throw new NullReferenceException($"HttClient {nameof(client)} must NOT be null");
                client = HttpClientInstance;

            if (string.IsNullOrEmpty(userAgent))
                throw new NotSupportedException($"{nameof(userAgent)} must NOT be null or empty");

            if (string.IsNullOrEmpty(version))
                throw new NotSupportedException($"{nameof(version)} must NOT be null or empty");

            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(userAgent, version));
        }

        #endregion Public Methods

        #region Internal Properties

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        internal static HttpClient HttpClientInstance { get; private set; }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        internal bool ThrowSerializationExceptions { get; set; } = true;

        #endregion Internal Properties
    }
}