using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
     public class Page
     {
        [JsonProperty("featured_media")]
        public long FeaturedMedia { get; set; }

        [JsonProperty("content")]
        public ContentWithProtectionStatus Content { get; set; }

        [JsonProperty("author")]
        public long Author { get; set; }

        [JsonProperty("_links")]
        public PageLinks Links { get; set; }

        [JsonProperty("comment_status")]
        public string CommentStatus { get; set; }

        [JsonProperty("date_gmt")]
        public string DateGmt { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("excerpt")]
        public Content Excerpt { get; set; }

        [JsonProperty("menu_order")]
        public long MenuOrder { get; set; }

        [JsonProperty("parent")]
        public long Parent { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("guid")]
        public RenderedProperty RenderedProperty { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("modified")]
        public string Modified { get; set; }

        //can be too different from blog to blog, hence yousing dynamic
        [JsonProperty("meta")]
        public dynamic Meta { get; set; }

        [JsonProperty("modified_gmt")]
        public string ModifiedGmt { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("template")]
        public string Template { get; set; }

        [JsonProperty("ping_status")]
        public string PingStatus { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("title")]
        public Content Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

    }
}
