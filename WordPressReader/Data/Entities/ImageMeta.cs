using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class ImageMeta
    {
        #region Public Properties

        [JsonProperty("aperture", NullValueHandling = NullValueHandling.Include)]
        public string? Aperture { get; set; }

        [JsonProperty("camera", NullValueHandling = NullValueHandling.Include)]
        public string? Camera { get; set; }

        [JsonProperty("caption", NullValueHandling = NullValueHandling.Include)]
        public string? Caption { get; set; }

        [JsonProperty("copyright", NullValueHandling = NullValueHandling.Include)]
        public string? Copyright { get; set; }

        [JsonProperty("created_timestamp", NullValueHandling = NullValueHandling.Include)]
        public string? CreatedTimestamp { get; set; }

        [JsonProperty("credit", NullValueHandling = NullValueHandling.Include)]
        public string? Credit { get; set; }

        [JsonProperty("focal_length", NullValueHandling = NullValueHandling.Include)]
        public string? FocalLength { get; set; }

        [JsonProperty("iso", NullValueHandling = NullValueHandling.Include)]
        public string? Iso { get; set; }

        [JsonProperty("keywords", NullValueHandling = NullValueHandling.Include)]
        public List<object>? Keywords { get; set; }

        [JsonProperty("orientation", NullValueHandling = NullValueHandling.Include)]
        public string? Orientation { get; set; }

        [JsonProperty("shutter_speed", NullValueHandling = NullValueHandling.Include)]
        public string? ShutterSpeed { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Include)]
        public string? Title { get; set; }

        #endregion Public Properties
    }
}