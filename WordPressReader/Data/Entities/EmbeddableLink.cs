using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class EmbeddableLink
    {
        #region Public Properties

        [JsonProperty("embeddable")]
        public bool Embeddable { get; set; }

        [JsonProperty("href", NullValueHandling = NullValueHandling.Include)]
        public string? Href { get; set; }

        #endregion Public Properties
    }
}