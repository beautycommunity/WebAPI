using ClosedXML.Excel;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebAPI.DATA.HR_SALE;

namespace WebAPI.Models.HR_SALE
{
    public class HR_SALERepository : IHR_SALE
    {
        [HttpPost]
        [ActionName("IndexHrSale")]
        public IEnumerable<Detail> IndexHrSale(user data)
        {
            List<Detail> results = new List<Detail>();

            try
            {
                Detail value = new Detail();

                using (HR_SALEDataContext db = new HR_SALEDataContext())
                {

                    var q = (from xx in db.MAS_USER_SYSTEMs
                             where xx.STCODE == data.User
                             && xx.PASS == data.Password
                             && xx.FLAG != 99
                             select xx).FirstOrDefault();

                    if (q == null)
                    {
                        value.Error = "null";
                        //return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        value.User = data.User;
                        value.FULLNAME = q.FULLNAME + ':' + ' ' + q.STCODE;

                        if (q.POSITION == "")
                        {
                            value.Error = "POSITION";
                            value.STCODE = q.STCODE;
                            //return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            var check = (from xx in db.HR_SALE_USERs
                                         where xx.STCODE == data.User
                                         select xx).FirstOrDefault();

                            if (check == null)
                            {
                                db.HR_SALE_ADDUSER(data.User);
                            }

                            //return RedirectToAction("Main", "Employee");
                        }
                    }
                }
                results.Add(value);
            }
            catch (Exception ex)
            {
                Detail res = new Detail();
                res.status = "F";
                res.message = ex.Message;
                results.Add(res);
            }

            return results.ToArray();
        }

        [HttpPost]
        [ActionName("AddPosition")]
        public IEnumerable<Detail> AddPosition(Detail data)
        {
            List<Detail> results = new List<Detail>();

            try
            {
                //Detail valus = new Detail();

                using (HR_SALEDataContext db = new HR_SALEDataContext())
                {
                    var str = (from xx in db.MAS_USER_SYSTEMs
                               where xx.STCODE == data.STCODE
                               select xx).FirstOrDefault();
                    str.POSITION = data.DROPDOWN;
                    db.SubmitChanges();

                    var check = (from xx in db.HR_SALE_USERs
                                 where xx.STCODE == data.STCODE
                                 select xx).FirstOrDefault();

                    if (check == null)
                    {
                        db.HR_SALE_ADDUSER(data.STCODE);
                    }
                }

                //results.Add(value);
            }
            catch (Exception ex)
            {
                Detail res = new Detail();
                res.status = "F";
                res.message = ex.Message;
                results.Add(res);
            }

            return results.ToArray();
        }

        [HttpPost]
        [ActionName("Main")]
        public IEnumerable<ShowProduct> Main(HR_DATA data)
        {
            List<ShowProduct> results = new List<ShowProduct>();

            try
            {
                ShowProduct getvalue = new ShowProduct();

                using (HR_SALEDataContext db = new HR_SALEDataContext())
                {
                    var sql = db.VW_SHOW_PRODUCTs.Where(F => F.STCODE == data.USERONLINE).OrderBy(F => F.PTDATE);

                    var q = db.HR_SALE_GETUSER(data.USERONLINE).FirstOrDefault();

                    getvalue.Bal = q.CBal;
                    getvalue.Total = q.CTotal;
                    getvalue.NET = q.ABal;

                    foreach (var ux in sql)
                    {
                        ShowProduct.SProduct mp = new ShowProduct.SProduct();

                        mp.S_MPCODE = ux.MPCODE;
                        mp.S_ABBNO = ux.ABBNO;
                        mp.S_MPNAME = ux.MPNAME;
                        mp.S_PRICE = ux.CPRICE;
                        mp.PRICE = ux.SPRICE;
                        mp.S_DATE = ux.CDATE;
                        mp.QTY = ux.QTY.ToString();

                        getvalue.Ans_SProduct.Add(mp);
                        //lstMP.Add(mp);
                    }
                }
                results.Add(getvalue);
            }
            catch (Exception ex)
            {
                //Detail res = new Detail();
                //res.status = "F";
                //res.message = ex.Message;
                //results.Add(res);
            }

            return results.ToArray();
        }

