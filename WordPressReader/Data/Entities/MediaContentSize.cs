using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class MediaContentSize
    {
        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("source_url")]
        public string SourceUrl { get; set; }

        [JsonProperty("file")]
        public string File { get; set; }

        [JsonProperty("mime_type")]
        public string MimeType { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }
    }
}
