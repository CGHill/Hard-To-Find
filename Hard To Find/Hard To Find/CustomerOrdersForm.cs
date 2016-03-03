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
    public partial class CustomerOrdersForm : Form
    {
        private Customer currCustomer;
        private DatabaseManager dbManager;
        private List<Order> customersOrders;
        private Order currOrder;

        public CustomerOrdersForm(Customer currCustomer)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            this.currCustomer = currCustomer;
            dbManager = new DatabaseManager();
            customersOrders = new List<Order>();

            //Set up column widths
            DataGridViewColumn colOrderID = dataGridView1.Columns[0];
            colOrderID.Width = 100;
            DataGridViewColumn colRef = dataGridView1.Columns[1];
            colRef.Width = 100;
            DataGridViewColumn colInvoiceDate = dataGridView1.Columns[2];
            colInvoiceDate.Width = 100;

            DataGridViewColumn colQuantity = dataGridView2.Columns[0];
            colQuantity.Width = 50;
            DataGridViewColumn colAuthor = dataGridView2.Columns[1];
            colAuthor.Width = 187;
            DataGridViewColumn colTitle = dataGridView2.Columns[2];
            colTitle.Width = 270;
            DataGridViewColumn colPrice = dataGridView2.Columns[3];
            colPrice.Width = 75;
            DataGridViewColumn colBookID = dataGridView2.Columns[4];
            colBookID.Width = 75;
            DataGridViewColumn colDiscount = dataGridView2.Columns[5];
            colDiscount.Width = 75;

            customersOrders = dbManager.searchCustomersOrders(currCustomer.custID);

            //Set up first order from customer
            if (customersOrders.Count > 0)
            {
                currOrder = customersOrders[0];

                foreach (Order o in customersOrders)
                {
                    dataGridView1.Rows.Add(o.orderID, o.orderReference, o.invoiceDate);
                }
            }

            selectedOrderUpdated();
        }

        private void selectedOrderUpdated()
        {
            dataGridView2.Rows.Clear();

            List<OrderedStock> customersOrderedStock = new List<OrderedStock>();

            labOrderID.Text = currOrder.orderID.ToString();
            boxOrderRef.Text = currOrder.orderReference;
            boxProgress.Text = currOrder.progress;
            boxInvoiceDate.Text = currOrder.invoiceDate;
            boxFreight.Text = currOrder.discPrice;
            boxComments.Text = currOrder.comments;

            customersOrderedStock = dbManager.searchOrderedStock(currOrder.orderID);

            foreach (OrderedStock o in customersOrderedStock)
            {
                dataGridView2.Rows.Add(o.quantity, o.author, o.title, o.price, o.bookID, o.discount);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int currRow = dataGridView1.CurrentCell.RowIndex;

            if (currRow < customersOrders.Count)
            {
                currOrder = customersOrders[currRow];
                selectedOrderUpdated();
            }
        }

    }
}
