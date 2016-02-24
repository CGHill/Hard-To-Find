using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Hard_To_Find
{
    public partial class StockForm : Form
    {
        //Variables
        private Form1 form1;
        private DatabaseManager dbManager;
        private List<Stock> allStock;
        private List<Stock> foundStock;

        //Constructor
        public StockForm(Form1 form1)
        {
            this.form1 = form1;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            //Create DB and list to store stock in
            dbManager = new DatabaseManager();
            allStock = new List<Stock>();

            DataGridViewColumn column1 = dataGridView1.Columns[0];
            column1.Width = 50;
            DataGridViewColumn column2 = dataGridView1.Columns[1];
            column2.Width = 200;
            DataGridViewColumn column3 = dataGridView1.Columns[2];
            column3.Width = 300;
            DataGridViewColumn column4 = dataGridView1.Columns[3];
            column4.Width = 200;
            DataGridViewColumn column5 = dataGridView1.Columns[4];
            column5.Width = 60;
            DataGridViewColumn column6 = dataGridView1.Columns[5];
            column6.Width = 75;
        }

        /*Precondition: 
         Postcondition: Go back to main menu*/
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            form1.Show();
        }


        /*Precondition: 
         Postcondition: Opens file browser for user to select a txt file to import stock*/
        private void btnImportStock_Click(object sender, EventArgs e)
        {
            //Set up file browser, to search for txt files and default directory of C: drive
            OpenFileDialog dialogBox = new OpenFileDialog();
            dialogBox.Title = "Open Stock txt file";
            dialogBox.Filter = "TXT files|*.txt";
            dialogBox.InitialDirectory = @"C:\";

            //Open the file browser and wait for user to select file
            if (dialogBox.ShowDialog() == DialogResult.OK)
            {
                //TODO find place for this
                dbManager.dropStockTable();
                dbManager.createStockTable();

                //Get the path for the file the user clicked on
                string filename = dialogBox.FileName;

                //Continue the procress in another method
                readFile(filename);

                //Thread thread = new Thread(() => readFile(filename));
                //thread.Start();
            }
        }

        /*Precondition: txt file must be formatted as a CSV separated by a | instead of , in order of:
          stockID, quantity, note, author, title, subtitle, publisher, description, comments, location, price, subject, catalogues, weight, sales, bookID, dateEntered
         Postcondition: Opens file browser for user to select a txt file to import stock*/
        private void readFile(string fileName)
        {
            //Open file from passed in path
            System.IO.StreamReader file = new System.IO.StreamReader(fileName);

            string line;
            string[] previousLine = new string[1];
            bool newLineCharacter = false;

            //Read through the whole file 1 line at a time
            while ((line = file.ReadLine()) != null)
            {
                //Remove double quotations from line for SQL insert
                string unquoted = line.Replace("\"", string.Empty);

                //Remove dashes from line for SQL insert
                string removedDashes = unquoted.Replace("-", string.Empty);

                //Check if it contains a single quotation
                if (removedDashes.Contains('\''))
                {
                    //Get number of single quotations
                    int numQuotes = removedDashes.Split('\'').Length - 1;
                    //int num = removedDashes.Count(c => c == '\'');

                    int previousIndex = 0;

                    //Loop over quotations
                    for (int i = 0; i < numQuotes; i++)
                    {
                        //Insert quotation before existing one because it's an escape character in SQLite
                        int indexOfQuote = removedDashes.IndexOf("'", previousIndex);
                        removedDashes = removedDashes.Insert(indexOfQuote, "'");

                        //Move index after quotation that was just fixed to stop repeating on the same one
                        previousIndex = indexOfQuote + 2;
                    }

                }

                //Split on | instead of comma because Stock entries can contain commas
                string[] splitStock = removedDashes.Split('|');

                //Importing from the old Access database contain a lot of new line characters
                //Check if current line contains all of the columns
                if (splitStock.Length < 17)
                {
                    //If previous line had a new line character in it
                    if (newLineCharacter)
                    {
                        //Check that it wasn't a second new line character by seeing if it's columns + the previous lines columns = the number needed
                        if ((splitStock.Length + previousLine.Length - 1) == 17)
                        {
                            //Go through and combined the lines into 1
                            string[] combinedLines = new string[17];
                            int combinedLineIndex = 0;

                            for (int i = 0; i < previousLine.Length; i++)
                            {
                                combinedLines[combinedLineIndex] = previousLine[i];
                                combinedLineIndex++;
                            }

                            for (int i = 0; i < splitStock.Length; i++)
                            {
                                if (i == 0)
                                {
                                    combinedLineIndex--;
                                    combinedLines[combinedLineIndex] = combinedLines[combinedLineIndex] + ", " + splitStock[i];
                                }
                                else
                                {
                                    combinedLines[combinedLineIndex] = splitStock[i];
                                }
                                combinedLineIndex++;
                            }

                            //Pull out all of the columns
                            int stockID = Convert.ToInt32(combinedLines[0]);
                            int quantity;

                            if (combinedLines[1] == "")
                                quantity = 0;
                            else
                                quantity = Convert.ToInt32(combinedLines[1]);

                            string note = combinedLines[2];
                            string author = combinedLines[3];
                            string title = combinedLines[4];
                            string subtitle = combinedLines[5];
                            string publisher = combinedLines[6];
                            string description = combinedLines[7];
                            string comments = combinedLines[8];
                            string location = combinedLines[9];
                            string price = combinedLines[10];
                            string subject = combinedLines[11];
                            string catalogue = combinedLines[12];
                            string weight = combinedLines[13];
                            string sales = combinedLines[14];
                            string bookID = combinedLines[15];
                            string enteredBy = combinedLines[16];

                            //Create a new stock entry from it and insert into list
                            Stock newStock = new Stock(stockID, quantity, note, author, title, subtitle, publisher, description, comments, location, price, subject, catalogue, weight, sales, bookID, enteredBy);
                            allStock.Add(newStock);

                            /*this.Invoke((MethodInvoker)delegate
                            {
                                listBox1.Items.Add("StockID: " + stockID.ToString() + " Quantity: " + quantity.ToString() + " Note: " + note + " Author: " + author + " Title: " + title + " Subtitle: " + subtitle
                               + " Publisher: " + publisher + " Description: " + description + " Comments: " + comments + " Price: " + price + " Subject: " + subject + " Catalogue: " + catalogue + " Sales: " + sales
                               + " BookID: " + bookID + " Date Entered: " + enteredBy);
                            });*/

                            //Reset values
                            newLineCharacter = false;
                            previousLine = new string[1];
                        }
                    }
                    else     //Was the first new line character and need to search for the rest of the line
                    {
                        //Update values to start searching for the rest of the line
                        newLineCharacter = true;
                        previousLine = splitStock;
                    }
                }
                else     //Else a normal line
                {
                    //Pull out all of the columns
                    int stockID = Convert.ToInt32(splitStock[0]);
                    int quantity;

                    if (splitStock[1] == "")
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

                    //Create a newStock entry and insert into list
                    Stock newStock = new Stock(stockID, quantity, note, author, title, subtitle, publisher, description, comments, location, price, subject, catalogue, weight, sales, bookID, enteredBy);
                    allStock.Add(newStock);
                }
            }
            //Close text file
            file.Close();

            //Insert all of the new stock into the database
            dbManager.insertStock(allStock, progressBar1);

            //Inform user that the process has been finished
            MessageBox.Show("Finished import");
        }


        /*Precondition:
         Postcondition: Starts search for Stock depending on which text boxes have been filled*/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Reset datagrid and stock for new search
            foundStock = new List<Stock>();
            dataGridView1.Rows.Clear();

            //If ID was entered then search only on that
            if (boxStockID.Text != "")
            {
                int stockID = Convert.ToInt32(boxStockID.Text);

                //Put found stock into list
                foundStock.Add(dbManager.searchStock(stockID));

                //Display found stock
                foreach (Stock s in foundStock)
                {
                    dataGridView1.Rows.Add(s.quantity, s.author, s.title, s.subtitle, s.price, s.bookID);
                }
            }
            else if(boxAuthor.Text != "" || boxTitle.Text != "" || boxSubject.Text != "") //ID wasn't entered, search if any other fields have been filled
            {
                string author = null;
                string title = null;
                string subject = null;

                //Find out which fields have been entered to be included in the search
                if (boxAuthor.Text != "")
                    author = boxAuthor.Text;
                if (boxTitle.Text != "")
                    title = boxTitle.Text;
                if (boxSubject.Text != "")
                    subject = boxSubject.Text;

                //Search for stock based on the parameters entered
                foundStock = dbManager.searchStock(author, title, subject);

                //Display found stock
                foreach (Stock s in foundStock)
                {
                    dataGridView1.Rows.Add(s.quantity, s.author, s.title, s.subtitle, s.price, s.bookID);
                }
            }
        }

        /*Precondition:
         Postcondition: Enables button to view more details about stock */
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnStockDetails.Enabled = true;
        }

        /*Precondition:
         Postcondition: Allows only numbers in ID text box */
        private void boxStockID_KeyPress(object sender, KeyPressEventArgs e)
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

        /*Precondition: Requires something be selected in the datagrid first
         Postcondition: Opens form to display futher details about stock*/
        private void btnStockDetails_Click(object sender, EventArgs e)
        {
            int currRow = dataGridView1.CurrentCell.RowIndex;

            Stock stockToDisplay = foundStock[currRow];

            StockDetailsForm sdf = new StockDetailsForm(stockToDisplay);
            sdf.Show();
        }
    }
}
