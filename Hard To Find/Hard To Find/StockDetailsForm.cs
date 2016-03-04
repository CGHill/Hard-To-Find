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

        //Constructor
        public StockDetailsForm(Stock currStock)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            dbManager = new DatabaseManager();

            this.currStock = currStock;
            loadStock();
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
            currStock.note = checkForSingleQuote(boxNote.Text);
            currStock.author = checkForSingleQuote(boxAuthor.Text);
            currStock.title = checkForSingleQuote(boxTitle.Text);
            currStock.subtitle = checkForSingleQuote(boxSubtitle.Text);
            currStock.publisher = checkForSingleQuote(boxPublisher.Text);
            currStock.description = checkForSingleQuote(boxDescription.Text);
            currStock.comments = checkForSingleQuote(boxComment.Text);
            currStock.location = checkForSingleQuote(boxLocation.Text);
            currStock.price = checkForSingleQuote(boxPrice.Text);
            currStock.subject = checkForSingleQuote(boxSubject.Text);
            currStock.catalogue = checkForSingleQuote(boxCatalogues.Text);
            currStock.weight = checkForSingleQuote(boxWeight.Text);
            currStock.sales = checkForSingleQuote(boxSales.Text);
            currStock.bookID = checkForSingleQuote(boxBookID.Text);
            currStock.dateEntered = checkForSingleQuote(boxDateEntered.Text);

            //Send updated stock information to database
            dbManager.updateStock(currStock);
        }

        private string checkForSingleQuote(string stringToCheck)
        {
            //Check if it contains a single quotation
            if (stringToCheck.Contains('\''))
            {
                //Get number of single quotations
                int numQuotes = stringToCheck.Split('\'').Length - 1;
                //int num = removedDashes.Count(c => c == '\'');

                int previousIndex = 0;

                //Loop over quotations
                for (int i = 0; i < numQuotes; i++)
                {
                    //Insert quotation before existing one because it's an escape character in SQLite
                    int indexOfQuote = stringToCheck.IndexOf("'", previousIndex);
                    stringToCheck = stringToCheck.Insert(indexOfQuote, "'");

                    //Move index after quotation that was just fixed to stop repeating on the same one
                    previousIndex = indexOfQuote + 2;
                }

            }

            return stringToCheck;
        }

        /*Precondition:
         Postcondition: Closes this form*/
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            boxLocation.ReadOnly = !boxLocation.ReadOnly;
            boxPrice.ReadOnly = !boxPrice.ReadOnly;
            boxSubject.ReadOnly = !boxSubject.ReadOnly;
            boxCatalogues.ReadOnly = !boxCatalogues.ReadOnly;
            boxWeight.ReadOnly = !boxWeight.ReadOnly;
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
            boxLocation.Text = currStock.location;
            boxPrice.Text = currStock.price;
            boxSubject.Text = currStock.subject;
            boxCatalogues.Text = currStock.catalogue;
            boxWeight.Text = currStock.weight;
            boxSales.Text = currStock.sales;
            boxBookID.Text = currStock.bookID;
            boxDateEntered.Text = currStock.dateEntered;
        }
    }
}