        [HttpPost]
        [ActionName("Change_now")]
        public IEnumerable<Detail> Change_now(ShowProduct data)
        {
            List<Detail> results = new List<Detail>();

            try
            {
                Detail value = new Detail(); 

                if (data.ch_QTY <= 0)
                {
                    value.Error = "QTY";
                    //TempData["QTY"] = "false";
                    //return RedirectToAction("Main", "Employee");
                }
                else
                {
                    int price = Convert.ToInt32(Convert.ToDouble(data.ch_PRICE));
                    int ch_price = data.ch_QTY * price;

                    using (HR_SALEDataContext db = new HR_SALEDataContext())
                    {
                        var ss = db.HR_SALE_GetBal(data.ch_USER).FirstOrDefault();
                        try
                        {
                            if (ss.NET + ch_price > ss.Total)
                            {
                                value.Error = "limit";
                                //TempData["limit"] = "false";
                                //return RedirectToAction("Main", "Employee");
                            }
                            else
                            {
                                //---------------------- HR_ChProduct ---------------//
                                var ch = (from xx in db.HR_SALE_PIs
                                          where xx.STCODE == data.ch_USER
                                          && xx.MPCODE == data.ch_MPCODE
                                          && xx.ABBNO == data.ch_ABBNO
                                          select xx).FirstOrDefault();

                                ch.QTY = data.ch_QTY;
                                ch.NET = ch_price;

                                db.SubmitChanges();

                                //----------------------------------------------------

                                var ss2 = db.HR_SALE_GetBal(data.ch_USER).FirstOrDefault();

                                //---------------------- HR_ChBal ---------------//

                                var USER = (from xx in db.HR_SALE_USERs
                                            where xx.STCODE == data.ch_USER
                                            select xx).FirstOrDefault();

                                USER.BAL = ss2.Total - ss2.NET;

                                db.SubmitChanges();

                                //----------------------------------------------------
                            }
                        }
                        catch
                        {

                        }
                    }
                }

                results.Add(value);
            }
            catch (Exception ex)
            {
                Detail res = new Detail();
                res.status = "F";
                res.message = ex.Message;
                results.Add(res);
            }

            return results.ToArray();
        }

        [HttpPost]
        [ActionName("Del_now")]
        public IEnumerable<Detail> Del_now(ShowProduct data)
        {
            List<Detail> results = new List<Detail>();

            try
            {
                Detail value = new Detail();

                using (HR_SALEDataContext db = new HR_SALEDataContext())
                {
                    //---------------------- HR_DelProduct ---------------//

                    var Del = (from xx in db.HR_SALE_PIs
                               where xx.STCODE == data.de_USER
                               && xx.ABBNO == data.de_ABBNO
                               && xx.MPCODE == data.de_MPCODE
                               select xx).FirstOrDefault();

                    db.HR_SALE_PIs.DeleteOnSubmit(Del);
                    db.SubmitChanges();

                    //----------------------------------------------------

                    var ss = db.HR_SALE_GetBal(data.de_USER).FirstOrDefault();

                    if (ss == null)
                    {
                        var ss2 = (from sale in db.HR_SALE_USERs
                                   where sale.STCODE == data.de_USER
                                   select sale).FirstOrDefault();

                        //---------------------- HR_ChBal ---------------//

                        var USER = (from xx in db.HR_SALE_USERs
                                    where xx.STCODE == data.de_USER
                                    select xx).FirstOrDefault();

                        USER.BAL = ss.Total - 0;

                        db.SubmitChanges();

                        //----------------------------------------------------
                    }
                    else
                    {
                        //---------------------- HR_ChBal ---------------//

                        var USER = (from xx in db.HR_SALE_USERs
                                    where xx.STCODE == data.de_USER
                                    select xx).FirstOrDefault();

                        USER.BAL = ss.Total - ss.NET;

                        db.SubmitChanges();

                        //----------------------------------------------------
                    }
                }

                results.Add(value);
            }
            catch (Exception ex)
            {
                Detail res = new Detail();
                res.status = "F";
                res.message = ex.Message;
                results.Add(res);
            }

            return results.ToArray();
        }

