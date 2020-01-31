using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class Page
    {
        #region Public Properties

        [JsonProperty("author")]
        public long Author { get; set; }

        [JsonProperty("comment_status", NullValueHandling = NullValueHandling.Include)]
        public string? CommentStatus { get; set; }

        [JsonProperty("content", NullValueHandling = NullValueHandling.Include)]
        public ContentWithProtectionStatus? Content { get; set; }

        [JsonProperty("date", NullValueHandling = NullValueHandling.Include)]
        public string? Date { get; set; }

        [JsonProperty("date_gmt", NullValueHandling = NullValueHandling.Include)]
        public string? DateGmt { get; set; }

        [JsonProperty("excerpt", NullValueHandling = NullValueHandling.Include)]
        public Content? Excerpt { get; set; }

        [JsonProperty("featured_media")]
        public long FeaturedMedia { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("link", NullValueHandling = NullValueHandling.Include)]
        public string? Link { get; set; }

        [JsonProperty("_links", NullValueHandling = NullValueHandling.Include)]
        public PageLinks? Links { get; set; }

        [JsonProperty("menu_order")]
        public long MenuOrder { get; set; }

        //can be too different from blog to blog, hence yousing dynamic
        [JsonProperty("meta", NullValueHandling = NullValueHandling.Include)]
        public dynamic? Meta { get; set; }

        [JsonProperty("modified", NullValueHandling = NullValueHandling.Include)]
        public string? Modified { get; set; }

        [JsonProperty("modified_gmt", NullValueHandling = NullValueHandling.Include)]
        public string? ModifiedGmt { get; set; }

        [JsonProperty("parent")]
        public long Parent { get; set; }

        [JsonProperty("ping_status", NullValueHandling = NullValueHandling.Include)]
        public string? PingStatus { get; set; }

        [JsonProperty("guid", NullValueHandling = NullValueHandling.Include)]
        public RenderedProperty? RenderedProperty { get; set; }

        [JsonProperty("slug", NullValueHandling = NullValueHandling.Include)]
        public string? Slug { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Include)]
        public string? Status { get; set; }

        [JsonProperty("template", NullValueHandling = NullValueHandling.Include)]
        public string? Template { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Include)]
        public Content? Title { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Include)]
        public string? Type { get; set; }

        #endregion Public Properties
    }
}