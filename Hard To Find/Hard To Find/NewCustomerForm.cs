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
            string firstName = SQLSyntaxHelper.escapeSingleQuotes(boxFirstName.Text);
            string lastName = SQLSyntaxHelper.escapeSingleQuotes(boxLastName.Text);
            string institution = SQLSyntaxHelper.escapeSingleQuotes(boxInstitution.Text);
            string address1 = SQLSyntaxHelper.escapeSingleQuotes(boxAddress1.Text);
            string address2 = SQLSyntaxHelper.escapeSingleQuotes(boxAddress2.Text);
            string address3 = SQLSyntaxHelper.escapeSingleQuotes(boxAddress3.Text);
            string postcode = SQLSyntaxHelper.escapeSingleQuotes(boxPostcode.Text);
            string country = SQLSyntaxHelper.escapeSingleQuotes(boxCountry.Text);
            string email = SQLSyntaxHelper.escapeSingleQuotes(boxEmail.Text);
            string comments = SQLSyntaxHelper.escapeSingleQuotes(boxComments.Text);
            string sales = SQLSyntaxHelper.escapeSingleQuotes(boxSales.Text);
            string payment = SQLSyntaxHelper.escapeSingleQuotes(boxPayment.Text);

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
