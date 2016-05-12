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
    public partial class ReportsForm : Form
    {
        //Globals
        private MainMenu mainMenu;
        private FileManager fileManager;
        private DatabaseManager dbManager;

        //Constructor
        public ReportsForm(MainMenu mainMenu)
        {
            this.mainMenu = mainMenu;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            setup();
        }

        /*Precondition: 
         Postcondition: Sets up everything needed */
        private void setup()
        {
            fileManager = new FileManager();
            dbManager = new DatabaseManager();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM/yyyy";
            dateTimePicker1.ShowUpDown = true;
        }

        /*Precondition:
         Postcondition: Close this form and return to main menu*/
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            mainMenu.Show();
            mainMenu.Activate();
        }

        /*Precondition:
         Postcondition: Listens for keypresses no matter which control has focus */
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                mainMenu.Show();
                mainMenu.Activate();
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /*Precondition: 
         Postcondition: Creates and opens the sales report for the given month */
        private void btnSalesReport_Click(object sender, EventArgs e)
        {
            //Check if location for the reports storage has been set
            bool haveStorageLocation = checkForStorageLocation();

            if (haveStorageLocation)
            {
                //Get the date from datepicker for the database search
                string date = dateTimePicker1.Value.ToString("MM/yyyy");

                //Get a 2nd date for the title of the report
                string title = dateTimePicker1.Value.ToString("MMMM yyyy");

                string[] splitDate = date.Split('/');

                //Get Orders from database
                List<Order> ordersForMonth = dbManager.getOrdersByMonth(splitDate[0], splitDate[1]);

                //Arrays for holding the number of books purchased for each order and the costs of the books in the orders
                int[] booksPerOrder = new int[ordersForMonth.Count];
                double[] pricePerOrder = new double[ordersForMonth.Count];

                int indexOfArrays = 0;

                //Loop over all orders for the month
                foreach(Order o in ordersForMonth)
                {
                    //Get the books ordered for this order
                    List<OrderedStock> currOrderedStock = dbManager.searchOrderedStock(o.orderID);

                    //Loop over the books for the order
                    foreach (OrderedStock os in currOrderedStock)
                    {
                        //Tally up the number of books bought in the order
                        booksPerOrder[indexOfArrays] += os.quantity;

                        //Discount the price
                        double costOfBook = os.price;
                        costOfBook -= os.discount;

                        //Tally up prices for order
                        pricePerOrder[indexOfArrays] += costOfBook;
                    }

                    //Update index
                    indexOfArrays++;
                }

                //Check that there were new orders
                if (ordersForMonth.Count > 0)
                {
                    SalesReportCreator mrc = new SalesReportCreator(title, ordersForMonth, booksPerOrder, pricePerOrder);

                    //Get file name and filepath
                    string documentName = dateTimePicker1.Value.ToString("MMMM yyyy") + " Sales Report.docx";
                    string filePath = fileManager.getStorageFilePath() + @"\Sales Reports\" + documentName;

                    //Create the report
                    bool successfulFileCreation = mrc.createReport(filePath);

                    //Open the report
                    if (successfulFileCreation)
                        System.Diagnostics.Process.Start(filePath);
                    else
                        MessageBox.Show("File failed to be created");
                }
                else
                {
                    MessageBox.Show("No orders or stock ordered for " + dateTimePicker1.Value.ToString("MMMM yyyy"));
                }
            }
        }


        /*Precondition: 
         Postcondition: Creates and opens the sales report for the given month */
        private void btnFreightReport_Click(object sender, EventArgs e)
        {
            //Check if location for the reports storage has been set
            bool haveStorageLocation = checkForStorageLocation();

            if (haveStorageLocation)
            {
                //Get the date from datepicker for the database search
                string date = dateTimePicker1.Value.ToString("MM/yyyy");

                //Get a 2nd date for the title of the report
                string title = dateTimePicker1.Value.ToString("MMMM yyyy");

                string[] splitDate = date.Split('/');

                //Get Orders from database
                List<Order> ordersForMonth = dbManager.getOrdersByMonth(splitDate[0], splitDate[1]);
                //Check that there were new orders
                if (ordersForMonth.Count > 0)
                {
                    FreightReportCreator frc = new FreightReportCreator(title, ordersForMonth);

                    //Get file name and filepath
                    string documentName = dateTimePicker1.Value.ToString("MMMM yyyy") + " Freight Report.docx";
                    string filePath = fileManager.getStorageFilePath() + @"\Freight Reports\" + documentName;

                    //Create the report
                    bool successfulFileCreation = frc.createReport(filePath);

                    //Open the report
                    if (successfulFileCreation)
                        System.Diagnostics.Process.Start(filePath);
                    else
                        MessageBox.Show("File failed to be created");
                }
                else
                {
                    MessageBox.Show("No orders for " + dateTimePicker1.Value.ToString("MMMM yyyy"));
                }
            }
        }

        /*Precondition: 
         Postcondition: Returns true if location has been set, if not asks user to set storage location and returns true, otherwise returns false if not set */
        private bool checkForStorageLocation()
        {
            bool canStoreFiles = false;

            //Check if the storage location has been set
            if (!fileManager.checkForStorageLocation())
            {
                //Hasn't been set so try get user to set it now
                DialogResult result = MessageBox.Show("Storage location not set for invoices and mailing labels.\nDo you want to set a location?", "Confirmation", MessageBoxButtons.YesNoCancel);

                //Check result
                if (result == DialogResult.Yes)
                {
                    //Get user to select a location to store files
                    FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                    folderBrowser.Description = "Select storage location";

                    if (folderBrowser.ShowDialog() == DialogResult.OK)
                    {
                        fileManager.setStorageLocationFile(folderBrowser.SelectedPath);

                        canStoreFiles = true;
                    }
                }
            }
            else
            {
                canStoreFiles = true;
            }

            //Return true if can set files and false if you can't
            return canStoreFiles;
        }
    }
}
