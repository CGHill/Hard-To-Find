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

            this.currStock = currStock;

            setup();            
        }

        /*Precondition: 
         Postcondition:  Initializes everything needed and loads up the stock to be displayed */
        private void setup()
        {
            dbManager = new DatabaseManager();
            loadStock();

            //boxStockID.BackColor = Color.White;
            //boxQuantity.BackColor = Color.White;
            //boxNote.BackColor = Color.White;
            //boxAuthor.BackColor = Color.White;
            //boxTitle.BackColor = Color.White;
            //boxSubtitle.BackColor = Color.White;
            //boxPublisher.BackColor = Color.White;
            //boxDescription.BackColor = Color.White;
            //boxComment.BackColor = Color.White;
            //boxPrice.BackColor = Color.White;
            //boxSubject.BackColor = Color.White;
            //boxCatalogues.BackColor = Color.White;
            //boxInitials.BackColor = Color.White;
            //boxSales.BackColor = Color.White;
            //boxBookID.BackColor = Color.White;
            //boxDateEntered.BackColor = Color.White;
        }
       
        /*Precondition:
         Postcondition: Closes this form*/
        private void btnClose_Click(object sender, EventArgs e)
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
    }
}
