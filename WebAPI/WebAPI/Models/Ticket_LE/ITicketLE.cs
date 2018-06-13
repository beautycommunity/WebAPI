using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models.Ticket_LE
{
    interface ITicketLE
    {                                 
        IEnumerable<Ticket> Ticketlist(Detail data);
        IEnumerable<TicketModels> CreateTicketShow();
        IEnumerable<Detail> CreateTicket(TicketModels data);
        IEnumerable<TicketModels> TicketDetail(TicketModels data);
                                   
        IEnumerable<Detail> TicketDelete(Detail data);
        IEnumerable<Detail> TicketReceive(Detail data); 
        IEnumerable<TicketModels> ApproveTicket(Detail data); 
        IEnumerable<Detail> Approve(Detail data);
        IEnumerable<Detail> TicketClose(Detail data);
        IEnumerable<TicketModels> Print(TicketModels data);
        IEnumerable<ListUserLogin> Manage_Partial(Detail data);
        IEnumerable<Detail> Edit(Detail data);
    }
}
