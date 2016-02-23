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
    public partial class CustomerSearchForm : Form
    {
        private Form1 form1;
        private DatabaseManager dbManager;

        public CustomerSearchForm(Form1 form1)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.form1 = form1;

            dbManager = new DatabaseManager();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            form1.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (boxCustID.Text != "")
            {
                int custID = Convert.ToInt32(boxCustID.Text);

                Customer foundCustomer = dbManager.searchCustomers(custID);

                boxCustomerSearchResults.Items.Add("Name: " + foundCustomer.firstName + " " + foundCustomer.lastName + ", Email: " + foundCustomer.email);
            }

            //First name entered but not last name
            else if (boxFirstName.Text != "" && boxLastName.Text == "")
            {
                string firstName = boxFirstName.Text;

                List<Customer> foundCustomers = dbManager.searchCustomers(firstName);

                foreach(Customer c in foundCustomers)
                    boxCustomerSearchResults.Items.Add("Name: " + c.firstName + " " + c.lastName + ", Email: " + c.email);
            }
            //Last name entered but not first name
            else if (boxFirstName.Text == "" && boxLastName.Text != "")
            {
            }
            //Both first and last name entered
            else if (boxFirstName.Text == "" && boxLastName.Text == "")
            {
            }
        }

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
        }
    }
}
