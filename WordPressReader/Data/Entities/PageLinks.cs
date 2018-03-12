using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class PageLinks
    {
        [JsonProperty("curies")]
        public List<Cury> Curies { get; set; }

        [JsonProperty("author")]
        public List<EmbeddableLink> Author { get; set; }

        [JsonProperty("about")]
        public List<Link> About { get; set; }

        [JsonProperty("collection")]
        public List<Link> Collection { get; set; }

        [JsonProperty("self")]
        public List<Link> Self { get; set; }

        [JsonProperty("wp:attachment")]
        public List<Link> WpAttachment { get; set; }

        [JsonProperty("replies")]
        public List<EmbeddableLink> Replies { get; set; }

        [JsonProperty("version-history")]
        public List<Link> VersionHistory { get; set; }

        [JsonProperty("wp:featuredmedia")]
        public List<EmbeddableLink> WpFeaturedmedia { get; set; }
    }
}
