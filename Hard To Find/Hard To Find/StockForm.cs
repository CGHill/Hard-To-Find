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
    public partial class StockForm : Form
    {
        private Form1 form1;
        private DatabaseManager dbManager;

        public StockForm(Form1 form1)
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

        private void btnImportStock_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogBox = new OpenFileDialog();
            dialogBox.Title = "Open Stock txt file";
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

                    if (removedDashes.Contains('\''))
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

                    string[] splitStock = removedDashes.Split('|');

                    int stockID = Convert.ToInt32(splitStock[0]);
                    int quantity;

                    if(splitStock[1] == "")
                        quantity = 0;
                    else
                        quantity = Convert.ToInt32(splitStock[1]);

                    string note = splitStock[2];
                    string author = splitStock[3];
                    string title = splitStock[4];
                    string subtitle = splitStock[5];
                    string publisher = splitStock[6];
                    string description = splitStock[7];
                    string comments = splitStock[8];
                    string location = splitStock[9];
                    string price = splitStock[10];
                    string subject = splitStock[11];
                    string catalogue = splitStock[12];
                    string weight = splitStock[13];
                    string sales = splitStock[14];
                    string bookID = splitStock[15];
                    string enteredBy = splitStock[16];


                    //dbManager.insertCustomer(custID, custFirstName, custLastName, custInstitution, custAddress1, custAddress2, custAddress3, custCountry, custPostCode, custPhone, custFax, custEmail, custComments, custSales, custPayment);
                    listBox1.Items.Add("StockID: " + stockID.ToString() + " Quantity: " + quantity.ToString() + " Note: " + note + " Author: " + author + " Title: " + title + " Subtitle: " + subtitle
                        + " Publisher: " + publisher + " Description: " + description + " Comments: " + comments + " Price: " + price + " Subject: " + subject + " Catalogue: " + catalogue + " Sales: " + sales
                        + " BookID: " + bookID + " Date Entered: " + enteredBy);

                    progressBar1.Increment(1);
                }

                file.Close();
                MessageBox.Show("Finished import");
            }
        }
    }
}
