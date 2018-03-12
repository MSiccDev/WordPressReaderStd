using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class PostLinks
    {
        [JsonProperty("curies")]
        public List<Cury> Curies { get; set; }

        [JsonProperty("author")]
        public List<EmbeddableLink> EmbeddableLink { get; set; }

        [JsonProperty("Link")]
        public List<Link> Link { get; set; }

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

        [JsonProperty("wp:term")]
        public List<WpTerm> WpTerm { get; set; }
    }

}
