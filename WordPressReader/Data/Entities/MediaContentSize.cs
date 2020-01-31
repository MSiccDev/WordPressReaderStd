using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class MediaContentSize
    {
        #region Public Properties

        [JsonProperty("file", NullValueHandling = NullValueHandling.Include)]
        public string? File { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("mime_type", NullValueHandling = NullValueHandling.Include)]
        public string? MimeType { get; set; }

        [JsonProperty("source_url", NullValueHandling = NullValueHandling.Include)]
        public string? SourceUrl { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        #endregion Public Properties
    }
}