using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WordPressReader.Data.Entities
{
    public class Tag
    {
        #region Public Properties

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Include)]
        public string? Description { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("link", NullValueHandling = NullValueHandling.Include)]
        public string? Link { get; set; }

        [JsonProperty("_links", NullValueHandling = NullValueHandling.Include)]
        public TagLinks? Links { get; set; }

        //can be too different from blog to blog, hence yousing dynamic
        [JsonProperty("meta", NullValueHandling = NullValueHandling.Include)]
        public dynamic? Meta { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Include)]
        public string? Name { get; set; }

        [JsonProperty("slug", NullValueHandling = NullValueHandling.Include)]
        public string? Slug { get; set; }

        [JsonProperty("taxonomy", NullValueHandling = NullValueHandling.Include)]
        public string? Taxonomy { get; set; }

        #endregion Public Properties
    }
}