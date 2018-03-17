using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class Media
    {
        [JsonProperty("description")]
        public RenderedProperty Description { get; set; }

        [JsonProperty("modified")]
        public string Modified { get; set; }

        [JsonProperty("caption")]
        public RenderedProperty Caption { get; set; }

        [JsonProperty("alt_text")]
        public string AltText { get; set; }

        [JsonProperty("_links")]
        public MediaLinks Links { get; set; }

        [JsonProperty("author")]
        public long Author { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("comment_status")]
        public string CommentStatus { get; set; }

        [JsonProperty("date_gmt")]
        public string DateGmt { get; set; }

        [JsonProperty("media_details")]
        public MediaDetails MediaDetails { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("guid")]
        public RenderedProperty Guid { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("meta")]
        public List<object> Meta { get; set; }

        [JsonProperty("media_type")]
        public string MediaType { get; set; }

        [JsonProperty("mime_type")]
        public string MimeType { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("ping_status")]
        public string PingStatus { get; set; }

        [JsonProperty("modified_gmt")]
        public string ModifiedGmt { get; set; }

        [JsonProperty("post")]
        public long? Post { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("title")]
        public RenderedProperty Title { get; set; }

        [JsonProperty("source_url")]
        public string SourceUrl { get; set; }

        [JsonProperty("template")]
        public string Template { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
