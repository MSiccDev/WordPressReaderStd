using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WordPressReader.Data.Entities;
using WordPressReader.Helpers;

namespace WordPressReader.Data.Models
{
    public class WordPressEntitySet<TWordPressEntity>
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        private readonly JsonSerializer _jsonSerializer = null;

        private WordPressEntitySet(bool throwExceptions)
        {
            _jsonSerializerSettings = new JsonSerializerSettings()
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
            };

            if (!throwExceptions)
            {
                _jsonSerializerSettings.Error = delegate (object sender, ErrorEventArgs args)
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

        public WordPressEntitySet(string json, string errorJson = null, bool throwExceptions = true) : this(throwExceptions)
        {

            if (!string.IsNullOrEmpty(json))
                this.Value = FromJson(json);

            if (!string.IsNullOrEmpty(errorJson))
                this.Error = ErrorFromJson(errorJson);


            this.Raw = json;
            this.RawError = errorJson;
        }

        public WordPressEntitySet(HttpContent httpContent, bool isError = false, bool throwExceptions = true) : this(throwExceptions)
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
                            this.Value = _jsonSerializer.Deserialize<List<TWordPressEntity>>(json);
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


        private List<TWordPressEntity> FromJson(string json)
        {
           return JsonConvert.DeserializeObject<List<TWordPressEntity>>(json, _jsonSerializerSettings);
        }

        private ApiError ErrorFromJson(string errorJson)
        {
            return JsonConvert.DeserializeObject<ApiError>(errorJson, _jsonSerializerSettings);
        }


        public string ToRaw(List<TWordPressEntity> entities)
        {
            return  JsonConvert.SerializeObject(entities, _jsonSerializerSettings);
        }

        public string ToRawError(ApiError error)
        {
                return JsonConvert.SerializeObject(error, _jsonSerializerSettings);
        }


        public List<TWordPressEntity> Value { get; }

        public ApiError Error { get; private set; }


        public string Raw { get; private set; }

        public string RawError { get; private set; }

    }
}
