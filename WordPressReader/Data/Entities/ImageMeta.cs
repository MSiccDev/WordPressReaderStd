using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class ImageMeta
    {
        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("iso")]
        public string Iso { get; set; }

        [JsonProperty("camera")]
        public string Camera { get; set; }

        [JsonProperty("aperture")]
        public string Aperture { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("credit")]
        public string Credit { get; set; }

        [JsonProperty("created_timestamp")]
        public string CreatedTimestamp { get; set; }

        [JsonProperty("focal_length")]
        public string FocalLength { get; set; }

        [JsonProperty("orientation")]
        public string Orientation { get; set; }

        [JsonProperty("keywords")]
        public List<object> Keywords { get; set; }

        [JsonProperty("shutter_speed")]
        public string ShutterSpeed { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
