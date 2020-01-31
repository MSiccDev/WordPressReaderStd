using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class Content
    {
        #region Public Properties

        [JsonProperty("rendered", NullValueHandling = NullValueHandling.Include)]
        public string? Rendered { get; set; }

        #endregion Public Properties
    }
}