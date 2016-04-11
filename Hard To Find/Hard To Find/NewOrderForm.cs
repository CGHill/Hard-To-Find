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
    public partial class NewOrderForm : Form, IStockReceiver, ICustomerReceiver
    {
        //Globals
        private Customer currentCustomer;
        private List<Stock> orderedBooks;
        private DatabaseManager dbManager;
        private OrdersForm ordersForm;
        private FileManager fileManager;

        //Constructor
        public NewOrderForm(OrdersForm ordersForm)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.ordersForm = ordersForm;

            setup();
        }

        /*Precondition:
         Postcondition: Sets up and initialises everthing needed */
        private void setup()
        {
            //Initialize globals
            orderedBooks = new List<Stock>();
            dbManager = new DatabaseManager();
            fileManager = new FileManager();

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

            //Display the OrderID/Invoice number for the user
            boxInvoiceNo.Text = dbManager.getNextOrderID().ToString();

            string date = DateTime.Now.ToString("d/MM/yyyy");
            boxInvoiceDate.Text = date;

            btnFindCustomer.Select();
        }

        /*Precondition:
         Postcondition: Closes this form*/
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*Precondition:
         Postcondition: Listens for keypresses no matter which control has focus */
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Closes this form when escape is pressed
            if (keyData == Keys.Escape)
            {
                this.Close();
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /*Precondition:
         Postcondition: Open form to search for customers*/
        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            CustomerSearch cs = new CustomerSearch(this);
            cs.Show();
        }

        /*Precondition:
         Postcondition: Open up form to search for a book to order */
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            StockSearch ss = new StockSearch(this);
            ss.Show();
        }

        /*Precondition:
         Postcondition: Gathers up order information and stores it into database*/
        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            //Unsure of CatItem, doesn't seem to be used anymore and could be BookID for older orders
            if (currentCustomer != null)
            {
                //Get invoice/orderID for current order
                int nextOrderIDAndInvoiceNo = dbManager.getNextOrderID();

                Order newOrder = createOrder();

                List<OrderedStock> newOrderedStock = createOrderedStock(newOrder);

                //Insert new order and orderedStock into database
                dbManager.insertOrder(newOrder);
                dbManager.insertOrderedStock(newOrderedStock);

                if(ordersForm != null)
                    ordersForm.loadOrder(nextOrderIDAndInvoiceNo);

                this.Close();
            }
            else
            {
                MessageBox.Show("No Customer selected");
            }
        }

        /*Precondition: 
          Postcondition: Check datagrid for right mouse click */
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
          Postcondition: Handles a click on the context menu, deletes a selected row from datagrid */
        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.CurrentCell.RowIndex;

            if (!dataGridView1.Rows[selectedRow].IsNewRow)
            {
                dataGridView1.Rows.RemoveAt(selectedRow);

                orderedBooks.RemoveAt(selectedRow);
            }
        }
        /*Precondition: 
          Postcondition: Open form for creating new customer */
        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            NewCustomerForm ncf = new NewCustomerForm();
            ncf.setNewOrderForm(this);
            ncf.Show();
        }

        /*Precondition:
         Postcondition: A book has been found, autofill information and store book*/
        public void addStock(Stock newStock)
        {
            orderedBooks.Add(newStock);

            dataGridView1.Rows.Add(1, newStock.author, newStock.title, newStock.price, newStock.bookID, "$0.00");
        }

        /*Precondition:
         Postcondition: Customer has been found or created, autofill with customer information */
        public void addCustomer(Customer newCustomer)
        {
            currentCustomer = newCustomer;

            boxFirstName.Text = newCustomer.firstName;
            boxLastName.Text = newCustomer.lastName;
            boxInstitution.Text = newCustomer.institution;
            boxAddress1.Text = newCustomer.address1;
            boxAddress2.Text = newCustomer.address2;
            boxAddress3.Text = newCustomer.address3;
            boxPostcode.Text = newCustomer.postCode;
            boxCountry.Text = newCustomer.country;
        }

        /*Precondition:
         Postcondition: Automatically adds $ and or makes the number double digit in price and discount when editing a cell is finished */
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Try to add a $ sign and make the numbers decimals in the price and discount boxes in the datagrid
                string priceCellValue = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                string discountCellValue = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

                if (priceCellValue != "")
                {
                    bool noLetters = priceCellValue.All(x => !char.IsLetter(x));

                    if (noLetters)
                    {
                        string price = SyntaxHelper.escapeSingleQuotes(priceCellValue);
                        string finalPrice = SyntaxHelper.checkAddDollarSignAndDoubleDecimal(price);
                        dataGridView1.Rows[e.RowIndex].Cells[3].Value = finalPrice;
                    }
                    else
                    {
                        MessageBox.Show("Price should not have letters");
                    }
                }
                if (discountCellValue != "")
                {
                    bool noLetters = discountCellValue.All(x => !char.IsLetter(x));

                    if (noLetters)
                    {

                        string discount = SyntaxHelper.escapeSingleQuotes(discountCellValue);
                        string finalDiscount = SyntaxHelper.checkAddDollarSignAndDoubleDecimal(discount);
                        dataGridView1.Rows[e.RowIndex].Cells[5].Value = finalDiscount;
                    }
                    else
                    {
                        MessageBox.Show("Discount should not have letters");
                    }
                }
            }
            catch (NullReferenceException)
            {
                //Cell was exited and price and discount are empty
            }
        }

        /*Precondition:
         Postcondition: Listens for keypresses no matter which control has focus */
        private void boxFreight_Leave(object sender, EventArgs e)
        {
            string priceEntered = boxFreight.Text;

            bool noLetters = priceEntered.All(x => !char.IsLetter(x));

            if (noLetters)
            {
                string checkedPrice = SyntaxHelper.checkAddDollarSignAndDoubleDecimal(priceEntered);

                boxFreight.Text = checkedPrice;
            }
            else
            {
                MessageBox.Show("Freight should not have letters");
            }
        }

        /*Precondition:
         Postcondition: Creates an invoice for the current order and opens it */
        private void btnInvoice_Click(object sender, EventArgs e)
        {
            bool haveStorageLocation = checkForStorageLocation();

            //Check if storage location is setup
            if (haveStorageLocation)
            {
                //Check that there is a customer selected because one is required for the invoice
                if (currentCustomer != null)
                {
                    //Get details about the current order
                    Order currOrder = createOrder();

                    //Get all of the stock being ordered
                    List<OrderedStock> newOrderedStock = createOrderedStock(currOrder);

                    currOrder.orderID = dbManager.getNextOrderID();


                    //Create the .docx file containing the invoice
                    InvoiceCreator wdm = new InvoiceCreator(null, currentCustomer, currOrder, newOrderedStock);

                    string documentName = currOrder.orderID.ToString() + ".docx";

                    string filePath = fileManager.getStorageFilePath() + @"\Invoices\" + documentName;
                    bool successfulFileCreation = wdm.createInvoice(filePath);

                    //Open the invoice automatically
                    if (successfulFileCreation)
                        System.Diagnostics.Process.Start(filePath);
                }
                else
                {
                    MessageBox.Show("No Customer selected");
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
                        fileManager.setStorageLocationFile(folderBrowser.SelectedPath);

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
         Postcondition: Returns an order from what information is currently entered in the form */
        private Order createOrder()
        {
            //Get all information out of text boxes
            string firstName = SyntaxHelper.escapeSingleQuotes(boxFirstName.Text);
            string lastName = SyntaxHelper.escapeSingleQuotes(boxLastName.Text);
            string institution = SyntaxHelper.escapeSingleQuotes(boxInstitution.Text);
            string add1 = SyntaxHelper.escapeSingleQuotes(boxAddress1.Text);
            string add2 = SyntaxHelper.escapeSingleQuotes(boxAddress2.Text);
            string add3 = SyntaxHelper.escapeSingleQuotes(boxAddress3.Text);
            string postcode = SyntaxHelper.escapeSingleQuotes(boxPostcode.Text);
            string country = SyntaxHelper.escapeSingleQuotes(boxCountry.Text);
            string orderRef = SyntaxHelper.escapeSingleQuotes(boxOrderRef.Text);
            string progress = SyntaxHelper.escapeSingleQuotes(boxProgress.Text);
            string stringDate = SyntaxHelper.escapeSingleQuotes(boxInvoiceDate.Text);
            string[] splitDate = stringDate.Split('/');
            DateTime invoiceDate = new DateTime(Convert.ToInt32(splitDate[2]), Convert.ToInt32(splitDate[1]), Convert.ToInt32(splitDate[0]));

            string freight = SyntaxHelper.escapeSingleQuotes(boxFreight.Text);
            string comments = SyntaxHelper.escapeSingleQuotes(boxComments.Text);

            //Get invoice/orderID for current order
            int nextOrderIDAndInvoiceNo = dbManager.getNextOrderID();

            Order newOrder = new Order(firstName, lastName, institution, postcode, orderRef, progress, freight, nextOrderIDAndInvoiceNo, invoiceDate, comments, currentCustomer.custID);

            return newOrder;
        }

        /*Precondition:
         Postcondition: Returns a list of orderedStock from the orderedBooks and data in datagrid */
        private List<OrderedStock> createOrderedStock(Order order)
        {
            List<OrderedStock> newOrderedStock = new List<OrderedStock>();

            //Get invoice/orderID for current order
            int nextOrderIDAndInvoiceNo = dbManager.getNextOrderID();

            int currRowIndex = 0;

            //Loop over all the books selected and create orderedStock from them
            foreach (Stock s in orderedBooks)
            {
                //TODO fix this so it all comes from datagrid
                //Get quantity, price and discount from the datagrid
                int quantity = Convert.ToInt32(dataGridView1.Rows[currRowIndex].Cells[0].Value.ToString());
                string price = dataGridView1.Rows[currRowIndex].Cells[3].Value.ToString();
                string discount = dataGridView1.Rows[currRowIndex].Cells[5].Value.ToString();
                string author = SyntaxHelper.escapeSingleQuotes(s.author);
                string title = SyntaxHelper.escapeSingleQuotes(s.title);
                string bookID = SyntaxHelper.escapeSingleQuotes(s.bookID);

                //Create the orderedStock and store
                OrderedStock o = new OrderedStock(nextOrderIDAndInvoiceNo, s.stockID, quantity, author, title, price, bookID, discount);
                newOrderedStock.Add(o);

                currRowIndex++;
            }

            return newOrderedStock;
        }

        /*Precondition:
         Postcondition: Creates a .docx file with a big mailing label and opens it automatically */
        private void btnBigMailingLabel_Click(object sender, EventArgs e)
        {
            bool haveStorageLocation = checkForStorageLocation();

            //Check that storage location is set
            if (haveStorageLocation)
            {
                //Check that customer is currently set because it's required for the mailing label
                if (currentCustomer != null)
                {
                    //Get the current order
                    Order currOrder = createOrder();

                    //Set the order to have the correct ID
                    currOrder.orderID = dbManager.getNextOrderID();

                    //Setup and create the .docx file that is the mailing label
                    bool bigLabel = true;
                    MailingLabelCreator labelCreator = new MailingLabelCreator(null, currentCustomer, bigLabel);

                    string documentName = currOrder.orderID.ToString() + ".docx";

                    string filePath = fileManager.getStorageFilePath() + @"\Mailing Labels\" + documentName;
                    bool successfulFileCreation = labelCreator.createMailingLabel(filePath);

                    //Open the file containing the mailing label
                    if (successfulFileCreation)
                        System.Diagnostics.Process.Start(filePath);
                }
            }
        }

        /*Precondition:
         Postcondition: Creates a .docx file with a small mailing label and opens it automatically */
        private void btnSmallMailingLabel_Click(object sender, EventArgs e)
        {
            bool haveStorageLocation = checkForStorageLocation();

            //Check that storage location is set
            if (haveStorageLocation)
            {
                //Check that the customer is set because it's required for the mailing label
                if (currentCustomer != null)
                {
                    //Get the current order
                    Order currOrder = createOrder();

                    //Correct the current orders ID
                    currOrder.orderID = dbManager.getNextOrderID();

                    //Setup and create the .docx file that contains the mailing label
                    bool bigLabel = false;
                    MailingLabelCreator labelCreator = new MailingLabelCreator(null, currentCustomer, bigLabel);

                    string documentName = currOrder.orderID.ToString() + ".docx";

                    string filePath = fileManager.getStorageFilePath() + @"\Mailing Labels\" + documentName;
                    bool successfulFileCreation = labelCreator.createMailingLabel(filePath);

                    //Open the file containing the mailing label
                    if (successfulFileCreation)
                        System.Diagnostics.Process.Start(filePath);
                }
            }
        }

    }
}
