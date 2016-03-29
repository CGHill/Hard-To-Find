using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Hard_To_Find_Stock
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

            Stock newStock = dbManager.searchNewStock(currStock.bookID, true);

            //Update all stock information
            currStock.quantity = Convert.ToInt32(boxQuantity.Text);
            currStock.note = SQLSyntaxHelper.escapeSingleQuotes(boxNote.Text);
            currStock.author = SQLSyntaxHelper.escapeSingleQuotes(boxAuthor.Text);
            currStock.title = SQLSyntaxHelper.escapeSingleQuotes(boxTitle.Text);
            currStock.subtitle = SQLSyntaxHelper.escapeSingleQuotes(boxSubtitle.Text);
            currStock.publisher = SQLSyntaxHelper.escapeSingleQuotes(boxPublisher.Text);
            currStock.description = SQLSyntaxHelper.escapeSingleQuotes(boxDescription.Text);
            currStock.comments = SQLSyntaxHelper.escapeSingleQuotes(boxComment.Text);
            currStock.price = SQLSyntaxHelper.escapeSingleQuotes(boxPrice.Text);
            currStock.subject = SQLSyntaxHelper.escapeSingleQuotes(boxSubject.Text);
            currStock.catalogue = SQLSyntaxHelper.escapeSingleQuotes(boxCatalogues.Text);
            currStock.sales = SQLSyntaxHelper.escapeSingleQuotes(boxSales.Text);
            currStock.bookID = SQLSyntaxHelper.escapeSingleQuotes(boxBookID.Text);
            currStock.dateEntered = SQLSyntaxHelper.escapeSingleQuotes(boxDateEntered.Text);

            //Send updated stock information to database
            //Check if the stock being updated is a new one so it can update it in both tables
            if (newStock != null)
            {
                //Get the updated data with the correct ID from the new stock table and update it
                newStock.quantity = currStock.quantity;
                newStock.note = currStock.note;
                newStock.author = currStock.author;
                newStock.title = currStock.title;
                newStock.subtitle = currStock.subtitle;
                newStock.publisher = currStock.publisher;
                newStock.description = currStock.description;
                newStock.comments = currStock.comments;
                newStock.price = currStock.price;
                newStock.subject = currStock.subject;
                newStock.catalogue = currStock.catalogue;
                newStock.sales = currStock.sales;
                newStock.bookID = currStock.bookID;
                newStock.dateEntered = currStock.dateEntered;

                dbManager.updateNewStock(newStock);

                //Update it on the main stock table as well
                dbManager.updateStock(currStock);
            }
            else
            {
                dbManager.updateStock(currStock);
            }
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
            boxPrice.ReadOnly = !boxPrice.ReadOnly;
            boxSubject.ReadOnly = !boxSubject.ReadOnly;
            boxCatalogues.ReadOnly = !boxCatalogues.ReadOnly;
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
            boxSales.Text = currStock.sales;
            boxBookID.Text = currStock.bookID;
            boxDateEntered.Text = currStock.dateEntered;
        }
    }
}
