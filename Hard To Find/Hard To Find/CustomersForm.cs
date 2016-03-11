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
    public partial class CustomersForm : Form
    {
        //Globals
        private DatabaseManager dbManager;
        private Customer currCustomer;

        //Constructor
        public CustomersForm(Customer currCustomer)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            //Create instance of database manager and list for storing customers
            dbManager = new DatabaseManager();

            this.currCustomer = currCustomer;

            loadUpCustomer();
        }

        /*Precondition:
         Postcondition: Fills text boxes up with the customers data*/
        public void loadUpCustomer()
        {
            labCustID.Text = currCustomer.custID.ToString();
            boxFirstName.Text = currCustomer.firstName;
            boxLastName.Text = currCustomer.lastName;
            boxInstitution.Text = currCustomer.institution;
            boxAddress1.Text = currCustomer.address1;
            boxAddress2.Text = currCustomer.address2;
            boxAddress3.Text = currCustomer.address3;
            boxPostcode.Text = currCustomer.postCode;
            boxCountry.Text = currCustomer.country;
            boxPhone.Text = currCustomer.phone;
            boxFax.Text = currCustomer.fax;
            boxEmail.Text = currCustomer.email;
            boxComments.Text = currCustomer.comments;
            boxSales.Text = currCustomer.sales;
            boxPayment.Text = currCustomer.payment;
        }

        /*Precondition:
         Postcondition: Enables editing to existing customer*/
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            toggleBoxesReadOnly();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        /*Precondition:
         Postcondition: Save the changes made to the customer*/
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
            toggleBoxesReadOnly();

            //Update all fields
            currCustomer.firstName = checkForSingleQuote(boxFirstName.Text);
            currCustomer.lastName = checkForSingleQuote(boxLastName.Text);
            currCustomer.institution = checkForSingleQuote(boxInstitution.Text);
            currCustomer.address1 = checkForSingleQuote(boxAddress1.Text);
            currCustomer.address2 = checkForSingleQuote(boxAddress2.Text);
            currCustomer.address3 = checkForSingleQuote(boxAddress3.Text);
            currCustomer.postCode = checkForSingleQuote(boxPostcode.Text);
            currCustomer.country = checkForSingleQuote(boxCountry.Text);
            currCustomer.phone = checkForSingleQuote(boxPhone.Text);
            currCustomer.fax = checkForSingleQuote(boxFax.Text);
            currCustomer.email = checkForSingleQuote(boxEmail.Text);
            currCustomer.comments = checkForSingleQuote(boxComments.Text);
            currCustomer.sales = checkForSingleQuote(boxSales.Text);
            currCustomer.payment = checkForSingleQuote(boxPayment.Text);

            //Send to dbManager to update entry
            dbManager.updateCustomer(currCustomer);
        }

        private string checkForSingleQuote(string stringToCheck)
        {
            //Check if it contains a single quotation
            if (stringToCheck.Contains('\''))
            {
                //Get number of single quotations
                int numQuotes = stringToCheck.Split('\'').Length - 1;
                //int num = removedDashes.Count(c => c == '\'');

                int previousIndex = 0;

                //Loop over quotations
                for (int i = 0; i < numQuotes; i++)
                {
                    //Insert quotation before existing one because it's an escape character in SQLite
                    int indexOfQuote = stringToCheck.IndexOf("'", previousIndex);
                    stringToCheck = stringToCheck.Insert(indexOfQuote, "'");

                    //Move index after quotation that was just fixed to stop repeating on the same one
                    previousIndex = indexOfQuote + 2;
                }

            }

            return stringToCheck;
        }


        /*Precondition: None
         Postcondition: Toggles textboxes ReadOnly between true and false so that customer data can be updated */
        private void toggleBoxesReadOnly()
        {
            boxFirstName.ReadOnly = !boxFirstName.ReadOnly;
            boxLastName.ReadOnly = !boxLastName.ReadOnly;
            boxInstitution.ReadOnly = !boxInstitution.ReadOnly;
            boxAddress1.ReadOnly = !boxAddress1.ReadOnly;
            boxAddress2.ReadOnly = !boxAddress2.ReadOnly;
            boxAddress3.ReadOnly = !boxAddress3.ReadOnly;
            boxPostcode.ReadOnly = !boxPostcode.ReadOnly;
            boxCountry.ReadOnly = !boxCountry.ReadOnly;
            boxPhone.ReadOnly = !boxPhone.ReadOnly;
            boxFax.ReadOnly = !boxFax.ReadOnly;
            boxEmail.ReadOnly = !boxEmail.ReadOnly;
            boxComments.ReadOnly = !boxComments.ReadOnly;
            boxSales.ReadOnly = !boxSales.ReadOnly;
            boxPayment.ReadOnly = !boxPayment.ReadOnly;
        }

        /*Precondition:
         Postcondition: Closes form*/
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*Precondition:
         Postcondition: Opens up form to see orders by the current customer*/
        private void btnCustomersOrders_Click(object sender, EventArgs e)
        {
            CustomerOrdersForm cof = new CustomerOrdersForm(currCustomer);
            cof.Show();
        }

        /*Precondition:
         Postcondition: Opens form to create a new order for the current customer*/
        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            NewOrderForm orderForm = new NewOrderForm(null);
            orderForm.setCustomer(currCustomer);
            orderForm.Show();
        }
    }
}