        [HttpPost]
        [ActionName("Setting")]
        public IEnumerable<Management> Setting(Input_Management data)
        {
            List<Management> results = new List<Management>();

            try
            {
                Management getvalue = new Management();

                using (HR_SALEDataContext db = new HR_SALEDataContext())
                {
                    if (data.Check == "1")
                    {
                        getvalue.S_User = data.User;
                        getvalue.S_PTDATE = data.PTDATE;
                        getvalue.S_ABBNO = data.ABBNO;
                        getvalue.S_FULLNAME = data.FULLNAME;
                        getvalue.S_QTY = data.QTY;
                        getvalue.S_NET = data.NET;

                        var sql_PT = (from xx in db.HR_SALE_PTs
                                      where xx.STCODE == data.User
                                      && xx.ABBNO == data.ABBNO
                                      select xx).FirstOrDefault();
                        getvalue.Detail = sql_PT.DETEIL;
                    }
                    else if (data.Check == "2")
                    {
                        getvalue.C_ABBNO = data.ABBNO;
                        getvalue.C_User = data.User;
                    }

                    var sql = db.HR_SALE_GetManagement();
                    foreach (var ux in sql)
                    {
                        Management.GetManagement mp = new Management.GetManagement();

                        mp.FULLNAME = ux.FULLNAME;
                        mp.ID_ST = ux.STCODE;
                        mp.ABBNO = ux.ABBNO;
                        mp.QTY = ux.QTY.ToString();
                        mp.NET = ux.NET;
                        mp.PTDATE = ux.PTDATE.ToString();
                        mp.FLAG = ux.FLAG.ToString();
                        mp.Dpcode = ux.DPCODE;

                        getvalue.AnsManagement.Add(mp);
                        //lstMP.Add(mp);
                    }

                    var sql2 = db.HR_SALE_ShowPI(data.User, data.ABBNO);

                    foreach (var ux in sql2)
                    {
                        Management.GetPro sp = new Management.GetPro();

                        sp.MPCODE = ux.MPCODE;
                        sp.MPNAME = ux.FULLNAME;
                        sp.QTY = ux.QTY.ToString();
                        //sp.DETAIL = ux.DETEIL;
                        //sp.row = Int32.Parse(ux.Row_.ToString());

                        getvalue.ShowManagement.Add(sp);
                        //lstMP.Add(mp);
                    }
                    //}

                    results.Add(getvalue);
                }
            }
            catch (Exception ex)
            {
                //Detail res = new Detail();
                //res.status = "F";
                //res.message = ex.Message;
                //results.Add(res);
            }

            return results.ToArray();
        }

        [HttpPost]
        [ActionName("SetEndDate")]
        public IEnumerable<SetPro> SetEndDate(Detail data)
        {
            List<SetPro> results = new List<SetPro>();

            try
            {
                SetPro getvalue = new SetPro();
                IQueryable<VW_USER_PRO> View_User;

                using (HR_SALEDataContext db = new HR_SALEDataContext())
                {
                    if (data.STCODE != null)
                    {
                        var sql = (from xx in db.VW_USER_PROs
                                   where xx.STCODE == data.STCODE
                                   select xx).FirstOrDefault();

                        getvalue.STCODE = sql.STCODE;
                        getvalue.FULLNAME = sql.FULLNAME;
                        getvalue.ENDDATE = sql.ENDDATE;
                        getvalue.ERROR = "ChPro";
                    }

                    View_User = db.VW_USER_PROs
                        .Where(tik => tik.STCODE.Contains(data.seach) || tik.DPCODE.Contains(data.seach) || tik.FULLNAME.Contains(data.seach) || tik.NICKNAME.Contains(data.seach));

                    foreach (var item in View_User)
                    {
                        SetPro.GetUser mp = new SetPro.GetUser();

                        mp.STCODE = item.STCODE;
                        mp.DEGREE = item.DEGREE;
                        mp.DPCODE = item.DPCODE;
                        mp.DPNAME = item.DPNAME;
                        mp.FULLNAME = item.FULLNAME;
                        mp.NICKNAME = item.NICKNAME;
                        mp.ENDDATE = item.ENDDATE;

                        getvalue.ShowUser.Add(mp);
                    }
                }

                results.Add(getvalue);
            }
            catch (Exception ex)
            {
                //Detail res = new Detail();
                //res.status = "F";
                //res.message = ex.Message;
                //results.Add(res);
            }

            return results.ToArray();
        }

