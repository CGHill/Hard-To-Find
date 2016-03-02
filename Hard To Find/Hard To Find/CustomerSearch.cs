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
            foundCustomers = new List<Customer>();
            dbManager = new DatabaseManager();

            //Set up column widths
            DataGridViewColumn column1 = dataGridView1.Columns[0];
            column1.Width = 160;
            DataGridViewColumn column2 = dataGridView1.Columns[1];
            column2.Width = 160;
            DataGridViewColumn column3 = dataGridView1.Columns[2];
            column3.Width = 270;
        }

        /*Precondition:
         Postcondition: Starts a search for customers depending on what search boxes have been filled in*/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Reset datagrid and foundcustomers so searches don't stack
            foundCustomers = new List<Customer>();
            dataGridView1.Rows.Clear();

            //Check if an ID has been entered and search on that if it has
            if (boxCustID.Text != "")
            {
                int custID = Convert.ToInt32(boxCustID.Text);

                //Put found customer into list
                foundCustomers.Add(dbManager.searchCustomers(custID));

                //Display found customer
                foreach (Customer c in foundCustomers)
                {
                    dataGridView1.Rows.Add(c.firstName, c.lastName, c.email);
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
                    dataGridView1.Rows.Add(c.firstName, c.lastName, c.email);
                }
            }
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
    }
}
