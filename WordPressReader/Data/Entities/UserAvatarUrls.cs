using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class UserAvatarUrls
    {
        [JsonProperty("48")]
        public string Size48Px { get; set; }

        [JsonProperty("24")]
        public string Size24Px { get; set; }

        [JsonProperty("96")]
        public string Size96Px { get; set; }
    }
}
