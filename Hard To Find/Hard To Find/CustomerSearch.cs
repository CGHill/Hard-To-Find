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
        private NewOrderForm orderForm;

        //Constructor
        public CustomerSearch(NewOrderForm orderForm)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            //Initialize globals
            this.orderForm = orderForm;

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
            colFirstName.Width = 140;
            DataGridViewColumn colLastName = dataGridView1.Columns[1];
            colLastName.Width = 160;
            DataGridViewColumn colAdd1 = dataGridView1.Columns[2];
            colLastName.Width = 100;
            DataGridViewColumn colAdd2 = dataGridView1.Columns[3];
            colLastName.Width = 100;
            DataGridViewColumn collCountry = dataGridView1.Columns[4];
            colLastName.Width = 100;
            DataGridViewColumn colEmail = dataGridView1.Columns[5];
            colEmail.Width = 200;
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
            orderForm.setCustomer(selectedCustomer);
            this.Close();
        }

        /*Precondition:
         Postcondition: Send customer back to order form for autofill and close this form*/
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int currRow = dataGridView1.CurrentCell.RowIndex;

            Customer selectedCustomer = foundCustomers[currRow];
            orderForm.setCustomer(selectedCustomer);
            this.Close();
        }

        /*Precondition:
         Postcondition: Cancel customer search*/
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /********************* Keypress handlers to check for enter to start search ************************************/
        private void boxCustID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                startSearch();

                e.Handled = true;
            }
        }

        private void boxFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                startSearch();

                e.Handled = true;
            }
        }

        private void boxLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                startSearch();

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
            btnSelectCustomer.Enabled = false;

            //Check if an ID has been entered and search on that if it has
            if (boxCustID.Text != "")
            {
                int custID = Convert.ToInt32(boxCustID.Text);

                //Put found customer into list
                foundCustomers.Add(dbManager.searchCustomers(custID));

                //Display found customer
                foreach (Customer c in foundCustomers)
                {
                    if (c != null)
                        dataGridView1.Rows.Add(c.firstName, c.lastName, c.address1, c.address2, c.country, c.email);
                }
            }
            else if (boxFirstName.Text != "" || boxLastName.Text != "")//Else if ID hasn't been entered check for first and last name
            {
                string firstName = null;
                string lastName = null;

                //Get names if they have been entered
                if (boxFirstName.Text != "")
                    firstName = boxFirstName.Text;
                if (boxLastName.Text != "")
                    lastName = boxLastName.Text;

                //Search for customers with names entered
                foundCustomers = dbManager.searchCustomers(firstName, lastName);

                //Display found customers
                foreach (Customer c in foundCustomers)
                {
                    dataGridView1.Rows.Add(c.firstName, c.lastName, c.address1, c.address2, c.country, c.email);
                }
            }
        }

        /*Precondition:
         Postcondition: Enables button to look for more details*/
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnSelectCustomer.Enabled = true;
        }

    }
}
