﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using Newtonsoft.Json;

namespace EpiServer.AlloyDemo.GraphAPI.Business.Parking
{

    public class OpeningTime
    {

        [JsonProperty("days")]
        public string[] Days { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }
    }

}