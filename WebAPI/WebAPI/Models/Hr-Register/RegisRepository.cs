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
                    USERNO = InsertData_One(item);
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
                    if (str == null)
                    {
                        USERNO = InsertData_Two(item);
                        Status = 1;
                    }
                    else
                    {
                        USERNO = UpdateData_Two(item);
                        USERNO = InsertData_Two(item);
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

        [HttpPost]
        [ActionName("Regis_Step_Three")]
        public IEnumerable<RetName> Regis_Step_Three(insert_Step_Three item)
        {
            List<RetName> results = new List<RetName>();

            try
            {
                using (Hr_RegisterDataContext bx = new Hr_RegisterDataContext())
                {
                    var str = (from xx in bx.STEP_THREE_DETAILs
                               where xx.USERNO == item.USERNO
                               select xx).FirstOrDefault();

                    int Status;
                    if (str == null)
                    {
                        InsertData_Three(item);
                        Status = 1;
                    }
                    else
                    {
                        UpdateData_Three(item);
                        InsertData_Three(item);
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
                    res.USERNO = item.USERNO;
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

        [HttpPost]
        [ActionName("Regis_Step_Four")]
        public IEnumerable<RetName> Regis_Step_Four(insert_Step_Four item)
        {
            List<RetName> results = new List<RetName>();

            try
            {
                using (Hr_RegisterDataContext bx = new Hr_RegisterDataContext())
                {
                    var str = (from xx in bx.STEP_FOURs
                               where xx.USERNO == item.USERNO
                               select xx).FirstOrDefault();

                    int Status;
                    if (str == null)
                    {
                        InsertData_Four(item);
                        Status = 1;
                    }
                    else
                    {
                        UpdateData_Four(item);
                        InsertData_Four(item);
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
                    res.USERNO = item.USERNO;
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

        [HttpPost]
        [ActionName("Update_Summary")]
        public IEnumerable<RetName> Update_Summary(ViewSummary item)
        {
            List<RetName> results = new List<RetName>();

            try
            {
                string USERNO;
                //int Status;
                //if (item._USERNO == null)
                //{
                InsertData_One(item.Step_One);
                InsertData_Two(item.Step_Two);
                //InsertData_Three(item.Step_Three);
                //InsertData_Four(item.Step_Four);
                //InsertData_One(item.Step_One);
                //InsertData_One(item.Step_One);
                //InsertData_One(item.Step_One);
                //    Status = 1;
                //}
                //else
                //{
                //    USERNO = UpdateData_One(item);
                //    Status = 2;
                //}

                RetName res = new RetName();
                res.status = "S";
                //if (Status == 1)
                //{
                    res.message = "Insert success";
                //}
                //else if (Status == 2)
                //{
                //    res.message = "Update success";
                //}
                //res.USERNO = USERNO;
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
        [ActionName("Summary")]
        public IEnumerable<ViewSummary> Summary(RetName item)
        {
            List<ViewSummary> results = new List<ViewSummary>();
            ViewSummary summary = new ViewSummary();
            string USERNO = item.USERNO;
            //List<insert_Step_One> One = new List<insert_Step_One>();
            try
            {
                using (Hr_RegisterDataContext bx = new Hr_RegisterDataContext())
                {
                    var str_one = (from xx in bx.STEP_ONEs
                               where xx.USERNO == USERNO
                                   select xx).FirstOrDefault();
             
                    insert_Step_One res_one = new insert_Step_One();

                    res_one._USERNO = str_one.USERNO;
                    res_one._POSITION = str_one.POSITION;
                    res_one._FULLNAME_TH = str_one.FULLNAME_TH;
                    res_one._NICKNAME_TH = str_one.NICKNAME_TH;
                    res_one._FULLNAME_EN = str_one.FULLNAME_EN;
                    res_one._NICKNAME_EN = str_one.NICKNAME_EN;
                    res_one._PEOPLEID = str_one.PEOPLEID;
                    res_one._ZONE = str_one.ZONE;
                    res_one._PROVINCE_BIRTH = str_one.PROVINCE_BIRTH;
                    res_one._BIRTHDATE = DateTime.Parse(str_one.BIRTHDATE.ToString());
                    res_one._AGE = str_one.AGE;
                    res_one._WEIGHT = str_one.WEIGHT;
                    res_one._HEIGHT = str_one.HEIGHT;
                    res_one._ADDR_ROW1 = str_one.ADDR_ROW1;
                    res_one._ADDR_ROW2 = str_one.ADDR_ROW2;
                    res_one._ADDR_ROW3 = str_one.ADDR_ROW3;
                    res_one._ADDR_HOME1 = str_one.ADDR_HOME1;
                    res_one._ADDR_HOME2 = str_one.ADDR_HOME2;
                    res_one._ADDR_HOME3 = str_one.ADDR_HOME3;
                    res_one._ADDR_TEL = str_one.ADDR_TEL;
                    res_one._ADDR_MOBILE = str_one.ADDR_MOBILE;
                    res_one._ADDR_EMAIL = str_one.ADDR_EMAIL;
                    res_one._ADDR_PHOTO = str_one.ADDR_PHOTO;

                    summary.Step_One = res_one;

                    //-------------------------------------------------------------------------------------------------

                    var str_two = (from xx in bx.STEP_TWOs
                               where xx.USERNO == USERNO
                                   select xx).FirstOrDefault();

                    insert_Step_Two res_two = new insert_Step_Two();

                    res_two.USERNO = str_two.USERNO;
                    res_two.STARTING_DATE = DateTime.Parse(str_two.STARTING_DATE.ToString());
                    res_two.MARITAL = str_two.MARITAL;
                    res_two.CHILDEN = str_two.CHILDEN;
                    res_two.SPOUSE_NAME = str_two.SPOUSE_NAME;
                    res_two.SPOUSE_AGE = str_two.SPOUSE_AGE;
                    res_two.SPOUSE_OCCUPATION = str_two.SPOUSE_OCCUPATION;
                    res_two.SPOUSE_OFFICE = str_two.SPOUSE_OFFICE;
                    res_two.SPOUSE_PHONE = str_two.SPOUSE_PHONE;
                    res_two.EMERGENCY = str_two.EMERGENCY;
                    res_two.EMERGENCY_ROW1 = str_two.EMERGENCY_ROW1;
                    res_two.EMERGENCY_ROW2 = str_two.EMERGENCY_ROW2;
                    res_two.EMERGENCY_RELATIONSHIP = str_two.EMERGENCY_RELATIONSHIP;
                    res_two.EMERGENCY_PHONE = str_two.EMERGENCY_PHONE;

                    summary.Step_Two = res_two;

                    //-------------------------------------------------------------------------------------------------

                    var str_three_detail = (from xx in bx.STEP_THREE_DETAILs
                                   where xx.USERNO == USERNO
                                            select xx).FirstOrDefault();

                    Step_Three_DETAIL res_three_detail = new Step_Three_DETAIL();

                    res_three_detail.CURRENTLY_STUDY = str_three_detail.CURRENTLY_STUDY;
                    res_three_detail.STUDY_NAME = str_three_detail.STUDY_NAME;
                    res_three_detail.STUDY_MAJOR = str_three_detail.STUDY_MAJOR;
                    res_three_detail.HOBBY_ROW1 = str_three_detail.HOBBY_ROW1;
                    res_three_detail.HOBBY_ROW2 = str_three_detail.HOBBY_ROW2;
                    res_three_detail.HOBBY_ROW3 = str_three_detail.HOBBY_ROW3;
                    res_three_detail.HOBBY_ROW4 = str_three_detail.HOBBY_ROW4;

                    summary.Detail = res_three_detail;

                    //-------------------------------------------------------------------------------------------------

                    var str_three_eduction = (from xx in bx.STEP_THREE_EDUCTIONs
                                            where xx.USERNO == USERNO
                                            select xx);

                    List<Step_Three_EDUCTION> res_three_Eduction = new List<Step_Three_EDUCTION>();

                    foreach (var item_Edu in str_three_eduction)
                    {
                        Step_Three_EDUCTION Eduction = new Step_Three_EDUCTION();

                        Eduction.EDUCATION_LV = item_Edu.EDUCATION_LV;
                        Eduction.EDUCATION_NAME = item_Edu.EDUCATION_NAME;
                        Eduction.DEGREE = item_Edu.DEGREE;
                        Eduction.S_YEAR = item_Edu.S_YEAR;
                        Eduction.E_YEAR = item_Edu.E_YEAR;
                        Eduction.GPA = decimal.Parse(item_Edu.GPA.ToString());
                        Eduction.MAJOR = item_Edu.MAJOR;

                        res_three_Eduction.Add(Eduction);
                    }

                    summary.Eduction = res_three_Eduction;

                    //-------------------------------------------------------------------------------------------------

                    var str_three_employment = (from xx in bx.STEP_THREE_EMPLOYMENTs
                                              where xx.USERNO == USERNO
                                              select xx);

                    List<Step_Three_EMPLOYMENT> res_three_Employment = new List<Step_Three_EMPLOYMENT>();

                    foreach (var item_Emp in str_three_employment)
                    {
                        Step_Three_EMPLOYMENT Employment = new Step_Three_EMPLOYMENT();

                        Employment.COMPANY_NAME = item_Emp.COMPANY_NAME;
                        Employment.S_DATE = item_Emp.S_DATE;
                        Employment.E_DATE = item_Emp.E_DATE;
                        Employment.POSITION = item_Emp.POSITION;
                        Employment.SALARY = item_Emp.SALARY;
                        Employment.DETAIL = item_Emp.DETAIL;
                        Employment.LEAVING = item_Emp.LEAVING;

                        res_three_Employment.Add(Employment);
                    }

                    summary.Employment = res_three_Employment;

                    //-------------------------------------------------------------------------------------------------

                    var str_three_language = (from xx in bx.STEP_THREE_LANGUAGEs
                                                where xx.USERNO == USERNO
                                                select xx);

                    List<Step_Three_LANGUAGE> res_three_Language = new List<Step_Three_LANGUAGE>();

                    foreach (var item_lan in str_three_language)
                    {
                        Step_Three_LANGUAGE Language = new Step_Three_LANGUAGE();

                        Language.LANGUAGE = item_lan.LANGUAGE;
                        Language.SPEAKING =item_lan.SPEAKING;
                        Language.READING = item_lan.READING;
                        Language.WRITING = item_lan.WRITING;

                        res_three_Language.Add(Language);
                    }

                    summary.Language = res_three_Language;

                    //-------------------------------------------------------------------------------------------------

                    var str_three_training = (from xx in bx.STEP_THREE_TRAININGs
                                              where xx.USERNO == USERNO
                                              select xx);

                    List<Step_Three_TRAINING> res_three_Training = new List<Step_Three_TRAINING>();

                    foreach (var item_Tra in str_three_training)
                    {
                        Step_Three_TRAINING Training = new Step_Three_TRAINING();

                        Training.DATE = DateTime.Parse(item_Tra.DATE.ToString());
                        Training.COURSE = item_Tra.COURSE;
                        Training.INSTITUTION = item_Tra.INSTITUTION;
                        Training.S_DATE = DateTime.Parse(item_Tra.S_DATE.ToString());
                        Training.E_DATE = DateTime.Parse(item_Tra.E_DATE.ToString());

                        res_three_Training.Add(Training);
                    }

                    summary.Training = res_three_Training;

                    //-------------------------------------------------------------------------------------------------

                    var str_four = (from xx in bx.STEP_FOURs
                                    where xx.USERNO == USERNO
                                    select xx);

                    List<Step_Four> res_four = new List<Step_Four>();

                    foreach (var item_Four in str_four)
                    {
                        Step_Four Four = new Step_Four();

                        Four.Q_ID = item_Four.Q_ID;
                        Four.CHOOSE = item_Four.CHOOSE;
                        Four.DETAIL_ROW1 = item_Four.DETAIL_ROW1;
                        Four.DETAIL_ROW2 = item_Four.DETAIL_ROW2;
                        Four.DETAIL_ROW3 = item_Four.DETAIL_ROW3;

                        res_four.Add(Four);
                    }

                    summary.Step_Four = res_four;

                    //-------------------------------------------------------------------------------------------------

                    results.Add(summary);
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

        // Insert ---------------------------------------------------------------------------------------------------------------

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

        private string InsertData_Three(insert_Step_Three item)
        {
            string USERNO;
            using (TransactionScope ts = new TransactionScope())
            {
                using (Hr_RegisterDataContext bx = new Hr_RegisterDataContext())
                {
                    try
                    {
                        USERNO = item.USERNO;
                        var Step_Three_Training = new STEP_THREE_TRAINING();
                        var Step_Three_Language = new STEP_THREE_LANGUAGE();
                        var Step_Three_Employment = new STEP_THREE_EMPLOYMENT();
                        var Step_Three_Detail = new STEP_THREE_DETAIL();

                        //----------------------------------------------------------------------------------

                        //List<Step_Three_EDUCTION> Eduction = new List<Step_Three_EDUCTION>();

                        foreach (var ux in item.Eduction)
                        {
                            STEP_THREE_EDUCTION value_Eduction = new STEP_THREE_EDUCTION();

                            value_Eduction.USERNO = item.USERNO;
                            value_Eduction.EDUCATION_LV = ux.EDUCATION_LV;
                            value_Eduction.EDUCATION_NAME = ux.EDUCATION_NAME;
                            value_Eduction.DEGREE = ux.DEGREE;
                            value_Eduction.S_YEAR = ux.S_YEAR;
                            value_Eduction.E_YEAR = ux.E_YEAR;
                            value_Eduction.GPA = ux.GPA;
                            value_Eduction.MAJOR = ux.MAJOR;
                            value_Eduction.FLAG = 0;

                            bx.STEP_THREE_EDUCTIONs.InsertOnSubmit(value_Eduction);
                            bx.SubmitChanges();
                        }

                        //----------------------------------------------------------------------------------

                        //List<Step_Three_TRAINING> Training = new List<Step_Three_TRAINING>();

                        foreach (var ux in item.Training)
                        {
                            STEP_THREE_TRAINING value_Training = new STEP_THREE_TRAINING();

                            value_Training.USERNO = item.USERNO;
                            value_Training.DATE = ux.DATE.AddYears(543);
                            value_Training.COURSE = ux.COURSE;
                            value_Training.INSTITUTION = ux.INSTITUTION;
                            value_Training.S_DATE = ux.S_DATE.AddYears(543);
                            value_Training.E_DATE = ux.E_DATE.AddYears(543);
                            value_Training.FLAG = 0;

                            bx.STEP_THREE_TRAININGs.InsertOnSubmit(value_Training);
                            bx.SubmitChanges();
                        }

                        //----------------------------------------------------------------------------------

                        STEP_THREE_DETAIL value_Detail = new STEP_THREE_DETAIL();

                        value_Detail.USERNO = item.USERNO;
                        value_Detail.STUDY_NAME = item.Detail.STUDY_NAME;
                        value_Detail.STUDY_MAJOR = item.Detail.STUDY_MAJOR;
                        value_Detail.HOBBY_ROW1 = item.Detail.HOBBY_ROW1;
                        value_Detail.HOBBY_ROW2 = item.Detail.HOBBY_ROW2;
                        value_Detail.HOBBY_ROW3 = item.Detail.HOBBY_ROW3;
                        value_Detail.HOBBY_ROW4 = item.Detail.HOBBY_ROW4;
                        value_Detail.FLAG = 0;

                        bx.STEP_THREE_DETAILs.InsertOnSubmit(value_Detail);
                        bx.SubmitChanges();

                        //----------------------------------------------------------------------------------

                        //List<Step_Three_LANGUAGE> Language = new List<Step_Three_LANGUAGE>();

                        foreach (var ux in item.Language)
                        {
                            STEP_THREE_LANGUAGE value_Language = new STEP_THREE_LANGUAGE();

                            value_Language.USERNO = item.USERNO;
                            value_Language.LANGUAGE = ux.LANGUAGE;
                            value_Language.SPEAKING = ux.SPEAKING;
                            value_Language.READING = ux.READING;
                            value_Language.WRITING = ux.WRITING;
                            value_Language.FLAG = 0;

                            bx.STEP_THREE_LANGUAGEs.InsertOnSubmit(value_Language);
                            bx.SubmitChanges();
                        }

                        //----------------------------------------------------------------------------------


                        //List<Step_Three_EMPLOYMENT> Employment = new List<Step_Three_EMPLOYMENT>();

                        foreach (var ux in item.Employment)
                        {
                            STEP_THREE_EMPLOYMENT value_Employment = new STEP_THREE_EMPLOYMENT();

                            value_Employment.USERNO = item.USERNO;
                            value_Employment.COMPANY_NAME = ux.COMPANY_NAME;
                            value_Employment.S_DATE = ux.S_DATE;
                            value_Employment.E_DATE = ux.E_DATE;
                            value_Employment.POSITION = ux.POSITION;
                            value_Employment.DETAIL = ux.DETAIL;
                            value_Employment.LEAVING = ux.LEAVING;
                            value_Employment.FLAG = 0;

                            bx.STEP_THREE_EMPLOYMENTs.InsertOnSubmit(value_Employment);
                            bx.SubmitChanges();
                        }

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

        private string InsertData_Four(insert_Step_Four item)
        {
            string USERNO;
            using (TransactionScope ts = new TransactionScope())
            {
                using (Hr_RegisterDataContext bx = new Hr_RegisterDataContext())
                {
                    try
                    {
                        //List<Step_Three_TRAINING> Training = new List<Step_Three_TRAINING>();

                        foreach (var ux in item.Step_Four)
                        {
                            STEP_FOUR value_Four = new STEP_FOUR();

                            value_Four.USERNO = item.USERNO;
                            value_Four.Q_ID = ux.Q_ID;
                            value_Four.CHOOSE = ux.CHOOSE;
                            value_Four.DETAIL_ROW1 = ux.DETAIL_ROW1;
                            value_Four.DETAIL_ROW2 = ux.DETAIL_ROW2;
                            value_Four.DETAIL_ROW3 = ux.DETAIL_ROW3;
                            value_Four.FLAG = 0;

                            bx.STEP_FOURs.InsertOnSubmit(value_Four);
                            bx.SubmitChanges();
                        }

                        var Starting_date = (from xx in bx.STEP_TWOs
                                             where xx.USERNO == item.USERNO
                                             select xx).FirstOrDefault();

                        Starting_date.STARTING_DATE = item.STARTINT_DATE;
                        //bx.STEP_TWOs.InsertOnSubmit(Starting_date);
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
            return USERNO = item.USERNO;
        }

        // Update -------------------------------------------------------------------------------------------------------------

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

                        bx.STEP_ONEs.DeleteOnSubmit(str);
                        bx.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        throw new ArgumentException(
                                    $"{ex.Message} ");
                    }
                }
            //}
            return USERNO = item._USERNO;
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

                    bx.STEP_TWOs.DeleteOnSubmit(str);
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
            return USERNO = item.USERNO;
        }

        private string UpdateData_Three(insert_Step_Three item)
        {
            string USERNO;
            using (Hr_RegisterDataContext bx = new Hr_RegisterDataContext())
            {
                try
                {
                    var value_Eduction = (from xx in bx.STEP_THREE_EDUCTIONs
                                          where xx.USERNO == item.USERNO
                                          select xx);

                    foreach (var ux in value_Eduction)
                    {
                        bx.STEP_THREE_EDUCTIONs.DeleteOnSubmit(ux);
                    }
                    bx.SubmitChanges();

                    //----------------------------------------------------------------------------------

                    var value_Training = (from xx in bx.STEP_THREE_TRAININGs
                                          where xx.USERNO == item.USERNO
                                          select xx);

                    foreach (var ux in value_Training)
                    {
                        bx.STEP_THREE_TRAININGs.DeleteOnSubmit(ux);
                    }
                    bx.SubmitChanges();

                    //----------------------------------------------------------------------------------

                    //STEP_THREE_DETAIL value_Detail = new STEP_THREE_DETAIL();
                    var value_Detail = (from xx in bx.STEP_THREE_DETAILs
                                          where xx.USERNO == item.USERNO
                                          select xx).FirstOrDefault();

                    bx.STEP_THREE_DETAILs.DeleteOnSubmit(value_Detail);
                    bx.SubmitChanges();

                    //----------------------------------------------------------------------------------

                    //List<Step_Three_LANGUAGE> Language = new List<Step_Three_LANGUAGE>();
                    var value_Language = (from xx in bx.STEP_THREE_LANGUAGEs
                                          where xx.USERNO == item.USERNO
                                          select xx);

                    foreach (var ux in value_Language)
                    {
                        bx.STEP_THREE_LANGUAGEs.DeleteOnSubmit(ux);
                    }
                    bx.SubmitChanges();

                    //----------------------------------------------------------------------------------


                    //List<Step_Three_EMPLOYMENT> Employment = new List<Step_Three_EMPLOYMENT>();
                    var value_Employment = (from xx in bx.STEP_THREE_EMPLOYMENTs
                                            where xx.USERNO == item.USERNO
                                            select xx);

                    foreach (var ux in value_Employment)
                    {
                        bx.STEP_THREE_EMPLOYMENTs.DeleteOnSubmit(ux);
                    }
                    bx.SubmitChanges();

                }
                catch (Exception ex)
                {
                    throw new ArgumentException(
                                $"{ex.Message} ");
                }
            }
            //}
            return USERNO = item.USERNO;
        }

        private string UpdateData_Four(insert_Step_Four item)
        {
            string USERNO;

            using (Hr_RegisterDataContext bx = new Hr_RegisterDataContext())
            {
                try
                {
                    var Four = (from xx in bx.STEP_FOURs
                                         where xx.USERNO == item.USERNO
                                         select xx);
            
                    foreach (var ux in Four)
                    {
                        bx.STEP_FOURs.DeleteOnSubmit(ux);
                    }
            
                    bx.SubmitChanges();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(
                                $"{ex.Message} ");
                }
            }

            return USERNO = item.USERNO;
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