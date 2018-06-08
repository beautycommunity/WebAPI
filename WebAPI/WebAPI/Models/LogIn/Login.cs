using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.LogIn
{
    [JsonObject(IsReference = true)]
    public class RetName
    {
        public string status { get; set; }
        public string message { get; set; }
        public string STCODE { get; set; }
        public string FULLNAME { get; set; }
        public string NICKNAME { get; set; }
    }

    [JsonObject(IsReference = true)]
    public class DataUser
    {
        public string STCODE { get; set; }
        public string PASS { get; set; }
    }
}