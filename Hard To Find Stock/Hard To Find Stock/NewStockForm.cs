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
        private List<bool> newStockAlreadyInDatabase;
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
            newStockAlreadyInDatabase = new List<bool>();
            tabPress = false;
            indexOfNewStock = 0;

            //Setup event handlers for when a texbox is entered
            boxQuantity.Enter += textbox_Enter;
            boxNote.Enter += textbox_Enter;
            boxAuthor.Enter += textbox_Enter;
            boxTitle.Enter += textbox_Enter;
            boxSubtitle.Enter += textbox_Enter;
            boxPublisher.Enter += textbox_Enter;
            boxComment.Enter += textbox_Enter;
            boxDescription.Enter += textbox_Enter;
            boxPrice.Enter += textbox_Enter;
            boxSubject.Enter += textbox_Enter;
            boxCatalogues.Enter += textbox_Enter;
            boxInitials.Enter += textbox_Enter;
            boxSales.Enter += textbox_Enter;
            boxBookID.Enter += textbox_Enter;
            boxDateEntered.Enter += textbox_Enter;

            //Give focus to author box
            boxAuthor.Select();

            //Get all of the stock that's in the newstock table
            newStockEntered = dbManager.getAllNewStock();

            //Check to see newstock wasn't 0
            if (newStockEntered.Count != 0)
            {
                //Set the index to the last entry
                indexOfNewStock = newStockEntered.Count - 1;

                //Get the last entry
                Stock currStock = newStockEntered[indexOfNewStock];

                //Load up last entry into textboxes
                loadStockIntoTextboxes(currStock);

                btnPrev.Enabled = true;

                //Track which entries came from the database already
                for (int i = 0; i < newStockEntered.Count; i++)
                {
                    newStockAlreadyInDatabase.Add(true);
                }
            }
        }

        /*Precondition: 
         Postcondition: Saves the new stock into the database*/
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (indexOfNewStock >= 0 && wasAnyInfoEntered())
            {
                saveEntry();
            }

            bool canSave = true;

            string failedEntries = "";

            int failedEntryIndex = 1;

            //Loop over stock checking if they can be saved
            foreach (Stock s in newStockEntered)
            {
                //Check to see if all the boxes are blank so the entry can be ignored
                if (s.note != "" || s.author != "" || s.title != "" || s.subtitle != "" || s.publisher != "" || s.comments != "" || s.description != "" || s.subject != "" || s.catalogue != ""
                    || s.initials != "" || s.sales != "" || s.bookID != "" || s.dateEntered != "")
                {
                    //Check if any of the basic information required to save is missing
                    if (s.author == "" || s.title == "" || s.bookID == "")
                    {
                        //Build up a list of the stock that failed to save to display to the user
                        if (!canSave)
                            failedEntries += ", " + failedEntryIndex.ToString();
                        else
                            failedEntries += failedEntryIndex.ToString();

                        canSave = false;
                    }
                }
                failedEntryIndex++;
            }

            if (canSave)
            {
                int index = 0;

                //Add to database
                foreach (Stock s in newStockEntered)
                {
                    //Check to see if all the boxes are blank so the entry can be ignored
                    if (s.note != "" || s.author != "" || s.title != "" || s.subtitle != "" || s.publisher != "" || s.comments != "" || s.description != "" || s.subject != "" || s.catalogue != ""
                        || s.initials != "" || s.sales != "" || s.bookID != "" || s.dateEntered != "")
                    {
                        //Check to see if index is within range of the array
                        if (index < newStockAlreadyInDatabase.Count)
                        {
                            //Check to see whether entry is already in the database
                            if (!newStockAlreadyInDatabase[index])
                            {
                                //Put entry into database
                                if (s.author != "" && s.title != "" && s.bookID != "")
                                    dbManager.insertNewStock(s);
                            }
                        }
                        else
                        {
                            //Entry outside range of array, hasn't been entered into database so enter it
                            if (s.author != "" && s.title != "" && s.bookID != "")
                                dbManager.insertNewStock(s);
                        }
                    }

                    index++;
                }

                //Finished saving, close form
                this.Close();
            }
            else
            {
                //Not enough information entered to save, inform user and load up the first failed entry
                MessageBox.Show("Issues with entries: " + failedEntries + "\nPlease make sure author, title and bookID and filled in on all entries");

                string[] failedEntrySplit = failedEntries.Split(',');

                int indexOfFailed = Convert.ToInt32(failedEntrySplit[0]) - 1;

                indexOfNewStock = indexOfFailed;

                Stock failedStock = newStockEntered[indexOfFailed];
                loadStockIntoTextboxes(failedStock);
            }
            
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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

            //Ctrl + ' shortcut to autofill in textbox with what was in the previous entry
            if (keyData == (Keys.Control | Keys.OemQuotes))
            {
                Stock previousStock = null;
                //Set previous stock out of array
                if ((indexOfNewStock - 1) >= 0)
                {
                    previousStock = newStockEntered[indexOfNewStock - 1];
                }
                //Set previous stock from database manager
                else if ((indexOfNewStock - 1) == -1)
                {
                    previousStock = dbManager.getLastStock();
                }

                if (previousStock != null)
                {
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
                        boxPrice.Text = "$" + previousStock.price.ToString();
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

            if(keyData == (Keys.Control | Keys.Oemcomma))
            {
                previousEntry();
            }
            if (keyData ==  (Keys.Control | Keys.OemPeriod))
            {
                nextEntry();
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

        /*Precondition:
         Postcondition: Moves to the previous stock entry */
        private void btnPrev_Click(object sender, EventArgs e)
        {
            previousEntry();
        }


        /*Precondition:
         Postcondition: Save current entry and load up previous */
        private void previousEntry()
        {
            if (indexOfNewStock >= 0 && wasAnyInfoEntered())
            {
                //Try to save the current newStock entry
                saveEntry();
            }

            //Update the index
            indexOfNewStock--;

            Stock currStock = null;

            if (indexOfNewStock < 0)
            {
                currStock = dbManager.getLastStock();

                if (indexOfNewStock != -1)
                {
                    int idOfStockToGet = currStock.stockID + indexOfNewStock + 1;
                    currStock = dbManager.searchStock(idOfStockToGet);
                }
            }
            else
            {
                //Load up the now current entry
                currStock = newStockEntered[indexOfNewStock];
            }

            loadStockIntoTextboxes(currStock);

            boxAuthor.Focus();
        }

        /*Precondition:
         Postcondition: Moves to the next entry in the list or create a new entry */
        private void btnNext_Click(object sender, EventArgs e)
        {
            nextEntry();
        }

        /*Precondition:
         Postcondition: Save current entry and load up next entry or blank */
        private void nextEntry()
        {
            bool cameFromNegativeEntry = false;

            if (indexOfNewStock < 0 && (indexOfNewStock + 1 == 0))
                cameFromNegativeEntry = true;

            if (indexOfNewStock >= 0 || cameFromNegativeEntry)
            {
                //Check to see if any new info has been updated to stop creating blank entries
                if (wasAnyInfoEntered())
                {
                    //Try to save entry
                    if (!cameFromNegativeEntry)
                        saveEntry();

                    //Update index
                    indexOfNewStock++;

                    //Update display for user
                    if (indexOfNewStock < newStockEntered.Count)
                        labEntryCounter.Text = (indexOfNewStock + 1).ToString() + " / " + (newStockEntered.Count);
                    else
                        labEntryCounter.Text = (indexOfNewStock + 1).ToString() + " / " + (newStockEntered.Count + 1);

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

                        loadStockIntoTextboxes(currStock);
                    }

                    //Reset focus back to the author box
                    boxAuthor.Select();
                }
            }
            else
            {
                //Update index
                indexOfNewStock++;

                Stock currStock = dbManager.getLastStock();

                if (indexOfNewStock != -1)
                {
                    int idOfStockToGet = currStock.stockID + indexOfNewStock + 1;
                    currStock = dbManager.searchStock(idOfStockToGet);
                }

                loadStockIntoTextboxes(currStock);
            }
        }

        /*Precondition:
         Postcondition: Checks to see if it's current information entered is a new entry that needs saved or existing entry that needs updated */
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
                string priceString = SyntaxHelper.escapeSingleQuotes(boxPrice.Text);
                double price = 0.00;
                if (priceString != "" && priceString.Any(x => !char.IsLetter(x)))
                {
                    if (priceString[0] == '$')
                        price = Convert.ToDouble(priceString.Substring(1));
                    else
                        price = Convert.ToDouble(priceString);
                }
                string subject = SyntaxHelper.escapeSingleQuotes(boxSubject.Text);
                string catalogues = SyntaxHelper.escapeSingleQuotes(boxCatalogues.Text);
                string initials = SyntaxHelper.escapeSingleQuotes(boxInitials.Text);
                string sales = SyntaxHelper.escapeSingleQuotes(boxSales.Text);
                string bookID = SyntaxHelper.escapeSingleQuotes(boxBookID.Text);
                string dateEntered = SyntaxHelper.escapeSingleQuotes(boxDateEntered.Text);

                Stock newStock = new Stock(quantity, note, author, title, subtitle, publisher, description, comment, price, subject, catalogues, initials, sales, bookID, dateEntered);

                newStockEntered.Add(newStock);
                newStockAlreadyInDatabase.Add(false);
            }
            else //Existing entry, update values
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
                string priceString = SyntaxHelper.escapeSingleQuotes(boxPrice.Text);
                if (priceString != "" && priceString.Any(x => !char.IsLetter(x)))
                {
                    if (priceString[0] == '$')
                        currStock.price = Convert.ToDouble(priceString.Substring(1));
                    else
                        currStock.price = Convert.ToDouble(priceString);
                }
                else
                    currStock.price = 0.00;
                currStock.subject = SyntaxHelper.escapeSingleQuotes(boxSubject.Text);
                currStock.catalogue = SyntaxHelper.escapeSingleQuotes(boxCatalogues.Text);
                currStock.initials = SyntaxHelper.escapeSingleQuotes(boxInitials.Text);
                currStock.sales = SyntaxHelper.escapeSingleQuotes(boxSales.Text);
                currStock.bookID = SyntaxHelper.escapeSingleQuotes(boxBookID.Text);
                currStock.dateEntered = SyntaxHelper.escapeSingleQuotes(boxDateEntered.Text);

                //Check to see if entry is in the database, then update it if it is
                if (indexOfNewStock < newStockAlreadyInDatabase.Count)
                {
                    if (newStockAlreadyInDatabase[indexOfNewStock])
                        dbManager.updateNewStock(currStock);
                }
            }
        }

        /*Precondition:
         Postcondition: Returns true if any of the textboxes has information in it */
        private bool wasAnyInfoEntered()
        {
            bool infoEntered = false;


            if (boxNote.Text != "" || boxAuthor.Text != "" || boxTitle.Text != "" || boxSubtitle.Text != "" || boxPublisher.Text != "" || boxDescription.Text != "" || boxComment.Text != ""
                || boxPrice.Text != "" || boxSubject.Text != "" || boxCatalogues.Text != "" || boxInitials.Text != "" || boxSales.Text != "" || boxBookID.Text != "" || boxDateEntered.Text != "")
                infoEntered = true;

            return infoEntered;
        }

        private void loadStockIntoTextboxes(Stock currStock)
        {
            //Update textboxes
            boxQuantity.Text = currStock.quantity.ToString(); ;
            boxNote.Text = currStock.note;
            boxAuthor.Text = currStock.author;
            boxTitle.Text = currStock.title;
            boxSubtitle.Text = currStock.subtitle;
            boxPublisher.Text = currStock.publisher;
            boxComment.Text = currStock.comments;
            boxDescription.Text = currStock.description;
            boxPrice.Text = "$" + String.Format("{0:0.00}", currStock.price);
            boxSubject.Text = currStock.subject;
            boxCatalogues.Text = currStock.catalogue;
            boxInitials.Text = currStock.initials;
            boxSales.Text = currStock.sales;
            boxBookID.Text = currStock.bookID;
            boxDateEntered.Text = currStock.dateEntered;

            //Update label so user knows the entry number
            labEntryCounter.Text = (indexOfNewStock + 1).ToString() + " / " + (newStockEntered.Count);
        }
    }
}
