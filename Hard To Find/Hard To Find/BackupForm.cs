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
    public partial class BackupForm : Form
    {
        //Globals
        private MainMenu mainMenu;
        private FileManager fileManager;
        private DatabaseManager dbManager;

        //Constructor
        public BackupForm(MainMenu mainMenu)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            this.mainMenu = mainMenu;

            setup();
        }

        /*Precondition:
         Postcondition: Setup and initialize everything needed */
        private void setup()
        {
            fileManager = new FileManager();
            dbManager = new DatabaseManager();
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
         Postcondition: Opens folder browser for user to select a location to store the sqlite file in */
        private void btnBackupFile_Click(object sender, EventArgs e)
        {
            //Setup folder browser
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "Select storage location";

            //Check the user selected something
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowser.SelectedPath;

                //Get the file copied over
                fileManager.copyDatabaseFile(path);

                MessageBox.Show("Backed up to: " + path);
            }
        }

        /*Precondition:
         Postcondition: Gets the user to select the file to copy into the programs directory for use */
        private void btnRestoreFile_Click(object sender, EventArgs e)
        {
             //Set up file browser, to search for txt files and default directory of C: drive
            OpenFileDialog dialogBox = new OpenFileDialog();
            dialogBox.Title = "Select HardToFindDB.sqlite";
            dialogBox.InitialDirectory = @"C:\";

            //Open the file browser and wait for user to select file
            if (dialogBox.ShowDialog() == DialogResult.OK)
            {
                //Get the path for the file the user clicked on
                string filename = dialogBox.FileName;

                //Pass the selected filepath into to get it copied
                bool success = fileManager.restoreDatabaseFile(filename);

                if(success)
                    MessageBox.Show("Restored to backup");
                else
                    MessageBox.Show("File was not called HardToFindDB.sqlite");
            }
        }

        /*Precondition:
         Postcondition: Gets the user to select the file to copy into the programs directory for use */
        private void btnBackupCSV_Click(object sender, EventArgs e)
        {
            //Setup folder browsers
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "Select storage location";

            //Check user selected a location
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowser.SelectedPath;

                //Change cursor so user has feedback that program is doing something
                Cursor.Current = Cursors.WaitCursor;

                //Pass in the selected location
                fileManager.createDatabaseTablesAsCSVFiles(path);

                //Change cursor back to default
                Cursor.Current = Cursors.Default;

                MessageBox.Show("Backed up to: " + path);
            }
        }

        /*Precondition:
        Postcondition: Clears the database of exsisting customers and replaces it with the customers in the csv file */
        private void btnRestoreCustomers_Click(object sender, EventArgs e)
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
                    List<Customer> allCustomers = new List<Customer>();

                    try
                    {
                        List<Object> customersAsObject = fileManager.importFromCSV(filename, FileManager.IMPORT_TYPE.CUSTOMER);

                        foreach (Object o in customersAsObject)
                            allCustomers.Add((Customer)o);

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
        Postcondition: Clears the database of exsisting stock and replaces it with the stock in the csv file */
        private void btnRestoreStock_Click(object sender, EventArgs e)
        {
            //Set up file browser, to search for txt files and default directory of C: drive
            OpenFileDialog dialogBox = new OpenFileDialog();
            dialogBox.Title = "Open stock txt file";
            dialogBox.Filter = "TXT files|*.txt";
            dialogBox.InitialDirectory = @"C:\";

            //Open the file browser and wait for user to select file
            if (dialogBox.ShowDialog() == DialogResult.OK)
            {
                //Get the path for the file the user clicked on
                string filename = dialogBox.FileName;

                if (filename.Contains("\\Stock.txt"))
                {
                    List<Stock> allStock = new List<Stock>();

                    try
                    {
                        List<Object> stockAsObject = fileManager.importFromCSV(filename, FileManager.IMPORT_TYPE.STOCK);

                        foreach (Object o in stockAsObject)
                            allStock.Add((Stock)o);

                        progressBar1.Visible = true;
                        progressBar1.Maximum = allStock.Count;
                        progressBar1.Value = 0;

                        //TODO find a better place for this?
                        dbManager.dropStockTable();
                        dbManager.createStockTable();

                        //Insert all of the new orders into the database
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
        Postcondition: Clears the database of exsisting orders and replaces it with the orders in the csv file */
        private void btnRestoreOrders_Click(object sender, EventArgs e)
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
                    List<Order> allOrders = new List<Order>();
                    try
                    {
                        List<Object> ordersAsObject = fileManager.importFromCSV(filename, FileManager.IMPORT_TYPE.ORDERS);

                        foreach (Object o in ordersAsObject)
                            allOrders.Add((Order)o);

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
        Postcondition: Clears the database of exsisting ordered stock and replaces it with the ordered stock in the csv file */
        private void btnRestoreOrderedStock_Click(object sender, EventArgs e)
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
                    List<OrderedStock> allOrderedStock = new List<OrderedStock>();
                    try
                    {
                        List<Object> ordersAsObject = fileManager.importFromCSV(filename, FileManager.IMPORT_TYPE.ORDEREDSTOCK);

                        foreach (Object o in ordersAsObject)
                            allOrderedStock.Add((OrderedStock)o);

                        //Insert all of the new orders into the database
                        progressBar1.Visible = true;
                        progressBar1.Maximum = allOrderedStock.Count;
                        progressBar1.Value = 0;

                        //TODO find a better place for this
                        dbManager.dropOrderedStockTable();
                        dbManager.createOrderedStock();

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
    }
}
