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
        private FileManager fileManager;

        //Contructor
        public Form1()
        {
            //Open center screen
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            fileManager = new FileManager();
        }

        /*Precondition: 
         Postcondition: Moves to customers form*/
        private void btnCustomers_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerSearchForm cf = new CustomerSearchForm(this);
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

        private void btnFileExports_Click(object sender, EventArgs e)
        {
            this.Hide();
            FileExportForm fef = new FileExportForm(this);
            fef.Show();
        }

        private void btnSetStorageLocation_Click(object sender, EventArgs e)
        {
           
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "Select storage location";

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                fileManager.createStorageLocationFile(folderBrowser.SelectedPath);
            }
        }
    }
}
