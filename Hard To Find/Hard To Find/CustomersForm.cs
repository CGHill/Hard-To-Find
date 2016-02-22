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
        private Form1 form1;
        private DatabaseManager dbManager;
        private List<Customer> customers;

        //Constructor
        public CustomersForm(Form1 form1)
        {
            this.form1 = form1;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            //Create instance of database manager and list for storing customers
            dbManager = new DatabaseManager();
            customers = new List<Customer>();
        }

        /*Precondition:
         Postcondition: Button to go back to main menu*/
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            form1.Show();
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
        }


        /*Precondition: None
         Postcondition: Toggles textboxes ReadOnly between true and false so that customer data can be updated */
        private void toggleBoxesReadOnly()
        {
            boxInstitution.ReadOnly = !boxInstitution.ReadOnly;
            boxAddress.ReadOnly = !boxAddress.ReadOnly;
            boxSuburb.ReadOnly = !boxSuburb.ReadOnly;
            boxCity.ReadOnly = !boxCity.ReadOnly;
            boxPostcode.ReadOnly = !boxPostcode.ReadOnly;
            boxCountry.ReadOnly = !boxCountry.ReadOnly;
            boxPhone.ReadOnly = !boxPhone.ReadOnly;
            boxFax.ReadOnly = !boxFax.ReadOnly;
            boxEmail.ReadOnly = !boxEmail.ReadOnly;
            boxComments.ReadOnly = !boxComments.ReadOnly;
            boxSales.ReadOnly = !boxSales.ReadOnly;
            boxPayment.ReadOnly = !boxPayment.ReadOnly;
        }

        /*Precondition: txt file must be formatted as a CSV in order of CustomerID, firstName, lastName, institution, address1, address2, address3, country, postcode, phone, fax, emails, comments, sales, payment
         Postcondition: Opens file browser for user to select a txt file to import customers*/
        private void btnImport_Click(object sender, EventArgs e)
        {
            //Set up file browser, to search for txt files and default directory of C: drive
            OpenFileDialog dialogBox = new OpenFileDialog();
            dialogBox.Title = "Open Customer txt file";
            dialogBox.Filter = "TXT files|*.txt";
            dialogBox.InitialDirectory = @"C:\";

            //Open the file browser and wait for user to select file
            if (dialogBox.ShowDialog() == DialogResult.OK)
            {
                //TODO find a place for this
                dbManager.createTables();

                //Get the path for the file the user clicked on
                string filename = dialogBox.FileName;

                //Open the file
                System.IO.StreamReader file = new System.IO.StreamReader(filename);

                string line;
                string[] previousLine = new string[1];

                //Read through the txt file one line at a time
                while ((line = file.ReadLine()) != null)
                {
                    //Remove double quotations for SQL insert
                    string unquoted = line.Replace("\"", string.Empty);

                    //Remove dashes for SQL insert
                    string removedDashes = unquoted.Replace("-", " ");
                    
                    //Check if there are any single quotations
                    if(removedDashes.Contains('\''))
                    {
                        //Get number of single quotations
                        int numQuotes = removedDashes.Split('\'').Length - 1;
                        //int num = removedDashes.Count(c => c == '\'');

                        int previousIndex = 0;

                        //Add another quotation behind existing quotations since it's the escape character for the SQL insert
                        for (int i = 0; i < numQuotes; i++)
                        {
                            int indexOfQuote = removedDashes.IndexOf("'", previousIndex);
                            removedDashes = removedDashes.Insert(indexOfQuote, "'");

                            //Move index ahead of just completed quotation so it doesn't repeat on it
                            previousIndex = indexOfQuote + 2;
                        }
                       
                    }

                    //Split on comma to get all values of customer
                    string[] splitCustomer = removedDashes.Split(',');

                    int custID = Convert.ToInt32(splitCustomer[0]);
                    string custFirstName = splitCustomer[1];
                    string custLastName = splitCustomer[2];
                    string custInstitution = splitCustomer[3];
                    string custAddress1 = splitCustomer[4];
                    string custAddress2 = splitCustomer[5];
                    string custAddress3 = splitCustomer[6];
                    string custCountry = splitCustomer[7];
                    string custPostCode = splitCustomer[8];
                    string custPhone = splitCustomer[9];
                    string custFax = splitCustomer[10];
                    string custEmail = splitCustomer[11];
                    string custComments = splitCustomer[12];
                    string custSales = splitCustomer[13];
                    string custPayment = splitCustomer[14];

                    //Create new customer and insert into list
                    Customer newCust = new Customer(custID, custFirstName, custLastName, custInstitution, custAddress1, custAddress2, custAddress3, custCountry, custPostCode, custPhone, custFax, custEmail, custComments, custSales, custPayment);
                    customers.Add(newCust);
                }

                //Close txt file
                file.Close();

                //Insert customers from list into DB
                dbManager.insertCustomers(customers, progressBar1);
                MessageBox.Show("Finished import");
            }
        }
    }
}
