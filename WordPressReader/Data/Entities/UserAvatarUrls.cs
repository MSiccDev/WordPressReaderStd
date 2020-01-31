using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class UserAvatarUrls
    {
        #region Public Properties

        [JsonProperty("24", NullValueHandling = NullValueHandling.Include)]
        public string? Size24Px { get; set; }

        [JsonProperty("48", NullValueHandling = NullValueHandling.Include)]
        public string? Size48Px { get; set; }

        [JsonProperty("96", NullValueHandling = NullValueHandling.Include)]
        public string? Size96Px { get; set; }

        #endregion Public Properties
    }
}