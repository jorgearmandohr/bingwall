using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Json;

namespace PictureService
{
    public class Wallpaper
    {
        private const string BASE_URL = "http://www.bing.com/";

        public Wallpaper()
        {
            
        }

        public async Task<string> GetTodayWallpaperUrl()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(BASE_URL + "HPImageArchive.aspx?format=js&idx=0&n=1&mkt=en-US"));
            request.ContentType = "application/json";
            request.Method = "GET";
            string urlResult = string.Empty;

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));

                    urlResult = BASE_URL + jsonDoc["url"];
                }
            }

            return urlResult;
        }
    }
}
