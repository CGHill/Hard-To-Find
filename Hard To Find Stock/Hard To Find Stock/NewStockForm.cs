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

        //Constructor
        public NewStockForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            dbManager = new DatabaseManager();

            string date = DateTime.Now.ToString("d/MM/yyyy");
            boxDateEntered.Text = date;
        }

        /*Precondition: 
         Postcondition: Saves the new stock into the database*/
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (boxQuantity.Text != "" && boxAuthor.Text != "" && boxTitle.Text != "" && boxBookID.Text != "")
            {
                int quantity = Convert.ToInt32(boxQuantity.Text);
                string note = SQLSyntaxHelper.escapeSingleQuotes(boxNote.Text);
                string author = SQLSyntaxHelper.escapeSingleQuotes(boxAuthor.Text);
                string title = SQLSyntaxHelper.escapeSingleQuotes(boxTitle.Text);
                string subtitle = SQLSyntaxHelper.escapeSingleQuotes(boxSubtitle.Text);
                string publisher = SQLSyntaxHelper.escapeSingleQuotes(boxPublisher.Text);
                string description = SQLSyntaxHelper.escapeSingleQuotes(boxDescription.Text);
                string comment = SQLSyntaxHelper.escapeSingleQuotes(boxComment.Text);
                string price = SQLSyntaxHelper.escapeSingleQuotes(boxPrice.Text);
                string subject = SQLSyntaxHelper.escapeSingleQuotes(boxSubtitle.Text);
                string catalogues = SQLSyntaxHelper.escapeSingleQuotes(boxCatalogues.Text);
                string sales = SQLSyntaxHelper.escapeSingleQuotes(boxSales.Text);
                string bookID = SQLSyntaxHelper.escapeSingleQuotes(boxBookID.Text);
                string dateEntered = SQLSyntaxHelper.escapeSingleQuotes(boxDateEntered.Text);

                Stock newStock = new Stock(quantity, note, author, title, subtitle, publisher, description, comment, price, subject, catalogues, sales, bookID, dateEntered);

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
    }
}
