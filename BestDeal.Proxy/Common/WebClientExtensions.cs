using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;

namespace BestDeal.Proxy.Common
{
    public static class WebClientExtensions
    {
        private const string JSON_MEDIA_TYPE = "application/json";
        private const string XML_MEDIA_TYPE = "application/xml";
        public static async Task<T> ContentAsType<T>(this HttpResponseMessage response)
        {
            T data = default(T);
            using (Stream content = await response.Content.ReadAsStreamAsync())
            {                
                if (content?.Length>0 && response.Content.Headers.ContentType!=null)
                {
                    if (response.Content.Headers.ContentType.MediaType == JSON_MEDIA_TYPE)
                    {
                        data = await JsonSerializer.DeserializeAsync<T>(content, new JsonSerializerOptions()
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });
                    }
                    else if (response.Content.Headers.ContentType.MediaType == XML_MEDIA_TYPE)
                    {
                        var serializer = new XmlSerializer(typeof(T));
                        data = (T)serializer.Deserialize(content);
                    }
                }
            }                
             //Thread.CurrentThread.ManagedThreadId   
            return data;
        }

        public static string ConvertToQueryString(this List<KeyValuePair<string, string>> parameters)
        {
            if (parameters == null) return string.Empty;
            string query = string.Join("&", parameters.Select(p => $"{HttpUtility.UrlEncode(p.Key)}={HttpUtility.UrlEncode(p.Value)}"));
            return "?" + query;
        }
    }
}