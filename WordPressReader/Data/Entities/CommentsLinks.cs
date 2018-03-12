using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class CommentsLinks
    {
        [JsonProperty("children")]
        public List<Link> Children { get; set; }

        [JsonProperty("in-reply-to")]
        public List<EmbeddableLink> InReplyTo { get; set; }

        [JsonProperty("author")]
        public List<EmbeddableLink> Author { get; set; }

        [JsonProperty("collection")]
        public List<Link> Collection { get; set; }

        [JsonProperty("self")]
        public List<Link> Self { get; set; }

        [JsonProperty("up")]
        public List<LinkWithType> Up { get; set; }
    }
}
