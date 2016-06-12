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
        private MainMenu mainMenu;
        private DatabaseManager dbManager;
        private List<Stock> allStock;
        private List<Stock> foundStock;
        private FileManager fileManager;
        private Stock currStock;

        //Constructor
        public StockForm(MainMenu mainMenu)
        {
            this.mainMenu = mainMenu;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            setup();
        }

        /*Precondition:
        Postcondition: Sets up and initialises everything needed */
        private void setup()
        {
            //Create DB and list to store stock in
            dbManager = new DatabaseManager();
            fileManager = new FileManager();
            allStock = new List<Stock>();
            
            //Set up datagridview column widths
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

            //Give focus to bookID box
            boxSearchBookID.Select();

            //Set up event handlers for when enter is pressed in textboxes
            boxSearchBookID.KeyPress += TextBox_KeyPress_Enter;
            boxSearchAuthor.KeyPress += TextBox_KeyPress_Enter;
            boxSearchTitle.KeyPress += TextBox_KeyPress_Enter;
            boxSearchSubject.KeyPress += TextBox_KeyPress_Enter;
        }

        /*Precondition: 
         Postcondition: Go back to main menu*/
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            mainMenu.Show();
            mainMenu.Activate();
        }

        /*Precondition:
        Postcondition: Listens for keypresses no matter which control has focus */
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                mainMenu.Show();
                mainMenu.Activate();
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }


        /*Precondition:
         Postcondition: Starts search for Stock depending on which text boxes have been filled*/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            startSearch();
        }

        /*Precondition:
         Postcondition: Update textboxes with selected stock */
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (foundStock.Count != 0)
            {
                int currRow = dataGridView1.CurrentCell.RowIndex;

                currStock = foundStock[currRow];

                loadStock();
            }
        }

        /*Precondition:
         Postcondition: Loads up text boxes with the current stocks information*/
        private void loadStock()
        {
            boxStockID.Text = currStock.stockID.ToString();
            boxQuantity.Text = currStock.quantity.ToString();
            boxNote.Text = currStock.note;
            boxAuthor.Text = currStock.author;
            boxTitle.Text = currStock.title;
            boxSubtitle.Text = currStock.subtitle;
            boxPublisher.Text = currStock.publisher;
            boxDescription.Text = currStock.description;
            boxComment.Text = currStock.comments;
            boxPrice.Text = "$" + String.Format("{0:0.00}", currStock.price);
            boxSubject.Text = currStock.subject;
            boxCatalogues.Text = currStock.catalogue;
            boxInitials.Text = currStock.initials;
            boxSales.Text = currStock.sales;
            boxBookID.Text = currStock.bookID;
            boxDateEntered.Text = currStock.dateEntered;
        }
     

        /*Precondition: 
         Postcondition: Open form to create a new stock entry */
        private void btnNewStock_Click(object sender, EventArgs e)
        {
            NewStockForm nsf = new NewStockForm();
            nsf.Show();
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
            bool searchAllStock = true;

            if (rdoInStock.Checked)
                searchAllStock = false;

            //If ID was entered then search only on that
            if (boxSearchBookID.Text != "")
            {
                string bookID = boxSearchBookID.Text;

                //Put found stock into list
                Stock found = dbManager.searchStock(bookID, searchAllStock);
                if (found != null)
                {
                    foundStock.Add(found);
                }
            }
            else if (boxSearchAuthor.Text != "" || boxSearchTitle.Text != "" || boxSearchSubject.Text != "") //ID wasn't entered, search if any other fields have been filled
            {
                string author = null;
                string title = null;
                string subject = null;

                //Find out which fields have been entered to be included in the search
                if (boxSearchAuthor.Text != "")
                    author = boxSearchAuthor.Text;
                if (boxSearchTitle.Text != "")
                    title = boxSearchTitle.Text;
                if (boxSearchSubject.Text != "")
                    subject = boxSearchSubject.Text;

                bool exactPhrase = checkExactPhrase.Checked;

                //Search for stock based on the parameters entered
                foundStock = dbManager.searchStock(author, title, subject, searchAllStock, exactPhrase);
            }

            //Sort the information as the user wants
            if (comboBox1.SelectedItem != null)
            {
                string selectedSort = comboBox1.SelectedItem.ToString();
                switch (selectedSort)
                {
                    case "Quantity":
                        foundStock = foundStock.OrderBy(x => x.quantity).ToList();
                        break;
                    case "Author":
                        foundStock = foundStock.OrderBy(x => x.author).ToList();
                        break;
                    case "Title":
                        foundStock = foundStock.OrderBy(x => x.title).ToList();
                        break;
                    case "Price":
                        foundStock = foundStock.OrderBy(x => x.price).ToList();
                        break;
                }
            }

            //Add information to datagrid to be displayed
            labResults.Text = foundStock.Count.ToString();
            if (foundStock.Count == 0)
            {
                dataGridView1.Rows.Add("", "No stock found", "", "", "", "");
            }
            else
            {
                //Display found stock
                foreach (Stock s in foundStock)
                {
                    dataGridView1.Rows.Add(s.quantity, s.author, s.title, s.subject, "$" + String.Format("{0:0.00}", s.price), s.bookID);
                }

                dataGridView1.Focus();
            }
        }

        private void btnExportToDesk_Click(object sender, EventArgs e)
        {
            ConfirmExportToDeskForm cf = new ConfirmExportToDeskForm(this);
            cf.Show();
        }

        public void startExport(int numEntries)
        {
            //Change cursor so user has feedback that program is doing something
            Cursor.Current = Cursors.WaitCursor;

            fileManager.writeStockExportToDeskPCFile(numEntries);

            //Change cursor back to default
            Cursor.Current = Cursors.Default;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;

            toggleBoxesReadOnly();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;

            boxQuantity.Select();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            int currRow = dataGridView1.CurrentCell.RowIndex;


            toggleBoxesReadOnly();
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;

            //Update all stock information
            currStock.quantity = Convert.ToInt32(boxQuantity.Text);
            currStock.note = boxNote.Text;
            currStock.author = boxAuthor.Text;
            currStock.title = boxTitle.Text;
            currStock.subtitle = boxSubtitle.Text;
            currStock.publisher = boxPublisher.Text;
            currStock.description = boxDescription.Text;
            currStock.comments = boxComment.Text;
            
            currStock.price = 0.00;
            string priceString = boxPrice.Text;
            if (priceString != "")
            {
                if (priceString[0] == '$')
                    currStock.price = Convert.ToDouble(priceString.Substring(1));
                else
                    currStock.price = Convert.ToDouble(priceString);
            }

            currStock.subject = boxSubject.Text;
            currStock.catalogue = boxCatalogues.Text;
            currStock.initials = boxInitials.Text;
            currStock.sales = boxSales.Text;
            currStock.bookID = boxBookID.Text;
            currStock.dateEntered = boxDateEntered.Text;

            //Send updated stock information to database
            dbManager.updateStock(currStock);

            startSearch();

            //Reselect row so user stays on the same entry
            dataGridView1.Rows[currRow].Selected = true;
        }

        /*Precondition: None
         Postcondition: Toggles textboxes ReadOnly between true and false so that stock data can be updated */
        private void toggleBoxesReadOnly()
        {
            boxQuantity.ReadOnly = !boxQuantity.ReadOnly;
            boxNote.ReadOnly = !boxNote.ReadOnly;
            boxAuthor.ReadOnly = !boxAuthor.ReadOnly;
            boxTitle.ReadOnly = !boxTitle.ReadOnly;
            boxSubtitle.ReadOnly = !boxSubtitle.ReadOnly;
            boxPublisher.ReadOnly = !boxPublisher.ReadOnly;
            boxDescription.ReadOnly = !boxDescription.ReadOnly;
            boxComment.ReadOnly = !boxComment.ReadOnly;
            boxPrice.ReadOnly = !boxPrice.ReadOnly;
            boxSubject.ReadOnly = !boxSubject.ReadOnly;
            boxCatalogues.ReadOnly = !boxCatalogues.ReadOnly;
            boxInitials.ReadOnly = !boxInitials.ReadOnly;
            boxSales.ReadOnly = !boxSales.ReadOnly;
            boxBookID.ReadOnly = !boxBookID.ReadOnly;
            boxDateEntered.ReadOnly = !boxDateEntered.ReadOnly;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (foundStock != null)
            {
                if (foundStock.Count != 0)
                {
                    dataGridView1.Rows.Clear();

                    string selectedSort = comboBox1.SelectedItem.ToString();

                    switch (selectedSort)
                    {
                        case "Quantity":
                            foundStock = foundStock.OrderBy(x => x.quantity).ToList();
                            break;
                        case "Author":
                            foundStock = foundStock.OrderBy(x => x.author).ToList();
                            break;
                        case "Title":
                            foundStock = foundStock.OrderBy(x => x.title).ToList();
                            break;
                        case "Price":
                            foundStock = foundStock.OrderBy(x => x.price).ToList();
                            break;
                    }

                    foreach (Stock s in foundStock)
                    {
                        dataGridView1.Rows.Add(s.quantity, s.author, s.title, s.subject, "$" + String.Format("{0:0.00}", s.price), s.bookID);
                    }
                }
            }
        }

        /*Precondition:
         Postcondition: Automatically sets the price to contain a $ and 2 decimal places if not already set */
        private void boxPrice_Leave(object sender, EventArgs e)
        {
            string priceEntered = boxPrice.Text;

            bool noLetters = priceEntered.All(x => !char.IsLetter(x));

            if (noLetters)
            {
                if (priceEntered != "")
                {
                    string checkedPrice = SyntaxHelper.checkAddDollarSignAndDoubleDecimal(priceEntered);

                    boxPrice.Text = checkedPrice;
                }
            }
            else
            {
                MessageBox.Show("Price should not have letters");
            }
        }
    }
}
