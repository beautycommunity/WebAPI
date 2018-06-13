using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPI.Models.Ticket_OP
{
    public class MTicket_OP
    {
    }

    [JsonObject(IsReference = true)]
    public class Detail
    {
        public string STCODE { get; set; }
        public int Ticket_ID { get; set; }
        public string Pos { get; set; }
        public string seach { get; set; }
        public string type { get; set; }
    }

    [JsonObject(IsReference = true)]
    public class AnsOP
    {
        public string status { get; set; }
        public string message { get; set; }
        public string STCODE { get; set; }
    }

    [JsonObject(IsReference = true)]
    public class AddComment
    {
        public string STCODE { get; set; }
        public int TK_ID { get; set; }
        public int ORDERNO { get; set; }
        public string TICKETNO { get; set; }

        public SelectList JT_LIST { get; set; }
        [Required(ErrorMessage = "กรุณาเลือกประเภทงาน")]
        [Display(Name = "ประเภท")]
        public int? JT_ID { get; set; }

        [Required(ErrorMessage = "กรุณาเพิ่มข้อความก่อนกดปุ่มบันทึก")]
        [Display(Name = "ข้อความ")]
        public string TK_MESAGE { get; set; }

        public int US_ID { get; set; }
        public string CREATEDATE { get; set; }
        public int? SS_ID { get; set; }

        public ICollection<Ticket> ticket { get; set; }

    }

    [JsonObject(IsReference = true)]
    public class CreTicket
    {
        public string STCODE { get; set; }
        public int TK_ID { get; set; }

        [Display(Name = "เลขที่")]
        public string TICKETNO { get; set; }

        [Required(ErrorMessage = "กรุณาใส่หัวข้อด้วยครับ")]
        [Display(Name = "หัวข้อ")]

        public string TOPIC { get; set; }

        [Required(ErrorMessage = "กรุณาใส่รายละเอียดด้วยครับ")]
        [Display(Name = "รายละเอียด")]
        public string DETAIL { get; set; }

        public int? SS_ID { get; set; }
        [Display(Name = "สถานะ")]
        public string ST_NAME { get; set; }

        [Required(ErrorMessage = "กรุณาเลือกประเภทงาน")]
        public int? JT_ID { get; set; }


        public int? US_ID { get; set; }

        [Display(Name = "ผู้แจ้ง")]
        public string CRE_NICKNAME { get; set; }

        [Display(Name = "วันที่แจ้ง")]
        public string CREATEDATE { get; set; }

        public string WHNAME { get; set; }

        public SelectList AREA { get; set; }

        [Required(ErrorMessage = "กรุณาเลือกแอเรียด้วยครับ")]
        public string AREA_NAME { get; set; }

        public IEnumerable<HttpPostedFileBase> file { get; set; }
    }

    [JsonObject(IsReference = true)]
    public class Ticket
    {
        public string BRAND { get; set; }
        public int TK_ID { get; set; }

        [Display(Name = "เลขที่")]
        public string TICKETNO { get; set; }

        [Display(Name = "รายละเอียด")]
        public string DETAIL { get; set; }

        public int? SS_ID { get; set; }
        [Display(Name = "สถานะ")]
        public string ST_NAME { get; set; }

        [Display(Name = "วันที่")]
        public string CREATEDATE { get; set; }

        [Display(Name = "เวลา")]
        public string CREATETIME { get; set; }

        [Display(Name = "รหัสสาขา")]
        public string WHCODE { get; set; }

        [Display(Name = "ชื่อสาขา")]
        public string WHNAME { get; set; }

        [Display(Name = "แอเรีย")]
        public string AREA { get; set; }

        [Display(Name = "ข้อความ")]
        public string TK_MESAGE { get; set; }

        public int? I_US_ID { get; set; }
        [Display(Name = "ตอบ")]
        public string POS_NAME { get; set; }

        [Display(Name = "วันที่")]
        public string POSTDATE { get; set; }

        [Display(Name = "ผู็รับงาน")]
        public string REC_NICKNAME { get; set; }

        public int? ORDERNO { get; set; }
        public string US_ID { get; set; }


        public string FLS { get; set; }

        public string FLS_I { get; set; }

        public string FLS_H_1 { get; set; }
        public string FLS_H_2 { get; set; }
        public string FLS_H_3 { get; set; }
        public string FLS_H_1_Name { get; set; }
        public string FLS_H_2_Name { get; set; }
        public string FLS_H_3_Name { get; set; }

        public string FLS_I_1 { get; set; }
        public string FLS_I_2 { get; set; }
        public string FLS_I_3 { get; set; }
        public string FLAG_1 { get; set; }
        public string FLAG_2 { get; set; }
        public string FLAG_3 { get; set; }
        public string IMG_1 { get; set; }
        public string IMG_2 { get; set; }
        public string IMG_3 { get; set; }
    }
}