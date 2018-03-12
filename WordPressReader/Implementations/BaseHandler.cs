using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WordPressReader
{
    public abstract class BaseHandler
    {
        /// <summary>
        /// setting up the client with default values
        /// </summary>
        /// <param name="modifiedSince">setting the if modified since parameter</param>
        /// <param name="userAgent">setting UserAgent</param>
        /// <param name="version">setting UserAgent version</param>
        public HttpClient SetupClient(DateTime? modifiedSince = null, string userAgent = null, string version = null)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Clear();
            //WordPress returns way to often a 304 wenn using DateTime.Now, adding it only if defined
            if (modifiedSince.HasValue)
            {
                client.DefaultRequestHeaders.IfModifiedSince = new DateTimeOffset(modifiedSince.Value);
            }
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("UTF-8"));

            if (!string.IsNullOrEmpty(userAgent) && !string.IsNullOrEmpty(version))
            {
                client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(userAgent, version));
            }

            return client;
        }

        /// <summary>
        /// setting the user agent of an already existing HttpClient
        /// </summary>
        /// <param name="modifiedSince">setting the if modified since parameter</param>
        /// <param name="userAgent">setting UserAgent</param>
        /// <param name="version">setting UserAgent version</param>
        public void SetUserAgent(HttpClient client, string userAgent, string version)
        {
            if (client == null)
                throw new NullReferenceException($"HttClient {nameof(client)} must NOT be null");

            if (string.IsNullOrEmpty(userAgent))
                throw new NotSupportedException($"{nameof(userAgent)} must NOT be null or empty");


            if (string.IsNullOrEmpty(version))
                throw new NotSupportedException($"{nameof(version)} must NOT be null or empty");


            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(userAgent, version));
        }
    }
}
