using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public partial class MediaSizes
    {
        #region Public Properties

        [JsonProperty("full", NullValueHandling = NullValueHandling.Include)]
        public MediaContentSize? Full { get; set; }

        [JsonProperty("large", NullValueHandling = NullValueHandling.Include)]
        public MediaContentSize? Large { get; set; }

        [JsonProperty("medium", NullValueHandling = NullValueHandling.Include)]
        public MediaContentSize? Medium { get; set; }

        [JsonProperty("medium_large", NullValueHandling = NullValueHandling.Include)]
        public MediaContentSize? MediumLarge { get; set; }

        [JsonProperty("sow-carousel-default", NullValueHandling = NullValueHandling.Include)]
        public MediaContentSize? SowCarouselDefault { get; set; }

        [JsonProperty("thumbnail", NullValueHandling = NullValueHandling.Include)]
        public MediaContentSize? Thumbnail { get; set; }

        #endregion Public Properties
    }
}