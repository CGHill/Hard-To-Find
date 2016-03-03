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
        //Globals
        const int ORDER_ARRAY_LENGTH = 18;
        const int ORDEREDSTOCK_ARRAY_LENGTH = 19;
        private Form1 form1;
        private DatabaseManager dbManager;
        private List<Order> allOrders;
        private List<OrderedStock> allOrderedStock;

        //Constructor
        public OrdersForm(Form1 form1)
        {
            this.form1 = form1;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            //Initialize globals
            dbManager = new DatabaseManager();
            allOrders = new List<Order>();
            allOrderedStock = new List<OrderedStock>();

            //Set up column widths
            DataGridViewColumn colQuantity = dataGridView1.Columns[0];
            colQuantity.Width = 50;
            DataGridViewColumn colAuthor = dataGridView1.Columns[1];
            colAuthor.Width = 187;
            DataGridViewColumn colTitle = dataGridView1.Columns[2];
            colTitle.Width = 270;
            DataGridViewColumn colPrice = dataGridView1.Columns[3];
            colPrice.Width = 75;
            DataGridViewColumn colBookID = dataGridView1.Columns[4];
            colBookID.Width = 75;
            DataGridViewColumn colDiscount = dataGridView1.Columns[5];
            colDiscount.Width = 75;

        }

        /*Precondition: 
         Postcondition: Move back to the main menu*/
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            form1.Show();
        }

        /*Precondition: 
         Postcondition: Starts import process, has user select a file  */
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
            }
        }

        /*Precondition: 
         Postcondition: Reads through users selected file and sorts the information to be stored as orders */
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

            progressBar1.Visible = true;
            //Insert all of the new orders into the database
            dbManager.insertOrders(allOrders, progressBar1);
            progressBar1.Visible = false;

            //Inform user that the process has been finished
            MessageBox.Show("Finished import");
        }

        /*Precondition: 
         Postcondition: Takes the array and stores it into a single Order object and puts it into the global list*/
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

        /*Precondition: 
         Postcondition: Starts import process for ordered stock by having user select a file*/
        private void btnImportOrderedStock_Click(object sender, EventArgs e)
        {
            //Set up file browser, to search for txt files and default directory of C: drive
            OpenFileDialog dialogBox = new OpenFileDialog();
            dialogBox.Title = "Open OrderedStock txt file";
            dialogBox.Filter = "TXT files|*.txt";
            dialogBox.InitialDirectory = @"C:\";

            //Open the file browser and wait for user to select file
            if (dialogBox.ShowDialog() == DialogResult.OK)
            {
                //TODO find place for this
                dbManager.dropOrderedStockTable();
                dbManager.createOrderedStock();

                //Get the path for the file the user clicked on
                string filename = dialogBox.FileName;

                //Continue the procress in another method
                readOrderedStockFile(filename);
            }
        }

        /*Precondition: 
         Postcondition: Reads through users selected file to import all of the OrderedStock information */
        private void readOrderedStockFile(string fileName)
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
                if (splitOrder.Length < ORDEREDSTOCK_ARRAY_LENGTH)
                {
                    //If previous line had a new line character in it
                    if (newLineCharacter)
                    {
                        //Check that it wasn't a second new line character by seeing if it's columns + the previous lines columns = the number needed
                        if ((splitOrder.Length + previousLine.Length - 1) == ORDEREDSTOCK_ARRAY_LENGTH)
                        {
                            //Go through and combined the lines into 1
                            string[] combinedLines = new string[ORDEREDSTOCK_ARRAY_LENGTH];
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
                            storeOrderedStock(combinedLines);

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

                                if (combinedLines.Length == ORDEREDSTOCK_ARRAY_LENGTH)
                                {
                                    storeOrderedStock(combinedLines);

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
                    storeOrderedStock(splitOrder);
                }
            }
            //Close text file
            file.Close();

            //Insert all of the new orders into the database
            progressBar1.Value = 0;
            progressBar1.Maximum = 42386;
            progressBar1.Visible = true;
            dbManager.insertOrderedStock(allOrderedStock, progressBar1);
            progressBar1.Visible = false;

            //Inform user that the process has been finished
            MessageBox.Show("Finished import");
        }

        /*Precondition: 
         Postcondition: Takes the array and stores it into a single OrderedStock object to be stored in global list */
        private void storeOrderedStock(string[] splitOrderedStock)
        {
            int orderedStockID = Convert.ToInt32(splitOrderedStock[0]);
            int orderID = Convert.ToInt32(splitOrderedStock[1]);
            int stockID = Convert.ToInt32(splitOrderedStock[2]);
            int quantity;
            if (splitOrderedStock[3] == "")
                quantity = 0;
            else
                quantity = Convert.ToInt32(splitOrderedStock[3]);
            string author = splitOrderedStock[4];
            string title = splitOrderedStock[5];
            string price = splitOrderedStock[11];
            string bookID = splitOrderedStock[16];
            string discount = splitOrderedStock[18];

            if(discount == "")
                discount = "$0.00";

            //Create a new order entry from it and insert into list
            OrderedStock newOrderedStock = new OrderedStock(orderedStockID, orderID, stockID, quantity, author, title, price, bookID, discount);
            allOrderedStock.Add(newOrderedStock);
        }

        /*Precondition: 
         Postcondition: Searches for orders from the ID the user typed in and displays any information found*/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Clear all the text boxes out for a new search
            clearForNewSearch();

            if (boxOrderID.Text != "")
            {
                int orderID = Convert.ToInt32(boxOrderID.Text);

                //Run search
                Order foundOrder = dbManager.searchOrders(orderID);

                //Check order wasn't null
                if (foundOrder != null)
                {
                    //Get the stock that was ordered for this order
                    List<OrderedStock> orderedStock = dbManager.searchOrderedStock(orderID);

                    //Autofill into text boxes the found order
                    labOrderID.Text = foundOrder.orderID.ToString();
                    boxOrderRef.Text = foundOrder.orderReference;
                    boxProgress.Text = foundOrder.progress;
                    boxInvoiceDate.Text = foundOrder.invoiceDate;
                    //Discprice is freight?
                    boxFreight.Text = foundOrder.discPrice;
                    boxComments.Text = foundOrder.comments;

                    //Search for customer attatched to the order
                    Customer foundCustomer = dbManager.searchCustomers(foundOrder.customerID);

                    //Use customers data if the customer was found
                    if (foundCustomer != null)
                    {
                        labCustID.Text = foundCustomer.custID.ToString();
                        boxCustName.Text = foundCustomer.firstName + " " + foundCustomer.lastName;
                        boxInstitution.Text = foundCustomer.institution;
                        boxPostcode.Text = foundCustomer.postCode;
                        boxAdd1.Text = foundCustomer.address1;
                        boxAdd2.Text = foundCustomer.address2;
                        boxAdd3.Text = foundCustomer.address3;
                        boxCountry.Text = foundCustomer.country;
                    }
                    else
                    {
                        //Use the default data that was stored in the order
                        boxCustName.Text = foundOrder.customerFirstName + " " + foundOrder.customerLastName;
                    }


                    //Loop over and display all of the ordered stock for the order
                    foreach (OrderedStock o in orderedStock)
                    {
                        dataGridView1.Rows.Add(o.quantity, o.author, o.title, o.price, o.bookID, o.discount);
                    }
                }
            }
        }

        /*Precondition: 
         Postcondition: Empty out textboxes and datagrid for a new search*/
        public void clearForNewSearch()
        {
            dataGridView1.Rows.Clear();

            labOrderID.Text = "";
            boxOrderRef.Text = "";
            boxProgress.Text = "";
            boxInvoiceDate.Text = "";
            boxFreight.Text = "";
            boxComments.Text = "";
            labCustID.Text = "";
            boxCustName.Text = "";
            boxInstitution.Text = "";
            boxPostcode.Text = "";
            boxAdd1.Text = "";
            boxAdd2.Text = "";
            boxAdd3.Text = "";
            boxCountry.Text = "";
        }

        /*Precondition: 
         Postcondition: Open form to create a new order */
        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            NewOrderForm nof = new NewOrderForm();
            nof.Show();
        }

        /*Precondition:
         Postcondition: Only allows numbers to be entered into ID textbox*/
        private void boxOrderID_KeyPress(object sender, KeyPressEventArgs e)
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
