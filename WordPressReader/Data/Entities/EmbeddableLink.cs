using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class EmbeddableLink
    {
        [JsonProperty("embeddable")]
        public bool Embeddable { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }
    }
}