        [HttpPost]
        [ActionName("ShowHistory")]
        public IEnumerable<Management> ShowHistory(Input_Management data)
        {
            List<Management> results = new List<Management>();

            try
            {
                Management getvalue = new Management();

                getvalue.U_User = data.User;
                getvalue.U_ABBNO = data.ABBNO;


                using (HR_SALEDataContext db = new HR_SALEDataContext())
                {

                    var sql = db.HR_SALE_ShowHistory(data.USERONLINE);
                    foreach (var ux in sql)
                    {
                        Management.GetManagement mp = new Management.GetManagement();

                        //mp.FULLNAME = ux.FULLNAME;
                        mp.ID_ST = ux.STCODE;
                        mp.ABBNO = ux.ABBNO;
                        mp.QTY = ux.QTY.ToString();
                        mp.NET = ux.NET;
                        mp.PTDATE = ux.WORKDATE.ToString();
                        mp.FLAG = ux.FLAG.ToString();
                        mp.Deteil = ux.DETEIL;

                        getvalue.AnsManagement.Add(mp);
                        //lstMP.Add(mp);
                    }

                    var sql2 = db.HR_SALE_ShowPI(data.USERONLINE, data.ABBNO);

                    foreach (var ux in sql2)
                    {
                        Management.GetPro sp = new Management.GetPro();

                        sp.MPCODE = ux.MPCODE;
                        sp.MPNAME = ux.FULLNAME;
                        sp.QTY = ux.QTY.ToString();
                        sp.DETAIL = ux.DETEIL;
                        sp.row = Int32.Parse(ux.Row_.ToString());

                        getvalue.ShowManagement.Add(sp);
                        //lstMP.Add(mp);
                    }
                }

                results.Add(getvalue);
            }
            catch (Exception ex)
            {
                //Detail res = new Detail();
                //res.status = "F";
                //res.message = ex.Message;
                //results.Add(res);
            }

            return results.ToArray();
        }

        [HttpPost]
        [ActionName("LVL")]
        public IEnumerable<lvl> LVL(Inputlvl data)
        {
            List<lvl> results = new List<lvl>();

            try
            {
                lvl getvalue = new lvl();

                getvalue.CH_LVLNAME = data.LVLNAME;
                getvalue.CH_SECTION = data.SECTION;
                getvalue.C_NET = data.NET;
                getvalue.NEW_NET = data.NET;
                getvalue.NEW_NET_CB = data.CNET;

                using (HR_SALEDataContext db = new HR_SALEDataContext())
                {
                    var sql = (from xx in db.HR_LVLs
                               select xx);

                    foreach (var item in sql)
                    {
                        lvl.Getlvl mp = new lvl.Getlvl();

                        mp.LVLNAME = item.LVL;
                        mp.SECTION = item.SECTION;
                        mp.CNET = item.CBAL.ToString();
                        mp.NET = item.BAL.ToString();

                        getvalue.Showlvl.Add(mp);
                    }
                }

                results.Add(getvalue);
            }
            catch (Exception ex)
            {
                //Detail res = new Detail();
                //res.status = "F";
                //res.message = ex.Message;
                //results.Add(res);
            }

            return results.ToArray();
        }

        [HttpPost]
        [ActionName("Ch_LVL_NOW")]
        public IEnumerable<Detail> Ch_LVL_NOW(lvl data)
        {
            List<Detail> results = new List<Detail>();

            try
            {
                Detail getvalue = new Detail();

                using (HR_SALEDataContext db = new HR_SALEDataContext())
                {
                    var sql = (from xx in db.HR_LVLs
                               where xx.LVL == data.CH_LVLNAME
                               && xx.SECTION == data.CH_SECTION
                               select xx).FirstOrDefault();
                    int Set_Net = Convert.ToInt32(Convert.ToDouble(data.NEW_NET));
                    int Set_Net_CB = Convert.ToInt32(Convert.ToDouble(data.NEW_NET_CB));
                    sql.BAL = Set_Net;
                    sql.CBAL = Set_Net_CB;

                    db.SubmitChanges();
                }

                results.Add(getvalue);
            }
            catch (Exception ex)
            {
                Detail res = new Detail();
                res.status = "F";
                res.message = ex.Message;
                results.Add(res);
            }

            return results.ToArray();
        }

