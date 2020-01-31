using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public partial class MediaLinks
    {
        #region Public Properties

        [JsonProperty("about", NullValueHandling = NullValueHandling.Include)]
        public List<Link>? About { get; set; }

        [JsonProperty("author", NullValueHandling = NullValueHandling.Include)]
        public List<EmbeddableLink>? Author { get; set; }

        [JsonProperty("collection", NullValueHandling = NullValueHandling.Include)]
        public List<Link>? Collection { get; set; }

        [JsonProperty("replies", NullValueHandling = NullValueHandling.Include)]
        public List<EmbeddableLink>? Replies { get; set; }

        [JsonProperty("self", NullValueHandling = NullValueHandling.Include)]
        public List<Link>? Self { get; set; }

        #endregion Public Properties
    }
}