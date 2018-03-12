using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class WpTerm
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("embeddable")]
        public bool Embeddable { get; set; }

        [JsonProperty("taxonomy")]
        public string Taxonomy { get; set; }
    }
}
