﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WordPressReader.Data.Entities
{
    public class Tag
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("taxonomy")]
        public string Taxonomy { get; set; }

        [JsonProperty("meta")]
        public List<object> Meta { get; set; }

        [JsonProperty("_links")]
        public TagLinks Links { get; set; }
    }
}