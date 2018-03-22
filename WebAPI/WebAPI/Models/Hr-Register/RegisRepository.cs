using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;
using System.Web.Http;
using System.IO;
using System.Web.Http.Results;
using WebAPI.DATA.Hr_Register;
using System.Transactions;

namespace WebAPI.Models.Hr_Register
{
    public class RegisRepository : IRegisRepository
    {
        [HttpPost]
        [ActionName("Regis_Step_One")]
        public IEnumerable<RetName> Regis_Step_One(insert_Step_One item)
        {
            //string strSQL = "SELECT POSITION,FULLNAME_TH FROM STEP_ONE";
            List<RetName> results = new List<RetName>();

            try
            {
                //string USERNO = item.USERNO;
                //if (item.USERNO == null) {
                string USERNO = InsertData(item);
                //}

                RetName res = new RetName();
                res.status = "S";
                res.message = "Insert success";
                res.USERNO = USERNO;
                results.Add(res);
            }
            catch (Exception ex)
            {
                RetName res = new RetName();
                res.status = "F";
                res.message = ex.Message;
                results.Add(res);
            }

            return results.ToArray();
        }

        [HttpPost]
        [ActionName("Regis_Step_Two")]
        public IEnumerable<RetName> Regis_Step_Two(insert_Step_Two item)
        {
            //string strSQL = "SELECT POSITION,FULLNAME_TH FROM STEP_ONE";
            List<RetName> results = new List<RetName>();

            try
            {
                //InsertData(item);

                RetName res = new RetName();
                res.status = "S";
                res.message = "Insert success";
                results.Add(res);
            }
            catch (Exception ex)
            {
                RetName res = new RetName();
                res.status = "F";
                res.message = ex.Message;
                results.Add(res);
            }

            return results.ToArray();
        }

        // ---------------------------------------------------------------------------------------------------------------------


        [HttpPost]
        [ActionName("Back_Two_To_One")]
        public IEnumerable<insert_Step_One> Back_Two_To_One(RetName item)
        {
            //string strSQL = "SELECT POSITION,FULLNAME_TH FROM STEP_ONE";
            List<insert_Step_One> results = new List<insert_Step_One>();

            try
            {
                using (Hr_RegisterDataContext bx = new Hr_RegisterDataContext())
                {
                    var str = (from xx in bx.STEP_ONEs
                               where xx.USERNO == item.USERNO
                               select xx).FirstOrDefault();

                    insert_Step_One res = new insert_Step_One();

                    //res.USERNO = str.USERNO;
                    //res.POSITION = item.POSITION;
                    //res.FULLNAME_TH = item.FULLNAME_TH;
                    //res.NICKNAME_TH = item.NICKNAME_TH;
                    //res.FULLNAME_EN = item.FULLNAME_EN;
                    //res.NICKNAME_EN = item.NICKNAME_EN;
                    //res.PEOPLEID = item.PEOPLEID;
                    //res.ZONE = item.ZONE;
                    //res.PROVINCE_BIRTH = item.PROVINCE_BIRTH;
                    //res.BIRTHDATE = item.BIRTHDATE;
                    //res.AGE = item.AGE;
                    //res.WEIGHT = item.WEIGHT;
                    //res.HEIGHT = item.HEIGHT;
                    //res.ADDR_ROW1 = item.ADDR_ROW1;
                    //res.ADDR_ROW2 = item.ADDR_ROW2;
                    //res.ADDR_ROW3 = item.ADDR_ROW3;
                    //res.ADDR_HOME1 = item.ADDR_HOME1;
                    //res.ADDR_HOME2 = item.ADDR_HOME2;
                    //res.ADDR_HOME3 = item.ADDR_HOME3;
                    //res.ADDR_TEL = item.ADDR_TEL;
                    //res.ADDR_MOBILE = item.ADDR_MOBILE;
                    //res.ADDR_EMAIL = item.ADDR_EMAIL;
                    //res.ADDR_PHOTO = item.ADDR_PHOTO;
                    //res.WORKDATE = DateTime.Now.AddYears(543);
                    //res.FLAG = 0;

                    //res.status = "S";
                    //res.message = "Insert success";
                    //res.USERNO = USERNO;
                    results.Add(res);
                }              
            }
            catch (Exception ex)
            {
                RetName res = new RetName();
                res.status = "F";
                res.message = ex.Message;
                //results.Add(res);
            }

            return results.ToArray();
        }

