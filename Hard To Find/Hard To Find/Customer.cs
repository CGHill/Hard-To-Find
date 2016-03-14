using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hard_To_Find
{
    public class Customer
    {
        public int custID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string institution { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string country { get; set; }
        public string postCode { get; set; }
        public string email { get; set; }
        public string comments { get; set; }
        public string sales { get; set; }
        public string payment { get; set; }

        //Constructor for customers with no IDs
        public Customer(string firstName, string lastName, string institution, string address1, string address2, string address3, string country, string postCode, string email, 
            string comments, string sales, string payment)
        {
            this.custID = -1;
            this.firstName = firstName;
            this.lastName = lastName;
            this.institution = institution;
            this.address1 = address1;
            this.address2 = address2;
            this.address3 = address3;
            this.country = country;
            this.postCode = postCode;
            this.email = email;
            this.comments = comments;
            this.sales = sales;
            this.payment = payment;
        }

        //Constructor for customers with ID
        public Customer(int custID, string firstName, string lastName, string institution, string address1, string address2, string address3, string country, string postCode, string email, 
            string comments, string sales, string payment)
        {
            this.custID = custID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.institution = institution;
            this.address1 = address1;
            this.address2 = address2;
            this.address3 = address3;
            this.country = country;
            this.postCode = postCode;
            this.email = email;
            this.comments = comments;
            this.sales = sales;
            this.payment = payment;
        }
    }
}
