using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class ContentWithProtectionStatus
    {
        #region Public Properties

        [JsonProperty("protected")]
        public bool Protected { get; set; }

        [JsonProperty("rendered", NullValueHandling = NullValueHandling.Include)]
        public string? Rendered { get; set; }

        #endregion Public Properties
    }
}