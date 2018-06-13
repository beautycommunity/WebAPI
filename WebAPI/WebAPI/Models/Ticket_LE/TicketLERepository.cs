using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
//using System.Web.Http;
using System.Web.Mvc;
using WebAPI.DATA.TicketLE;
using WebAPI.DATA.TicketOP;

namespace WebAPI.Models.Ticket_LE
{
    public class TicketLERepository : ITicketLE
    {
        [HttpPost]
        [ActionName("Ticketlist")]
        public IEnumerable<Ticket> Ticketlist(Detail data)
        {
            List<Ticket> results = new List<Ticket>();

            try
            {
                IQueryable<DATA.TicketLE.VW_TICKET> View_Ticket;
                var seach = data.seach;
                var type = data.type;

                UserDataContext Con = new UserDataContext();
                TicketLEDataContext db = new TicketLEDataContext();

                List<Ticket> lstTicket = new List<Ticket>();

                var User = (from xx in Con.MAS_USERs
                            where xx.STCODE == data.STCODE
                            select xx).FirstOrDefault();

                using (TicketLEDataContext Context = new TicketLEDataContext())
                {
                    View_Ticket = Context.VW_TICKETs.Where(s => s.TICKETNO.Contains(seach) || s.DPCODE.Contains(seach) || s.NICKNAME.Contains(seach)).Where(s => s.FLAG == "1").OrderBy(s => s.STATUS);

                    if (type != "")
                    {
                        View_Ticket = View_Ticket.Where(tik => tik.STATUS == type);
                    }

                    if (User.D_ID != 10)
                    {
                        View_Ticket = View_Ticket.Where(s => s.STCODE == data.STCODE);

                        foreach (var item in View_Ticket)
                        {
                            Ticket ux = new Ticket();

                            ux.ID = item.ID;
                            ux.TICKETNO = item.TICKETNO;
                            ux.DETAIL = item.DETEIL;
                            ux.CREATEDATE = DateTime.Parse(item.WORKDATE.ToString()).ToShortDateString();
                            ux.CREATETIME = DateTime.Parse(item.WORKDATE.ToString()).ToLongTimeString();
                            ux.CRE_NICKNAME = item.NICKNAME;
                            ux.DEP = item.DPCODE;
                            ux.SSID = Int32.Parse(item.STATUS);
                            ux.SSNAME = item.SS_NAME;

                            lstTicket.Add(ux);
                        }
                    }
                    else
                    {
                        if (User.A_ID == 3)
                        {
                            View_Ticket = View_Ticket.Where(s => s.STCODE == data.STCODE);
                        }
                        else
                        {
                            View_Ticket = View_Ticket.Where(s => s.APPROVE_ID >= 2);
                        }

                        foreach (var item in View_Ticket)
                        {
                            Ticket ux = new Ticket();

                            ux.ID = item.ID;
                            ux.TICKETNO = item.TICKETNO;
                            ux.DETAIL = item.DETEIL;
                            ux.CREATEDATE = DateTime.Parse(item.WORKDATE.ToString()).ToShortDateString();
                            ux.CREATETIME = DateTime.Parse(item.WORKDATE.ToString()).ToLongTimeString();
                            ux.CRE_NICKNAME = item.NICKNAME;
                            ux.DEP = item.DPCODE;
                            ux.SSID = Int32.Parse(item.STATUS);
                            ux.SSNAME = item.SS_NAME;

                            lstTicket.Add(ux);
                        }
                    }
                    results = lstTicket;
                }
            }
            catch (Exception ex)
            {
                //AnsOP res = new AnsOP();
                //res.status = "F";
                //res.message = ex.Message;
                //results.Add(res);
            }

            return results.ToArray();
        }

