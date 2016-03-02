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
    public partial class StockSearch : Form
    {
        private NewOrderForm orderForm;
        private List<Stock> foundStock;
        private DatabaseManager dbManager;

        public StockSearch(NewOrderForm orderForm)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            this.orderForm = orderForm;
            foundStock = new List<Stock>();
            dbManager = new DatabaseManager();

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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Reset datagrid and stock for new search
            foundStock = new List<Stock>();
            dataGridView1.Rows.Clear();

            //If ID was entered then search only on that
            if (boxStockID.Text != "")
            {
                int stockID = Convert.ToInt32(boxStockID.Text);

                //Put found stock into list
                foundStock.Add(dbManager.searchStock(stockID));

                //Display found stock
                foreach (Stock s in foundStock)
                {
                    dataGridView1.Rows.Add(s.quantity, s.author, s.title, s.subtitle, s.price, s.bookID);
                }
            }
            else if (boxAuthor.Text != "" || boxTitle.Text != "" || boxSubject.Text != "") //ID wasn't entered, search if any other fields have been filled
            {
                string author = null;
                string title = null;
                string subject = null;

                //Find out which fields have been entered to be included in the search
                if (boxAuthor.Text != "")
                    author = boxAuthor.Text;
                if (boxTitle.Text != "")
                    title = boxTitle.Text;
                if (boxSubject.Text != "")
                    subject = boxSubject.Text;

                //Search for stock based on the parameters entered
                foundStock = dbManager.searchStock(author, title, subject);

                //Display found stock
                foreach (Stock s in foundStock)
                {
                    dataGridView1.Rows.Add(s.quantity, s.author, s.title, s.subtitle, s.price, s.bookID);
                }
            }
        }

        private void btnSelectStock_Click(object sender, EventArgs e)
        {
            int currRow = dataGridView1.CurrentCell.RowIndex;

            Stock selectedStock = foundStock[currRow];
            orderForm.addBook(selectedStock);
            this.Close();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int currRow = dataGridView1.CurrentCell.RowIndex;

            Stock selectedStock = foundStock[currRow];
            orderForm.addBook(selectedStock);
            this.Close();
        }
    }
}
