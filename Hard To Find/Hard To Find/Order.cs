using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hard_To_Find
{
    class Order
    {
        public int orderID { get; set; }
        public string customerFirstName { get; set; }
        public string customerLastName { get; set; }
        public string institution { get; set; }
        public string postcode { get; set; }
        public string orderReference { get; set; }
        public string catItem { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public int quantity { get; set; }
        public string price { get; set; }
        public string progress { get; set; }
        public string freightCost { get; set; }
        public int invoiceNo { get; set; }
        public string invoiceDate { get; set; }
        public string comments { get; set; }
        public int stockID { get; set; }
        public int customerID { get; set; }

        public Order(int orderID, string customerFirstName, string customerLastName, string institution, string postcode, string orderReference, string catItem, string author, string title, int quantity, string price,
            string progress, string freightCost, int invoiceNo, string invoiceDate, string comments, int stockID, int customerID)
        {
            this.orderID = orderID;
            this.customerFirstName = customerFirstName;
            this.customerLastName = customerLastName;
            this.institution = institution;
            this.postcode = postcode;
            this.orderReference = orderReference;
            this.catItem = catItem;
            this.author = author;
            this.title = title;
            this.quantity = quantity;
            this.price = price;
            this.progress = progress;
            this.freightCost = freightCost;
            this.invoiceNo = invoiceNo;
            this.invoiceDate = invoiceDate;
            this.comments = comments;
            this.stockID = stockID;
            this.customerID = customerID;
        }

        public Order(string firstName, string lastName, string institution, string postcode, string orderReference, string catItem, string author, string title, int quantity, string price,
            string progress, string freightcost, int invoiceNo, string invoiceDate, string comments, int stockID, int customerID)
        {
            this.orderID = -1;
            this.customerFirstName = customerFirstName;
            this.customerLastName = customerLastName;
            this.institution = institution;
            this.postcode = postcode;
            this.orderReference = orderReference;
            this.catItem = catItem;
            this.author = author;
            this.title = title;
            this.quantity = quantity;
            this.price = price;
            this.progress = progress;
            this.freightCost = freightcost;
            this.invoiceNo = invoiceNo;
            this.invoiceDate = invoiceDate;
            this.comments = comments;
            this.stockID = stockID;
            this.customerID = customerID;
        }
    }
}
