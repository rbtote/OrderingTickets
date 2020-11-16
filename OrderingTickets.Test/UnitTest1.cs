using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
            var ticketsILv4 = test.GetTicketsbyDocument("IL", "response6.json", 1234, debitFlag);
            var ticketsILv5 = test.GetTicketsbyDocument("IL", "response5.json", 1234, debitFlag);

            var ticketsMXv1 = test.GetTicketsbyDocument("MX", "response2.json", 1234, debitFlag);
            var ticketsMXv2 = test.GetTicketsbyDocument("MX", "response6.json", 1234, debitFlag);
            var ticketsMXv3 = test.GetTicketsbyDocument("MX", "response5.json", 1234, debitFlag);



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

            //Expected order 
            var expectedResponseILv1 = new List<String> { "1111111111", "91111111111", "224567890", "224567890", "9224567890", "6423121267", "96423121267", "81234567890" };
            //Assert ordered tickets
            for (int i = 0; i < expectedResponseILv1.Count; i++)
            {
                Assert.IsTrue(ticketsILv1[i].ExternalDelivery.Equals(expectedResponseILv1[i]), "expectedResponseILv1 failed at index: " + i);
            }

            //Expected order 
            var expectedResponseticketsILv2 = new List<String> { "222", "2222", "222222", "9222222", "2222222", "85412765" };
            //Tickets ordered by IL's requirements
            //Assert ordered tickets
            for (int i = 0; i < expectedResponseticketsILv2.Count; i++)
            {
                Assert.IsTrue(ticketsILv2[i].ExternalDelivery.Equals(expectedResponseticketsILv2[i]), "expectedResponseticketsILv2 failed at index: " + i);
            }

            //Expected order 
            var expectedResponseticketsILv3 = new List<String> { "9111111111", "9123456789", "224567890", "224567890", "9224567890", "5400121267", "95400121267" };
            //Tickets ordered by IL's requirements
            //Assert ordered tickets
            for (int i = 0; i < expectedResponseticketsILv3.Count; i++)
            {
                Assert.IsTrue(ticketsILv3[i].ExternalDelivery.Equals(expectedResponseticketsILv3[i]), "expectedResponseticketsILv3 failed at index: " + i);
            }


            //Externar Delivery input is ""
            ticketsILv5[0].ExternalDelivery.Equals("");


            //Tickets are not sorted because it's Mexico
            //Expected order 
            var expectedResponseticketsMXv1 = new List<String> { "5400121267", "91111111111", "95400121267", "1111111111", "224567890", "9224567890", "91234567890", "224567890" };

            //Assert ordered tickets
            for (int i = 0; i < expectedResponseticketsMXv1.Count; i++)
            {
                Assert.IsTrue(ticketsMXv1[i].ExternalDelivery.Equals(expectedResponseticketsMXv1[i]), "expectedResponseticketsMXv1 failed at index: " + i);
            }


            //Externar Delivery input is ""
            ticketsMXv3[0].ExternalDelivery.Equals("");

        }
    }
}