        [HttpPost]
        [ActionName("SetPass")]
        public IEnumerable<Detail> SetPass(user data)
        {
            List<Detail> results = new List<Detail>();

            try
            {
                Detail getvalue = new Detail();

                using (HR_SALEDataContext db = new HR_SALEDataContext())
                {
                    if (data.New_Password != null && data.Confirm_Password != null && data.Old_Password != null)
                    {
                        var pass = (from xx in db.MAS_USER_SYSTEMs
                                    where xx.STCODE == data.USERONLINE
                                    select xx).FirstOrDefault();

                        if (pass.PASS != data.Old_Password)
                        {
                            getvalue.Error = "Oldpass";
                            //TempData["Oldpass"] = "pass";
                            //return RedirectToAction("ChPass", "Employee");
                        }
                        else
                        {
                            if (data.New_Password != data.Confirm_Password)
                            {
                                getvalue.Error = "pass";
                                //TempData["pass"] = "pass";
                                //return RedirectToAction("ChPass", "Employee");
                            }
                            else
                            {

                                var sql = (from xx in db.MAS_USER_SYSTEMs
                                           where xx.STCODE == data.USERONLINE
                                           select xx).FirstOrDefault();
                                sql.PASS = data.New_Password;
                                db.SubmitChanges();

                                getvalue.Error = "chpass";
                                //Logout();
                            }
                        }
                    }
                }

                results.Add(getvalue);
            }
            catch (Exception ex)
            {
                Detail res = new Detail();
                res.status = "F";
                res.message = ex.Message;
                results.Add(res);
            }

            return results.ToArray();
        }

        [HttpPost]
        [ActionName("Deteil")]
        public IEnumerable<Detail> Deteil(Management data)
        {
            List<Detail> results = new List<Detail>();

            try
            {
                Detail getvalue = new Detail();

                using (HR_SALEDataContext db = new HR_SALEDataContext())
                {
                    var a = data.ShowManagement.FirstOrDefault();
                    var sql = (from xx in db.HR_SALE_PTs
                               where xx.STCODE == data.User
                               && xx.ABBNO == data.ABB
                               select xx).FirstOrDefault();
                    sql.DETEIL = data.Detail;

                    db.SubmitChanges();
                }

                results.Add(getvalue);
            }
            catch (Exception ex)
            {
                Detail res = new Detail();
                res.status = "F";
                res.message = ex.Message;
                results.Add(res);
            }

            return results.ToArray();
        }

      
        [HttpPost]
        [ActionName("Ch_Pro")]
        public IEnumerable<Detail> Ch_Pro(Detail data)
        {
            List<Detail> results = new List<Detail>();

            try
            {
                Detail getvalue = new Detail();

                using (HR_SALEDataContext db = new HR_SALEDataContext())
                {
                    var sql = (from xx in db.MAS_USER_SYSTEMs
                               where xx.STCODE == data.STCODE
                               select xx).FirstOrDefault();
                    
                    sql.ENDDATE = data.dateofbirth.AddYears(543);
                    db.SubmitChanges();
                }

                results.Add(getvalue);
            }
            catch (Exception ex)
            {
                Detail res = new Detail();
                res.status = "F";
                res.message = ex.Message;
                results.Add(res);
            }

            return results.ToArray();
        }

        [HttpPost]
        [ActionName("Setting_ALL")]
        public IEnumerable<Management_All> Setting_ALL()
        {
            List<Management_All> results = new List<Management_All>();

            try
            {
                Management_All getvalue = new Management_All();

                using (HR_SALEDataContext db = new HR_SALEDataContext())
                {
                    var sql = db.HR_SALE_GetALLManagement();
                    foreach (var ux in sql)
                    {
                        Management_All.GetManagementAll mp = new Management_All.GetManagementAll();

                        mp.MPCODE = ux.MPCODE;
                        mp.MPNAME = ux.ABBNAME;
                        mp.QTY = ux.SUM.ToString();

                        getvalue.AnsManagementAll.Add(mp);
                        //lstMP.Add(mp);
                    }
                }
                results.Add(getvalue);
            }
            catch (Exception ex)
            {
                //Detail res = new Detail();
                //res.status = "F";
                //res.message = ex.Message;
                //results.Add(res);
            }

            return results.ToArray();
        }

