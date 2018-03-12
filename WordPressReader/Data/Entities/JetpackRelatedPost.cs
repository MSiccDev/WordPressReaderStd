using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordPressReader.Data.Entities
{
    public class JetpackRelatedPost
    {
        [JsonProperty("excerpt")]
        public string Excerpt { get; set; }

        [JsonProperty("rel")]
        public string Rel { get; set; }

        [JsonProperty("context")]
        public string Context { get; set; }

        [JsonProperty("classes")]
        public List<object> Classes { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("format")]
        public bool Format { get; set; }

        [JsonProperty("img")]
        public JetPackImage Img { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url_meta")]
        public JetPackUrlMeta UrlMeta { get; set; }
    }
}
