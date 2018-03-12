using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class Link
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}
