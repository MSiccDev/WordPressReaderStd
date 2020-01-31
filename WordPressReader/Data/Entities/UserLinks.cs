using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class UserLinks
    {
        #region Public Properties

        [JsonProperty("collection", NullValueHandling = NullValueHandling.Include)]
        public List<Link>? Collection { get; set; }

        [JsonProperty("self", NullValueHandling = NullValueHandling.Include)]
        public List<Link>? Self { get; set; }

        #endregion Public Properties
    }
}