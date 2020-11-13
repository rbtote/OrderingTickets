using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OrderingTickets
{
    public class DataAccess : IDataAccess
    {
        /// <summary>
        /// Gets the data of the tickets
        /// </summary>
        /// <param name="file">The JSON file to get the data from</param>
        /// <returns>A list of type <see cref="TicketResponse"/>></returns>
        public List<TicketResponse> getData(string file)
        {
            string jsonString = File.ReadAllText("../../../TestCases/" + file);
            return JsonConvert.DeserializeObject<List<TicketResponse>>(jsonString);
        }

    }
}
