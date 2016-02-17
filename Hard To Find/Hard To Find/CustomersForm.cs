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
        Form1 form1;
        DatabaseManager dbManager;

        public CustomersForm(Form1 form1)
        {
            this.form1 = form1;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            dbManager = new DatabaseManager();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            form1.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            toggleBoxesReadOnly();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

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

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogBox = new OpenFileDialog();
            dialogBox.Title = "Open Customer txt file";
            dialogBox.Filter = "TXT files|*.txt";
            dialogBox.InitialDirectory = @"C:\";

            if (dialogBox.ShowDialog() == DialogResult.OK)
            {
                dbManager.createTables();
                string filename = dialogBox.FileName;

                System.IO.StreamReader file = new System.IO.StreamReader(filename);

                string line;
                string[] previousLine = new string[1];
                while ((line = file.ReadLine()) != null)
                {
                    string unquoted = line.Replace("\"", string.Empty);
                    string removedDashes = unquoted.Replace("-", " ");
                    
                    if(removedDashes.Contains('\''))
                    {
                        int numQuotes = removedDashes.Split('\'').Length - 1;
                        //int num = removedDashes.Count(c => c == '\'');

                        int previousIndex = 0;

                        for (int i = 0; i < numQuotes; i++)
                        {
                            int indexOfQuote = removedDashes.IndexOf("'", previousIndex);
                            removedDashes = removedDashes.Insert(indexOfQuote, "'");

                            previousIndex = indexOfQuote + 2;
                        }
                       
                    }

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


                    dbManager.insertCustomer(custID, custFirstName, custLastName, custInstitution, custAddress1, custAddress2, custAddress3, custCountry, custPostCode, custPhone, custFax, custEmail, custComments, custSales, custPayment);
                        /*listBox1.Items.Add("CustID: " + custID.ToString() + " FirstName: " + custFirstName + " LastName: " + custLastName + " Institution: " + custInstitution + " Address1: " + custAddress1 + " Address2: " + custAddress2
                            + " Address3: " + custAddress3 + " Country: " + custCountry + " PostCode: " + custPostCode + " Phone: " + custPhone + " Fax: " + custFax + " Email: " + custEmail + " Comments: " + custComments
                            + " Sales: " + custSales + " Payment: " + custPayment);*/

                    progressBar1.Increment(1);
                }

                file.Close();
                MessageBox.Show("Finished import");
            }
        }
    }
}
