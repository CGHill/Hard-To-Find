using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hard_To_Find
{
    public partial class NewCustomerForm : Form
    {
        //Globals
        private DatabaseManager dbManager;

        public NewCustomerForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            dbManager = new DatabaseManager();
        }

        /*Precondition:
         Postcondition: Closes form*/
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*Precondition:
         Postcondition: Creates a new customer and passes it to database for storage*/
        private void btnSave_Click(object sender, EventArgs e)
        {
            string firstName = boxFirstName.Text;
            string lastName = boxLastName.Text;
            string institution = boxInstitution.Text;
            string address1 = boxAddress1.Text;
            string address2 = boxAddress2.Text;
            string address3 = boxAddress3.Text;
            string postcode = boxPostcode.Text;
            string country = boxCountry.Text;
            string email = boxEmail.Text;
            string comments = boxComments.Text;
            string sales = boxSales.Text;
            string payment = boxPayment.Text;

            //Check that the basic things haven't been left empty so a blank customer isn't saved
            if (firstName != "" || lastName != "" || address1 != "" || address2 != "" || address3 != "")
            {
                Customer newCustomer = new Customer(firstName, lastName, institution, address1, address2, address3, country, postcode, email, comments, sales, payment);

                dbManager.insertCusomter(newCustomer);

                this.Close();
            }
            else
            {
                MessageBox.Show("Not enough information entered");
            }
        }
    }
}
