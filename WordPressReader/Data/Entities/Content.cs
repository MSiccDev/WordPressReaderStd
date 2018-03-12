using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class Content
    {
        [JsonProperty("rendered")]
        public string Rendered { get; set; }
    }
}
