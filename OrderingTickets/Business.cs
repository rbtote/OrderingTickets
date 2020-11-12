using System;
using System.Collections.Generic;
using System.Text;

namespace OrderingTickets
{
    public class Business
    {
        IDataAccess data_access;
        public Business(IDataAccess dataAccess)
        {
            data_access = dataAccess;
        }

        /// <summary>
        /// Checks if the first digit of a string is 9
        /// </summary>
        /// <param name="str">The string to check</param>
        /// <returns>The string without ONE leading 9 if there is one</returns>
        public string removeNine(string str)
        {
            return str[0] == '9' ? str.Substring(1) : str;
        }

        /// <summary>
        /// Sorts a list of type <see cref="TicketResponse"/> by smallest to largest without
        /// counting leading 9
        /// </summary>
        /// <param name="tickets"> List of tickets to sort</param>
        public void sortData(List<TicketResponse> tickets)
        {
            tickets.Sort(delegate (TicketResponse x, TicketResponse y)
            {
                int ret = removeNine(x.ExternalDelivery).CompareTo(removeNine(y.ExternalDelivery));
                return ret != 0 ? ret : (x.ExternalDelivery.Length.CompareTo(y.ExternalDelivery.Length));
            });
        }

        // Params are the same as in the FinancialDocumentsRepository.cs
        // We will use the customerCode as the file name in this case
        /// <summary>
        /// Get tickets by document
        /// </summary>
        /// <param name="countryCode"> The country code of the request</param>
        /// <param name="customerCode"> The customer code of the request</param>
        /// <param name="documentId"> Document Id of the request</param>
        /// <param name="debitFlag"> Whether if the document is debit or not</param>
        /// <returns> Sorted list if the country code is IL</returns>
        public List<TicketResponse> GetTicketsbyDocument(string countryCode, string customerCode, long documentId,
            bool debitFlag, bool? ticketItem = true)
        {
            var tickets = data_access.getData(customerCode);
            if (countryCode.Equals("IL"))
            {
                sortData(tickets);
            }            
            return tickets;
        }
    }
}
