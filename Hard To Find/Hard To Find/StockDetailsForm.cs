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
    public partial class StockDetailsForm : Form
    {
        //Global variables
        private DatabaseManager dbManager;
        private Stock currStock;
        Form previousForm;
        private bool tabPress;

        //Constructor
        public StockDetailsForm(Stock currStock, Form previousForm)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.currStock = currStock;
            this.previousForm = previousForm;

            setup();            
        }

        /*Precondition: 
         Postcondition:  Initializes everything needed and loads up the stock to be displayed */
        private void setup()
        {
            dbManager = new DatabaseManager();
            tabPress = false;

            //Setup event handlers for when a texbox is entered
            boxStockID.Enter += textbox_Enter;
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

            loadStock();

            btnUpdate.Select();
        }

        /*Precondition:
         Postcondition: Listens for keypresses no matter which control has focus */
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                previousForm.Activate();
            }
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
            boxPrice.Text = currStock.price;
            boxSubject.Text = currStock.subject;
            boxCatalogues.Text = currStock.catalogue;
            boxInitials.Text = currStock.initials;
            boxSales.Text = currStock.sales;
            boxBookID.Text = currStock.bookID;
            boxDateEntered.Text = currStock.dateEntered;
        }

        /*Precondition:
        Postcondition: Adds a $ sign and makes number 2 decimal places if it's not already */
        private void boxPrice_Leave(object sender, EventArgs e)
        {
            string priceEntered = boxPrice.Text;

            if (priceEntered != "")
            {
                bool noLetters = priceEntered.All(x => !char.IsLetter(x));

                if (noLetters)
                {
                    string checkedPrice = SyntaxHelper.checkAddDollarSignAndDoubleDecimal(priceEntered);

                    boxPrice.Text = checkedPrice;
                }
                else
                {
                    MessageBox.Show("Price shouldn't contain letters");
                }
            }
        }

        /*Precondition:
         Postcondition: Toggle text boxes to be written in*/
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            toggleBoxesReadOnly();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        /*Precondition:
         Postcondition: Toggle text boxes back. Send updated stock to database so the updates can be stored*/
        private void btnSave_Click(object sender, EventArgs e)
        {
            toggleBoxesReadOnly();
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;

            //Update all stock information
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

            //Send updated stock information to database
            dbManager.updateStock(currStock);
        }

        /*Precondition:
         Postcondition: Closes this form*/
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            previousForm.Activate();
        }
    }
}
