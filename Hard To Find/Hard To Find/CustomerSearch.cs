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
    public partial class CustomerSearch : Form
    {
        //Globals
        private List<Customer> foundCustomers;
        private DatabaseManager dbManager;
        private ICustomerReceiver customerReceiver;

        //Constructor
        public CustomerSearch(ICustomerReceiver customerReceiver)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            //Initialize globals
            this.customerReceiver = customerReceiver;

            setup();
        }

        /*Precondition:
         Postcondition: Sets up everything needed when form is initialized*/
        private void setup()
        {
            foundCustomers = new List<Customer>();
            dbManager = new DatabaseManager();

            //Set up column widths
            DataGridViewColumn colFirstName = dataGridView1.Columns[0];
            colFirstName.Width = 110;
            DataGridViewColumn colLastName = dataGridView1.Columns[1];
            colLastName.Width = 110;
            DataGridViewColumn colAdd1 = dataGridView1.Columns[2];
            colAdd1.Width = 120;
            DataGridViewColumn colAdd2 = dataGridView1.Columns[3];
            colAdd2.Width = 120;
            DataGridViewColumn colCountry = dataGridView1.Columns[4];
            colCountry.Width = 60;
            DataGridViewColumn colEmail = dataGridView1.Columns[5];
            colEmail.Width = 182;

            //Give focus to firstname box
            boxFirstName.Select();

            //Setup keypress handler for when enter is pressed in textboxes
            boxCustID.KeyPress += TextBox_KeyPress_Enter;
            boxFirstName.KeyPress += TextBox_KeyPress_Enter;
            boxLastName.KeyPress += TextBox_KeyPress_Enter;
            boxInstiution.KeyPress += TextBox_KeyPress_Enter;
            boxEmail.KeyPress += TextBox_KeyPress_Enter;
        }

        /*Precondition:
         Postcondition: Starts a search for customers when button is clicked*/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            startSearch();
        }

        /*Precondition:
         Postcondition: Send customer back to the orders form for autofill and close this form */
        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            int currRow = dataGridView1.CurrentCell.RowIndex;

            Customer selectedCustomer = foundCustomers[currRow];
            customerReceiver.addCustomer(selectedCustomer);
            this.Close();
        }

        /*Precondition:
         Postcondition: Cancel customer search*/
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*Precondition:
         Postcondition: Listens for keypresses no matter which control has focus */
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Close form if user presses escape key
            if (keyData == Keys.Escape)
            {
                this.Close();
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }


        /********************* Event Handlers ************************************/

        /*Precondition:
         Postcondition: Only allows numbers to be entered in textbox */
        private void boxCustID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /*Precondition:
        Postcondition: Handles keypresses for the datagrid by selecting the customer when enter is pressed */
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            //Listen for enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Supress key to stop datagrid moving to the next row
                e.SuppressKeyPress = true;

                try
                {
                    int currRow = dataGridView1.CurrentCell.RowIndex;

                    //Get the customer and pass it back to the form that needs it
                    Customer selectedCustomer = foundCustomers[currRow];
                    customerReceiver.addCustomer(selectedCustomer);
                    this.Close();
                }
                catch (NullReferenceException)
                {
                    //User hit enter on datagrid when nothing was searched
                }
            }
        }

        /*Precondition:
         Postcondition: Keypress handler for all textboxes. Starts the search for customers */
        private void TextBox_KeyPress_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                startSearch();

                //Stops the windows noise
                e.Handled = true;
            }
        }
        /**************************************************************************************************************/


        /*Precondition:
         Postcondition: Runs a search based on what information was entered by user*/
        private void startSearch()
        {
            //Reset datagrid and foundcustomers so searches don't stack
            foundCustomers = new List<Customer>();
            dataGridView1.Rows.Clear();
            bool customersFound = false;



            //Check if an ID has been entered and search on that if it has
            if (boxCustID.Text != "")
            {
                int custID = Convert.ToInt32(boxCustID.Text);

                //Put found customer into list
                foundCustomers.Add(dbManager.searchCustomers(custID));

                labResults.Text = foundCustomers.Count.ToString();

                //Display found customer
                foreach (Customer c in foundCustomers)
                {
                    if (c != null)
                    {
                        labResults.Text = foundCustomers.Count.ToString();
                        customersFound = true;
                        dataGridView1.Rows.Add(c.firstName, c.lastName, c.address1, c.address2, c.country, c.email);
                        dataGridView1.Focus();
                    }
                    else
                        labResults.Text = "0";
                }
            }
            else if (boxFirstName.Text != "" || boxLastName.Text != "" || boxInstiution.Text != "" || boxEmail.Text != "")//Else if ID hasn't been entered check for first and last name
            {
                string firstName = null;
                string lastName = null;
                string instutution = null;
                string email = null;

                //Check if the user wants the name to match exactly what they typed
                bool exactName = checkExactName.Checked;

                //Get names if they have been entered
                if (boxFirstName.Text != "")
                    firstName = boxFirstName.Text;
                if (boxLastName.Text != "")
                    lastName = boxLastName.Text;
                if (boxInstiution.Text != "")
                    instutution = boxInstiution.Text;
                if (boxEmail.Text != "")
                    email = boxEmail.Text;

                //Search for customers with names entered
                foundCustomers = dbManager.searchCustomers(firstName, lastName, instutution, email, exactName);

                labResults.Text = foundCustomers.Count.ToString();

                if (foundCustomers.Count > 0)
                {
                    customersFound = true;
                    foundCustomers = foundCustomers.OrderBy(x => x.firstName).ToList();

                    //Display found customers
                    foreach (Customer c in foundCustomers)
                    {
                        dataGridView1.Rows.Add(c.firstName, c.lastName, c.address1, c.address2, c.country, c.email);
                    }

                    dataGridView1.Focus();
                }
            }

            if (!customersFound)
            {
                dataGridView1.Rows.Add("No customer found", "", "", "", "", "");
            }
        }

        /*Precondition:
         Postcondition: Enables button to look for more details*/
        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            btnSelectCustomer.Enabled = true;
        }

        /*Precondition:
        Postcondition: Send customer back to order form for autofill and close this form*/
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int currRow = dataGridView1.CurrentCell.RowIndex;

                Customer selectedCustomer = foundCustomers[currRow];
                customerReceiver.addCustomer(selectedCustomer);
                this.Close();
            }
            catch (NullReferenceException)
            {
                //User clicked on header
            }
        }

       
    }
}
