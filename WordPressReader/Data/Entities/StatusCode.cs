using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WordPressReader.Data.Entities
{
    public class StatusCode
    {
        [JsonProperty("status")]
        public long Code { get; set; }
    }
}
