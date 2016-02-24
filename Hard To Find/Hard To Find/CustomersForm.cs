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
        //Variables
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
            currCustomer.firstName = boxFirstName.Text;
            currCustomer.lastName = boxLastName.Text;
            currCustomer.institution = boxInstitution.Text;
            currCustomer.address1 = boxAddress1.Text;
            currCustomer.address2 = boxAddress2.Text;
            currCustomer.address3 = boxAddress3.Text;
            currCustomer.postCode = boxPostcode.Text;
            currCustomer.country = boxCountry.Text;
            currCustomer.phone = boxPhone.Text;
            currCustomer.fax = boxFax.Text;
            currCustomer.email = boxEmail.Text;
            currCustomer.comments = boxComments.Text;
            currCustomer.sales = boxSales.Text;
            currCustomer.payment = boxPayment.Text;

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
    }
}
