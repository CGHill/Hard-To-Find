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
        public Form1()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomersForm cf = new CustomersForm(this);
            cf.Show();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockForm sf = new StockForm(this);
            sf.Show();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrdersForm of = new OrdersForm(this);
            of.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportsForm rf = new ReportsForm(this);
            rf.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
