using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;

namespace bingwall
{
    public class WallpaperService
    {
        private const string BASE_URL = "http://www.bing.com/";

        public WallpaperService()
        {
        }

        public async Task<string> GetTodayWallpaperUrlAsync()
        {
            string urlResult = string.Empty;
            try
            {
                BingModel model = new BingModel();
                var requestUrl = new Uri(BASE_URL + "HPImageArchive.aspx?format=js&idx=0&n=1&mkt=en-US");
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<BingModel>(content);
                }

                if (model.Images != null)
                {
                    urlResult = BASE_URL + model.Images.FirstOrDefault().Url;
                }
            }
            catch (Exception ex)
            {
                urlResult = ex.Message;
            }

            return urlResult;
        }

        public Image GetTodayWallpaperUrl()
        {
            BingModel model = new BingModel();
            try
            {
                
                var requestUrl = new Uri(BASE_URL + "HPImageArchive.aspx?format=js&idx=0&n=1&mkt=en-US");
                HttpClient client = new HttpClient();
                var response = client.GetAsync(requestUrl);
                if (response.Result.IsSuccessStatusCode)
                {
                    var content = response.Result.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<BingModel>(content.Result);
                }

                if (model.Images != null)
                {
                    model.Images.FirstOrDefault().Url = BASE_URL + model.Images.FirstOrDefault().Url;
                }
            }
            catch (Exception)
            {
                
            }

            return model.Images.FirstOrDefault();
        }

        public Stream GetStream(string url)
        {
            HttpClient client = new HttpClient();
            var stream = client.GetStreamAsync(url);
            return stream.Result;
        }

        public byte[] GetByte(string url)
        {
            HttpClient client = new HttpClient();
            var stream = client.GetByteArrayAsync(url);
            return stream.Result;
        }
    }
}
