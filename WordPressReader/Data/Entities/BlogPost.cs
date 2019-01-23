using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class BlogPost
    {
        [JsonProperty("excerpt")]
        public Content Excerpt { get; set; }

        [JsonProperty("modified")]
        public string Modified { get; set; }

        [JsonProperty("comment_status")]
        public string CommentStatus { get; set; }

        [JsonProperty("author")]
        public long Author { get; set; }

        [JsonProperty("_links")]
        public PostLinks Links { get; set; }

        [JsonProperty("categories")]
        public List<long> Categories { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("content")]
        public Content Content { get; set; }

        [JsonProperty("date_gmt")]
        public string DateGmt { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("featured_media")]
        public long FeaturedMedia { get; set; }

        [JsonProperty("guid")]
        public RenderedProperty RenderedProperty { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("jetpack-related-posts")]
        public List<JetpackRelatedPost> JetpackRelatedPosts { get; set; }

        //can be too different from blog to blog, hence yousing dynamic
        [JsonProperty("meta")]
        public dynamic Meta { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("ping_status")]
        public string PingStatus { get; set; }

        [JsonProperty("modified_gmt")]
        public string ModifiedGmt { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("tags")]
        public List<long> Tags { get; set; }

        [JsonProperty("title")]
        public RenderedProperty Title { get; set; }

        [JsonProperty("sticky")]
        public bool Sticky { get; set; }

        [JsonProperty("template")]
        public string Template { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

    }

}
