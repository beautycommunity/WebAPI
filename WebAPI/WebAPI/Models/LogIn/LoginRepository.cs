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
using WebAPI.DATA.dbMasIT;

namespace WebAPI.Models.LogIn
{
    public class LoginRepository : ILoginRepository
    {
        [HttpPost]
        [ActionName("APILogin")]
        public IEnumerable<RetName> APILogin(DataUser data)
        {
            List<RetName> results = new List<RetName>();
            try
            {
                using (LoginMainDataContext Context = new LoginMainDataContext())
                {
                    var sql = (from xx in Context.MAS_USER_SYSTEMs
                               where xx.STCODE == data.STCODE
                               && xx.PASS == data.PASS
                              // where xx.STCODE == "8063"
                              //&& xx.PASS == "8063"
                              select xx).FirstOrDefault();
                    int Status;
                    RetName res = new RetName();

                    if (sql != null)
                    {
                        Status = 1;
                        res.status = "S";
                        res.STCODE = sql.STCODE;
                        res.FULLNAME = sql.FULLNAME;
                        res.NICKNAME = sql.NICKNAME;
                        res.FULLNAME_EN = sql.FULLNAME_EN;
                        res.EMAIL = sql.EMAIL;
                        res.DPCODE = sql.DPCODE;
                        res.DPNAME = sql.DPNAME;
                    }
                    else
                    {
                        Status = 2;
                        res.status = "F";
                    }

                    if (Status == 1)
                    {
                        res.message = "Login success";         
                    }
                    else if (Status == 2)
                    {
                        res.message = "Loing Error";
                    }
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
        //[ActionName("APILogin")]
        //public IEnumerable<RetName> SeleteUser(DataUser item)
        //{
        //    List<RetName> results = new List<RetName>();

        //    try
        //    {
        //        string USERNO;
        //        int Status;
        //        if (item._USERNO == null)
        //        {
        //            USERNO = InsertData_One(item);
        //            Status = 1;
        //        }
        //        else
        //        {
        //            USERNO = UpdateData_One(item);
        //            USERNO = InsertData_One(item);
        //            Status = 2;
        //        }

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
    }
}