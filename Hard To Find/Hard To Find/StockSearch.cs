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
    public partial class StockSearch : Form
    {
        //Globals
        private NewOrderForm orderForm;
        private List<Stock> foundStock;
        private DatabaseManager dbManager;

        //Constructor
        public StockSearch(NewOrderForm orderForm)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            this.orderForm = orderForm;
            foundStock = new List<Stock>();
            dbManager = new DatabaseManager();

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
         Postcondition: Closes form */
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*Precondition:
         Postcondition: Starts the search when button is clicked*/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            startSearch();
        }

        /*Precondition:
        Postcondition: Closes form after passing the stock back which the user selected */
        private void btnSelectStock_Click(object sender, EventArgs e)
        {
            int currRow = dataGridView1.CurrentCell.RowIndex;

            Stock selectedStock = foundStock[currRow];
            orderForm.addBook(selectedStock);
            this.Close();
        }

        /*Precondition:
         Postcondition: If user double clicks on datagridrow, it counts as selecting an item, closes form and sends selection to previous form */
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int currRow = dataGridView1.CurrentCell.RowIndex;

                Stock selectedStock = foundStock[currRow];
                orderForm.addBook(selectedStock);
                this.Close();
            }
            catch (NullReferenceException)
            {
                //Do nothing, user double clicked on the header
            }
        }

        /******************** Keypress Handlers to start search on enter press*****************************/
        private void boxBookID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                startSearch();

                e.Handled = true;
            }
        }

        private void boxAuthor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                startSearch();

                e.Handled = true;
            }
        }

        private void boxTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                startSearch();

                e.Handled = true;
            }
        }

        private void boxSubject_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                startSearch();

                e.Handled = true;
            }
        }
        /*************************************************************************************************/

        /*Precondition:
         Postcondition: Starts a search for stock depending on what search boxes have been filled in*/
        private void startSearch()
        {
            //Reset datagrid and stock for new search
            foundStock = new List<Stock>();
            dataGridView1.Rows.Clear();
            btnSelectStock.Enabled = false;
            bool searchAllStock = true;

            if (rdoInStock.Checked)
                searchAllStock = false;

            //If ID was entered then search only on that
            if (boxBookID.Text != "")
            {
                string bookID = boxBookID.Text;

                //Put found stock into list
                foundStock.Add(dbManager.searchStock(bookID, searchAllStock));

                //Display found stock
                foreach (Stock s in foundStock)
                {
                    if(s != null)
                        dataGridView1.Rows.Add(s.quantity, s.author, s.title, s.subtitle, s.price, s.bookID);
                }
            }
            else if (boxAuthor.Text != "" || boxTitle.Text != "" || boxSubject.Text != "") //ID wasn't entered, search if any other fields have been filled
            {
                string author = null;
                string title = null;
                string subject = null;

                //Find out which fields have been entered to be included in the search
                if (boxAuthor.Text != "")
                    author = SQLSyntaxHelper.escapeSingleQuotes(boxAuthor.Text);
                if (boxTitle.Text != "")
                    title = SQLSyntaxHelper.escapeSingleQuotes(boxTitle.Text);
                if (boxSubject.Text != "")
                    subject = SQLSyntaxHelper.escapeSingleQuotes(boxSubject.Text);

                //Search for stock based on the parameters entered
                foundStock = dbManager.searchStock(author, title, subject, searchAllStock);

                //Display found stock
                foreach (Stock s in foundStock)
                {
                    dataGridView1.Rows.Add(s.quantity, s.author, s.title, s.subtitle, s.price, s.bookID);
                }
            }
        }

        /*Precondition:
         Postcondition: Enable button once there is something that has been selected */
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnSelectStock.Enabled = true;
        }
    }
}
