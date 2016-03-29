﻿using System;
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


        /********************* Keypress handlers to check for enter to start search ************************************/
        private void boxCustID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

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
                    else
                        dataGridView1.Rows.Add("No customer found", "", "", "", "", "");
                }
            }
            else if (boxFirstName.Text != "" || boxLastName.Text != "")//Else if ID hasn't been entered check for first and last name
            {
                string firstName = null;
                string lastName = null;

                //Get names if they have been entered
                if (boxFirstName.Text != "")
                    firstName = SQLSyntaxHelper.escapeSingleQuotes(boxFirstName.Text);
                if (boxLastName.Text != "")
                    lastName = SQLSyntaxHelper.escapeSingleQuotes(boxLastName.Text);

                //Search for customers with names entered
                foundCustomers = dbManager.searchCustomers(firstName, lastName);

                if (foundCustomers.Count == 0)
                {
                    dataGridView1.Rows.Add("No customer found", "", "", "", "", "");
                }
                else
                {
                    //Display found customers
                    foreach (Customer c in foundCustomers)
                    {
                        dataGridView1.Rows.Add(c.firstName, c.lastName, c.address1, c.address2, c.country, c.email);
                    }
                }
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
            int currRow = dataGridView1.CurrentCell.RowIndex;

            Customer selectedCustomer = foundCustomers[currRow];
            customerReceiver.addCustomer(selectedCustomer);
            this.Close();
        }
    }
}
