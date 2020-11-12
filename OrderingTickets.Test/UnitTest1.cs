using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace OrderingTickets.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MockDataAccess dataAccess = new MockDataAccess();

            OrderingTickets.Business test = new OrderingTickets.Business(dataAccess);
            bool debitFlag = true;
            var ticketsILv1 = test.GetTicketsbyDocument("IL", "response1.json", 11, debitFlag);
            var ticketsILv2 = test.GetTicketsbyDocument("IL", "response4.json", 11, debitFlag);
            var ticketsILv3 = test.GetTicketsbyDocument("IL", "response3.json", 1234, debitFlag);
            var ticketsMXv1 = test.GetTicketsbyDocument("MX", "response2.json", 1234, debitFlag);
            var ticketsMXv2 = test.GetTicketsbyDocument("MX", "response6.json", 1234, debitFlag);
            var ticketsILv4 = test.GetTicketsbyDocument("IL", "response6.json", 1234, debitFlag);
            var ticketsMXv3 = test.GetTicketsbyDocument("IL", "response5.json", 1234, debitFlag);
            var ticketsILv5 = test.GetTicketsbyDocument("MX", "response5.json", 1234, debitFlag);

            // Tickets is not null
            Assert.IsNotNull(ticketsILv1);
            Assert.IsNotNull(ticketsILv2);
            Assert.IsNotNull(ticketsMXv1);
            Assert.IsNotNull(ticketsILv3);
            Assert.IsNotNull(ticketsMXv3); //Receives only one element without external delivery number-> does not crash
            Assert.IsNotNull(ticketsILv5); //Receives only one element without external delivery number-> does not crash
            Assert.IsNotNull(ticketsMXv2); //Receives empty list -> does not crash
            Assert.IsNotNull(ticketsILv4); //Receives empty list -> does not crash

            //Tickets ordered by IL's requirements
            Assert.IsTrue(ticketsILv1[0].ExternalDelivery.Equals("1111111111"));
            Assert.IsTrue(ticketsILv1[1].ExternalDelivery.Equals("91111111111"));
            Assert.IsTrue(ticketsILv1[5].ExternalDelivery.Equals("6423121267"));
            Assert.IsTrue(ticketsILv1[6].ExternalDelivery.Equals("96423121267"));

            Console.WriteLine(ticketsILv2[0].ExternalDelivery);
            //Tickets ordered by IL's requirements
            Assert.IsTrue(ticketsILv2[0].ExternalDelivery.Equals("222"));
            Assert.IsTrue(ticketsILv2[1].ExternalDelivery.Equals("2222"));
            Assert.IsTrue(ticketsILv2[3].ExternalDelivery.Equals("9222222"));
            Assert.IsTrue(ticketsILv2[4].ExternalDelivery.Equals("2222222"));


            //Tickets ordered by IL's requirements
            Assert.IsTrue(ticketsILv3[0].ExternalDelivery.Equals("9111111111"));
            Assert.IsTrue(ticketsILv3[3].ExternalDelivery.Equals("224567890"));
            Assert.IsTrue(ticketsILv3[5].ExternalDelivery.Equals("5400121267"));

             
             //Tickets are not sorted because it's Mexico
            Assert.IsTrue(ticketsMXv1[0].ExternalDelivery.Equals("5400121267"));
            Assert.IsTrue(ticketsMXv1[4].ExternalDelivery.Equals("224567890"));
            Assert.IsTrue(ticketsMXv1[6].ExternalDelivery.Equals("91234567890"));
                
        }
    }
}
