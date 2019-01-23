using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class User
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("avatar_urls")]
        public UserAvatarUrls AvatarUrls { get; set; }

        [JsonProperty("_links")]
        public UserLinks Links { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        //can be too different from blog to blog, hence yousing dynamic
        [JsonProperty("meta")]
        public dynamic Meta { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
