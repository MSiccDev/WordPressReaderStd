using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class JetPackImage
    {
        #region Public Properties

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("src", NullValueHandling = NullValueHandling.Include)]
        public string? Src { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        #endregion Public Properties
    }
}