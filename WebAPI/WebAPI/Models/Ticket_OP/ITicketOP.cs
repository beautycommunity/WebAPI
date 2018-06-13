using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models.Ticket_OP
{
    interface ITicketOP
    {
        IEnumerable<AnsOP> CreateTicket(CreTicket data);
        IEnumerable<AnsOP> TicketComment(AddComment data);
        IEnumerable<AddComment> TicketDetail(Detail data);
        IEnumerable<Ticket> Ticketlist(Detail data); 

    }
}
