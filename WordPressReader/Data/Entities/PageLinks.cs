using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class PageLinks
    {
        #region Public Properties

        [JsonProperty("about", NullValueHandling = NullValueHandling.Include)]
        public List<Link>? About { get; set; }

        [JsonProperty("author", NullValueHandling = NullValueHandling.Include)]
        public List<EmbeddableLink>? Author { get; set; }

        [JsonProperty("collection", NullValueHandling = NullValueHandling.Include)]
        public List<Link>? Collection { get; set; }

        [JsonProperty("curies", NullValueHandling = NullValueHandling.Include)]
        public List<Cury>? Curies { get; set; }

        [JsonProperty("replies", NullValueHandling = NullValueHandling.Include)]
        public List<EmbeddableLink>? Replies { get; set; }

        [JsonProperty("self", NullValueHandling = NullValueHandling.Include)]
        public List<Link>? Self { get; set; }

        [JsonProperty("version-history", NullValueHandling = NullValueHandling.Include)]
        public List<Link>? VersionHistory { get; set; }

        [JsonProperty("wp:attachment", NullValueHandling = NullValueHandling.Include)]
        public List<Link>? WpAttachment { get; set; }

        [JsonProperty("wp:featuredmedia", NullValueHandling = NullValueHandling.Include)]
        public List<EmbeddableLink>? WpFeaturedmedia { get; set; }

        #endregion Public Properties
    }
}