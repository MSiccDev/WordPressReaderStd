using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WordPressReader.Data.Entities
{
    public class ApiError
    {
        #region Public Properties

        [JsonProperty("code", NullValueHandling = NullValueHandling.Include)]
        public string? Code { get; set; }

        [JsonProperty("data", NullValueHandling = NullValueHandling.Include)]
        public StatusCode? Data { get; set; }

        [JsonProperty("message", NullValueHandling = NullValueHandling.Include)]
        public string? Message { get; set; }

        #endregion Public Properties
    }
}