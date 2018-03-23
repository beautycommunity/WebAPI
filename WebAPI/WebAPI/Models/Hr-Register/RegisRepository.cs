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
            List<RetName> results = new List<RetName>();

            try
            {
                string USERNO;
                int Status;
                if (item._USERNO == null)
                {
                    USERNO = InsertData_One(item);
                    Status = 1;
                }
                else
                {
                    USERNO = UpdateData_One(item);
                    Status = 2;
                }
                
                RetName res = new RetName();
                res.status = "S";
                if (Status == 1)
                {
                    res.message = "Insert success";
                }else if(Status == 2)
                {
                    res.message = "Update success";
                }
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
            List<RetName> results = new List<RetName>();

            try
            {
                using (Hr_RegisterDataContext bx = new Hr_RegisterDataContext())
                {
                    var str = (from xx in bx.STEP_TWOs
                               where xx.USERNO == item.USERNO
                               select xx).FirstOrDefault();

                    string USERNO;
                    int Status;
                    if (str.USERNO == null)
                    {
                        USERNO = InsertData_Two(item);
                        Status = 1;
                    }
                    else
                    {
                        USERNO = UpdateData_Two(item);
                        Status = 2;
                    }

                    RetName res = new RetName();
                    res.status = "S";
                    if (Status == 1)
                    {
                        res.message = "Insert success";
                    }
                    else if (Status == 2)
                    {
                        res.message = "Update success";
                    }
                    res.USERNO = USERNO;
                    results.Add(res);
                }
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

        //[HttpPost]
        //[ActionName("Regis_Step_Three")]
        //public IEnumerable<RetName> Regis_Step_Three(insert_Step_Three item)
        //{
        //    //string strSQL = "SELECT POSITION,FULLNAME_TH FROM STEP_ONE";
        //    List<RetName> results = new List<RetName>();

        //    try
        //    {
        //        string USERNO;
        //        int Status;
        //        item.Detail.

        //        USERNO = InsertData_Three(item);

        //        RetName res = new RetName();
        //        res.status = "S";
        //        if (Status == 1)
        //        {
        //            res.message = "Insert success";
        //        }
        //        else if (Status == 2)
        //        {
        //            res.message = "Update success";
        //        }
        //        res.USERNO = USERNO;
        //        results.Add(res);
        //    }
        //    catch (Exception ex)
        //    {
        //        RetName res = new RetName();
        //        res.status = "F";
        //        res.message = ex.Message;
        //        results.Add(res);
        //    }

        //    return results.ToArray();
        //}

        [HttpPost]
        [ActionName("Regis_Step_Four")]
        public IEnumerable<RetName> Regis_Step_Four(insert_Step_Four item)
        {
            List<RetName> results = new List<RetName>();

            try
            {
                //string USERNO;
                //int Status;

                //InsertData_Four(item);

                //RetName res = new RetName();
                //res.status = "S";
                //res.message = "Insert success";
                //res.USERNO = USERNO;
                //results.Add(res);
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
             
                    res._USERNO = str.USERNO;
                    res._POSITION = str.POSITION;
                    res._FULLNAME_TH = str.FULLNAME_TH;
                    res._NICKNAME_TH = str.NICKNAME_TH;
                    res._FULLNAME_EN = str.FULLNAME_EN;
                    res._NICKNAME_EN = str.NICKNAME_EN;
                    res._PEOPLEID = str.PEOPLEID;
                    res._ZONE = str.ZONE;
                    res._PROVINCE_BIRTH = str.PROVINCE_BIRTH;
                    res._BIRTHDATE = DateTime.Parse(str.BIRTHDATE.ToString());
                    res._AGE = str.AGE;
                    res._WEIGHT = str.WEIGHT;
                    res._HEIGHT = str.HEIGHT;
                    res._ADDR_ROW1 = str.ADDR_ROW1;
                    res._ADDR_ROW2 = str.ADDR_ROW2;
                    res._ADDR_ROW3 = str.ADDR_ROW3;
                    res._ADDR_HOME1 = str.ADDR_HOME1;
                    res._ADDR_HOME2 = str.ADDR_HOME2;
                    res._ADDR_HOME3 = str.ADDR_HOME3;
                    res._ADDR_TEL = str.ADDR_TEL;
                    res._ADDR_MOBILE = str.ADDR_MOBILE;
                    res._ADDR_EMAIL = str.ADDR_EMAIL;
                    res._ADDR_PHOTO = str.ADDR_PHOTO;
                    //res._WORKDATE = DateTime.Now.AddYears(543);
                    res._FLAG = 0;
                    results.Add(res);
                }
            }
            catch (Exception ex)
            {
                insert_Step_One res = new insert_Step_One();
                res._USERNO = ex.Message;
                //results.Add(res);
            }

            return results.ToArray();
        }

        [HttpPost]
        [ActionName("Back_Three_To_Two")]
        public IEnumerable<insert_Step_Two> Back_Three_To_Two(RetName item)
        {
            //string strSQL = "SELECT POSITION,FULLNAME_TH FROM STEP_ONE";
            List<insert_Step_Two> results = new List<insert_Step_Two>();

            try
            {
                using (Hr_RegisterDataContext bx = new Hr_RegisterDataContext())
                {
                    var str = (from xx in bx.STEP_TWOs
                               where xx.USERNO == item.USERNO
                               select xx).FirstOrDefault();

                    insert_Step_Two res = new insert_Step_Two();

                    res.USERNO = str.USERNO;
                    res.MARITAL = str.MARITAL;
                    res.CHILDEN = str.CHILDEN;
                    res.SPOUSE_NAME = str.SPOUSE_NAME;
                    res.SPOUSE_AGE = str.SPOUSE_AGE;
                    res.SPOUSE_OCCUPATION = str.SPOUSE_OCCUPATION;
                    res.SPOUSE_OFFICE = str.SPOUSE_OFFICE;
                    res.SPOUSE_PHONE = str.SPOUSE_PHONE;
                    res.EMERGENCY = str.EMERGENCY;
                    res.EMERGENCY_ROW1 = str.EMERGENCY_ROW1;
                    res.EMERGENCY_ROW2 = str.EMERGENCY_ROW2;
                    res.EMERGENCY_RELATIONSHIP = str.EMERGENCY_RELATIONSHIP;
                    res.EMERGENCY_PHONE = str.EMERGENCY_PHONE;
                    //res._WORKDATE = DateTime.Now.AddYears(543);
                    results.Add(res);
                }
            }
            catch (Exception ex)
            {
                insert_Step_One res = new insert_Step_One();
                res._USERNO = ex.Message;
                //results.Add(res);
            }

            return results.ToArray();
        }

        private string InsertData_Three(insert_Step_Three item)
        {
            throw new NotImplementedException();
        }

        // ---------------------------------------------------------------------------------------------------------------------

        private string InsertData_One(insert_Step_One item)
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
                        Step_One.POSITION = item._POSITION;
                        Step_One.FULLNAME_TH = item._FULLNAME_TH;
                        Step_One.NICKNAME_TH = item._NICKNAME_TH;
                        Step_One.FULLNAME_EN = item._FULLNAME_EN;
                        Step_One.NICKNAME_EN = item._NICKNAME_EN;
                        Step_One.PEOPLEID = item._PEOPLEID;
                        Step_One.ZONE = item._ZONE;
                        Step_One.PROVINCE_BIRTH = item._PROVINCE_BIRTH;
                        Step_One.BIRTHDATE = item._BIRTHDATE;
                        Step_One.AGE = item._AGE;
                        Step_One.WEIGHT = item._WEIGHT;
                        Step_One.HEIGHT = item._HEIGHT;
                        Step_One.ADDR_ROW1 = item._ADDR_ROW1;
                        Step_One.ADDR_ROW2 = item._ADDR_ROW2;
                        Step_One.ADDR_ROW3 = item._ADDR_ROW3;
                        Step_One.ADDR_HOME1 = item._ADDR_HOME1;
                        Step_One.ADDR_HOME2 = item._ADDR_HOME2;
                        Step_One.ADDR_HOME3 = item._ADDR_HOME3;
                        Step_One.ADDR_TEL = item._ADDR_TEL;
                        Step_One.ADDR_MOBILE = item._ADDR_MOBILE;
                        Step_One.ADDR_EMAIL = item._ADDR_EMAIL;
                        Step_One.ADDR_PHOTO = item._ADDR_PHOTO;
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

        private string InsertData_Two(insert_Step_Two item)
        {
            string USERNO;
            using (TransactionScope ts = new TransactionScope())
            {
                using (Hr_RegisterDataContext bx = new Hr_RegisterDataContext())
                {
                    try
                    {
                        var Step_Two = new STEP_TWO();

                        Step_Two.USERNO = item.USERNO;
                        USERNO = item.USERNO;
                        Step_Two.MARITAL = item.MARITAL;
                        Step_Two.CHILDEN = item.CHILDEN;
                        Step_Two.SPOUSE_NAME = item.SPOUSE_NAME;
                        Step_Two.SPOUSE_AGE = item.SPOUSE_AGE;
                        Step_Two.SPOUSE_OCCUPATION = item.SPOUSE_OCCUPATION;
                        Step_Two.SPOUSE_OFFICE = item.SPOUSE_OFFICE;
                        Step_Two.SPOUSE_PHONE = item.SPOUSE_PHONE;
                        Step_Two.EMERGENCY = item.EMERGENCY;
                        Step_Two.EMERGENCY_ROW1 = item.EMERGENCY_ROW1;
                        Step_Two.EMERGENCY_ROW2 = item.EMERGENCY_ROW2;
                        Step_Two.EMERGENCY_RELATIONSHIP = item.EMERGENCY_RELATIONSHIP;
                        Step_Two.EMERGENCY_PHONE = item.EMERGENCY_PHONE;
                        Step_Two.FLAG = 0;

                        bx.STEP_TWOs.InsertOnSubmit(Step_Two);
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

        private string UpdateData_One(insert_Step_One item)
        {
            string USERNO;
            //using (TransactionScope ts = new TransactionScope())
            //{
                using (Hr_RegisterDataContext bx = new Hr_RegisterDataContext())
                {
                    try
                    {
                        var str = (from xx in bx.STEP_ONEs
                                   where xx.USERNO == item._USERNO
                                   select xx).FirstOrDefault();

                        str.POSITION = item._POSITION;
                        str.FULLNAME_TH = item._FULLNAME_TH;
                        str.NICKNAME_TH = item._NICKNAME_TH;
                        str.FULLNAME_EN = item._FULLNAME_EN;
                        str.NICKNAME_EN = item._NICKNAME_EN;
                        str.PEOPLEID = item._PEOPLEID;
                        str.ZONE = item._ZONE;
                        str.PROVINCE_BIRTH = item._PROVINCE_BIRTH;
                        str.BIRTHDATE = item._BIRTHDATE;
                        str.AGE = item._AGE;
                        str.WEIGHT = item._WEIGHT;
                        str.HEIGHT = item._HEIGHT;
                        str.ADDR_ROW1 = item._ADDR_ROW1;
                        str.ADDR_ROW2 = item._ADDR_ROW2;
                        str.ADDR_ROW3 = item._ADDR_ROW3;
                        str.ADDR_HOME1 = item._ADDR_HOME1;
                        str.ADDR_HOME2 = item._ADDR_HOME2;
                        str.ADDR_HOME3 = item._ADDR_HOME3;
                        str.ADDR_TEL = item._ADDR_TEL;
                        str.ADDR_MOBILE = item._ADDR_MOBILE;
                        str.ADDR_EMAIL = item._ADDR_EMAIL;
                        str.ADDR_PHOTO = item._ADDR_PHOTO;
                        //str.WORKDATE = DateTime.Now;
                        USERNO = item._USERNO;

                        bx.SubmitChanges();
                        //ts.Complete();
                    }
                    catch (Exception ex)
                    {
                        throw new ArgumentException(
                                    $"{ex.Message} ");
                    }
                }
            //}
            return USERNO;
        }

        private string UpdateData_Two(insert_Step_Two item)
        {
            string USERNO;
            using (Hr_RegisterDataContext bx = new Hr_RegisterDataContext())
            {
                try
                {
                    var str = (from xx in bx.STEP_TWOs
                               where xx.USERNO == item.USERNO
                               select xx).FirstOrDefault();

                    USERNO = item.USERNO;
                    str.MARITAL = item.MARITAL;
                    str.CHILDEN = item.CHILDEN;
                    str.SPOUSE_NAME = item.SPOUSE_NAME;
                    str.SPOUSE_AGE = item.SPOUSE_AGE;
                    str.SPOUSE_OCCUPATION = item.SPOUSE_OCCUPATION;
                    str.SPOUSE_OFFICE = item.SPOUSE_OFFICE;
                    str.SPOUSE_PHONE = item.SPOUSE_PHONE;
                    str.EMERGENCY = item.EMERGENCY;
                    str.EMERGENCY_ROW1 = item.EMERGENCY_ROW1;
                    str.EMERGENCY_ROW2 = item.EMERGENCY_ROW2;
                    str.EMERGENCY_RELATIONSHIP = item.EMERGENCY_RELATIONSHIP;
                    str.EMERGENCY_PHONE = item.EMERGENCY_PHONE;

                    bx.SubmitChanges();
                    //ts.Complete();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(
                                $"{ex.Message} ");
                }
            }
            //}
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