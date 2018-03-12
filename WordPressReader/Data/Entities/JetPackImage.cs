using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class JetPackImage
    {
        [JsonProperty("src")]
        public string Src { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }
    }
}
