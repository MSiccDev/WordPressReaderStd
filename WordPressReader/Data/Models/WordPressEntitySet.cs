using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WordPressReader.Data.Entities;

namespace WordPressReader.Data.Models
{
    public class WordPressEntitySet<TWordPressEntity>
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;


        public WordPressEntitySet(string json, string errorJson = null, bool throwExceptions = true)
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

            if (!string.IsNullOrEmpty(json))
                this.Value = FromJson(json);

            if (!string.IsNullOrEmpty(errorJson))
                this.Error = ErrorFromJson(errorJson);


            this.Raw = json;
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
            return JsonConvert.SerializeObject(entities, _jsonSerializerSettings);
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
