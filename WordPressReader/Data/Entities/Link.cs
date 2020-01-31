using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class Link
    {
        #region Public Properties

        [JsonProperty("href", NullValueHandling = NullValueHandling.Include)]
        public string? Href { get; set; }

        #endregion Public Properties
    }
}