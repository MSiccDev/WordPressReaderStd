using System;
using System.Collections.Generic;
using System.Text;
using WordPressReader.Data;

namespace WordPressReader.Helpers
{
    public static class UrlHelper
    {
        /// <summary>
        /// creates the url to request for entitiy lists from the WordPress site
        /// </summary>
        public static string GetEntitySetApiUrl(this string baseUrl, Resource resource = Resource.Posts, int perPage = 10, int count = 10, int pageNr = 1, OrderBy orderby = OrderBy.Date, Order order = Order.Desc)
        {
            string apiResource = string.Empty;

            switch (resource)
            {
                case Resource.Root:
                    apiResource = Constants.ApiRootResource;
                    break;
                case Resource.Posts:
                    apiResource = Constants.PostsResource;
                    break;
                case Resource.Pages:
                    apiResource = Constants.PagesResource;
                    break;
                case Resource.Comments:
                    apiResource = Constants.CommentsResource;
                    break;
                case Resource.Tags:
                    apiResource = Constants.TagsResource;
                    break;
                case Resource.Categories:
                    apiResource = Constants.CategoriesResource;
                    break;
            }

            if (baseUrl.EndsWith("/"))
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }

            var parameters = new Dictionary<string, string>()
            {
                [Constants.ParameterPerPage] = perPage.ToString(),
                [Constants.ParameterCount] = count.ToString(),
                [Constants.ParameterPageNr] = pageNr.ToString(),
                [Constants.ParameterOrderBy] = orderby.ToString().ToLower(),
                [Constants.ParameterOrder] = order.ToString().ToLower()
            };

            //if (categories != null)
            //{
            //    parameters.Add(Constants.ParameterCategories, categories.ToArrayString());
            //}

            return (baseUrl + apiResource).AddParametersToUrl(parameters);
        }

        /// <summary>
        /// creates the url to request for an entitiy from the WordPress site
        /// </summary>
        public static string GetEntityApiUrl(this string baseUrl, long id, Resource resource = Resource.Posts)
        {
            string apiResource = string.Empty;

            switch (resource)
            {
                case Resource.Root:
                    apiResource = Constants.ApiRootResource;
                    break;
                case Resource.Posts:
                    apiResource = Constants.PostsResource;
                    break;
                case Resource.Pages:
                    apiResource = Constants.PagesResource;
                    break;
                case Resource.Comments:
                    apiResource = Constants.CommentsResource;
                    break;
                case Resource.Media:
                    apiResource = Constants.MediaResource;
                    break;
                case Resource.User:
                    apiResource = Constants.UserResource;
                    break;
            }

            if (baseUrl.EndsWith("/"))
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }

            var result = $"{baseUrl}{apiResource}/{id}";

            return result;
        }

        /// <summary>
        /// creates a post url for posting to WordPress. Currently supports only comments.
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        public static string GetPostApiUrl(this string baseUrl, Resource resource = Resource.Comments)
        {
            string apiResource = string.Empty;

            switch (resource)
            { 
                case Resource.Comments:
                    apiResource = Constants.CommentsResource;
                    break;
                default:
                    throw new NotImplementedException("this method currently supports only POST for comments");
            }

            if (baseUrl.EndsWith("/"))
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }

            var result = $"{baseUrl}{apiResource}";

            return result;
        }

        /// <summary>
        /// adds parameters to the url to make requests agains the WordPress API
        /// </summary>
        public static string AddParametersToUrl(this string url, Dictionary<string, string> parameters)
        {
            var result = url;

            if (parameters.Count > 0)
            {
                foreach (var p in parameters)
                {
                    result = result.AddParameterToUrl(p.Key, p.Value);
                }
            }

            return result;
        }

        /// <summary>
        /// adds a single parameter to the url to make requests agains the WordPress API
        /// </summary>
        public static string AddParameterToUrl(this string url, string parameterName, string parameterValue)
        {
            if (url.Contains("?"))
            {
                return $"{url}&{parameterName}={parameterValue}";
            }
            else
            {
                return $"{url}?{parameterName}={parameterValue}";
            }
        }
    }


}
