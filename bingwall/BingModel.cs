using System;
namespace bingwall
{
    using System;
    using System.Net;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public partial class BingModel
    {
        [JsonProperty("images")]
        public Image[] Images { get; set; }

        [JsonProperty("tooltips")]
        public Tooltips Tooltips { get; set; }
    }

    public partial class Tooltips
    {
        [JsonProperty("loading")]
        public string Loading { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("walle")]
        public string Walle { get; set; }

        [JsonProperty("walls")]
        public string Walls { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("bot")]
        public long Bot { get; set; }

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("copyrightlink")]
        public string Copyrightlink { get; set; }

        [JsonProperty("drk")]
        public long Drk { get; set; }

        [JsonProperty("enddate")]
        public string Enddate { get; set; }

        [JsonProperty("fullstartdate")]
        public string Fullstartdate { get; set; }

        [JsonProperty("hs")]
        public object[] Hs { get; set; }

        [JsonProperty("hsh")]
        public string Hsh { get; set; }

        [JsonProperty("quiz")]
        public string Quiz { get; set; }

        [JsonProperty("startdate")]
        public string Startdate { get; set; }

        [JsonProperty("top")]
        public long Top { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("urlbase")]
        public string Urlbase { get; set; }

        [JsonProperty("wp")]
        public bool Wp { get; set; }
    }

    public partial class BingModel
    {
        public static BingModel FromJson(string json) => JsonConvert.DeserializeObject<BingModel>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this BingModel self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
