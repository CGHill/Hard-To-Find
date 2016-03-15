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
    public partial class CustomerSearchForm : Form
    {
        //Variables
        private Form1 form1;
        private DatabaseManager dbManager;
        private List<Customer> foundCustomers;
        private List<Customer> allCustomers;

        //Constructor
        public CustomerSearchForm(Form1 form1)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.form1 = form1;

            //Intialization of globals
            dbManager = new DatabaseManager();
            foundCustomers = new List<Customer>();
            allCustomers = new List<Customer>();

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
         Postcondition: Return back to the main menu*/
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            form1.Show();
            form1.TopMost = true;
        }

        /*Precondition:
         Postcondition: Starts a search for customers depending on what search boxes have been filled in*/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            startSearch();
        }

        /*Precondition:
         Postcondition: Only allows numbers to be entered into ID textbox*/
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

        /*Precondition: Can't be called until something has been selected in datagrid
         Postcondition: Opens up new form to display further customer details*/
        private void btnCustDetails_Click(object sender, EventArgs e)
        {
            int currRow = dataGridView1.CurrentCell.RowIndex;

            Customer customerToDisplay = foundCustomers[currRow];

            CustomersForm cf = new CustomersForm(customerToDisplay);
            cf.Show();
        }

        /*Precondition: Customer CSV order = ID, first name, last name, institution, address1, address2, address3, country, postcode, phone, fax, email, comments, sales, payment
         Postcondition: Starts the import process to move customers from a csv text file into the SQLite database*/
        private void btnImportCustomers_Click(object sender, EventArgs e)
        {

            //Set up file browser, to search for txt files and default directory of C: drive
            OpenFileDialog dialogBox = new OpenFileDialog();
            dialogBox.Title = "Open Customer txt file";
            dialogBox.Filter = "TXT files|*.txt";
            dialogBox.InitialDirectory = @"C:\";

            //Open the file browser and wait for user to select file
            if (dialogBox.ShowDialog() == DialogResult.OK)
            {
                //Get the path for the file the user clicked on
                string filename = dialogBox.FileName;

                if (filename.Contains("\\Customers.txt"))
                {
                    try
                    {
                        allCustomers = new List<Customer>();

                        //Open the file
                        System.IO.StreamReader file = new System.IO.StreamReader(filename);

                        string line;
                        string[] previousLine = new string[1];

                        //Read through the txt file one line at a time
                        while ((line = file.ReadLine()) != null)
                        {
                            //Remove double quotations for SQL insert
                            string unquoted = line.Replace("\"", string.Empty);

                            unquoted = SQLSyntaxHelper.escapeSingleQuotes(unquoted);

                            //Split on comma to get all values of customer
                            string[] splitCustomer = unquoted.Split('|');

                            int custID = Convert.ToInt32(splitCustomer[0]);
                            string custFirstName = splitCustomer[1];
                            string custLastName = splitCustomer[2];
                            string custInstitution = splitCustomer[3];
                            string custAddress1 = splitCustomer[4];
                            string custAddress2 = splitCustomer[5];
                            string custAddress3 = splitCustomer[6];
                            string custCountry = splitCustomer[7];
                            string custPostCode = splitCustomer[8];
                            string custEmail = splitCustomer[11];
                            string custComments = splitCustomer[12];
                            string custSales = splitCustomer[13];
                            string custPayment = splitCustomer[14];

                            //Create new customer and insert into list
                            Customer newCust = new Customer(custID, custFirstName, custLastName, custInstitution, custAddress1, custAddress2, custAddress3, custCountry, custPostCode, custEmail, custComments, custSales, custPayment);
                            allCustomers.Add(newCust);
                        }

                        //Close txt file
                        file.Close();

                        //TODO find a better place for this?
                        dbManager.dropCustomerTable();
                        dbManager.createCustomerTable();

                        //Insert customers from list into DB
                        progressBar1.Visible = true;
                        dbManager.insertCustomers(allCustomers, progressBar1);
                        progressBar1.Visible = false;
                        MessageBox.Show("Finished import");
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Error: File was formatted incorrectly");
                    }
                    catch (IndexOutOfRangeException)
                    {
                        MessageBox.Show("Error: File was formatted incorrectly");
                    }
                }
                else
                {
                    MessageBox.Show("Error: Wrong file selected");
                }
            }
        }

        /*Precondition:
         Postcondition: Open form to create a new customer*/
        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            NewCustomerForm ncf = new NewCustomerForm();
            ncf.Show();
        }

        /*Precondition:
         Postcondition: Starts a search for customers depending on what search boxes have been filled in*/
        private void startSearch()
        {
            //Reset datagrid and foundcustomers so searches don't stack
            foundCustomers = new List<Customer>();
            dataGridView1.Rows.Clear();
            btnCustDetails.Enabled = false;

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
                    firstName = SQLSyntaxHelper.escapeSingleQuotes(boxFirstName.Text);
                if (boxLastName.Text != "")
                    lastName = SQLSyntaxHelper.escapeSingleQuotes(boxLastName.Text);

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
        Postcondition: Enables details button when entry is selected in datagrid*/
        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            btnCustDetails.Enabled = true;
        }

        /*Precondition:
         Postcondition: Open up form for customer details that was double clicked on*/
        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int currRow = dataGridView1.CurrentCell.RowIndex;

                Customer customerToDisplay = foundCustomers[currRow];

                CustomersForm cf = new CustomersForm(customerToDisplay);
                cf.Show();
            }
            catch (NullReferenceException)
            {
                //Do nothing, user double clicked on header of datagrid
            }
        }


        /************ Keypress handlers to check for enter to start search ***********/
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
        /*****************************************************************************/
    }
}
