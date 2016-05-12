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
        private IStockReceiver stockReceiver;
        private List<Stock> foundStock;
        private DatabaseManager dbManager;

        //Constructor
        public StockSearch(IStockReceiver stockReceiver)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            this.stockReceiver = stockReceiver;

            setup();
            
        }

        /*Precondition:
        Postcondition: Sets up and initialises everything needed */
        private void setup()
        {
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

            boxBookID.Select();

            boxBookID.KeyPress += TextBox_KeyPress_Enter;
            boxAuthor.KeyPress += TextBox_KeyPress_Enter;
            boxTitle.KeyPress += TextBox_KeyPress_Enter;
            boxSubject.KeyPress += TextBox_KeyPress_Enter;
        }

        /*Precondition:
         Postcondition: Closes form */
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*Precondition:
        Postcondition: Listens for keypresses no matter which control has focus */
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
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
            stockReceiver.addStock(selectedStock);
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
                stockReceiver.addStock(selectedStock);
                this.Close();
            }
            catch (NullReferenceException)
            {
                //Do nothing, user double clicked on the header
            }
        }


        /*Precondition:
        Postcondition: Keypress handler for all textboxes. Starts the search for customers */
        private void TextBox_KeyPress_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                startSearch();

                //Stops the windows noise
                e.Handled = true;
            }
        }

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
                Stock found = dbManager.searchStock(bookID, searchAllStock);
                if (found != null)
                {
                    foundStock.Add(found);

                    labResults.Text = foundStock.Count.ToString();

                    //Display found stock
                    foreach (Stock s in foundStock)
                    {
                        dataGridView1.Rows.Add(s.quantity, s.author, s.title, s.subject, "$" + String.Format("{0:0.00}", s.price), s.bookID);
                    }

                    dataGridView1.Focus();
                }
                else
                {
                    dataGridView1.Rows.Add("", "No stock found", "", "", "", "");
                    btnSelectStock.Enabled = false;
                }
            }
            else if (boxAuthor.Text != "" || boxTitle.Text != "" || boxSubject.Text != "") //ID wasn't entered, search if any other fields have been filled
            {
                string author = null;
                string title = null;
                string subject = null;

                //Find out which fields have been entered to be included in the search
                if (boxAuthor.Text != "")
                    author = SyntaxHelper.escapeSingleQuotes(boxAuthor.Text);
                if (boxTitle.Text != "")
                    title = SyntaxHelper.escapeSingleQuotes(boxTitle.Text);
                if (boxSubject.Text != "")
                    subject = SyntaxHelper.escapeSingleQuotes(boxSubject.Text);

                bool exactPhrase = checkExactPhrase.Checked;

                //Search for stock based on the parameters entered
                foundStock = dbManager.searchStock(author, title, subject, searchAllStock, exactPhrase);

                labResults.Text = foundStock.Count.ToString();

                if (foundStock.Count == 0)
                {
                    dataGridView1.Rows.Add("", "No stock found", "", "", "", "");
                    btnSelectStock.Enabled = false;
                }
                else
                {
                    foundStock = foundStock.OrderBy(x => x.title).ToList();

                    //Display found stock
                    foreach (Stock s in foundStock)
                    {
                        dataGridView1.Rows.Add(s.quantity, s.author, s.title, s.subject, "$" + String.Format("{0:0.00}", s.price), s.bookID);
                    }

                    dataGridView1.Focus();
                }
            }
        }

        /*Precondition:
         Postcondition: Enable button once there is something that has been selected */
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnSelectStock.Enabled = true;
        }

        /*Precondition:
        Postcondition: Passes stock back to form that needs it when enter is pressed on datagrid */
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            //Check key was enter
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;

                int currRow = dataGridView1.CurrentCell.RowIndex;

                //Get the selected stock and pass it into the stockReceiver
                Stock selectedStock = foundStock[currRow];
                stockReceiver.addStock(selectedStock);
                this.Close();
            }
        }
    }
}
