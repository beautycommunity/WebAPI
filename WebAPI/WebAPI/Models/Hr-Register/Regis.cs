using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.Hr_Register
{
    [JsonObject(IsReference = true)]
    public class RetName
    {
        public string status { get; set; }
        public string message { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }

    [JsonObject(IsReference = true)]
    public class insert_Step_One
    {
        public int WH_ID { get; set; }
        public string POSITION { get; set; }
        public string FULLNAME_TH { get; set; }
        public string NICKNAME_TH { get; set; }
        public string FULLNAME_EN { get; set; }
        public string NICKNAME_EN { get; set; }
        public string PEOPLEID { get; set; }
        public string ZONE { get; set; }
        public string PROVINCE_BIRTH { get; set; }
        public DateTime BIRTHDATE { get; set; }
        public int AGE { get; set; }
        public int WEIGHT { get; set; }
        public int HEIGHT { get; set; }
        public string ADDR_ROW1 { get; set; }
        public string ADDR_ROW2 { get; set; }
        public string ADDR_ROW3 { get; set; }
        public string ADDR_HOME1 { get; set; }
        public string ADDR_HOME2 { get; set; }
        public string ADDR_HOME3 { get; set; }
        public string ADDR_TEL { get; set; }
        public string ADDR_MOBILE { get; set; }
        public string ADDR_EMAIL { get; set; }
        public string ADDR_PHOTO { get; set; }
        public DateTime WORKDATE { get; set; }
        public int FLAG { get; set; }
    }

    [JsonObject(IsReference = true)]
    public class insert_Step_Two
    {
        public int WH_ID { get; set; }
        public string POSITION { get; set; }
        public string FULLNAME_TH { get; set; }
        public string NICKNAME_TH { get; set; }
        public string FULLNAME_EN { get; set; }
        public string NICKNAME_EN { get; set; }
        public string PEOPLEID { get; set; }
        public string ZONE { get; set; }
        public string PROVINCE_BIRTH { get; set; }
        public DateTime BIRTHDATE { get; set; }
        public int AGE { get; set; }
        public int WEIGHT { get; set; }
        public int HEIGHT { get; set; }
        public string ADDR_ROW1 { get; set; }
        public string ADDR_ROW2 { get; set; }
        public string ADDR_ROW3 { get; set; }
        public string ADDR_HOME1 { get; set; }
        public string ADDR_HOME2 { get; set; }
        public string ADDR_HOME3 { get; set; }
        public string ADDR_TEL { get; set; }
        public string ADDR_MOBILE { get; set; }
        public string ADDR_EMAIL { get; set; }
        public string ADDR_PHOTO { get; set; }
        public DateTime WORKDATE { get; set; }
        public int FLAG { get; set; }
    }
}