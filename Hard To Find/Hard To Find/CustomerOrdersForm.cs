﻿using System;
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
        //Globals
        private Customer currCustomer;
        private DatabaseManager dbManager;
        private List<Order> customersOrders;
        private Order currOrder;

        //Constructor
        public CustomerOrdersForm(Customer currCustomer)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.currCustomer = currCustomer;

            setup();
        }

        /*Precondition:
         Postcondition: Sets up everything that needs to be done when form is initialized*/
        private void setup()
        {
            dbManager = new DatabaseManager();
            customersOrders = new List<Order>();

            labCustomerName.Text = "Orders for: " + currCustomer.firstName + " " + currCustomer.lastName;

            //Set up column widths
            DataGridViewColumn colOrderID = dataGridView1.Columns[0];
            colOrderID.Width = 100;
            DataGridViewColumn colRef = dataGridView1.Columns[1];
            colRef.Width = 100;
            DataGridViewColumn colInvoiceDate = dataGridView1.Columns[2];
            colInvoiceDate.Width = 100;

            //Set column widths of 2nd datagridview
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

            //Find the customers orders
            customersOrders = dbManager.searchCustomersOrders(currCustomer.custID);

            //Set up first order from customer if they have any orders
            if (customersOrders.Count > 0)
            {
                currOrder = customersOrders[0];

                foreach (Order o in customersOrders)
                {
                    dataGridView1.Rows.Add(o.orderID, o.orderReference, o.invoiceDate);
                }

                selectedOrderUpdated();
            }
        }

        /*Precondition:
         Postcondition: Runs when a new order has been selected and updates all value for the user to see*/
        private void selectedOrderUpdated()
        {
            //Reset so orders don't stack
            dataGridView2.Rows.Clear();
            List<OrderedStock> customersOrderedStock = new List<OrderedStock>();

            //Update textboxes
            boxOrderID.Text = currOrder.orderID.ToString();
            boxOrderRef.Text = currOrder.orderReference;
            boxProgress.Text = currOrder.progress;
            boxInvoiceDate.Text = currOrder.invoiceDate.ToString("d-MM-yyyy");
            boxFreight.Text = "$" + String.Format("{0:0.00}", currOrder.freightCost);
            boxComments.Text = currOrder.comments;

            //Search DB for stock for the order
            customersOrderedStock = dbManager.searchOrderedStock(currOrder.orderID);

            //Loop over and display all stock for the order
            foreach (OrderedStock o in customersOrderedStock)
            {
                dataGridView2.Rows.Add(o.quantity, o.author, o.title, o.price, o.bookID, o.discount);
            }
        }

        /*Precondition:
         Postcondition: Closes form*/
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*Precondition:
         Postcondition: Listens for a keypress no matter which control has focus */
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Close form if user presses escape
            if (keyData == Keys.Escape)
            {
                this.Close();
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /*Precondition:
         Postcondition: When user selects new order, information is updated to display the selected order*/
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int currRow = dataGridView1.CurrentCell.RowIndex;

            if (currRow < customersOrders.Count)
            {
                currOrder = customersOrders[currRow];
                selectedOrderUpdated();
            }
        }

        /*Precondition:
         Postcondition: Open up orders form with current order loaded up */
        private void btnGoToOrder_Click(object sender, EventArgs e)
        {
            OrdersForm of = new OrdersForm(null);
            of.loadOrder(currOrder.orderID);
            of.Show();
        }

    }
}
