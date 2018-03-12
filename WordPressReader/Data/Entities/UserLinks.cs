using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class UserLinks
    {
        [JsonProperty("collection")]
        public List<Link> Collection { get; set; }

        [JsonProperty("self")]
        public List<Link> Self { get; set; }
    }
}
