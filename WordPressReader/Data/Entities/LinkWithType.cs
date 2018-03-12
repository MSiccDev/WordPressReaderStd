using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class LinkWithType
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("embeddable")]
        public bool Embeddable { get; set; }

        [JsonProperty("post_type")]
        public string PostType { get; set; }
    }
}
