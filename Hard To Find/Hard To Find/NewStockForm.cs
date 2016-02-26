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

        //Constructor
        public NewStockForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            dbManager = new DatabaseManager();
        }

        /*Precondition: 
         Postcondition: Saves the new stock into the database*/
        private void btnSave_Click(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(boxQuantity.Text);
            string note = boxNote.Text;
            string author = boxAuthor.Text;
            string title = boxTitle.Text;
            string subtitle = boxSubtitle.Text;
            string publisher = boxPublisher.Text;
            string description = boxDescription.Text;
            string comment = boxComment.Text;
            string location = boxLocation.Text;
            string price = boxPrice.Text;
            string subject = boxSubtitle.Text;
            string catalogues = boxCatalogues.Text;
            string weight = boxWeight.Text;
            string sales = boxSales.Text;
            string bookID = boxBookID.Text;
            string dateEntered = boxDateEntered.Text;

            Stock newStock = new Stock(quantity, note, author, title, subtitle, publisher, description, comment, location, price, subject, catalogues, weight, sales, bookID, dateEntered);

            dbManager.insertStock(newStock);

            this.Close();
        }

        /*Precondition: 
         Postcondition: Closes the form on button push*/
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
