using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class Comment
    {
        [JsonProperty("date_gmt")]
        public string DateGmt { get; set; }

        [JsonProperty("author_name")]
        public string AuthorName { get; set; }

        [JsonProperty("author")]
        public long Author { get; set; }

        [JsonProperty("_links")]
        public CommentsLinks Links { get; set; }

        [JsonProperty("author_avatar_urls")]
        public UserAvatarUrls UserAvatarUrls { get; set; }

        [JsonProperty("content")]
        public Content Content { get; set; }

        [JsonProperty("author_url")]
        public string AuthorUrl { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("parent")]
        public long Parent { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        //can be too different from blog to blog, hence yousing dynamic
        [JsonProperty("meta")]
        public dynamic Meta { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("post")]
        public long Post { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

}
