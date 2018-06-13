using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.DATA.TicketOP;

namespace WebAPI.Models.Ticket_OP
{
    public class TicketOPRepository : ITicketOP
    {
        [HttpPost]
        [ActionName("Ticketlist")]
        public IEnumerable<Ticket> Ticketlist(Detail data)
        {
            List<Ticket> results = new List<Ticket>();

            try
            {
                IQueryable<VW_TICKET> View_Ticket;

                var seach = data.seach.Trim();
                var type = data.type.Trim();

                TicketOPDataContext Context = new TicketOPDataContext();
                UserDataContext C_user = new UserDataContext();

                List<Ticket> lstTicket = new List<Ticket>();

                //string a = userOnline;
                if (data.Pos == "1")
                {
                    var queryX = Context.MAS_WHs.Where(x => x.WHCODE == data.STCODE).FirstOrDefault();

                    //ViewBag.BRAND = queryX.BRAND;

                    View_Ticket = Context.VW_TICKETs
                        .Where(tik => tik.WHCODE == data.STCODE)
                        .Where(tik => tik.AREA.Contains(seach) || tik.WHNAME.Contains(seach) || tik.TICKETNO.Contains(seach))
                        .Where(tik => tik.FLAG == "0")
                        .OrderBy(tik => tik.SS_ID);
                }
                else
                {
                    var sql = C_user.VW_USER_ALLs.Where(x => x.STCODE == data.STCODE).FirstOrDefault();
                    //ViewBag.BRAND = sql.DPCODE;

                    View_Ticket = Context.VW_TICKETs
                        .Where(tik => tik.BRAND == sql.DPCODE)
                        .Where(tik => tik.AREA.Contains(seach) || tik.WHNAME.Contains(seach) || tik.TICKETNO.Contains(seach))
                        .Where(tik => tik.FLAG == "0")
                        .OrderBy(tik => tik.SS_ID);
                }

                if (type != "")
                {
                    View_Ticket = View_Ticket.Where(tik => tik.TNAME == type);
                }

                foreach (var ux in View_Ticket)
                {
                    Ticket _ticket = new Ticket();

                    _ticket.TK_ID = ux.TK_ID;
                    _ticket.TICKETNO = ux.TICKETNO;
                    _ticket.WHCODE = ux.WHCODE;
                    _ticket.WHNAME = ux.WHNAME;
                    _ticket.AREA = ux.AREA;
                    _ticket.DETAIL = ux.DETAIL;
                    _ticket.SS_ID = ux.SS_ID;
                    _ticket.ST_NAME = ux.TNAME;
                    _ticket.REC_NICKNAME = ux.NICKNAME;
                    _ticket.CREATEDATE = DateTime.Parse(ux.CREATEDATE.ToString()).ToShortDateString();
                    _ticket.CREATETIME = ux.CREATETIME.ToString();

                    lstTicket.Add(_ticket);
                }
                results = lstTicket;
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
        [ActionName("TicketComment")]
        public IEnumerable<AnsOP> TicketComment(AddComment data)
        {
            List<AnsOP> results = new List<AnsOP>();
            try
            {
                Ticket ticket = new Ticket();

                int oderNo = idOderno(data.TK_ID);

                using (TicketOPDataContext Context = new TicketOPDataContext())
                {
                    var trnTicketI = new TRN_TICKET_I();

                    trnTicketI.TK_ID = data.TK_ID;
                    trnTicketI.TK_MESAGE = data.TK_MESAGE;
                    trnTicketI.ORDERNO = (Int16)oderNo;
                    //trnTicketI.US_ID = idUser(userOnline);
                    trnTicketI.CREATEDATE = DateTime.Now;
                    trnTicketI.STCODE = data.STCODE;

                    Context.TRN_TICKET_Is.InsertOnSubmit(trnTicketI);
                    //Context.SubmitChanges();

                    int tkId = data.TK_ID;
                    Context.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                AnsOP res = new AnsOP();
                res.status = "F";
                res.message = ex.Message;
                results.Add(res);
            }

            return results.ToArray();
        }

        [HttpPost]
        [ActionName("CreTicket")]
        public IEnumerable<AnsOP> CreateTicket(CreTicket data)
        {
            List<AnsOP> results = new List<AnsOP>();
            try
            {
                Ticket ticket = new Ticket();

                using (TicketOPDataContext Context = new TicketOPDataContext())
                {
                    var queryX = Context.MAS_WHs.Where(x => x.WHCODE == data.STCODE).FirstOrDefault();
                    var trnTicket = new TRN_TICKET();
                    var trnTicket_f = new TRN_TICKET_F();
                    //var TmpTicket = new TRN_TICKET_TMP();

                    string tketNo = ticketNo(queryX.BRAND);

                    trnTicket.TICKETNO = tketNo;
                    trnTicket.WHCODE = data.STCODE;
                    trnTicket.WHNAME = data.WHNAME;
                    trnTicket.AREA = data.AREA_NAME;
                    trnTicket.DETAIL = data.DETAIL;
                    //trnTicket.JT_ID = newItem.JT_ID;
                    trnTicket.SS_ID = 1;

                    trnTicket.CREATEDATE = DateTime.Now;
                    trnTicket.FLAG = "0";
                    Context.TRN_TICKETs.InsertOnSubmit(trnTicket);

                    Context.SubmitChanges();

                    var Detail = Context.TRN_TICKETs.Where(s => s.TICKETNO == tketNo).FirstOrDefault();

                    int tkId = Detail.TK_ID;
                    //Int16 oderNo = 0;
                    //string pathSet = "FilesUpload";
                          
                    //if (Request.Files[0].ContentLength > 0)
                    //{
                    //    HttpPostedFileBase hpf_1 = Request.Files[0];
                    //    HttpPostedFileBase hpf_2 = Request.Files[1];
                    //    HttpPostedFileBase hpf_3 = Request.Files[2];

                    //    string fileName1 = "";
                    //    string fileName2 = "";
                    //    string fileName3 = "";
                    //    pathSet = "~/FilesUpload/";

                    //    if (hpf_1.FileName != null && hpf_1.FileName.Length > 0)
                    //    {
                    //        fileName1 = tketNo + "_" + tkId.ToString() + "_" + oderNo.ToString() + "_" + Path.GetFileName(hpf_1.FileName);
                    //        var path1 = Path.Combine(Server.MapPath("~/FilesUpload"), fileName1);
                    //        hpf_1.SaveAs(path1);

                    //        fileName1 = pathSet + fileName1;
                    //    }

                    //    if (hpf_2.FileName != null && hpf_2.FileName.Length > 0)
                    //    {
                    //        fileName2 = tketNo + "_" + tkId.ToString() + "_" + oderNo.ToString() + "_" + Path.GetFileName(hpf_2.FileName);
                    //        var path2 = Path.Combine(Server.MapPath("~/FilesUpload"), fileName2);
                    //        hpf_2.SaveAs(path2);

                    //        fileName2 = pathSet + fileName2;
                    //    }

                    //    if (hpf_3.FileName != null && hpf_3.FileName.Length > 0)
                    //    {
                    //        fileName3 = tketNo + "_" + tkId.ToString() + "_" + oderNo.ToString() + "_" + Path.GetFileName(hpf_3.FileName);
                    //        var path3 = Path.Combine(Server.MapPath("~/FilesUpload"), fileName3);
                    //        hpf_3.SaveAs(path3);

                    //        fileName3 = pathSet + fileName3;
                    //    }

                    //    trnTicket_f.TK_ID = tkId;
                    //    trnTicket_f.ORDERNO = oderNo;
                    //    trnTicket_f.FILENO = 1;
                    //    trnTicket_f.PATH1 = fileName1;
                    //    trnTicket_f.PATH2 = fileName2;
                    //    trnTicket_f.PATH3 = fileName3;

                    //    Context.TRN_TICKET_Fs.InsertOnSubmit(trnTicket_f);
                    //    Context.SubmitChanges();
                    //}
                }
            }
            catch (Exception ex)
            {
                AnsOP res = new AnsOP();
                res.status = "F";
                res.message = ex.Message;
                results.Add(res);
            }

            return results.ToArray();
        }

        [HttpPost]
        [ActionName("TicketDetail")]
        public IEnumerable<AddComment> TicketDetail(Detail data)
        {
            List<AddComment> results = new List<AddComment>();

            try
            {
                AddComment addComment = new AddComment();
                IQueryable<VW_TICKET_DETAIL> View_Ticket;

                TicketOPDataContext Context = new TicketOPDataContext();

                List<Ticket> lstTicket = new List<Ticket>();

                View_Ticket = Context.VW_TICKET_DETAILs
                    .Where(tik => tik.TK_ID == data.Ticket_ID);

                foreach (var ux in View_Ticket)
                {
                    Ticket _ticket = new Ticket();

                    _ticket.TK_ID = ux.TK_ID;
                    _ticket.TICKETNO = ux.TICKETNO;
                    _ticket.WHCODE = ux.WHCODE;
                    _ticket.WHNAME = ux.WHNAME;
                    _ticket.AREA = ux.AREA;
                    _ticket.DETAIL = ux.DETAIL;
                    _ticket.SS_ID = ux.SS_ID;
                    _ticket.ST_NAME = ux.TNAME;
                    _ticket.CREATEDATE = DateTime.Parse(ux.CREATEDATE.ToString()).ToShortDateString();
                    _ticket.CREATETIME = ux.CREATETIME.ToString();
                    _ticket.REC_NICKNAME = ux.NICKNAME;

                    _ticket.ORDERNO = ux.ORDERNO;
                    _ticket.TK_MESAGE = ux.TK_MESAGE;
                    _ticket.US_ID = ux.Expr1;

                    //_ticket.POS_NAME = ux.POS_NICKNAME;
                    _ticket.POSTDATE = ux.DETAILDATE.ToString();

                    //_ticket.FLS = flsPath(ux.TK_ID, 1);
                    ////_ticket.FLS_I = flsPath(ux.TK_ID, 1, (Int16)ux.ORDERNO);
                    //_ticket.FLS_H_1 = flsPath(ux.TK_ID, 1);
                    //_ticket.FLS_H_2 = flsPath(ux.TK_ID, 2);
                    //_ticket.FLS_H_3 = flsPath(ux.TK_ID, 3);

                    //try
                    //{
                    //    _ticket.FLS_H_1_Name = _ticket.FLS_H_1.Substring(14, _ticket.FLS_H_1.Length - 14);
                    //    String[] substrings_1 = _ticket.FLS_H_1.Split('.');
                    //    int num_1 = substrings_1.Length;
                    //    string check_1 = substrings_1[num_1 - 1];
                    //    var sql_1 = (from xx in Context.DEV_TASK_FLAGs
                    //                 where xx.Type_name == check_1
                    //                 select xx).FirstOrDefault();
                    //    if (sql_1.FLAG == 1)
                    //    {
                    //        _ticket.FLAG_1 = "1";
                    //    }
                    //    else
                    //    {
                    //        _ticket.FLAG_1 = "2";
                    //        _ticket.IMG_1 = sql_1.File_img;
                    //    }

                    //    _ticket.FLS_H_2_Name = _ticket.FLS_H_2.Substring(14, _ticket.FLS_H_2.Length - 14);
                    //    String[] substrings_2 = _ticket.FLS_H_2.Split('.');
                    //    int num_2 = substrings_2.Length;
                    //    string check_2 = substrings_2[num_2 - 1];
                    //    var sql_2 = (from xx in Context.DEV_TASK_FLAGs
                    //                 where xx.Type_name == check_2
                    //                 select xx).FirstOrDefault();
                    //    if (sql_2.FLAG == 1)
                    //    {
                    //        _ticket.FLAG_2 = "1";
                    //    }
                    //    else
                    //    {
                    //        _ticket.FLAG_2 = "2";
                    //        _ticket.IMG_2 = sql_2.File_img;
                    //    }

                    //    _ticket.FLS_H_3_Name = _ticket.FLS_H_3.Substring(14, _ticket.FLS_H_3.Length - 14);
                    //    String[] substrings_3 = _ticket.FLS_H_3.Split('.');
                    //    int num_3 = substrings_3.Length;
                    //    string check_3 = substrings_3[num_3 - 1];
                    //    var sql_3 = (from xx in Context.DEV_TASK_FLAGs
                    //                 where xx.Type_name == check_3
                    //                 select xx).FirstOrDefault();
                    //    if (sql_3.FLAG == 1)
                    //    {
                    //        _ticket.FLAG_3 = "1";
                    //    }
                    //    else
                    //    {
                    //        _ticket.FLAG_3 = "2";
                    //        _ticket.IMG_3 = sql_3.File_img;
                    //    }
                    //}
                    //catch
                    //{

                    //}


                    lstTicket.Add(_ticket);
                    addComment.TK_ID = ux.TK_ID;
                    addComment.TICKETNO = ux.TICKETNO;
                    addComment.SS_ID = ux.SS_ID;
                }
                addComment.ticket = lstTicket;

                results.Add(addComment);
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





        //----------------------------------------------------------------------------------------------------------------

        private int idOderno(int tkId)
        {
            int id = 0;

            using (TicketOPDataContext searchContext = new TicketOPDataContext())
            {
                var queryX = searchContext.TRN_TICKET_Is.OrderByDescending(s => s.TK_ID)
                          .ThenByDescending(s => s.ORDERNO)
                          .Where(s => s.TK_ID == tkId)
                          .FirstOrDefault();

                try
                {
                    id = queryX.ORDERNO;
                    id = id + 1;
                }
                catch
                {
                    id = 1;
                }
            }

            return id;
        }

        private string ticketNo(string Bread)
        {
            string runNo = Bread;
            string strRun = "";
            string yy = DateTime.Now.Year.ToString();
            string mm = DateTime.Now.Month.ToString();
            int intRun = 1;


            yy = yy.Substring(yy.Length - 2, 2);
            if (mm.Length == 1) { mm = "0" + mm; }

            runNo = runNo + yy + mm;

            using (TicketOPDataContext Context = new TicketOPDataContext())
            {
                try
                {
                    var queryX = Context.TRN_TICKETs.OrderByDescending(s => s.TICKETNO)
                    .Where(s => s.TICKETNO.Contains(runNo))
                    .FirstOrDefault();
                    strRun = queryX.TICKETNO;
                }
                catch
                {
                    strRun = Bread + "18010000";
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