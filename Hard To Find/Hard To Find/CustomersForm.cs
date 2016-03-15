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
            boxCustID.Text = currCustomer.custID.ToString();
            boxFirstName.Text = currCustomer.firstName;
            boxLastName.Text = currCustomer.lastName;
            boxInstitution.Text = currCustomer.institution;
            boxAddress1.Text = currCustomer.address1;
            boxAddress2.Text = currCustomer.address2;
            boxAddress3.Text = currCustomer.address3;
            boxPostcode.Text = currCustomer.postCode;
            boxCountry.Text = currCustomer.country;
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
            currCustomer.firstName = SQLSyntaxHelper.escapeSingleQuotes(boxFirstName.Text);
            currCustomer.lastName = SQLSyntaxHelper.escapeSingleQuotes(boxLastName.Text);
            currCustomer.institution = SQLSyntaxHelper.escapeSingleQuotes(boxInstitution.Text);
            currCustomer.address1 = SQLSyntaxHelper.escapeSingleQuotes(boxAddress1.Text);
            currCustomer.address2 = SQLSyntaxHelper.escapeSingleQuotes(boxAddress2.Text);
            currCustomer.address3 = SQLSyntaxHelper.escapeSingleQuotes(boxAddress3.Text);
            currCustomer.postCode = SQLSyntaxHelper.escapeSingleQuotes(boxPostcode.Text);
            currCustomer.country = SQLSyntaxHelper.escapeSingleQuotes(boxCountry.Text);
            currCustomer.email = SQLSyntaxHelper.escapeSingleQuotes(boxEmail.Text);
            currCustomer.comments = SQLSyntaxHelper.escapeSingleQuotes(boxComments.Text);
            currCustomer.sales = SQLSyntaxHelper.escapeSingleQuotes(boxSales.Text);
            currCustomer.payment = SQLSyntaxHelper.escapeSingleQuotes(boxPayment.Text);

            //Send to dbManager to update entry
            dbManager.updateCustomer(currCustomer);
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
