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
    public partial class NewOrderForm : Form
    {
        //Globals
        private Customer currentCustomer;
        private List<Stock> orderedBooks;
        private DatabaseManager dbManager;
        private OrdersForm ordersForm;

        //Constructor
        public NewOrderForm(OrdersForm ordersForm)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            //Initialize globals
            orderedBooks = new List<Stock>();
            dbManager = new DatabaseManager();
            this.ordersForm = ordersForm;

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
        }

        /*Precondition:
         Postcondition: Closes this form*/
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*Precondition:
         Postcondition: Open form to search for customers*/
        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            CustomerSearch cs = new CustomerSearch(this);
            cs.Show();
        }

        /*Precondition:
         Postcondition: Customer has been found, autofill with customer information */
        public void setCustomer(Customer selectedCustomer)
        {
            currentCustomer = selectedCustomer;

            boxFirstName.Text = selectedCustomer.firstName;
            boxLastName.Text = selectedCustomer.lastName;
            boxInstitution.Text = selectedCustomer.institution;
            boxAddress1.Text = selectedCustomer.address1;
            boxAddress2.Text = selectedCustomer.address2;
            boxAddress3.Text = selectedCustomer.address3;
            boxPostcode.Text = selectedCustomer.postCode;
            boxCountry.Text = selectedCustomer.country;
        }

        /*Precondition:
         Postcondition: A book has been found, autofill information and store book*/
        public void addBook(Stock selectedStock)
        {
            orderedBooks.Add(selectedStock);

            dataGridView1.Rows.Add(1, selectedStock.author, selectedStock.title, selectedStock.price, selectedStock.bookID, "$0.00");
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
            
            //Get all information out of text boxes
            string firstName = SQLSyntaxHelper.escapeSingleQuotes(boxFirstName.Text);
            string lastName = SQLSyntaxHelper.escapeSingleQuotes(boxLastName.Text);
            string institution = SQLSyntaxHelper.escapeSingleQuotes(boxInstitution.Text);
            string add1 = SQLSyntaxHelper.escapeSingleQuotes(boxAddress1.Text);
            string add2 = SQLSyntaxHelper.escapeSingleQuotes(boxAddress2.Text);
            string add3 = SQLSyntaxHelper.escapeSingleQuotes(boxAddress3.Text);
            string postcode = SQLSyntaxHelper.escapeSingleQuotes(boxPostcode.Text);
            string country = SQLSyntaxHelper.escapeSingleQuotes(boxCountry.Text);
            string orderRef = SQLSyntaxHelper.escapeSingleQuotes(boxOrderRef.Text);
            string progress = SQLSyntaxHelper.escapeSingleQuotes(boxProgress.Text);
            string invoiceDate = SQLSyntaxHelper.escapeSingleQuotes(boxInvoiceDate.Text);
            string freight = SQLSyntaxHelper.escapeSingleQuotes(boxFreight.Text);
            string comments = SQLSyntaxHelper.escapeSingleQuotes(boxComments.Text);

            //Get invoice/orderID for current order
            int nextOrderIDAndInvoiceNo = dbManager.getNextOrderID();

            //Unsure of CatItem, doesn't seem to be used anymore and could be BookID for older orders
            if (currentCustomer != null)
            {
                Order newOrder = new Order(firstName, lastName, institution, postcode, orderRef, progress, freight, nextOrderIDAndInvoiceNo, invoiceDate, comments, currentCustomer.custID);

                List<OrderedStock> newOrderedStock = new List<OrderedStock>();

                int currRowIndex = 0;

                //Loop over all the books selected and create orderedStock from them
                foreach (Stock s in orderedBooks)
                {
                    //Get quantity, price and discount from the datagrid
                    int quantity = Convert.ToInt32(dataGridView1.Rows[currRowIndex].Cells[0].Value.ToString());
                    string price = dataGridView1.Rows[currRowIndex].Cells[3].Value.ToString();
                    string discount = dataGridView1.Rows[currRowIndex].Cells[5].Value.ToString();
                    string author = SQLSyntaxHelper.escapeSingleQuotes(s.author);
                    string title = SQLSyntaxHelper.escapeSingleQuotes(s.title);
                    string bookID = SQLSyntaxHelper.escapeSingleQuotes(s.bookID);

                    //Create the orderedStock and store
                    OrderedStock o = new OrderedStock(nextOrderIDAndInvoiceNo, s.stockID, quantity, author, title, price, bookID, discount);
                    newOrderedStock.Add(o);

                    currRowIndex++;
                }

                //Insert new order and orderedStock into database
                dbManager.insertOrder(newOrder);
                dbManager.insertOrderedStock(newOrderedStock);

                if(ordersForm != null)
                    ordersForm.loadOrder(nextOrderIDAndInvoiceNo);

                this.Close();

                //TODO remove
                MessageBox.Show("Saved \nOrder ID: " + nextOrderIDAndInvoiceNo);
            }
            else
            {
                MessageBox.Show("No Customer selected");
            }
        }

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

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.CurrentCell.RowIndex;

            if (!dataGridView1.Rows[selectedRow].IsNewRow)
            {
                dataGridView1.Rows.RemoveAt(selectedRow);

                orderedBooks.RemoveAt(selectedRow);
            }
        }
    }
}
