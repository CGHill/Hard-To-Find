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
        private NewOrderForm nof;
        private bool tabPress;

        //Constructor
        public NewCustomerForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            setup();
        }

        /*Precondition:
         Postcondition: Sets up and initialises everything needed */
        private void setup()
        {
            dbManager = new DatabaseManager();
            nof = null;
            tabPress = false;
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
            string firstName = SyntaxHelper.escapeSingleQuotes(boxFirstName.Text);
            string lastName = SyntaxHelper.escapeSingleQuotes(boxLastName.Text);
            string institution = SyntaxHelper.escapeSingleQuotes(boxInstitution.Text);
            string address1 = SyntaxHelper.escapeSingleQuotes(boxAddress1.Text);
            string address2 = SyntaxHelper.escapeSingleQuotes(boxAddress2.Text);
            string address3 = SyntaxHelper.escapeSingleQuotes(boxAddress3.Text);
            string postcode = SyntaxHelper.escapeSingleQuotes(boxPostcode.Text);
            string country = SyntaxHelper.escapeSingleQuotes(boxCountry.Text);
            string email = SyntaxHelper.escapeSingleQuotes(boxEmail.Text);
            string comments = SyntaxHelper.escapeSingleQuotes(boxComments.Text);
            string sales = SyntaxHelper.escapeSingleQuotes(boxSales.Text);
            string payment = SyntaxHelper.escapeSingleQuotes(boxPayment.Text);

            //Check that the basic things haven't been left empty so a blank customer isn't saved
            if (firstName != "" || lastName != "" || address1 != "" || address2 != "" || address3 != "")
            {
                Customer newCustomer = new Customer(firstName, lastName, institution, address1, address2, address3, country, postcode, email, comments, sales, payment);

                dbManager.insertCustomer(newCustomer);

                //If not null then it was created from the new order form, so send customer back to that
                if (nof != null)
                {
                    nof.addCustomer(newCustomer);
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Not enough information entered");
            }
        }

        /*Precondition: 
          Postcondition: Set the form to send the new customer back to */
        public void setNewOrderForm(NewOrderForm nof)
        {
            this.nof = nof;
        }

        /*Precondition:
         Postcondition: Listens for keypresses no matter which control has focus */
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Listen for tab key
            if (keyData == Keys.Tab)
            {
                tabPress = true;
                return false;    // indicate that you handled this keystroke
            }
            //Listen for shift+tab being pressed
            if (keyData == (Keys.Tab | Keys.Shift))
            {
                tabPress = true;
                return false;    // indicate that you handled this keystroke
            }
            //Close form when escape is pressed 
            if (keyData == Keys.Escape)
            {
                this.Close();
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /*Precondition:
         Postcondition: Handler for when textboxes gain focus to see if the text needs to be selected or not */
        private void textbox_Enter(Object sender, EventArgs e)
        {
            if (tabPress)
            {
                TextBox enteredTextbox = (TextBox)sender;

                enteredTextbox.SelectAll();

                tabPress = false;
            }
        }
    }
}
