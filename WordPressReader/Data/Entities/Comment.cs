using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class Comment
    {
        #region Public Properties

        [JsonProperty("author")]
        public long Author { get; set; }

        [JsonProperty("author_name", NullValueHandling = NullValueHandling.Include)]
        public string? AuthorName { get; set; }

        [JsonProperty("author_url", NullValueHandling = NullValueHandling.Include)]
        public string? AuthorUrl { get; set; }

        [JsonProperty("content", NullValueHandling = NullValueHandling.Include)]
        public Content? Content { get; set; }

        [JsonProperty("date", NullValueHandling = NullValueHandling.Include)]
        public string? Date { get; set; }

        [JsonProperty("date_gmt", NullValueHandling = NullValueHandling.Include)]
        public string? DateGmt { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("link", NullValueHandling = NullValueHandling.Include)]
        public string? Link { get; set; }

        [JsonProperty("_links", NullValueHandling = NullValueHandling.Include)]
        public CommentsLinks? Links { get; set; }

        //can be too different from blog to blog, hence yousing dynamic
        [JsonProperty("meta", NullValueHandling = NullValueHandling.Include)]
        public dynamic? Meta { get; set; }

        [JsonProperty("parent")]
        public long Parent { get; set; }

        [JsonProperty("post")]
        public long Post { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Include)]
        public string? Status { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Include)]
        public string? Type { get; set; }

        [JsonProperty("author_avatar_urls", NullValueHandling = NullValueHandling.Include)]
        public UserAvatarUrls? UserAvatarUrls { get; set; }

        #endregion Public Properties
    }
}