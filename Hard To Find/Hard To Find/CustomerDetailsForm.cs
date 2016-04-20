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
    public partial class CustomerDetailsForm : Form
    {
        //Globals
        private DatabaseManager dbManager;
        private Customer currCustomer;
        private Form previousForm;
        private bool tabPress;

        //Constructor
        public CustomerDetailsForm(Customer currCustomer, Form previousForm)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            this.currCustomer = currCustomer;
            this.previousForm = previousForm;

            setup();
        }

        /*Precondition:
         Postcondition: Setup and initialize everything needed */
        private void setup()
        {
            //Create instance of database manager and list for storing customers
            dbManager = new DatabaseManager();
            tabPress = false;

            //Setup Event Handler for textboxes to highlight text when they are entered if tab was pressed
            boxCustID.Enter += textbox_Enter;
            boxFirstName.Enter += textbox_Enter;
            boxLastName.Enter += textbox_Enter;
            boxInstitution.Enter += textbox_Enter;
            boxAddress1.Enter += textbox_Enter;
            boxAddress2.Enter += textbox_Enter;
            boxAddress3.Enter += textbox_Enter;
            boxPostcode.Enter += textbox_Enter;
            boxCountry.Enter += textbox_Enter;
            boxEmail.Enter += textbox_Enter;
            boxComments.Enter += textbox_Enter;
            boxSales.Enter += textbox_Enter;
            boxPayment.Enter += textbox_Enter;

            //Fill in the texboxes with customers data
            loadUpCustomer();

            //Move focus onto button
            btnCustomersOrders.Select();
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
            currCustomer.firstName = SyntaxHelper.escapeSingleQuotes(boxFirstName.Text);
            currCustomer.lastName = SyntaxHelper.escapeSingleQuotes(boxLastName.Text);
            currCustomer.institution = SyntaxHelper.escapeSingleQuotes(boxInstitution.Text);
            currCustomer.address1 = SyntaxHelper.escapeSingleQuotes(boxAddress1.Text);
            currCustomer.address2 = SyntaxHelper.escapeSingleQuotes(boxAddress2.Text);
            currCustomer.address3 = SyntaxHelper.escapeSingleQuotes(boxAddress3.Text);
            currCustomer.postCode = SyntaxHelper.escapeSingleQuotes(boxPostcode.Text);
            currCustomer.country = SyntaxHelper.escapeSingleQuotes(boxCountry.Text);
            currCustomer.email = SyntaxHelper.escapeSingleQuotes(boxEmail.Text);
            currCustomer.comments = SyntaxHelper.escapeSingleQuotes(boxComments.Text);
            currCustomer.sales = SyntaxHelper.escapeSingleQuotes(boxSales.Text);
            currCustomer.payment = SyntaxHelper.escapeSingleQuotes(boxPayment.Text);

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
            previousForm.Activate();
        }

        /*Precondition:
         Postcondition: Listens for keypress no matter which control has focus */
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Close form when escape is pressed
            if (keyData == Keys.Escape)
            {
                this.Close();
                previousForm.Activate();
            }
            //Check for tab pressed
            if (keyData == Keys.Tab)
            {
                tabPress = true;
                return false;    // indicate that you handled this keystroke
            }
            //Check for shift+tab pressed
            if (keyData == (Keys.Tab | Keys.Shift))
            {
                tabPress = true;
                return false;    // indicate that you handled this keystroke
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /*Precondition:
         Postcondition: Handles all the textboxes when they get focus to check if the text in them needs to be selected or not */
        private void textbox_Enter(Object sender, EventArgs e)
        {
            if (tabPress)
            {
                TextBox enteredTextbox = (TextBox)sender;

                enteredTextbox.SelectAll();

                tabPress = false;
            }
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
            orderForm.addCustomer(currCustomer);
            orderForm.Show();
        }
    }
}
