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
    public partial class Form1 : Form
    {
        //Contructor
        public Form1()
        {
            //Open center screen
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        /*Precondition: 
         Postcondition: Moves to customers form*/
        private void btnCustomers_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomersForm cf = new CustomersForm(this);
            cf.Show();
        }


        /*Precondition: 
         Postcondition: Moves to stock form*/
        private void btnStock_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockForm sf = new StockForm(this);
            sf.Show();
        }

        /*Precondition: 
         Postcondition: Moves to orders form*/
        private void btnOrders_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrdersForm of = new OrdersForm(this);
            of.Show();
        }

        /*Precondition: 
         Postcondition: Moves to reports Form*/
        private void btnReports_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportsForm rf = new ReportsForm(this);
            rf.Show();
        }

        /*Precondition: 
         Postcondition: Exits the application*/
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
