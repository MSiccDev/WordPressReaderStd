using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public partial class MediaDetails
    {
        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("sizes")]
        public MediaSizes Sizes { get; set; }

        [JsonProperty("file")]
        public string File { get; set; }

        [JsonProperty("image_meta")]
        public ImageMeta ImageMeta { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }
    }
}
