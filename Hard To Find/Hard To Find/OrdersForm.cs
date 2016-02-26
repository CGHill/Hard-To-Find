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
    public partial class OrdersForm : Form
    {
        const int ORDER_ARRAY_LENGTH = 18;
        private Form1 form1;
        private DatabaseManager dbManager;
        private List<Order> allOrders;

        public OrdersForm(Form1 form1)
        {
            this.form1 = form1;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            dbManager = new DatabaseManager();
            allOrders = new List<Order>();
        }

        /*Precondition: 
         Postcondition: Move back to the main menu*/
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            form1.Show();
        }

        private void btnImportOrders_Click(object sender, EventArgs e)
        {
            //Set up file browser, to search for txt files and default directory of C: drive
            OpenFileDialog dialogBox = new OpenFileDialog();
            dialogBox.Title = "Open Orders txt file";
            dialogBox.Filter = "TXT files|*.txt";
            dialogBox.InitialDirectory = @"C:\";

            //Open the file browser and wait for user to select file
            if (dialogBox.ShowDialog() == DialogResult.OK)
            {
                //TODO find place for this
                dbManager.dropOrdersTable();
                dbManager.createOrdersTable();

                //Get the path for the file the user clicked on
                string filename = dialogBox.FileName;

                //Continue the procress in another method
                readFile(filename);

                //Thread thread = new Thread(() => readFile(filename));
                //thread.Start();
            }
        }

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
                string removedDashes = unquoted.Replace("-", " ");

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

                //Split on | instead of comma because Order entries could contain commas in comments
                string[] splitOrder = removedDashes.Split('|');

                //Importing from the old Access database contain a lot of new line characters
                //Check if current line contains all of the columns
                if (splitOrder.Length < ORDER_ARRAY_LENGTH)
                {
                    //If previous line had a new line character in it
                    if (newLineCharacter)
                    {
                        //Check that it wasn't a second new line character by seeing if it's columns + the previous lines columns = the number needed
                        if ((splitOrder.Length + previousLine.Length - 1) == ORDER_ARRAY_LENGTH)
                        {
                            //Go through and combined the lines into 1
                            string[] combinedLines = new string[ORDER_ARRAY_LENGTH];
                            int combinedLineIndex = 0;

                            for (int i = 0; i < previousLine.Length; i++)
                            {
                                combinedLines[combinedLineIndex] = previousLine[i];
                                combinedLineIndex++;
                            }

                            for (int i = 0; i < splitOrder.Length; i++)
                            {
                                if (i == 0)
                                {
                                    combinedLineIndex--;
                                    combinedLines[combinedLineIndex] = combinedLines[combinedLineIndex] + ", " + splitOrder[i];
                                }
                                else
                                {
                                    combinedLines[combinedLineIndex] = splitOrder[i];
                                }
                                combinedLineIndex++;
                            }

                            //Pull out all of the columns
                            storeOrder(combinedLines);

                            //Reset values
                            newLineCharacter = false;
                            previousLine = new string[1];
                        }
                        else
                        {
                            if (splitOrder.Length == 1)
                            {
                                int previousLineLength = previousLine.Length;
                                previousLine[previousLineLength - 1] = previousLine[previousLineLength - 1] + " " + splitOrder[0];
                            }
                            else
                            {
                                //Go through and combined the lines into 1
                                string[] combinedLines = new string[previousLine.Length + splitOrder.Length - 1];
                                int combinedLineIndex = 0;

                                for (int i = 0; i < previousLine.Length; i++)
                                {
                                    combinedLines[combinedLineIndex] = previousLine[i];
                                    combinedLineIndex++;
                                }

                                for (int i = 0; i < splitOrder.Length; i++)
                                {
                                    if (i == 0)
                                    {
                                        combinedLineIndex--;
                                        combinedLines[combinedLineIndex] = combinedLines[combinedLineIndex] + ", " + splitOrder[i];
                                    }
                                    else
                                    {
                                        combinedLines[combinedLineIndex] = splitOrder[i];
                                    }
                                    combinedLineIndex++;
                                }

                                if (combinedLines.Length == ORDER_ARRAY_LENGTH)
                                {
                                    storeOrder(combinedLines);

                                    //Reset values
                                    newLineCharacter = false;
                                    previousLine = new string[1];
                                }

                            }
                        }
                    }
                    else     //Was the first new line character and need to search for the rest of the line
                    {
                        //Update values to start searching for the rest of the line
                        newLineCharacter = true;
                        previousLine = splitOrder;
                    }
                }
                else     //Else a normal line
                {
                    storeOrder(splitOrder);
                }
            }
            //Close text file
            file.Close();

            //Insert all of the new orders into the database
            dbManager.insertOrders(allOrders, progressBar1);

            //Inform user that the process has been finished
            MessageBox.Show("Finished import");
        }

        private void storeOrder(string[] splitOrder)
        {
            int orderID = Convert.ToInt32(splitOrder[0]);
            string customerFirstName = splitOrder[1];
            string customerLastName = splitOrder[2];
            string institution = splitOrder[3];
            string postcode = splitOrder[4];
            string orderReference = splitOrder[5];
            string catItem = splitOrder[6];
            string author = splitOrder[7];
            string title = splitOrder[8];

            int quantity;

            if (splitOrder[1] == "")
                quantity = 0;
            else
                quantity = Convert.ToInt32(splitOrder[9]);

            string price = splitOrder[10];
            string progress = splitOrder[11];
            string discPrice = splitOrder[12];

            int invoiceNo;
            if (splitOrder[13] == "")
                invoiceNo = -1;
            else
                invoiceNo = Convert.ToInt32(splitOrder[13]);

            string invoiceDate = splitOrder[14];
            string comments = splitOrder[15];

            int stockID;
            if (splitOrder[16] == "")
                stockID = -1;
            else
                stockID = Convert.ToInt32(splitOrder[16]);

            int customerID;
            if (splitOrder[17] == "")
                customerID = -1;
            else
                customerID = Convert.ToInt32(splitOrder[17]);

            //Create a new order entry from it and insert into list
            Order newOrder = new Order(orderID, customerFirstName, customerLastName, institution, postcode, orderReference, catItem, author, title, quantity, price,
                progress, discPrice, invoiceNo, invoiceDate, comments, stockID, customerID);
            allOrders.Add(newOrder);
        }

    }
}
