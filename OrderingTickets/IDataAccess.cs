using System.Collections.Generic;

namespace OrderingTickets
{
    public interface IDataAccess
    {
        List<TicketResponse> getData(string file);
    }
}