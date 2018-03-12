using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public partial class MediaLinks
    {
        [JsonProperty("author")]
        public List<EmbeddableLink> Author { get; set; }

        [JsonProperty("replies")]
        public List<EmbeddableLink> Replies { get; set; }

        [JsonProperty("about")]
        public List<Link> About { get; set; }

        [JsonProperty("collection")]
        public List<Link> Collection { get; set; }

        [JsonProperty("self")]
        public List<Link> Self { get; set; }
    }
}
