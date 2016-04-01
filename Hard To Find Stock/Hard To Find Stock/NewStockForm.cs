using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hard_To_Find_Stock
{
    public partial class NewStockForm : Form
    {
        //Globals
        private DatabaseManager dbManager;
        private bool tabPress;
        private List<Stock> newStockEntered;
        private int indexOfNewStock;

        //Constructor
        public NewStockForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            setup();
        }

        /*Precondition: 
          Postcondition: Initializes everything needed and autofills date */
        private void setup()
        {
            dbManager = new DatabaseManager();
            newStockEntered = new List<Stock>();
            tabPress = false;
            indexOfNewStock = 0;
        }

        /*Precondition: 
         Postcondition: Saves the new stock into the database*/
        private void btnSave_Click(object sender, EventArgs e)
        {
            saveEntry();

            bool canSave = true;

            string failedEntries = "";

            int failedEntryIndex = 1;

            //Add to database
            foreach (Stock s in newStockEntered)
            {
                if (s.author == "" && s.title == "" && s.bookID == "")
                {
                    if (!canSave)
                        failedEntries += ", " + failedEntryIndex.ToString();
                    else
                        failedEntries += failedEntryIndex.ToString();

                    canSave = false;
                }
                failedEntryIndex++;
            }


            if (canSave)
            {
                //Add to database
                foreach (Stock s in newStockEntered)
                {
                    if (s.author != "" && s.title != "" && s.bookID != "")
                    {
                        dbManager.insertStock(s);
                    }
                }

                this.Close();
            }
            else
                MessageBox.Show("Issues with entries: " + failedEntries + "\nPlease make sure author, title and bookID and filled in on all entries");
            
        }

        /*Precondition: 
         Postcondition: Closes the form on button push*/
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*Precondition:
         Postcondition: Only allows numbers in the quantity box */
        private void boxQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

        /*Precondition:
         Postcondition: Listens for keypresses no matter which control has focus */
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Check for tab pressed
            if (keyData == Keys.Tab)
            {
                tabPress = true;
                return false;    // indicate that you handled this keystroke
            }
            //Check for shift+tab pressed
            if (keyData == (Keys.Tab | Keys.Shift))
            {
                tabPress = true;
                return false;    // indicate that you handled this keystroke
            }
            if (keyData == (Keys.Control | Keys.OemQuotes))
            {
                if ((indexOfNewStock - 1) >= 0)
                {
                    Stock previousStock = newStockEntered[indexOfNewStock - 1];

                    //Load in value from previous entry
                    if (boxQuantity.Focused)
                        boxQuantity.Text = previousStock.quantity.ToString();
                    if (boxAuthor.Focused)
                        boxAuthor.Text = previousStock.author;
                    if (boxTitle.Focused)
                        boxTitle.Text = previousStock.title;
                    if (boxSubtitle.Focused)
                        boxSubtitle.Text = previousStock.subtitle;
                    if (boxPublisher.Focused)
                        boxPublisher.Text = previousStock.publisher;
                    if (boxComment.Focused)
                        boxComment.Text = previousStock.comments;
                    if (boxDescription.Focused)
                        boxDescription.Text = previousStock.description;
                    if (boxPrice.Focused)
                        boxPrice.Text = previousStock.price;
                    if (boxSubject.Focused)
                        boxSubject.Text = previousStock.subject;
                    if (boxCatalogues.Focused)
                        boxCatalogues.Text = previousStock.catalogue;
                    if (boxInitials.Focused)
                        boxInitials.Text = previousStock.initials;
                    if (boxSales.Focused)
                        boxSales.Text = previousStock.sales;
                    if (boxBookID.Focused)
                        boxBookID.Text = previousStock.bookID;
                    if (boxDateEntered.Focused)
                        boxDateEntered.Text = previousStock.dateEntered;
                }
            }


            //Closes form if escape is pressed
            if (keyData == Keys.Escape)
            {
                this.Close();
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /*Precondition:
         Postcondition: Handles all the textboxes when they get focus to check if the text in them needs to be selected or not */
        private void textbox_Enter(Object sender, EventArgs e)
        {
            if (tabPress)
            {
                TextBox enteredTextbox = (TextBox)sender;

                enteredTextbox.SelectAll();

                tabPress = false;
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            saveEntry();  

            indexOfNewStock--;

            labEntryCounter.Text = (indexOfNewStock + 1).ToString() + " / " + (newStockEntered.Count);

            if (indexOfNewStock == 0)
            {
                btnPrev.Enabled = false;
            }


            Stock currStock = newStockEntered[indexOfNewStock];

            boxQuantity.Text = currStock.quantity.ToString();
            boxNote.Text = currStock.note;
            boxAuthor.Text = currStock.author;
            boxTitle.Text = currStock.title;
            boxSubtitle.Text = currStock.subtitle;
            boxPublisher.Text = currStock.publisher;
            boxComment.Text = currStock.comments;
            boxDescription.Text = currStock.description;
            boxPrice.Text = currStock.price;
            boxSubject.Text = currStock.subject;
            boxCatalogues.Text = currStock.catalogue;
            boxInitials.Text = currStock.initials;
            boxSales.Text = currStock.sales;
            boxBookID.Text = currStock.bookID;
            boxDateEntered.Text = currStock.dateEntered;

            boxAuthor.Focus();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            saveEntry();

            indexOfNewStock++;

            if(indexOfNewStock < newStockEntered.Count)
                labEntryCounter.Text = (indexOfNewStock + 1).ToString() + " / " + (newStockEntered.Count);
            else
                labEntryCounter.Text = (indexOfNewStock + 1).ToString() + " / " + (newStockEntered.Count + 1);

            if (btnPrev.Enabled == false)
                btnPrev.Enabled = true;

            //New Entry
            if (indexOfNewStock == newStockEntered.Count)
            {
                boxQuantity.Text = "1";
                boxNote.Text = "";
                boxAuthor.Text = "";
                boxTitle.Text = "";
                boxSubtitle.Text = "";
                boxPublisher.Text = "";
                boxComment.Text = "";
                boxDescription.Text = "";
                boxPrice.Text = "";
                boxSubject.Text = "";
                boxCatalogues.Text = "";
                boxInitials.Text = "";
                boxSales.Text = "";
                boxBookID.Text = "";
                boxDateEntered.Text = "";
            }
            else //Not new entry, load up an existing new stock
            {
                Stock currStock = newStockEntered[indexOfNewStock];

                boxQuantity.Text = currStock.quantity.ToString(); ;
                boxNote.Text = currStock.note;
                boxAuthor.Text = currStock.author;
                boxTitle.Text = currStock.title;
                boxSubtitle.Text = currStock.subtitle;
                boxPublisher.Text = currStock.publisher;
                boxComment.Text = currStock.comments;
                boxDescription.Text = currStock.description;
                boxPrice.Text = currStock.price;
                boxSubject.Text = currStock.subject;
                boxCatalogues.Text = currStock.catalogue;
                boxInitials.Text = currStock.initials;
                boxSales.Text = currStock.sales;
                boxBookID.Text = currStock.bookID;
                boxDateEntered.Text = currStock.dateEntered;
            }

            boxAuthor.Focus();
        }

        private void saveEntry()
        {
            //Check if it's a new entry
            if (indexOfNewStock == newStockEntered.Count)
            {
                int quantity = Convert.ToInt32(boxQuantity.Text);
                string note = SyntaxHelper.escapeSingleQuotes(boxNote.Text);
                string author = SyntaxHelper.escapeSingleQuotes(boxAuthor.Text);
                string title = SyntaxHelper.escapeSingleQuotes(boxTitle.Text);
                string subtitle = SyntaxHelper.escapeSingleQuotes(boxSubtitle.Text);
                string publisher = SyntaxHelper.escapeSingleQuotes(boxPublisher.Text);
                string description = SyntaxHelper.escapeSingleQuotes(boxDescription.Text);
                string comment = SyntaxHelper.escapeSingleQuotes(boxComment.Text);
                string price = SyntaxHelper.escapeSingleQuotes(boxPrice.Text);
                string subject = SyntaxHelper.escapeSingleQuotes(boxSubject.Text);
                string catalogues = SyntaxHelper.escapeSingleQuotes(boxCatalogues.Text);
                string initials = SyntaxHelper.escapeSingleQuotes(boxInitials.Text);
                string sales = SyntaxHelper.escapeSingleQuotes(boxSales.Text);
                string bookID = SyntaxHelper.escapeSingleQuotes(boxBookID.Text);
                string dateEntered = SyntaxHelper.escapeSingleQuotes(boxDateEntered.Text);

                Stock newStock = new Stock(quantity, note, author, title, subtitle, publisher, description, comment, price, subject, catalogues, initials, sales, bookID, dateEntered);

                newStockEntered.Add(newStock);
            }
            else //Old entry, update values
            {
                Stock currStock = newStockEntered[indexOfNewStock];

                currStock.quantity = Convert.ToInt32(boxQuantity.Text);
                currStock.note = SyntaxHelper.escapeSingleQuotes(boxNote.Text);
                currStock.author = SyntaxHelper.escapeSingleQuotes(boxAuthor.Text);
                currStock.title = SyntaxHelper.escapeSingleQuotes(boxTitle.Text);
                currStock.subtitle = SyntaxHelper.escapeSingleQuotes(boxSubtitle.Text);
                currStock.publisher = SyntaxHelper.escapeSingleQuotes(boxPublisher.Text);
                currStock.description = SyntaxHelper.escapeSingleQuotes(boxDescription.Text);
                currStock.comments = SyntaxHelper.escapeSingleQuotes(boxComment.Text);
                currStock.price = SyntaxHelper.escapeSingleQuotes(boxPrice.Text);
                currStock.subject = SyntaxHelper.escapeSingleQuotes(boxSubject.Text);
                currStock.catalogue = SyntaxHelper.escapeSingleQuotes(boxCatalogues.Text);
                currStock.initials = SyntaxHelper.escapeSingleQuotes(boxInitials.Text);
                currStock.sales = SyntaxHelper.escapeSingleQuotes(boxSales.Text);
                currStock.bookID = SyntaxHelper.escapeSingleQuotes(boxBookID.Text);
                currStock.dateEntered = SyntaxHelper.escapeSingleQuotes(boxDateEntered.Text);
            }
        }
    }
}
