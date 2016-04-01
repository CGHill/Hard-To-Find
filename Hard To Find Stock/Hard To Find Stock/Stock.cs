using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hard_To_Find_Stock
{
    public class Stock
    {
        public int stockID { get; set; }
        public int quantity { get; set; }
        public string note { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public string publisher { get; set; }
        public string description { get; set; }
        public string comments { get; set; }
        public string price { get; set; }
        public string subject { get; set; }
        public string catalogue { get; set; }
        public string initials { get; set; }
        public string sales { get; set; }
        public string bookID { get; set; }
        public string dateEntered { get; set; }

        //Constructor for stock with existing IDs
        public Stock(int stockID, int quantity, string note, string author, string title, string subtitle, string publisher, string description, string comments, string price,
            string subject, string catalogue, string initials, string sales, string bookID, string dateEntered)
        {
            this.stockID = stockID;
            this.quantity = quantity;
            this.note = note;
            this.author = author;
            this.title = title;
            this.subtitle = subtitle;
            this.publisher = publisher;
            this.description = description;
            this.comments = comments;
            this.price = price;
            this.subject = subject;
            this.catalogue = catalogue;
            this.initials = initials;
            this.sales = sales;
            this.bookID = bookID;
            this.dateEntered = dateEntered;
        }

        //Constructor for new stock
        public Stock(int quantity, string note, string author, string title, string subtitle, string publisher, string description, string comments, string price,
            string subject, string catalogue, string initials, string sales, string bookID, string dateEntered)
        {
            this.stockID = -1;
            this.quantity = quantity;
            this.note = note;
            this.author = author;
            this.title = title;
            this.subtitle = subtitle;
            this.publisher = publisher;
            this.description = description;
            this.comments = comments;
            this.price = price;
            this.subject = subject;
            this.catalogue = catalogue;
            this.initials = initials;
            this.sales = sales;
            this.bookID = bookID;
            this.dateEntered = dateEntered;
        }
    }
}
