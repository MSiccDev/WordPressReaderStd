using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class CommentsLinks
    {
        #region Public Properties

        [JsonProperty("author", NullValueHandling = NullValueHandling.Include)]
        public List<EmbeddableLink>? Author { get; set; }

        [JsonProperty("children", NullValueHandling = NullValueHandling.Include)]
        public List<Link>? Children { get; set; }

        [JsonProperty("collection", NullValueHandling = NullValueHandling.Include)]
        public List<Link>? Collection { get; set; }

        [JsonProperty("in-reply-to", NullValueHandling = NullValueHandling.Include)]
        public List<EmbeddableLink>? InReplyTo { get; set; }

        [JsonProperty("self", NullValueHandling = NullValueHandling.Include)]
        public List<Link>? Self { get; set; }

        [JsonProperty("up", NullValueHandling = NullValueHandling.Include)]
        public List<LinkWithType>? Up { get; set; }

        #endregion Public Properties
    }
}