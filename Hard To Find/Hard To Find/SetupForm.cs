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
    public partial class SetupForm : Form
    {
        //Globals
        private DatabaseManager dbManager;
        private FileManager fileManager;
        private MainMenu mainMenu;
        private List<Customer> allCustomers;
        private List<Stock> allStock;
        private List<Order> allOrders;
        private List<OrderedStock> allOrderedStock;

        public SetupForm(MainMenu mainMenu)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.mainMenu = mainMenu;

            setup();
        }

        private void setup()
        {
            dbManager = new DatabaseManager();
            fileManager = new FileManager();
            allStock = new List<Stock>();
            allCustomers = new List<Customer>();
            allOrders = new List<Order>();
            allOrderedStock = new List<OrderedStock>();
        }

        /*Precondition: Customer CSV order = ID, first name, last name, institution, address1, address2, address3, country, postcode, phone, fax, email, comments, sales, payment
         Postcondition: Starts the import process to move customers from a csv text file into the SQLite database*/
        private void btnImportCustomers_Click(object sender, EventArgs e)
        {
            //Set up file browser, to search for txt files and default directory of C: drive
            OpenFileDialog dialogBox = new OpenFileDialog();
            dialogBox.Title = "Open Customer txt file";
            dialogBox.Filter = "TXT files|*.txt";
            dialogBox.InitialDirectory = @"C:\";

            //Open the file browser and wait for user to select file
            if (dialogBox.ShowDialog() == DialogResult.OK)
            {
                //Get the path for the file the user clicked on
                string filename = dialogBox.FileName;

                if (filename.Contains("\\Customers.txt"))
                {
                    allCustomers = new List<Customer>();

                    try
                    {
                        allCustomers = fileManager.getCustomersFromFile(filename);

                        progressBar1.Visible = true;
                        progressBar1.Maximum = allCustomers.Count;
                        progressBar1.Value = 0;

                        //TODO find a better place for this?
                        dbManager.dropCustomerTable();
                        dbManager.createCustomerTable();

                        //Insert all of the new orders into the database
                        dbManager.insertCustomers(allCustomers, progressBar1);
                        progressBar1.Visible = false;

                        //Inform user that the process has been finished
                        MessageBox.Show("Finished import");
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Error: File was formatted incorrectly");
                    }
                    catch (IndexOutOfRangeException)
                    {
                        MessageBox.Show("Error: File was formatted incorrectly");
                    }
                }
                else
                {
                    MessageBox.Show("Error: Wrong file selected");
                }
            }
        }

        /*Precondition: 
         Postcondition: Opens file browser for user to select a txt file to import stock*/
        private void btnImportStock_Click(object sender, EventArgs e)
        {
            //Set up file browser, to search for txt files and default directory of C: drive
            OpenFileDialog dialogBox = new OpenFileDialog();
            dialogBox.Title = "Open Stock txt file";
            dialogBox.Filter = "TXT files|*.txt";
            dialogBox.InitialDirectory = @"C:\";

            //Open the file browser and wait for user to select file
            if (dialogBox.ShowDialog() == DialogResult.OK)
            {
                //Get the path for the file the user clicked on
                string filename = dialogBox.FileName;

                if (filename.Contains("\\Stock.txt"))
                {
                    try
                    {
                        allStock = fileManager.getStockFromFile(filename);

                        progressBar1.Visible = true;
                        progressBar1.Maximum = allStock.Count;
                        progressBar1.Value = 0;

                        //TODO find a better place for this
                        dbManager.dropStockTable();
                        dbManager.createStockTable();

                        //Insert all of the new stock into the database
                        dbManager.insertStock(allStock, progressBar1);
                        progressBar1.Visible = false;

                        //Inform user that the process has been finished
                        MessageBox.Show("Finished import");
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Error: File was formatted incorrectly");
                    }
                    catch (IndexOutOfRangeException)
                    {
                        MessageBox.Show("Error: File was formatted incorrectly");
                    }

                }
                else
                {
                    MessageBox.Show("Error: Wrong file selected");
                }
            }
        }

        /*Precondition: 
         Postcondition: Starts import process, has user select a file  */
        private void btnImportOrders_Click(object sender, EventArgs e)
        {
            //Set up file browser, to search for txt files and default directory of C: drive
            OpenFileDialog dialogBox = new OpenFileDialog();
            dialogBox.Title = "Open Orders txt file";
            dialogBox.Filter = "TXT files|*.txt";
            dialogBox.InitialDirectory = @"C:\";

            //Open the file browser and wait for user to select file
            if (dialogBox.ShowDialog() == DialogResult.OK)
            {
                //Get the path for the file the user clicked on
                string filename = dialogBox.FileName;

                if (filename.Contains("\\Orders.txt"))
                {
                    try
                    {
                        allOrders = fileManager.getOrdersFromFile(filename);

                        progressBar1.Visible = true;
                        progressBar1.Maximum = allOrders.Count;
                        progressBar1.Value = 0;

                        //TODO find a better place for this?
                        dbManager.dropOrdersTable();
                        dbManager.createOrdersTable();

                        //Insert all of the new orders into the database
                        dbManager.insertOrders(allOrders, progressBar1);
                        progressBar1.Visible = false;

                        //Inform user that the process has been finished
                        MessageBox.Show("Finished import");
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Error: File was formatted incorrectly");
                    }
                    catch (IndexOutOfRangeException)
                    {
                        MessageBox.Show("Error: File was formatted incorrectly");
                    }
                }
                else
                {
                    MessageBox.Show("Error: Wrong file selected");
                }
            }
        }

        /*Precondition: 
        Postcondition: Starts import process for ordered stock by having user select a file*/
        private void btnImportOrderedStock_Click(object sender, EventArgs e)
        {
            //Set up file browser, to search for txt files and default directory of C: drive
            OpenFileDialog dialogBox = new OpenFileDialog();
            dialogBox.Title = "Open OrderedStock txt file";
            dialogBox.Filter = "TXT files|*.txt";
            dialogBox.InitialDirectory = @"C:\";

            //Open the file browser and wait for user to select file
            if (dialogBox.ShowDialog() == DialogResult.OK)
            {
                //Get the path for the file the user clicked on
                string filename = dialogBox.FileName;

                if (filename.Contains("\\OrderedStock.txt"))
                {
                    try
                    {
                        allOrderedStock = fileManager.getOrderedStockFromFile(filename);

                        //TODO find a better place for this
                        dbManager.dropOrderedStockTable();
                        dbManager.createOrderedStock();

                        //Insert all of the new orders into the database
                        progressBar1.Value = 0;
                        progressBar1.Maximum = allOrderedStock.Count;
                        progressBar1.Visible = true;

                        dbManager.insertOrderedStock(allOrderedStock, progressBar1);

                        progressBar1.Visible = false;

                        //Inform user that the process has been finished
                        MessageBox.Show("Finished import");
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Error: File was formatted incorrectly");
                    }
                    catch (IndexOutOfRangeException)
                    {
                        MessageBox.Show("Error: File was formatted incorrectly");
                    }
                }
                else
                {
                    MessageBox.Show("Error: Wrong file selected");
                }
            }
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
         Postcondition: Allows the user to set the location to import stock files from */
        private void btnSetImportLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "Select storage location";

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowser.SelectedPath;

                fileManager.setImportStorageLocationFile(folderBrowser.SelectedPath);
            }
        }

        /*Precondition:
         Postcondition: Close this form and go back to the main menu */
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
            //Close form and return to main menu when escape is pressed
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
         Postcondition: Allows the user to set the export stock csv file to */
        private void btnSetStockExport_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "Select storage location";

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowser.SelectedPath;

                fileManager.setStockExportStorageLocationFile(folderBrowser.SelectedPath);
            }
        }
    }
}