        [HttpPost]
        [ActionName("TicketDetail")]
        public IEnumerable<TicketModels> TicketDetail(TicketModels data)
        {
            List<TicketModels> results = new List<TicketModels>();

            try
            {
                TicketModels valus = new TicketModels();

                UserDataContext Con = new UserDataContext();

                var User = (from xx in Con.MAS_USERs
                            where xx.STCODE == data.STCODE
                            select xx).FirstOrDefault();

                valus.DP = User.D_ID;
                valus.A_ID = User.A_ID;
                valus.Back = data.Url;

                using (TicketLEDataContext Context = new TicketLEDataContext())
                {
                    var Main = (from xx in Context.VW_TICKETs
                                where xx.ID == data.TicketId
                                select xx).FirstOrDefault();

                    var Sub = (from xx in Context.TASK_SUBs
                               join yy in Context.MAS_DOCs on xx.DOC_ID equals yy.DOC_ID
                               where xx.LE_ID == data.TicketId
                               orderby xx.DETEIL_SUB
                               select new { xx, yy });

                    List<CheckBox> lstSub = new List<CheckBox>();

                    int row = 1;
                    foreach (var item in Sub)
                    {
                        CheckBox ux = new CheckBox();

                        ux.row = row;
                        ux.Doc = item.yy.DOC_NAME;
                        ux.NAME = item.xx.DETEIL_SUB;
                        ux.Type = item.yy.TYPE;

                        lstSub.Add(ux);
                        row++;
                    }

                    valus.Detail = lstSub;

                    Ticket lis = new Ticket();

                    lis.TICKETNO = Main.TICKETNO;
                    lis.DETAIL = Main.DETEIL;
                    lis.CREATEDATE = DateTime.Parse(Main.WORKDATE.ToString()).ToShortDateString();
                    lis.CREATETIME = DateTime.Parse(Main.WORKDATE.ToString()).ToLongTimeString();
                    lis.CRE_NICKNAME = Main.NICKNAME;
                    lis.DEP = Main.DPCODE;
                    lis.SSID = Int32.Parse(Main.STATUS);
                    lis.SSNAME = Main.SS_NAME;
                    lis.NAME_OPEN = Main.FNAME + " " + Main.LNAME;
                    lis.DATE_OPEN = DateTime.Parse(Main.WORKDATE.ToString()).ToShortDateString();
                    lis.NAME_HDEP = Main.HDEP_NAME;

                    if (Main.HDEP_DATE != null)
                    {
                        lis.DATE_HDEP = DateTime.Parse(Main.HDEP_DATE.ToString()).ToShortDateString();
                    }

                    lis.NAME_RECEIVE = Main.RECEIVE_NAME;
                    if (Main.RECEIVE_DATE != null)
                    {
                        lis.DATE_RECEIVE = DateTime.Parse(Main.RECEIVE_DATE.ToString()).ToShortDateString();
                    }

                    lis.NAME_CLOSE = Main.CLOSE_NAME;
                    if (Main.CLOSE_DATE != null)
                    {
                        lis.DATE_CLOSE = DateTime.Parse(Main.CLOSE_DATE.ToString()).ToShortDateString();
                    }

                    lis.APP_ID = Main.APPROVE_ID;
                    valus.TicketSub = lis;

                }
                results.Add(valus);
            }
            catch (Exception ex)
            {
                //AnsOP res = new AnsOP();
                //res.status = "F";
                //res.message = ex.Message;
                //results.Add(res);
            }

            return results.ToArray();
        }

        [HttpPost]
        [ActionName("CreateTicketShow")]
        public IEnumerable<TicketModels> CreateTicketShow()
        {
            List<TicketModels> results = new List<TicketModels>();

            try
            {
                TicketModels valus = new TicketModels();

                using (TicketLEDataContext Context = new TicketLEDataContext())
                {
                    var sql = (from xx in Context.MAS_DOCs
                               orderby xx.TYPE
                               select xx);

                    List<CheckBox> list = new List<CheckBox>();

                    //ViewBag.Count = sql.Count();
                    //ViewBag.Check = ViewBag.Count / 2;

                    foreach (var item in sql)
                    {
                        CheckBox ux = new CheckBox();
                        ux.ID = item.DOC_ID;
                        ux.Doc = item.DOC_NAME;
                        ux.Type = item.TYPE;

                        list.Add(ux);
                    }

                    valus.GetCheck = list;
                }
                results.Add(valus);
            }
            catch (Exception ex)
            {
                //AnsOP res = new AnsOP();
                //res.status = "F";
                //res.message = ex.Message;
                //results.Add(res);
            }

            return results.ToArray();
        }

