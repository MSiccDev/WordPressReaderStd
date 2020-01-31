using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class Media
    {
        #region Public Properties

        [JsonProperty("alt_text", NullValueHandling = NullValueHandling.Include)]
        public string? AltText { get; set; }

        [JsonProperty("author")]
        public long Author { get; set; }

        [JsonProperty("caption", NullValueHandling = NullValueHandling.Include)]
        public RenderedProperty? Caption { get; set; }

        [JsonProperty("comment_status", NullValueHandling = NullValueHandling.Include)]
        public string? CommentStatus { get; set; }

        [JsonProperty("date", NullValueHandling = NullValueHandling.Include)]
        public string? Date { get; set; }

        [JsonProperty("date_gmt", NullValueHandling = NullValueHandling.Include)]
        public string? DateGmt { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Include)]
        public RenderedProperty? Description { get; set; }

        [JsonProperty("guid", NullValueHandling = NullValueHandling.Include)]
        public RenderedProperty? Guid { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("link", NullValueHandling = NullValueHandling.Include)]
        public string? Link { get; set; }

        [JsonProperty("_links", NullValueHandling = NullValueHandling.Include)]
        public MediaLinks? Links { get; set; }

        [JsonProperty("media_details", NullValueHandling = NullValueHandling.Include)]
        public MediaDetails? MediaDetails { get; set; }

        [JsonProperty("media_type", NullValueHandling = NullValueHandling.Include)]
        public string? MediaType { get; set; }

        //can be too different from blog to blog, hence yousing dynamic
        [JsonProperty("meta", NullValueHandling = NullValueHandling.Include)]
        public dynamic? Meta { get; set; }

        [JsonProperty("mime_type", NullValueHandling = NullValueHandling.Include)]
        public string? MimeType { get; set; }

        [JsonProperty("modified", NullValueHandling = NullValueHandling.Include)]
        public string? Modified { get; set; }

        [JsonProperty("modified_gmt", NullValueHandling = NullValueHandling.Include)]
        public string? ModifiedGmt { get; set; }

        [JsonProperty("ping_status", NullValueHandling = NullValueHandling.Include)]
        public string? PingStatus { get; set; }

        [JsonProperty("post", NullValueHandling = NullValueHandling.Include)]
        public long? Post { get; set; }

        [JsonProperty("slug", NullValueHandling = NullValueHandling.Include)]
        public string? Slug { get; set; }

        [JsonProperty("source_url", NullValueHandling = NullValueHandling.Include)]
        public string? SourceUrl { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Include)]
        public string? Status { get; set; }

        [JsonProperty("template", NullValueHandling = NullValueHandling.Include)]
        public string? Template { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Include)]
        public RenderedProperty? Title { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Include)]
        public string? Type { get; set; }

        #endregion Public Properties
    }
}