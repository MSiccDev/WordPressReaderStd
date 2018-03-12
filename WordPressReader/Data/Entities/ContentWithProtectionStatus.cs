using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class ContentWithProtectionStatus
    {
        [JsonProperty("protected")]
        public bool Protected { get; set; }

        [JsonProperty("rendered")]
        public string Rendered { get; set; }
    }
}
