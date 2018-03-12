using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public partial class MediaSizes
    {
        [JsonProperty("large")]
        public MediaContentSize Large { get; set; }

        [JsonProperty("medium_large")]
        public MediaContentSize MediumLarge { get; set; }

        [JsonProperty("full")]
        public MediaContentSize Full { get; set; }

        [JsonProperty("medium")]
        public MediaContentSize Medium { get; set; }

        [JsonProperty("sow-carousel-default")]
        public MediaContentSize SowCarouselDefault { get; set; }

        [JsonProperty("thumbnail")]
        public MediaContentSize Thumbnail { get; set; }
    }
}
