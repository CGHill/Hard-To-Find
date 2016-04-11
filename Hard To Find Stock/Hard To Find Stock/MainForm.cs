using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Hard_To_Find_Stock
{
    public partial class MainForm : Form
    {
        //Globals
        private DatabaseManager dbManager;
        private List<Stock> allStock;
        private List<Stock> foundStock;
        private FileManager fileManager;

        //Constructor
        public MainForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            setup();
        }

        /*Precondition:
         Postcondition: Sets up and initialises everything needed */
        private void setup()
        {
            //Create DB and list to store stock in
            dbManager = new DatabaseManager();
            fileManager = new FileManager();
            allStock = new List<Stock>();

            boxBookID.Select();

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

            dbManager.createNewStockTable();

            if (!fileManager.checkForStorageLocation())
            {
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                folderBrowser.Description = "Select storage location";

                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    string path = folderBrowser.SelectedPath;

                    fileManager.setStorageLocationFile(folderBrowser.SelectedPath);
                }
            }
        }

        /*Precondition:
         Postcondition: Starts search for Stock depending on which text boxes have been filled*/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            startSearch();
        }

        /*Precondition:
         Postcondition: Starts a search for stock depending on what search boxes have been filled in*/
        private void startSearch()
        {
            //Reset datagrid and stock for new search
            foundStock = new List<Stock>();
            dataGridView1.Rows.Clear();
            btnStockDetails.Enabled = false;
            bool searchAllStock = true;

            if (rdoInStock.Checked)
                searchAllStock = false;

            //If ID was entered then search only on that
            if (boxBookID.Text != "")
            {
                string bookID = boxBookID.Text;

                //Put found stock into list
                Stock found = dbManager.searchStock(bookID, searchAllStock);
                if (found != null)
                {
                    foundStock.Add(found);
                    labResults.Text = foundStock.Count.ToString();
                }

                

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
                    author = SyntaxHelper.escapeSingleQuotes(boxAuthor.Text);
                if (boxTitle.Text != "")
                    title = SyntaxHelper.escapeSingleQuotes(boxTitle.Text);
                if (boxSubject.Text != "")
                    subject = SyntaxHelper.escapeSingleQuotes(boxSubject.Text);

                //Search for stock based on the parameters entered
                foundStock = dbManager.searchStock(author, title, subject, searchAllStock);
                labResults.Text = foundStock.Count.ToString();


                if (foundStock.Count == 0)
                {
                    dataGridView1.Rows.Add("", "No stock found", "", "", "", "");
                }
                else
                {
                    //Display found stock
                    foreach (Stock s in foundStock)
                    {
                        dataGridView1.Rows.Add(s.quantity, s.author, s.title, s.subtitle, s.price, s.bookID);
                    }
                }
            }
        }

        /*Precondition: 
         Postcondition: Open form to create a new stock entry */
        private void btnNewStock_Click(object sender, EventArgs e)
        {
            NewStockForm nsf = new NewStockForm();
            nsf.Show();
        }

        /*Precondition: Requires something be selected in the datagrid first
        Postcondition: Opens form to display futher details about stock*/
        private void btnStockDetails_Click(object sender, EventArgs e)
        {
            int currRow = dataGridView1.CurrentCell.RowIndex;

            Stock stockToDisplay = foundStock[currRow];

            StockDetailsForm sdf = new StockDetailsForm(stockToDisplay);
            sdf.Show();
        }

        /*Precondition:
         Postcondition: Enables button to view more details about stock */
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnStockDetails.Enabled = true;
        }

        /*Precondition: 
         Postcondition: Allow stock to be selected on double click */
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int currRow = dataGridView1.CurrentCell.RowIndex;

                Stock stockToDisplay = foundStock[currRow];

                StockDetailsForm sdf = new StockDetailsForm(stockToDisplay);
                sdf.Show();
            }
            catch (NullReferenceException)
            {
                //Do nothing, user double clicked on header
            }
        }

        /*Precondition:
         Postcondition: Closes the application when exit button is clicked */
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        /**************** Keypress handlers to check if enter has been pushed to start search ***********************/
        private void boxStockID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                startSearch();

                e.Handled = true;
            }

        }

        private void boxAuthor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                startSearch();

                e.Handled = true;
            }
        }

        private void boxTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                startSearch();

                e.Handled = true;
            }
        }

        private void boxSubject_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                startSearch();

                e.Handled = true;
            }
        }
        /***********************************************************************************************************/

        /*Precondition:
         Postcondition: When button is clicked, creates a csv file that contains all of the new stock that has been entered and stores it in the Export Files folder */
        private void btnCreateExport_Click(object sender, EventArgs e)
        {
            List<Stock> allNewStock = dbManager.getAllNewStock();

            if (allNewStock.Count > 0)
            {
                string timeStamp = getTimestamp(DateTime.Now);

                //Create a unique filename using timestamp
                string fileName = @"\Stock" + timeStamp + ".txt";

                string storageLocation = fileManager.getStorageFilePath() + fileName;

                //Create the textfile and write the newstock information into it
                using (FileStream stream = File.Create(storageLocation))
                {
                    StreamWriter sw = new StreamWriter(stream);

                    foreach (Stock s in allNewStock)
                    {
                        sw.WriteLine("-1" + "|\"" + s.quantity + "\"|\"" + s.note + "\"|\"" + s.author + "\"|\"" + s.title + "\"|\"" + s.subtitle + "\"|\"" + s.publisher + "\"|\"" + s.description +
                            "\"|\"" + s.comments + "\"|\"" + "" + "\"|\"" + s.price + "\"|\"" + s.subject + "\"|\"" + s.catalogue + "\"|\"" + "" + "\"|\"" + s.sales + "\"|\"" + s.bookID + "\"|\"" + s.dateEntered + "\"");
                    }

                    sw.Close();
                }

                //Reset the new stock table
                dbManager.dropNewStockTable();
                dbManager.createNewStockTable();

                MessageBox.Show("Export File created");
            }
            else
                MessageBox.Show("No new data");
        }

        /*Precondition:
        Postcondition: Returns a timestamp of current year,month, day and time */
        private static String getTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssfff");
        }

        private void btnSetExportLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "Select storage location";

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowser.SelectedPath;

                fileManager.setStorageLocationFile(folderBrowser.SelectedPath);
            }
        }

    }
}
