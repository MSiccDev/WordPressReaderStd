using Newtonsoft.Json;
using WordPressReader.Data.Entities;

namespace WordPressReader.Data.Models
{
    public class WordPressEntity<TWordPressEntity>
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public WordPressEntity(string json, string errorJson = null)
        {
            _jsonSerializerSettings = new JsonSerializerSettings()
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
            };

            if (!string.IsNullOrEmpty(json))
                this.Value = FromJson(json);

            if (!string.IsNullOrEmpty(errorJson))
                this.Error = ErrorFromJson(errorJson);

            this.Raw = json;
            this.RawError = errorJson;
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

        public ApiError Error { get; }



        public string Raw { get; private set; }

        public string RawError { get; private set; }
    }
}
