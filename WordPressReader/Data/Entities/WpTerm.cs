using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class WpTerm
    {
        #region Public Properties

        [JsonProperty("embeddable")]
        public bool Embeddable { get; set; }

        [JsonProperty("href", NullValueHandling = NullValueHandling.Include)]
        public string? Href { get; set; }

        [JsonProperty("taxonomy", NullValueHandling = NullValueHandling.Include)]
        public string? Taxonomy { get; set; }

        #endregion Public Properties
    }
}