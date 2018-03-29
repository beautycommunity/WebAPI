using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.Hr_Register
{
    [JsonObject(IsReference = true)]
    public class ViewSummary
    {
        public string USERNO { get; set; }
        public insert_Step_One Step_One { get; set; }
        public insert_Step_Two Step_Two { get; set; }
        //public insert_Step_Three Step_Three { get; set; }
        public Step_Three_DETAIL Detail { get; set; }
        public List<Step_Three_EDUCTION> Eduction { get; set; }
        public List<Step_Three_EMPLOYMENT> Employment { get; set; }
        public List<Step_Three_LANGUAGE> Language { get; set; }
        public List<Step_Three_TRAINING> Training { get; set; }
        public List<Step_Four> Step_Four { get; set; }
    }

    [JsonObject(IsReference = true)]
    public class RetName
    {
        public string status { get; set; }
        public string message { get; set; }
        public string USERNO { get; set; }
    }

    [JsonObject(IsReference = true)]
    public class insert_Step_One
    {
        public string _USERNO { get; set; }
        public string _POSITION { get; set; }
        public string _FULLNAME_TH { get; set; }
        public string _NICKNAME_TH { get; set; }
        public string _FULLNAME_EN { get; set; }
        public string _NICKNAME_EN { get; set; }
        public string _PEOPLEID { get; set; }
        public string _ZONE { get; set; }
        public string _PROVINCE_BIRTH { get; set; }
        public DateTime _BIRTHDATE { get; set; }
        public int? _AGE { get; set; }
        public int? _WEIGHT { get; set; }
        public int? _HEIGHT { get; set; }
        public string _ADDR_ROW1 { get; set; }
        public string _ADDR_ROW2 { get; set; }
        public string _ADDR_ROW3 { get; set; }
        public string _ADDR_HOME1 { get; set; }
        public string _ADDR_HOME2 { get; set; }
        public string _ADDR_HOME3 { get; set; }
        public string _ADDR_TEL { get; set; }
        public string _ADDR_MOBILE { get; set; }
        public string _ADDR_EMAIL { get; set; }
        public string _ADDR_PHOTO { get; set; }
        public int _FLAG { get; set; }
    }

    [JsonObject(IsReference = true)]
    public class insert_Step_Two
    {
        public string USERNO { get; set; }
        public DateTime STARTING_DATE { get; set; }
        public string MARITAL { get; set; }
        public int? CHILDEN { get; set; }
        public string SPOUSE_NAME { get; set; }
        public int? SPOUSE_AGE { get; set; }
        public string SPOUSE_OCCUPATION { get; set; }
        public string SPOUSE_OFFICE { get; set; }
        public string SPOUSE_PHONE { get; set; }
        public string EMERGENCY { get; set; }
        public string EMERGENCY_ROW1 { get; set; }
        public string EMERGENCY_ROW2 { get; set; }
        public string EMERGENCY_RELATIONSHIP { get; set; }
        public string EMERGENCY_PHONE { get; set; }
        public int FLAG { get; set; }
    }

    // ------------------------------------------------------------------------------------------------------------------

    [JsonObject(IsReference = true)]
    public class insert_Step_Three
    {
        public string USERNO { get; set; }
        public Step_Three_DETAIL Detail { get; set; }
        public List<Step_Three_EDUCTION> Eduction { get; set; }
        public List<Step_Three_EMPLOYMENT> Employment { get; set; }
        public List<Step_Three_LANGUAGE> Language { get; set; }
        public List<Step_Three_TRAINING> Training { get; set; }
    }

    [JsonObject(IsReference = true)]
    public class Step_Three_DETAIL
    {
        public string CURRENTLY_STUDY { get; set; }
        public string STUDY_NAME { get; set; }
        public string STUDY_MAJOR { get; set; }
        public string HOBBY_ROW1 { get; set; }
        public string HOBBY_ROW2 { get; set; }
        public string HOBBY_ROW3 { get; set; }
        public string HOBBY_ROW4 { get; set; }
        public int FLAG { get; set; }
    }

    [JsonObject(IsReference = true)]
    public class Step_Three_EDUCTION
    {
        public string EDUCATION_LV { get; set; }
        public string EDUCATION_NAME { get; set; }
        public string DEGREE { get; set; }
        public string S_YEAR { get; set; }
        public string E_YEAR { get; set; }
        public decimal GPA { get; set; }
        public string MAJOR { get; set; }
        public int FLAG { get; set; }
    }

    [JsonObject(IsReference = true)]
    public class Step_Three_EMPLOYMENT
    {
        public string COMPANY_NAME { get; set; }
        public string S_DATE { get; set; }
        public string E_DATE { get; set; }
        public string POSITION { get; set; }
        public int? SALARY { get; set; }
        public string DETAIL { get; set; }
        public string LEAVING { get; set; }
        public int FLAG { get; set; }
    }

    [JsonObject(IsReference = true)]
    public class Step_Three_LANGUAGE
    {
        public string LANGUAGE { get; set; }
        public string SPEAKING { get; set; }
        public string READING { get; set; }
        public string WRITING { get; set; }
        public int FLAG { get; set; }
    }

    [JsonObject(IsReference = true)]
    public class Step_Three_TRAINING
    {
        public DateTime DATE { get; set; }
        public string COURSE { get; set; }
        public string INSTITUTION { get; set; }
        public DateTime S_DATE { get; set; }
        public DateTime E_DATE { get; set; }
        public int FLAG { get; set; }
    }
    

   // ----------------------------------------------------------------------------------------------------------------

   [JsonObject(IsReference = true)]
    public class insert_Step_Four
    {
        public string USERNO { get; set; }
        public DateTime STARTINT_DATE { get; set; }
        public List<Step_Four> Step_Four { get; set; }
    }

    [JsonObject(IsReference = true)]
    public class Step_Four
    {
        public int Q_ID { get; set; }
        public string CHOOSE { get; set; }
        public string DETAIL_ROW1 { get; set; }
        public string DETAIL_ROW2 { get; set; }
        public string DETAIL_ROW3 { get; set; }
        public int FLAG { get; set; }
    }


}