        [HttpPost]
        [ActionName("BuyProduct")]
        public IEnumerable<Product> BuyProduct(Detail data)
        {
            List<Product> results = new List<Product>();

            try
            {
                Product getvalue = new Product();

                getvalue.Get_MPCODE = data.GET_MPCODE;
                getvalue.Get_MPNAME = data.GET_MPNAME;
                getvalue.Get_PRICE = data.GET_PRICE;
                getvalue.Get_USER = data.GET_USER;
                //getvalue.QTY = 'A';

                //if (data.GET_MPCODE != null)
                //{
                //    data.seach = data.GET_MPCODE;
                //}

                using (Mona77DataContext db = new Mona77DataContext())
                {
                    var sql = db.PP_GET_HR_MP(data.seach);

                    foreach (var ux in sql)
                    {
                        Product.GetProduct mp = new Product.GetProduct();

                        mp.MPCODE = ux.CODE;
                        mp.MPNAME = ux.NAMETH;
                        mp.PRICE = ux.PRICE;
                        mp.MAXPRICE = ux.MAXPRICE;

                        getvalue.AnsProduct.Add(mp);
                    }
                }

                results.Add(getvalue);
            }
            catch (Exception ex)
            {
                //Detail res = new Detail();
                //res.status = "F";
                //res.message = ex.Message;
                //results.Add(res);
            }

            return results.ToArray();
        }

