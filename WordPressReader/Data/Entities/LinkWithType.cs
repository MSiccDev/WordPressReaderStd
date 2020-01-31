using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class LinkWithType
    {
        #region Public Properties

        [JsonProperty("embeddable")]
        public bool Embeddable { get; set; }

        [JsonProperty("href", NullValueHandling = NullValueHandling.Include)]
        public string? Href { get; set; }

        [JsonProperty("post_type", NullValueHandling = NullValueHandling.Include)]
        public string? PostType { get; set; }

        #endregion Public Properties
    }
}