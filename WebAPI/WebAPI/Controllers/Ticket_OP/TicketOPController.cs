using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models.Ticket_OP;

namespace WebAPI.Controllers.Ticket_OP
{
    public class TicketOPController : ApiController
    {
        static readonly ITicketOP repository = new TicketOPRepository();
                            
        [HttpPost]
        [ActionName("CreateTicket")]
        public IEnumerable<AnsOP> CreateTicket([FromBody]CreTicket data)
        {
            return repository.CreateTicket(data);
        }

        [HttpPost]
        [ActionName("TicketComment")]
        public IEnumerable<AnsOP> TicketComment([FromBody]AddComment data)
        {
            return repository.TicketComment(data);
        }

        [HttpPost]
        [ActionName("TicketDetail")]
        public IEnumerable<AddComment> TicketDetail([FromBody]Detail data)
        {
            return repository.TicketDetail(data);
        }

        [HttpPost]
        [ActionName("Ticketlist")]
        public IEnumerable<Ticket> Ticketlist([FromBody]Detail data)
        {
            return repository.Ticketlist(data);
        }
        
    }
}