        [HttpPost]
        [ActionName("SetProduct")]
        public IEnumerable<Detail> SetProduct(Product data)
        {
            List<Detail> results = new List<Detail>();

            try
            {
                Detail value = new Detail();

                if (data.QTY <= 0)
                {
                    value.Error = "QTY";
                    //return RedirectToAction("BuyProduct", "Employee");
                }
                else
                {
                    using (HR_SALEDataContext db = new HR_SALEDataContext())
                    {
                        var q = (from xx in db.HR_SALE_PIs
                                 where xx.STCODE == data.Get_USER
                                 select xx).OrderByDescending(xx => xx.ABBNO).FirstOrDefault();

                        value.q = q;

                        if (q == null)
                        {
                            int Set_QTY = data.QTY;
                            var Set_USER = data.Get_USER;
                            int Set_PRICE = Convert.ToInt32(Convert.ToDouble(data.Get_PRICE));
                            var Set_MPCODE = data.Get_MPCODE;
                            var ABB = "00001";
                            int NET = Set_QTY * Set_PRICE;
                            DateTime Get_date = DateTime.Now;
                            DateTime Get_today = DateTime.Today;

                            using (HR_SALEDataContext db2 = new HR_SALEDataContext())
                            {
                                //var ss = db2.HR_GetBal(Set_USER).FirstOrDefault();
                                var ss = (from sale in db2.HR_SALE_USERs
                                          where sale.STCODE == data.Get_USER
                                          select sale).FirstOrDefault();
                                if (NET > ss.TOTAL)
                                {
                                    value.Error = "limit";
                                    //return RedirectToAction("Main", "Employee");
                                }
                                else
                                {
                                    //---------------------- HR_GetProduct ---------------//
                                    var ux = new HR_SALE_PI();

                                    ux.STCODE = Set_USER;
                                    ux.ABBNO = ABB;
                                    ux.MPCODE = Set_MPCODE;
                                    ux.QTY = Set_QTY;
                                    ux.PRICE = Set_PRICE;
                                    ux.NET = NET;
                                    ux.PTDATE = Get_date;
                                    ux.WORKDATE = Get_today;
                                    ux.FLAG = 0;

                                    db2.HR_SALE_PIs.InsertOnSubmit(ux);

                                    //----------------------------------------------------


                                    //---------------------- HR_ChBal ---------------//

                                    var USER = (from xx in db2.HR_SALE_USERs
                                                where xx.STCODE == Set_USER
                                                select xx).FirstOrDefault();

                                    USER.BAL = ss.TOTAL - NET;

                                    db2.SubmitChanges();

                                    //----------------------------------------------------
                                }
                            }
                        }
                        else
                        {
                            var c = (from xx in db.HR_SALE_PIs
                                     where xx.STCODE == data.Get_USER
                                     && xx.MPCODE == data.Get_MPCODE
                                     && xx.FLAG == 0
                                     select xx);

                            if (c.Count() > 0)
                            {
                                value.Error = "check";
                                //return RedirectToAction("Main", "Employee");
                            }
                            else
                            {
                                value.q_FLAG = q.FLAG;
                                if (q.FLAG == 0)
                                {
                                    int Set_QTY = data.QTY;
                                    var Set_USER = data.Get_USER;
                                    int Set_PRICE = Convert.ToInt32(Convert.ToDouble(data.Get_PRICE));
                                    var Set_MPCODE = data.Get_MPCODE;
                                    var ABB = q.ABBNO;
                                    int NET = Set_QTY * Set_PRICE;
                                    DateTime Get_date = DateTime.Now;
                                    DateTime Get_today = DateTime.Today;

                                    using (HR_SALEDataContext db2 = new HR_SALEDataContext())
                                    {
                                        var ss = db2.HR_SALE_GetBal(Set_USER).FirstOrDefault();

                                        if (ss.NET + NET > ss.Total)
                                        {
                                            value.Error = "limit";
                                            //return RedirectToAction("Main", "Employee");
                                        }
                                        else
                                        {
                                            //---------------------- HR_GetProduct ---------------//
                                            var ux = new HR_SALE_PI();

                                            ux.STCODE = Set_USER;
                                            ux.ABBNO = ABB;
                                            ux.MPCODE = Set_MPCODE;
                                            ux.QTY = Set_QTY;
                                            ux.PRICE = Set_PRICE;
                                            ux.NET = NET;
                                            ux.PTDATE = Get_date;
                                            ux.WORKDATE = Get_today;
                                            ux.FLAG = 0;

                                            db2.HR_SALE_PIs.InsertOnSubmit(ux);
                                            db2.SubmitChanges();

                                            //----------------------------------------------------

                                            var ss2 = db2.HR_SALE_GetBal(Set_USER).FirstOrDefault();

                                            //---------------------- HR_ChBal ---------------//

                                            var USER = (from xx in db2.HR_SALE_USERs
                                                        where xx.STCODE == Set_USER
                                                        select xx).FirstOrDefault();

                                            USER.BAL = ss.Total - ss2.NET;

                                            db2.SubmitChanges();

                                            //----------------------------------------------------
                                        }
                                    }
                                }
                                else if (q.FLAG == 1 || q.FLAG == 2)
                                {
                                    //var a = "00001";
                                    //var b = intval();
                                    int intTostr = Convert.ToInt32(Convert.ToDouble(q.ABBNO));
                                    int Plus = intTostr + 1;
                                    var New_ABBNO = Plus.ToString();
                                    for (int i = New_ABBNO.Length; i < 5; i++)
                                    {
                                        New_ABBNO = "0" + New_ABBNO;
                                    }

                                    int Set_QTY = data.QTY;
                                    var Set_USER = data.Get_USER;
                                    int Set_PRICE = Convert.ToInt32(Convert.ToDouble(data.Get_PRICE));
                                    var Set_MPCODE = data.Get_MPCODE;
                                    var ABB = New_ABBNO;

                                    int NET = Set_QTY * Set_PRICE;
                                    DateTime Get_date = DateTime.Now;
                                    DateTime Get_today = DateTime.Today;

                                    using (HR_SALEDataContext db2 = new HR_SALEDataContext())
                                    {
                                        var ss2 = (from sale in db.HR_SALE_USERs
                                                   where sale.STCODE == Set_USER
                                                   select sale).FirstOrDefault();

                                        //---------------------- HR_GetProduct ---------------//
                                        var ux = new HR_SALE_PI();

                                        ux.STCODE = Set_USER;
                                        ux.ABBNO = ABB;
                                        ux.MPCODE = Set_MPCODE;
                                        ux.QTY = Set_QTY;
                                        ux.PRICE = Set_PRICE;
                                        ux.NET = NET;
                                        ux.PTDATE = Get_date;
                                        ux.WORKDATE = Get_today;
                                        ux.FLAG = 0;

                                        db2.HR_SALE_PIs.InsertOnSubmit(ux);

                                        //----------------------------------------------------

                                        //---------------------- HR_ChBal ---------------//

                                        var USER = (from xx in db2.HR_SALE_USERs
                                                    where xx.STCODE == Set_USER
                                                    select xx).FirstOrDefault();

                                        USER.BAL = ss2.TOTAL - NET;

                                        db2.SubmitChanges();

                                        //----------------------------------------------------
                                    }
                                }
                            }
                        }
                    }

                    results.Add(value);
                }
            }
            catch (Exception ex)
            {
                //Detail res = new Detail();
                //res.status = "F";
                //res.message = ex.Message;
                //results.Add(res);
            }

            return results.ToArray();
        }


    }
}