        // ---------------------------------------------------------------------------------------------------------------------

        private string InsertData(insert_Step_One item)
        {
            string USERNO;
            using (TransactionScope ts = new TransactionScope())
            {
                using (Hr_RegisterDataContext bx = new Hr_RegisterDataContext())
                {
                    try
                    {
                        var Step_One = new STEP_ONE();

                        string tketNo = GenNo();
                        USERNO = tketNo;

                        Step_One.USERNO = tketNo;
                        Step_One.POSITION = item.POSITION;
                        Step_One.FULLNAME_TH = item.FULLNAME_TH;
                        Step_One.NICKNAME_TH = item.NICKNAME_TH;
                        Step_One.FULLNAME_EN = item.FULLNAME_EN;
                        Step_One.NICKNAME_EN = item.NICKNAME_EN;
                        Step_One.PEOPLEID = item.PEOPLEID;
                        Step_One.ZONE = item.ZONE;
                        Step_One.PROVINCE_BIRTH = item.PROVINCE_BIRTH;
                        Step_One.BIRTHDATE = item.BIRTHDATE.AddYears(543);
                        Step_One.AGE = item.AGE;
                        Step_One.WEIGHT = item.WEIGHT;
                        Step_One.HEIGHT = item.HEIGHT;
                        Step_One.ADDR_ROW1 = item.ADDR_ROW1;
                        Step_One.ADDR_ROW2 = item.ADDR_ROW2;
                        Step_One.ADDR_ROW3 = item.ADDR_ROW3;
                        Step_One.ADDR_HOME1 = item.ADDR_HOME1;
                        Step_One.ADDR_HOME2 = item.ADDR_HOME2;
                        Step_One.ADDR_HOME3 = item.ADDR_HOME3;
                        Step_One.ADDR_TEL = item.ADDR_TEL;
                        Step_One.ADDR_MOBILE = item.ADDR_MOBILE;
                        Step_One.ADDR_EMAIL = item.ADDR_EMAIL;
                        Step_One.ADDR_PHOTO = item.ADDR_PHOTO;
                        Step_One.WORKDATE = DateTime.Now;
                        Step_One.FLAG = 0;

                        bx.STEP_ONEs.InsertOnSubmit(Step_One);
                        bx.SubmitChanges();
                        ts.Complete();
                    }
                    catch (Exception ex)
                    {
                        throw new ArgumentException(
                                    $"{ex.Message} ");
                    }
                }
            }
            return USERNO;
        }



        private string GenNo()
        {
            string runNo = "HR"; //IT17000009
            string strRun = "";
            string yy = DateTime.Now.Year.ToString();
            string mm = DateTime.Now.Month.ToString();
            int intRun = 1;


            yy = yy.Substring(yy.Length - 2, 2);
            if (mm.Length == 1) { mm = "0" + mm; }

            runNo = runNo + yy + mm;

            using (Hr_RegisterDataContext Context = new Hr_RegisterDataContext())
            {
                try
                {
                    var queryX = Context.STEP_ONEs.OrderByDescending(s => s.USERNO)
                    .Where(s => s.USERNO.Contains(runNo))
                    .FirstOrDefault();
                    strRun = queryX.USERNO;
                }
                catch
                {
                    strRun = "HR18010000";
                }

            }

            strRun = strRun.Substring(strRun.Length - 4, 4);
            intRun = Int32.Parse(strRun);
            intRun = intRun + 1;

            strRun = intRun.ToString();

            switch (strRun.Length)
            {
                case 1:
                    strRun = "000" + strRun;
                    break;
                case 2:
                    strRun = "00" + strRun;
                    break;
                case 3:
                    strRun = "0" + strRun;
                    break;
            }

            runNo = runNo + strRun;

            return runNo;
        }
    }
}