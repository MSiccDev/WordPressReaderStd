using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class User
    {
        #region Public Properties

        [JsonProperty("avatar_urls", NullValueHandling = NullValueHandling.Include)]
        public UserAvatarUrls? AvatarUrls { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Include)]
        public string? Description { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("link", NullValueHandling = NullValueHandling.Include)]
        public string? Link { get; set; }

        [JsonProperty("_links", NullValueHandling = NullValueHandling.Include)]
        public UserLinks? Links { get; set; }

        //can be too different from blog to blog, hence yousing dynamic
        [JsonProperty("meta", NullValueHandling = NullValueHandling.Include)]
        public dynamic? Meta { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Include)]
        public string? Name { get; set; }

        [JsonProperty("slug", NullValueHandling = NullValueHandling.Include)]
        public string? Slug { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Include)]
        public string? Url { get; set; }

        #endregion Public Properties
    }
}