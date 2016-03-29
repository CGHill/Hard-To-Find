﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Hard_To_Find
{
    public partial class OrdersForm : Form, IStockReceiver, ICustomerReceiver
    {
        //Globals
        private Form1 form1;
        private DatabaseManager dbManager;
        private List<Order> allOrders;
        private List<OrderedStock> allOrderedStock;
        private Order currOrder;
        private Customer currCustomer;
        private List<OrderedStock> currOrderedStock;
        private List<OrderedStock> newOrderedStock;
        private FileManager fileManager;

        //Constructor
        public OrdersForm(Form1 form1)
        {
            this.form1 = form1;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            setup();
        }

        /*Precondition: 
          Postcondition: Does setup and initializes everything needed*/
        private void setup()
        {
            //Initialize globals
            dbManager = new DatabaseManager();
            allOrders = new List<Order>();
            allOrderedStock = new List<OrderedStock>();
            currOrderedStock = new List<OrderedStock>();
            newOrderedStock = new List<OrderedStock>();
            fileManager = new FileManager();
            currCustomer = null;
            currOrder = null;

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

            //If this form was opened through customers orders then remove unneccessary controls and adjust form
            if (form1 == null)
            {
                labOrderID.Visible = false;
                boxOrderSearchID.Visible = false;
                btnSearch.Enabled = false;
                btnSearch.Visible = false;

                btnNewestOrder.Enabled = false;
                btnNewestOrder.Visible = false;

                btnNewOrder.Enabled = false;
                btnNewOrder.Visible = false;

                btnCreateInvoice.Enabled = false;
                btnCreateInvoice.Visible = false;

                labMailingLabels.Visible = false;

                btnBigMailingLabel.Enabled = false;
                btnBigMailingLabel.Visible = false;

                btnSmallMailingLabel.Enabled = false;
                btnSmallMailingLabel.Visible = false;

                btnImportOrders.Enabled = false;
                btnImportOrders.Visible = false;

                btnImportOrderedStock.Enabled = false;
                btnImportOrderedStock.Visible = false;

                btnMainMenu.Text = "Close";

                groupBox1.Left = groupBox1.Left - 180;
                btnAddBook.Left = btnAddBook.Left - 180;
                btnMainMenu.Left = btnMainMenu.Left - 180;

                Width = Width - 180;
            }
        }

        /*Precondition: 
         Postcondition: Move back to the main menu*/
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            if (form1 != null)
            {
                form1.Show();
                form1.TopLevel = true;
            }
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
                //Get the path for the file the user clicked on
                string filename = dialogBox.FileName;

                if (filename.Contains("\\Orders.txt"))
                {
                    try
                    {
                        allOrders = fileManager.getOrdersFromFile(filename);

                        progressBar1.Visible = true;

                        //TODO find a better place for this?
                        dbManager.dropOrdersTable();
                        dbManager.createOrdersTable();

                        //Insert all of the new orders into the database
                        dbManager.insertOrders(allOrders, progressBar1);
                        progressBar1.Visible = false;

                        //Inform user that the process has been finished
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
                //Get the path for the file the user clicked on
                string filename = dialogBox.FileName;

                if (filename.Contains("\\OrderedStock.txt"))
                {
                    try
                    {
                        allOrderedStock = fileManager.getOrderedStockFromFile(filename);

                        //TODO find a better place for this
                        dbManager.dropOrderedStockTable();
                        dbManager.createOrderedStock();

                        //Insert all of the new orders into the database
                        progressBar1.Value = 0;
                        progressBar1.Maximum = 42386;
                        progressBar1.Visible = true;
                        dbManager.insertOrderedStock(allOrderedStock, progressBar1);
                        progressBar1.Visible = false;

                        //Inform user that the process has been finished
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
         Postcondition: Searches for orders from the ID the user typed in and displays any information found*/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            startSearch();
        }

        /*Precondition: 
         Postcondition: Empty out textboxes and datagrid for a new search*/
        public void clearForNewSearch()
        {
            dataGridView1.Rows.Clear();

            boxOrderID.Text = "";
            boxOrderRef.Text = "";
            boxProgress.Text = "";
            boxInvoiceDate.Text = "";
            boxFreight.Text = "";
            boxComments.Text = "";
            boxCustID.Text = "";
            boxFirstName.Text = "";
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
            NewOrderForm nof = new NewOrderForm(this);
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

            //Check if enter was pressed to start the search
            if (e.KeyChar == (Char)Keys.Enter)
            {
                startSearch();

                e.Handled = true;
            }
        }

        /*Precondition:
         Postcondition: Starts a search for orders depending on what search boxes have been filled in*/
        private void startSearch()
        {
            //Clear all the text boxes out for a new search
            clearForNewSearch();

            if (boxOrderSearchID.Text != "")
            {
                int orderID = Convert.ToInt32(boxOrderSearchID.Text);

                //Run search
                currOrder = dbManager.searchOrders(orderID);

                //Check order wasn't null
                if (currOrder != null)
                {
                    //Get the stock that was ordered for this order

                    currOrderedStock = dbManager.searchOrderedStock(orderID);

                    //Autofill into text boxes the found order
                    boxOrderID.Text = currOrder.orderID.ToString();
                    boxOrderRef.Text = currOrder.orderReference;
                    boxProgress.Text = currOrder.progress;
                    boxInvoiceDate.Text = currOrder.invoiceDate;
                    boxFreight.Text = currOrder.freightCost;
                    boxComments.Text = currOrder.comments;

                    //Search for customer attatched to the order
                    currCustomer = dbManager.searchCustomers(currOrder.customerID);

                    //Use customers data if the customer was found
                    if (currCustomer != null)
                    {
                        boxCustID.Text = currCustomer.custID.ToString();
                        boxFirstName.Text = currCustomer.firstName;
                        boxLastName.Text = currCustomer.lastName;
                        boxInstitution.Text = currCustomer.institution;
                        boxPostcode.Text = currCustomer.postCode;
                        boxAdd1.Text = currCustomer.address1;
                        boxAdd2.Text = currCustomer.address2;
                        boxAdd3.Text = currCustomer.address3;
                        boxCountry.Text = currCustomer.country;
                    }
                    else
                    {
                        //Use the default data that was stored in the order
                        boxFirstName.Text = currOrder.customerFirstName + " " + currOrder.customerLastName;
                    }


                    //Loop over and display all of the ordered stock for the order
                    foreach (OrderedStock o in currOrderedStock)
                    {
                        dataGridView1.Rows.Add(o.quantity, o.author, o.title, o.price, o.bookID, o.discount);
                    }
                }
                else
                {
                    MessageBox.Show("Order not found");
                }
            }
        }

        /*Precondition:
         Postcondition: Loads up an order in the form for when a new order has finished being made so user can see the completed order*/
        public void loadOrder(int orderID)
        {
            boxOrderSearchID.Text = orderID.ToString();
            startSearch();
        }

        /*Precondition: Needs an order to be loaded
         Postcondition: Creates a .docx file containing the invoice and opens it */
        private void btnCreateInvoice_Click(object sender, EventArgs e)
        {
            bool haveStorageLocation = checkForStorageLocation();

            if (haveStorageLocation)
            {
                if (currOrder != null)
                {
                    WordDocumentManager wdm = new WordDocumentManager(this, currCustomer, currOrder, currOrderedStock);

                    string documentName = currOrder.orderID.ToString() + ".docx";

                    string filePath = fileManager.getStorageFilePath() + @"\Invoices\" + documentName;
                    bool successfulFileCreation = wdm.createInvoice(filePath);

                    if(successfulFileCreation)
                        System.Diagnostics.Process.Start(filePath);
                }
            }
        }

        /*Precondition: Needs an order to be loaded
         Postcondition: Creates a .docx file containing the a small mailing label and opens it */
        private void btnSmallMailingLabel_Click(object sender, EventArgs e)
        {

            bool haveStorageLocation = checkForStorageLocation();

            if (haveStorageLocation)
            {
                if (currOrder != null)
                {
                    bool bigLabel = false;
                    MailingLabelCreator labelCreator = new MailingLabelCreator(this, currCustomer, bigLabel);

                    string documentName = currOrder.orderID.ToString() + ".docx";

                    string filePath = fileManager.getStorageFilePath() + @"\Mailing Labels\" + documentName;
                    bool successfulFileCreation = labelCreator.createMailingLabel(filePath);

                    if(successfulFileCreation)
                        System.Diagnostics.Process.Start(filePath);
                }
            }
        }

        /*Precondition: Needs an order to be loaded
         Postcondition: Creates a .docx file containing the big mailing label and opens it */
        private void btnBigMailingLabel_Click(object sender, EventArgs e)
        {
            bool haveStorageLocation = checkForStorageLocation();

            if (haveStorageLocation)
            {
                if (currOrder != null)
                {
                    bool bigLabel = true;
                    MailingLabelCreator labelCreator = new MailingLabelCreator(this, currCustomer, bigLabel);

                    string documentName = currOrder.orderID.ToString() + ".docx";

                    string filePath = fileManager.getStorageFilePath() + @"\Mailing Labels\" + documentName;
                    bool successfulFileCreation = labelCreator.createMailingLabel(filePath);

                    if (successfulFileCreation)
                        System.Diagnostics.Process.Start(filePath);
                }
            }
        }

        /*Precondition: 
         Postcondition: Returns true if location has been set, if not asks user to set storage location and returns true, otherwise returns false if not set */
        private bool checkForStorageLocation()
        {
            bool canStoreFiles = false;

            //Check if the storage location has been set
            if (!fileManager.checkForStorageLocation())
            {
                //Hasn't been set so try get user to set it now
                DialogResult result = MessageBox.Show("Storage location not set for invoices and mailing labels.\nDo you want to set a location?", "Confirmation", MessageBoxButtons.YesNoCancel);

                //Check result
                if (result == DialogResult.Yes)
                {
                    //Get user to select a location to store files
                    FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                    folderBrowser.Description = "Select storage location";

                    if (folderBrowser.ShowDialog() == DialogResult.OK)
                    {
                        fileManager.createStorageLocationFile(folderBrowser.SelectedPath);

                        canStoreFiles = true;
                    }
                }
            }
            else
            {
                canStoreFiles = true;
            }

            //Return true if can set files and false if you can't
            return canStoreFiles;
        }

        /*Precondition: 
         Postcondition: Let user know that the .docx file can't be made and give a possible solution to the problem */
        public void errorOpeningFile()
        {
            MessageBox.Show("Cannot create or open file. \nMake sure the existing file with the same name is closed.");
        }

        /*Precondition: 
         Postcondition: Load up the newest order */
        private void btnNewestOrder_Click(object sender, EventArgs e)
        {
            int nextID = dbManager.getNextOrderID();
            int latestID = nextID - 1;

            loadOrder(latestID);
        }

        /*Precondition: 
         Postcondition: Enables editing of the order */
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(currOrder != null)
                toggleEditing();
        }

        /*Precondition: 
         Postcondition: Saves changes made to the order */
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currOrder != null)
            {
                //Disable editing
                toggleEditing();

                //Get the updated fields
                currOrder.orderReference = SQLSyntaxHelper.escapeSingleQuotes(boxOrderRef.Text);
                currOrder.progress = SQLSyntaxHelper.escapeSingleQuotes(boxProgress.Text);
                currOrder.invoiceDate = SQLSyntaxHelper.escapeSingleQuotes(boxInvoiceDate.Text);
                currOrder.freightCost = SQLSyntaxHelper.escapeSingleQuotes(boxFreight.Text);
                currOrder.comments = SQLSyntaxHelper.escapeSingleQuotes(boxComments.Text);

                //Update order in the database
                dbManager.updateOrder(currOrder);

                //Update the orderedStock in the database
                foreach (OrderedStock os in currOrderedStock)
                {
                    dbManager.updateOrderedStock(os);
                }

                //Insert any new orderedStock that was added
                dbManager.insertOrderedStock(newOrderedStock);

                //Ad new ordered stock to the overall orderedStock list
                foreach (OrderedStock os in newOrderedStock)
                {
                    currOrderedStock.Add(os);
                }

                //Reset the newOrderedStock list
                newOrderedStock = new List<OrderedStock>();
            }
        }

        /*Precondition: 
         Postcondition: Toggles readonly values of textboxes and hides/shows buttons */
        private void toggleEditing()
        {
            boxOrderRef.ReadOnly = !boxOrderRef.ReadOnly;
            boxProgress.ReadOnly = !boxProgress.ReadOnly;
            boxInvoiceDate.ReadOnly = !boxInvoiceDate.ReadOnly;
            boxFreight.ReadOnly = !boxFreight.ReadOnly;
            boxComments.ReadOnly = !boxComments.ReadOnly;

            btnAddBook.Visible = !btnAddBook.Visible;
            btnAddBook.Enabled = !btnAddBook.Enabled;

            btnUpdate.Enabled = !btnUpdate.Enabled;
            btnSave.Enabled = !btnSave.Enabled;

            btnChangeCustomer.Enabled = !btnChangeCustomer.Enabled;
            btnChangeCustomer.Visible = !btnChangeCustomer.Visible;

            dataGridView1.ReadOnly = !dataGridView1.ReadOnly;
        }

        /*Precondition: 
         Postcondition: Updates orderedStock after the user has edited a cell */
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            OrderedStock current = null;

            if (rowIndex < currOrderedStock.Count)
            {
                current = currOrderedStock[rowIndex];
            }
            else
            {
                rowIndex = rowIndex - currOrderedStock.Count;
                current = newOrderedStock[rowIndex];
            }
                
            current.quantity = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            current.author = SQLSyntaxHelper.escapeSingleQuotes(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            current.title = SQLSyntaxHelper.escapeSingleQuotes(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            current.price = SQLSyntaxHelper.escapeSingleQuotes(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            current.bookID = SQLSyntaxHelper.escapeSingleQuotes(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            current.discount = SQLSyntaxHelper.escapeSingleQuotes(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());

        }

        /*Precondition: 
         Postcondition: Opens up form to search for stock to add to the orderedStock list */
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            StockSearch ss = new StockSearch(this);
            ss.Show();
        }

        /*Precondition: 
         Postcondition: Adds the stock send in into the newOrderedStock list, also add it to the datagrid to be viewed */
        public void addStock(Stock newStock)
        {
            OrderedStock os = new OrderedStock(currOrder.orderID, newStock.stockID, 1, newStock.author, newStock.title, newStock.price, newStock.bookID, "$0.00");
            newOrderedStock.Add(os);

            dataGridView1.Rows.Add(1, newStock.author, newStock.title, newStock.price, newStock.bookID, "$0.00");
        }

        /*Precondition: 
         Postcondition: Checks for right click on the datagrid */
        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int selectedRow = e.RowIndex;
                //dataGridView1.Rows[e.RowIndex].Selected = true;

                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        /*Precondition: 
         Postcondition: Handles clicks on the datagrid, allows deleting of orderedStock */
        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            //Confirm with user that they want to delete the orderedStock
            DialogResult dr = MessageBox.Show("Are you sure you want to delete", "YesNo",MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                //Get the row they clicked on
                int selectedRow = dataGridView1.CurrentCell.RowIndex;

                //Check that it isn't an empty row the user clicked on
                if (!dataGridView1.Rows[selectedRow].IsNewRow)
                {
                    dataGridView1.Rows.RemoveAt(selectedRow);

                    //Check if it was a newly entered one or an existing one in the order
                    if (selectedRow < currOrderedStock.Count)
                    {
                        //Get the ordered stock and delete it from the database
                        OrderedStock orderedStockToDelete = currOrderedStock[selectedRow];
                        currOrderedStock.RemoveAt(selectedRow);

                        dbManager.deleteOrderedStock(orderedStockToDelete);
                    }
                    else
                    {
                        //newOrdered stock that hasn't been saved so just remove it from the list
                        newOrderedStock.RemoveAt(selectedRow - currOrderedStock.Count);
                    }
                }
            }
        }

        /*Precondition: 
         Postcondition: Opens form to change the current set customer */
        private void btnChangeCustomer_Click(object sender, EventArgs e)
        {
            CustomerSearch cs = new CustomerSearch(this);
            cs.Show();
        }

        /*Precondition: 
         Postcondition: Changes the currently set customer and updates the relevant display for customer */
        public void addCustomer(Customer newCustomer)
        {
            currCustomer = newCustomer;

            boxCustID.Text = currCustomer.custID.ToString();
            boxFirstName.Text = currCustomer.firstName;
            boxLastName.Text = currCustomer.lastName;
            boxInstitution.Text = currCustomer.institution;
            boxPostcode.Text = currCustomer.postCode;
            boxAdd1.Text = currCustomer.address1;
            boxAdd2.Text = currCustomer.address2;
            boxAdd3.Text = currCustomer.address3;
            boxCountry.Text = currCustomer.country;

            currOrder.customerID = currCustomer.custID;
        }
    }
}
