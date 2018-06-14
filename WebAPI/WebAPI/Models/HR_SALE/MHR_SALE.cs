using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models.HR_SALE
{
    public class MHR_SALE
    {

    }

    public class ShowProduct
    {
        public ShowProduct()
        {
            this.Ans_SProduct = new List<SProduct>();
        }

        public class SProduct
        {
            public string S_MPCODE { get; set; }
            public string S_ABBNO { get; set; }
            public string S_MPNAME { get; set; }
            public string S_PRICE { get; set; }
            public string PRICE { get; set; }
            public string S_DATE { get; set; }
            public string QTY { get; set; }
        }

        public string ch_PRICE { get; set; }
        public string ch_MPCODE { get; set; }
        public string ch_ABBNO { get; set; }
        public string ch_MPNAME { get; set; }
        public string ch_USER { get; set; }


        [DataType(DataType.PhoneNumber)]
        public int ch_QTY { get; set; }


        public string de_USER { get; set; }
        public string de_MPCODE { get; set; }
        public string de_ABBNO { get; set; }
        public string de_MPNAME { get; set; }

        public string Total { get; set; }
        public string Bal { get; set; }
        public string NET { get; set; }

        public List<SProduct> Ans_SProduct { get; set; }
    }

    [JsonObject(IsReference = true)]
    public class HR_DATA
    {
        public string ssName { get; set; }
        public string USERONLINE { get; set; }
        public string MPCODE { get; set; }
        public string PRICE { get; set; }
        public string ABBNO { get; set; }
        public string USER { get; set; }
        public string MPNAME { get; set; }
        public string CHECK { get; set; }
        public string QTY { get; set; }
    }

    [JsonObject(IsReference = true)]
    public class Detail
    {
        public int? q_FLAG { get; set; }
        public object q { get; set; }
        public string GET_MPCODE { get; set; }
        public string GET_USER { get; set; }
        public string GET_MPNAME { get; set; }
        public string GET_PRICE { get; set; }
        public string seach { get; set; }

        public string DROPDOWN { get; set; }
        public string STCODE { get; set; }
        public string FULLNAME { get; set; }
        public string User { get; set; }
        public string Show { get; set; }
        public string Error { get; set; }
        public string message { get; set; }
        public string status { get; set; }
    }

    public class user
    {
        [Required]
        [Display(Name = "User name")]
        public string User { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Old Password")]
        public string Old_Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string New_Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string Confirm_Password { get; set; }
    }

    public class Product
    {

        public Product()
        {
            this.AnsProduct = new List<GetProduct>();
        }

        public class GetProduct
        {
            public string MPCODE { get; set; }
            public string MPNAME { get; set; }
            public string PRICE { get; set; }
            public string MAXPRICE { get; set; }

        }

        public string Get_MPCODE { get; set; }
        public string Get_USER { get; set; }
        public string Get_PRICE { get; set; }
        public string Get_MPNAME { get; set; }

        //[DataType(DataType.PhoneNumber)]
        public int QTY { get; set; }
        //public string Get_MPNAME { get; set; }


        //public string MPCODE { get; set; }
        //public string MPNAME { get; set; }
        //public string PRICE { get; set; }

        public int index { get; set; }

        public string ProductCode { get; set; }

        public List<GetProduct> AnsProduct { get; set; }
    }

    public class Input_Management
    {
        public string User { get; set; }
        public string PTDATE { get; set; }
        public string ABBNO { get; set; }
        public string FULLNAME { get; set; }
        public string QTY { get; set; }
        public string NET { get; set; }
        public string Check { get; set; }

        public string Dpcode { get; set; }
        public string Deteil { get; set; }
    }

    public class Management
    {
        public Management()
        {
            this.AnsManagement = new List<GetManagement>();
            this.ShowManagement = new List<GetPro>();
        }

        public class GetManagement
        {
            public string FULLNAME { get; set; }
            public string ID_ST { get; set; }
            public string ABBNO { get; set; }
            public string QTY { get; set; }
            public string NET { get; set; }
            public string PTDATE { get; set; }
            public string FLAG { get; set; }
            public string Dpcode { get; set; }
            public string Deteil { get; set; }
        }

        public class GetPro
        {
            public int row { get; set; }
            public string MPCODE { get; set; }
            public string MPNAME { get; set; }
            public string QTY { get; set; }
            public string DETAIL { get; set; }
        }

        public string Detail { get; set; }
        public string S_User { get; set; }
        public string S_PTDATE { get; set; }
        public string S_ABBNO { get; set; }
        public string S_FULLNAME { get; set; }
        public string S_QTY { get; set; }
        public string S_NET { get; set; }

        public string U_User { get; set; }
        public string U_PTDATE { get; set; }
        public string U_ABBNO { get; set; }
        public string U_QTY { get; set; }
        public string U_NET { get; set; }

        public string D_Deteil { get; set; }

        public string C_User { get; set; }
        public string C_ABBNO { get; set; }

        public List<GetManagement> AnsManagement { get; set; }
        public List<GetPro> ShowManagement { get; set; }
    }

    public class Management_All
    {
        public Management_All()
        {
            this.AnsManagementAll = new List<GetManagementAll>();
        }

        public class GetManagementAll
        {
            //public string FULLNAME { get; set; }
            public string PTDATE { get; set; }
            public string MPCODE { get; set; }
            public string MPNAME { get; set; }
            public string QTY { get; set; }
        }

        public List<GetManagementAll> AnsManagementAll { get; set; }
    }
}