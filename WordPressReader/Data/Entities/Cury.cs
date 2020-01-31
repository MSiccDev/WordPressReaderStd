using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class Cury
    {
        #region Public Properties

        [JsonProperty("href", NullValueHandling = NullValueHandling.Include)]
        public string? Href { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Include)]
        public string? Name { get; set; }

        [JsonProperty("templated")]
        public bool Templated { get; set; }

        #endregion Public Properties
    }
}