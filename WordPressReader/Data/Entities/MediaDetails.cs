using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public partial class MediaDetails
    {
        #region Public Properties

        [JsonProperty("file", NullValueHandling = NullValueHandling.Include)]
        public string? File { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("image_meta", NullValueHandling = NullValueHandling.Include)]
        public ImageMeta? ImageMeta { get; set; }

        [JsonProperty("sizes", NullValueHandling = NullValueHandling.Include)]
        public MediaSizes? Sizes { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        #endregion Public Properties
    }
}