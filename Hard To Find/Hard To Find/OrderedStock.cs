using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hard_To_Find
{
    public class OrderedStock
    {
        public int orderedStockID { get; set; }
        public int orderID { get; set; }
        public int stockID { get; set; }
        public int quantity { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string price { get; set; }
        public string bookID { get; set; }
        public string discount { get; set; }

        public OrderedStock(int orderedStockID, int orderID, int stockID, int quantity, string author, string title, string price, string bookID, string discount)
        {
            this.orderedStockID = orderedStockID;
            this.orderID = orderID;
            this.stockID = stockID;
            this.quantity = quantity;
            this.author = author;
            this.title = title;
            this.price = price;
            this.bookID = bookID;
            this.discount = discount;
        }

        public OrderedStock(int orderID, int stockID, int quantity, string author, string title, string price, string bookID, string discount)
        {
            this.orderedStockID = -1;
            this.orderID = orderID;
            this.stockID = stockID;
            this.quantity = quantity;
            this.author = author;
            this.title = title;
            this.price = price;
            this.bookID = bookID;
            this.discount = discount;
        }
    }
}
