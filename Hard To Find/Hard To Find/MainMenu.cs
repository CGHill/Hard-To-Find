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
    public partial class MainMenu : Form
    {
        private FileManager fileManager;

        //Contructor
        public MainMenu()
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
            CustomerForm cf = new CustomerForm(this);
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

        /*Precondition:
         Postcondition: Opens up file exports form */
        private void btnFileExports_Click(object sender, EventArgs e)
        {
            this.Hide();
            FileExportForm fef = new FileExportForm(this);
            fef.Show();
        }

        /*Precondition:
         Postcondition: Allows the user to set and change the storage location of files */
        private void btnSetStorageLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "Select storage location";

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowser.SelectedPath;

                fileManager.setStorageLocationFile(folderBrowser.SelectedPath);
            }
        }

        /*Precondition:
         Postcondition: Opens up imports form*/
        private void btnImports_Click(object sender, EventArgs e)
        {
            this.Hide();
            ImportsForm importForm = new ImportsForm(this);
            importForm.Show();
        }

        /*Precondition: 
         Postcondition: Opens up the backup form */
        private void btnBackup_Click(object sender, EventArgs e)
        {
            this.Hide();
            BackupForm buf = new BackupForm(this);
            buf.Show();
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            this.Hide();
            SetupForm sf = new SetupForm(this);
            sf.Show();
        }
    }
}
