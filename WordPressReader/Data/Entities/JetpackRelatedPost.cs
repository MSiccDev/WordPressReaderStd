using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class JetpackRelatedPost
    {
        #region Public Properties

        [JsonProperty("classes", NullValueHandling = NullValueHandling.Include)]
        public List<object>? Classes { get; set; }

        [JsonProperty("context", NullValueHandling = NullValueHandling.Include)]
        public string? Context { get; set; }

        [JsonProperty("date", NullValueHandling = NullValueHandling.Include)]
        public string? Date { get; set; }

        [JsonProperty("excerpt", NullValueHandling = NullValueHandling.Include)]
        public string? Excerpt { get; set; }

        [JsonProperty("format")]
        public bool Format { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("img", NullValueHandling = NullValueHandling.Include)]
        public JetPackImage? Img { get; set; }

        [JsonProperty("rel", NullValueHandling = NullValueHandling.Include)]
        public string? Rel { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Include)]
        public string? Title { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Include)]
        public string? Url { get; set; }

        [JsonProperty("url_meta", NullValueHandling = NullValueHandling.Include)]
        public JetPackUrlMeta? UrlMeta { get; set; }

        #endregion Public Properties
    }
}