        [HttpPost]
        [ActionName("CreateTicket")]
        public IEnumerable<Detail> CreateTicket(TicketModels newItem)
        {
            List<Detail> results = new List<Detail>();

            try
            {
                string tketNo = ticketNo();

                using (TicketLEDataContext Context = new TicketLEDataContext())
                {
                    TASK_MAIN Insert_Main = new TASK_MAIN();

                    Insert_Main.TICKETNO = tketNo;
                    Insert_Main.DETEIL = newItem.Add.Detail;
                    Insert_Main.WORKDATE = DateTime.Now;
                    Insert_Main.STCODE = newItem.STCODE;
                    Insert_Main.STATUS = "1";
                    Insert_Main.FLAG = "1";
                    Insert_Main.APPROVE_ID = 1;

                    Context.TASK_MAINs.InsertOnSubmit(Insert_Main);
                    Context.SubmitChanges();

                    var sql = (from xx in Context.TASK_MAINs
                               where xx.TICKETNO == tketNo
                               select xx).FirstOrDefault();

                    var doc = from xx in Context.MAS_DOCs
                              select xx;
                    int i = 0;
                    foreach (var item in doc)
                    {
                        TASK_SUB Insert_Sub = new TASK_SUB();

                        if (newItem.GetCheck[i].Checked == true)
                        {
                            Insert_Sub.LE_ID = sql.ID;
                            Insert_Sub.DOC_ID = newItem.GetCheck[i].ID;
                            Insert_Sub.DETEIL_SUB = newItem.GetCheck[i].NAME;

                            Context.TASK_SUBs.InsertOnSubmit(Insert_Sub);
                            Context.SubmitChanges();
                        }
                        i++;
                    }
                }
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
        [ActionName("Print")]
        public IEnumerable<TicketModels> Print(TicketModels newItem)
        {
            List<TicketModels> results = new List<TicketModels>();

            try
            {
                TicketModels valus = new TicketModels();

                UserDataContext Con = new UserDataContext();

                var User = (from xx in Con.MAS_USERs
                            join yy in Con.MAS_DEPs on xx.D_ID equals yy.DP_ID
                            where xx.STCODE == newItem.STCODE
                            select new { xx, yy }).FirstOrDefault();

                newItem.DP = User.xx.D_ID;
                newItem.DPNAME = User.yy.DPCODE;
                newItem.FULLNAME = User.xx.FNAME + " " + User.xx.LNAME;

                using (TicketLEDataContext Context = new TicketLEDataContext())
                {
                    var Main = (from xx in Context.VW_TICKETs
                                where xx.ID == newItem.TicketId
                                select xx).FirstOrDefault();

                    var Sub = (from xx in Context.TASK_SUBs
                               join yy in Context.MAS_DOCs on xx.DOC_ID equals yy.DOC_ID
                               where xx.LE_ID == newItem.TicketId
                               orderby xx.DETEIL_SUB
                               select new { xx, yy });

                    List<CheckBox> lstSub = new List<CheckBox>();

                    int row = 1;
                    foreach (var item in Sub)
                    {
                        CheckBox ux = new CheckBox();

                        ux.row = row;
                        ux.Doc = item.yy.DOC_NAME;
                        ux.NAME = item.xx.DETEIL_SUB;
                        ux.Type = item.yy.TYPE;

                        lstSub.Add(ux);
                        row++;
                    }

                    valus.Detail = lstSub;

                    Ticket lis = new Ticket();

                    lis.TICKETNO = Main.TICKETNO;
                    lis.DETAIL = Main.DETEIL;
                    lis.CREATEDATE = DateTime.Parse(Main.WORKDATE.ToString()).ToShortDateString();
                    lis.CREATETIME = DateTime.Parse(Main.WORKDATE.ToString()).ToLongTimeString();
                    lis.CRE_NICKNAME = Main.NICKNAME;
                    lis.DEP = Main.DPCODE;
                    lis.SSID = Int32.Parse(Main.STATUS);
                    lis.SSNAME = Main.SS_NAME;
                    lis.NAME_OPEN = Main.FNAME + " " + Main.LNAME;
                    lis.DATE_OPEN = DateTime.Parse(Main.WORKDATE.ToString()).ToShortDateString();
                    lis.NAME_HDEP = Main.HDEP_NAME;

                    if (Main.HDEP_DATE != null)
                    {
                        lis.DATE_HDEP = DateTime.Parse(Main.HDEP_DATE.ToString()).ToShortDateString();
                    }

                    lis.NAME_RECEIVE = Main.RECEIVE_NAME;
                    if (Main.RECEIVE_DATE != null)
                    {
                        lis.DATE_RECEIVE = DateTime.Parse(Main.RECEIVE_DATE.ToString()).ToShortDateString();
                    }

                    lis.NAME_CLOSE = Main.CLOSE_NAME;
                    if (Main.CLOSE_DATE != null)
                    {
                        lis.DATE_CLOSE = DateTime.Parse(Main.CLOSE_DATE.ToString()).ToShortDateString();
                    }

                    valus.TicketSub = lis;
                }

                valus.TicNo = newItem.TicketId;

                results.Add(valus);
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
        [ActionName("ApproveTicket")]
        public IEnumerable<TicketModels> ApproveTicket(Detail data)
        {
            List<TicketModels> results = new List<TicketModels>();

            try
            {
                IQueryable<WebAPI.DATA.TicketLE.VW_TICKET> View_Ticket;
                var seach = data.seach;
                var type = data.type;

                UserDataContext Con = new UserDataContext();
                TicketLEDataContext db = new TicketLEDataContext();

                TicketModels value = new TicketModels();

                //value.Type = new SelectList(db.MAS_SSes, "SS_ID", "SS_NAME");

                var User = (from xx in Con.MAS_USERs
                            join yy in Con.MAS_DEPs on xx.D_ID equals yy.DP_ID
                            where xx.STCODE == data.STCODE
                            select new { xx, yy }).FirstOrDefault();

                //value.DP = User.xx.D_ID;

                using (TicketLEDataContext Context = new TicketLEDataContext())
                {
                    View_Ticket = Context.VW_TICKETs.Where(s => s.TICKETNO.Contains(seach) || s.DPCODE.Contains(seach) || s.NICKNAME.Contains(seach)).Where(s => s.STATUS == "1").Where(s => s.FLAG == "1").Where(s => s.APPROVE_ID == 1).Where(s => s.DPCODE == User.yy.DPCODE).OrderBy(s => s.STATUS);

                    List<Ticket> ticketsAns = new List<Ticket>();

                    foreach (var item in View_Ticket)
                    {
                        Ticket ux = new Ticket();

                        ux.ID = item.ID;
                        ux.TICKETNO = item.TICKETNO;
                        ux.DETAIL = item.DETEIL;
                        ux.CREATEDATE = DateTime.Parse(item.WORKDATE.ToString()).ToShortDateString();
                        ux.CREATETIME = DateTime.Parse(item.WORKDATE.ToString()).ToLongTimeString();
                        ux.CRE_NICKNAME = item.NICKNAME;
                        ux.DEP = item.DPCODE;
                        ux.SSID = Int32.Parse(item.STATUS);
                        ux.SSNAME = item.SS_NAME;

                        ticketsAns.Add(ux);
                    }

                    value.TicketDetail = ticketsAns;
                }

                //value.WordSearch = seach;
                //value.typeSearch = type;

                results.Add(value);
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
        [ActionName("Approve")]
        public IEnumerable<Detail> Approve(Detail data)
        {
            List<Detail> results = new List<Detail>();

            try
            {
                UserDataContext Con = new UserDataContext();
                var User = (from xx in Con.MAS_USERs
                            join yy in Con.MAS_DEPs on xx.D_ID equals yy.DP_ID
                            where xx.STCODE == data.STCODE
                            select new { xx, yy }).FirstOrDefault();

                using (TicketLEDataContext Context = new TicketLEDataContext())
                {
                    var insert_Approve = Context.TASK_MAINs.Where(s => s.ID == data.Ticket_ID).FirstOrDefault();

                    insert_Approve.HDEP_NAME = User.xx.FNAME + " " + User.xx.LNAME;
                    insert_Approve.HDEP_DATE = DateTime.Now;
                    insert_Approve.APPROVE_ID = 2;
                    Context.SubmitChanges();
                }
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
        [ActionName("Manage_Partial")]
        public IEnumerable<ListUserLogin> Manage_Partial(Detail data)
        {
            List<ListUserLogin> results = new List<ListUserLogin>();

            try
            {
                ListUserLogin value = new ListUserLogin();

                UserDataContext DropD = new UserDataContext();
                var dep = (from xx in DropD.MAS_USER_As
                           orderby xx.US_ID
                           select xx).GroupBy(x => x.ANAME).Select(grp => grp.First());

                //value.Dep = new SelectList(dep, "US_ID", "ANAME");

                var sh = data.sh;

                using (UserDataContext Context = new UserDataContext())
                {
                    IQueryable<VW_USER_FOR_LE> DataUser;
                    DataUser = Context.VW_USER_FOR_LEs;

                    if (sh.Length > 0)
                    {
                        DataUser = DataUser.Where(x => x.STCODE.Contains(sh) || x.NAME.Contains(sh) || x.DPCODE.Contains(sh));
                    }

                    List<USER_LOGIN> UserAns = new List<USER_LOGIN>();

                    foreach (var dx in DataUser)
                    {
                        USER_LOGIN ux = new USER_LOGIN();

                        ux.ID = dx.US_ID;
                        ux.STCODE = dx.STCODE;
                        ux.FULLNAME = dx.NAME;
                        ux.DEP = dx.DPCODE;
                        ux.A_NAME = dx.ANAME;

                        UserAns.Add(ux);
                        //PhoneModels.RowPhone.Add(ipn);
                    }  
                    value.Userloginid = UserAns;
                }

                value.sh = sh;
          
                results.Add(value);
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
        [ActionName("TicketClose")]
        public IEnumerable<Detail> TicketClose(Detail data)
        {
            List<Detail> results = new List<Detail>();

            try
            {
                UserDataContext Con = new UserDataContext();
                var User = (from xx in Con.MAS_USERs
                            join yy in Con.MAS_DEPs on xx.D_ID equals yy.DP_ID
                            where xx.STCODE == data.STCODE
                            select new { xx, yy }).FirstOrDefault();

                using (TicketLEDataContext Context = new TicketLEDataContext())
                {
                    var insert_Close = Context.TASK_MAINs.Where(s => s.ID == data.Ticket_ID).FirstOrDefault();

                    insert_Close.CLOSE_NAME = User.xx.FNAME + " " + User.xx.LNAME;
                    insert_Close.CLOSE_DATE = DateTime.Now;
                    insert_Close.APPROVE_ID = 4;
                    insert_Close.STATUS = "3";
                    Context.SubmitChanges();
                }
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
        [ActionName("TicketReceive")]
        public IEnumerable<Detail> TicketReceive(Detail data)
        {
            List<Detail> results = new List<Detail>();

            try
            {
                UserDataContext Con = new UserDataContext();
                var User = (from xx in Con.MAS_USERs
                            join yy in Con.MAS_DEPs on xx.D_ID equals yy.DP_ID
                            where xx.STCODE == data.STCODE
                            select new { xx, yy }).FirstOrDefault();

                using (TicketLEDataContext Context = new TicketLEDataContext())
                {
                    var sql_Main = Context.TASK_MAINs.Where(s => s.ID == data.Ticket_ID).FirstOrDefault();

                    sql_Main.STATUS = "2";
                    sql_Main.RECEIVE_NAME = User.xx.FNAME + " " + User.xx.LNAME;
                    sql_Main.RECEIVE_DATE = DateTime.Now;
                    sql_Main.APPROVE_ID = 3;

                    Context.SubmitChanges();
                }
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
        [ActionName("Edit")]
        public IEnumerable<Detail> Edit(Detail data)
        {
            List<Detail> results = new List<Detail>();

            try
            {
                using (UserDataContext Context = new UserDataContext())
                {
                    var sql = (from xx in Context.MAS_USERs
                               where xx.US_ID == data.Ticket_ID
                               select xx).FirstOrDefault();

                    sql.A_ID = byte.Parse(data.Dep);
                    Context.SubmitChanges();
                }
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
        [ActionName("TicketDelete")]
        public IEnumerable<Detail> TicketDelete(Detail data)
        {
            List<Detail> results = new List<Detail>();

            try
            {
                using (TicketLEDataContext Context = new TicketLEDataContext())
                {
                    var sql_Main = Context.TASK_MAINs.Where(s => s.ID == data.Ticket_ID).FirstOrDefault();
                    sql_Main.FLAG = "0";
                    Context.SubmitChanges();
                }
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

        private string ticketNo()
        {
            string runNo = "LE"; //IT17000009
            string strRun = "";
            string yy = DateTime.Now.Year.ToString();
            string mm = DateTime.Now.Month.ToString();
            int intRun = 1;


            yy = yy.Substring(yy.Length - 2, 2);
            if (mm.Length == 1) { mm = "0" + mm; }

            runNo = runNo + yy + mm;

            using (TicketLEDataContext Context = new TicketLEDataContext())
            {
                try
                {
                    var queryX = Context.TASK_MAINs.OrderByDescending(s => s.TICKETNO)
                    .Where(s => s.TICKETNO.Contains(runNo))
                    .FirstOrDefault();
                    strRun = queryX.TICKETNO;
                }
                catch
                {
                    strRun = "LE18010000";
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