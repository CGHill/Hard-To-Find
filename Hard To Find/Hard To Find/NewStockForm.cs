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
    public partial class NewStockForm : Form
    {
        //Globals
        private DatabaseManager dbManager;
        private bool tabPress;

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
            tabPress = false;
        }

        /*Precondition: 
         Postcondition: Saves the new stock into the database*/
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (boxQuantity.Text != "" && boxAuthor.Text != "" && boxTitle.Text != "" && boxBookID.Text != "")
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

                dbManager.insertStock(newStock);

                this.Close();
            }
            else
            {

                MessageBox.Show("Please make sure quantity, author, title and bookID are entered");
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
    }
}
