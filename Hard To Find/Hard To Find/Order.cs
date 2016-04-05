using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hard_To_Find
{
    class Order
    {
        public int orderID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string institution { get; set; }
        public string postcode { get; set; }
        public string orderReference { get; set; }
        public string progress { get; set; }
        public string freightCost { get; set; }
        public int invoiceNo { get; set; }
        public string invoiceDate { get; set; }
        public string comments { get; set; }
        public int customerID { get; set; }

        public Order(int orderID, string firstName, string lastName, string institution, string postcode, string orderReference, string progress, string freightCost, 
            int invoiceNo, string invoiceDate, string comments, int customerID)
        {
            this.orderID = orderID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.institution = institution;
            this.postcode = postcode;
            this.orderReference = orderReference;
            this.progress = progress;
            this.freightCost = freightCost;
            this.invoiceNo = invoiceNo;
            this.invoiceDate = invoiceDate;
            this.comments = comments;
            this.customerID = customerID;
        }

        public Order(string firstName, string lastName, string institution, string postcode, string orderReference, string progress, string freightcost, int invoiceNo, 
            string invoiceDate, string comments, int customerID)
        {
            this.orderID = -1;
            this.firstName = firstName;
            this.lastName = lastName;
            this.institution = institution;
            this.postcode = postcode;
            this.orderReference = orderReference;
            this.progress = progress;
            this.freightCost = freightcost;
            this.invoiceNo = invoiceNo;
            this.invoiceDate = invoiceDate;
            this.comments = comments;
            this.customerID = customerID;
        }
    }
}
