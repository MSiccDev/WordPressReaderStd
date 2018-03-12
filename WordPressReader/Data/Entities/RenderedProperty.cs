using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class RenderedProperty
    {
        [JsonProperty("rendered")]
        public string Rendered { get; set; }
    }
}
