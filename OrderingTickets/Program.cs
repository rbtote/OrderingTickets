using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

class MainClass
{

    public class TicketResponse
    {
        public string Contract { get; set; }

        public string ExternalDelivery { get; set; }

        public string PointOfDeliveryCode { get; set; }

        public string PurchaseOrder { get; set; }

        public string DocDate { get; set; }

        public string PointOfDeliveryDesc { get; set; }

        public string TicketCode { get; set; }

        public string PointOfDeliveryAddress { get; set; }

    }

    public static void printData(List<TicketResponse> tickets)
    {
        foreach (TicketResponse t in tickets)
        {
            Console.WriteLine("Contract: " + t.Contract);
            Console.WriteLine("ExternalDelivery: " + t.ExternalDelivery);
            Console.WriteLine("PointOfDeliveryCode: " + t.PointOfDeliveryCode);
            Console.WriteLine("PurchaseOrder: " + t.PurchaseOrder);
            Console.WriteLine("DocDate: " + t.DocDate);
            Console.WriteLine("PointOfDeliveryDesc: " + t.PointOfDeliveryDesc);
            Console.WriteLine("TicketCode: " + t.TicketCode);
            Console.WriteLine("PointOfDeliveryAddress: " + t.PointOfDeliveryAddress);
            Console.WriteLine("");
        }
    }

    public static List<TicketResponse>  LoadJson(string file)
    {
        string jsonString = File.ReadAllText(file);
        return JsonConvert.DeserializeObject<List<TicketResponse>>(jsonString);
    }


    public static string removeNine(string str)
    {
        return str[0] == '9' ? str.Substring(1) : str;
    }

    public static void sortData(List<TicketResponse> tickets)
    {
        tickets.Sort(delegate (TicketResponse x, TicketResponse y)
        {
            int ret = removeNine(x.ExternalDelivery).CompareTo(removeNine(y.ExternalDelivery));
            //Console.WriteLine(x.ExternalDelivery + " " + y.ExternalDelivery + " " + ret);
            return ret != 0 ? ret : (x.ExternalDelivery.Length.CompareTo(y.ExternalDelivery.Length));
        });
    }

    static void Main()
    {
        List<TicketResponse> tickets = LoadJson("response4.json");
        printData(tickets);
        sortData(tickets);
        Console.WriteLine("Sorted\n");
        printData(tickets);
    }
}