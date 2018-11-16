using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Net.Http;
using WordPressReader.Data.Entities;

namespace WordPressReader.Data.Models
{
    public class WordPressEntity<TWordPressEntity>
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        private JsonSerializer _jsonSerializer = null;

        private WordPressEntity(bool throwExceptions)
        {
            _jsonSerializerSettings = new JsonSerializerSettings()
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
            };

            if (!throwExceptions)
            {
                _jsonSerializerSettings.Error = delegate (object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
                                                {
                                                    this.Error = new ApiError()
                                                    {
                                                        Code = args.CurrentObject.GetType().ToString(),
                                                        Data = new StatusCode() { Code = 0 },
                                                        Message = args.ErrorContext.Error.Message
                                                    };

                                                    args.ErrorContext.Handled = true;
                                                };
            }

        }

        public WordPressEntity(string json, string errorJson = null, bool throwExceptions = true) : this(throwExceptions)
        {
            
            if (!string.IsNullOrEmpty(json))
                this.Value = FromJson(json);

            if (!string.IsNullOrEmpty(errorJson))
                this.Error = ErrorFromJson(errorJson);

            this.Raw = json;
            this.RawError = errorJson;

        }

        public WordPressEntity(HttpContent httpContent, bool isError = false, bool throwExceptions = true) : this(throwExceptions)
        {
            _jsonSerializer = JsonSerializer.Create(_jsonSerializerSettings);

            using (var stream = httpContent.ReadAsStreamAsync().GetAwaiter().GetResult())
            {
                using (var reader = new StreamReader(stream))
                {
                    using (var json = new JsonTextReader(reader))
                    {
                        if (!isError)
                        {
                            this.Value = _jsonSerializer.Deserialize<TWordPressEntity>(json);
                            this.Raw = ToRaw(this.Value);
                        }
                        else
                        {
                            this.Error = _jsonSerializer.Deserialize<ApiError>(json);
                            this.RawError = ToRawError(this.Error);
                        }
                    }
                }
            }
        }

        private TWordPressEntity FromJson(string json)
        {
            return JsonConvert.DeserializeObject<TWordPressEntity>(json, _jsonSerializerSettings);
        }

        private ApiError ErrorFromJson(string errorJson)
        {
            return JsonConvert.DeserializeObject<ApiError>(errorJson, _jsonSerializerSettings);
        }


        public string ToRaw(TWordPressEntity entity)
        {
            return JsonConvert.SerializeObject(entity, _jsonSerializerSettings);
        }

        public string ToRawError(ApiError error)
        {
            return JsonConvert.SerializeObject(error, _jsonSerializerSettings);
        }


        public TWordPressEntity Value { get; }

        public ApiError Error { get; private set;  }



        public string Raw { get; private set; }

        public string RawError { get; private set; }
    }
}
