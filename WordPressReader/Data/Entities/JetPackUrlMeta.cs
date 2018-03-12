using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class JetPackUrlMeta
    {
        [JsonProperty("origin")]
        public long Origin { get; set; }

        [JsonProperty("position")]
        public long Position { get; set; }
    }
}
