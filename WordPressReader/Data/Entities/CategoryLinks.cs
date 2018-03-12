using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WordPressReader.Data.Entities
{
    public class CategoryLinks
    {
        [JsonProperty("self")]
        public List<Link> Self { get; set; }

        [JsonProperty("collection")]
        public List<Link> Collection { get; set; }

        [JsonProperty("about")]
        public List<Link> About { get; set; }

        [JsonProperty("up")]
        public List<EmbeddableLink> Up { get; set; }

        [JsonProperty("wp:post_type")]
        public List<Link> WpPostType { get; set; }

        [JsonProperty("curies")]
        public List<Cury> Curies { get; set; }
    }
}
