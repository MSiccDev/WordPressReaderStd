using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WordPressReader.Data.Entities
{
    public class TagLinks
    {
        #region Public Properties

        [JsonProperty("about", NullValueHandling = NullValueHandling.Include)]
        public List<Link>? About { get; set; }

        [JsonProperty("collection", NullValueHandling = NullValueHandling.Include)]
        public List<Link>? Collection { get; set; }

        [JsonProperty("curies", NullValueHandling = NullValueHandling.Include)]
        public List<Cury>? Curies { get; set; }

        [JsonProperty("self", NullValueHandling = NullValueHandling.Include)]
        public List<Link>? Self { get; set; }

        [JsonProperty("wp:post_type", NullValueHandling = NullValueHandling.Include)]
        public List<Link>? WpPostType { get; set; }

        #endregion Public Properties
    }
}