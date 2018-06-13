using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models.Ticket_LE;

namespace WebAPI.Controllers.Ticket_LE
{
    public class TicketLEController : ApiController
    {
        static readonly ITicketLE repository = new TicketLERepository();

        [HttpPost]
        [ActionName("Ticketlist")]
        public IEnumerable<Ticket> Ticketlist([FromBody]Detail data)
        {
            return repository.Ticketlist(data);
        }

        [HttpPost]
        [ActionName("CreateTicketShow")]
        public IEnumerable<TicketModels> CreateTicketShow()
        {
            return repository.CreateTicketShow();
        }

        [HttpPost]
        [ActionName("CreateTicket")]
        public IEnumerable<Detail> CreateTicket([FromBody]TicketModels data)
        {
            return repository.CreateTicket(data);
        }

        [HttpPost]
        [ActionName("TicketDetail")]
        public IEnumerable<TicketModels> TicketDetail([FromBody]TicketModels data)
        {
            return repository.TicketDetail(data);
        }

        [HttpPost]
        [ActionName("TicketDelete")]
        public IEnumerable<Detail> TicketDelete([FromBody]Detail data)
        {
            return repository.TicketDelete(data);
        }

        [HttpPost]
        [ActionName("TicketReceive")]
        public IEnumerable<Detail> TicketReceive([FromBody]Detail data)
        {
            return repository.TicketReceive(data);
        }

        [HttpPost]
        [ActionName("ApproveTicket")]
        public IEnumerable<TicketModels> ApproveTicket([FromBody]Detail data)
        {
            return repository.ApproveTicket(data);
        }

        [HttpPost]
        [ActionName("Approve")]
        public IEnumerable<Detail> Approve([FromBody]Detail data)
        {
            return repository.Approve(data);
        }

        [HttpPost]
        [ActionName("TicketClose")]
        public IEnumerable<Detail> TicketClose([FromBody]Detail data)
        {
            return repository.TicketClose(data);
        }
                 
        [HttpPost]
        [ActionName("Print")]
        public IEnumerable<TicketModels> Print([FromBody]TicketModels data)
        {
            return repository.Print(data);
        }

        [HttpPost]
        [ActionName("Manage_Partial")]
        public IEnumerable<ListUserLogin> Manage_Partial([FromBody]Detail data)
        {
            return repository.Manage_Partial(data);
        }

        [HttpPost]
        [ActionName("Edit")]
        public IEnumerable<Detail> Edit([FromBody]Detail data)
        {
            return repository.Edit(data);
        }

    }
}
