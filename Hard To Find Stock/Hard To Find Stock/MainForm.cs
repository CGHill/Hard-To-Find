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
        private Stock currStock;

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
            currStock = null;

            //Setup datagridview column widths
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

            //Make the newstock table if it doesn't exist already
            dbManager.createNewStockTable();

            //Setup keypress handlers for when enter is pressed on textboxes
            boxSearchBookID.KeyPress += TextBox_KeyPress_Enter;
            boxSearchAuthor.KeyPress += TextBox_KeyPress_Enter;
            boxSearchTitle.KeyPress += TextBox_KeyPress_Enter;
            boxSearchSubject.KeyPress += TextBox_KeyPress_Enter;

            //Check to make sure storage location has been set for export files, if not then ask user to set it
            if (!fileManager.checkForStorageLocation())
            {
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                folderBrowser.Description = "Select storage location";

                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    string path = folderBrowser.SelectedPath;

                    fileManager.setExportStorageLocationFile(folderBrowser.SelectedPath);
                }
            }

            //Give focus to bookID box
            boxSearchBookID.Select();
        }

        /*Precondition:
        Postcondition: Keypress handler for all textboxes. Starts the search for customers */
        private void TextBox_KeyPress_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                startSearch();

                //Stops the windows noise
                e.Handled = true;
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
            bool searchAllStock = true;

            if (rdoInStock.Checked)
                searchAllStock = false;

            //If ID was entered then search only on that
            if (boxSearchBookID.Text != "")
            {
                string bookID = boxSearchBookID.Text;

                //Put found stock into list
                Stock found = dbManager.searchStock(bookID, searchAllStock);
                if (found != null)
                {
                    foundStock.Add(found);
                }
            }
            else if (boxSearchAuthor.Text != "" || boxSearchTitle.Text != "" || boxSearchSubject.Text != "") //ID wasn't entered, search if any other fields have been filled
            {
                string author = null;
                string title = null;
                string subject = null;

                //Find out which fields have been entered to be included in the search
                if (boxSearchAuthor.Text != "")
                    author = SyntaxHelper.escapeSingleQuotes(boxSearchAuthor.Text);
                if (boxSearchTitle.Text != "")
                    title = SyntaxHelper.escapeSingleQuotes(boxSearchTitle.Text);
                if (boxSearchSubject.Text != "")
                    subject = SyntaxHelper.escapeSingleQuotes(boxSearchSubject.Text);

                bool exactPhrase = checkExactPhrase.Checked;

                //Search for stock based on the parameters entered
                foundStock = dbManager.searchStock(author, title, subject, searchAllStock, exactPhrase);
            }

            //Sort the information as the user wants
            if (comboBox1.SelectedItem != null)
            {
                string selectedSort = comboBox1.SelectedItem.ToString();
                switch (selectedSort)
                {
                    case "Quantity":
                        foundStock = foundStock.OrderBy(x => x.quantity).ToList();
                        break;
                    case "Author":
                        foundStock = foundStock.OrderBy(x => x.author).ToList();
                        break;
                    case "Title":
                        foundStock = foundStock.OrderBy(x => x.title).ToList();
                        break;
                    case "Price":
                        foundStock = foundStock.OrderBy(x => x.price).ToList();
                        break;
                }
            }

            //Add information to datagrid to be displayed
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
                    dataGridView1.Rows.Add(s.quantity, s.author, s.title, s.subject, "$" + String.Format("{0:0.00}", s.price), s.bookID);
                }

                dataGridView1.Focus();
            }
        }

        /*Precondition: 
         Postcondition: Open form to create a new stock entry */
        private void btnNewStock_Click(object sender, EventArgs e)
        {
            NewStockForm nsf = new NewStockForm();
            nsf.Show();
        }

        /*Precondition:
         Postcondition: Update textboxes with selected stock */
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (foundStock.Count != 0)
            {
                int currRow = dataGridView1.CurrentCell.RowIndex;

                currStock = foundStock[currRow];

                loadStock();
            }
        }

        /*Precondition:
         Postcondition: Loads up text boxes with the current stocks information*/
        private void loadStock()
        {
            boxStockID.Text = currStock.stockID.ToString();
            boxQuantity.Text = currStock.quantity.ToString();
            boxNote.Text = currStock.note;
            boxAuthor.Text = currStock.author;
            boxTitle.Text = currStock.title;
            boxSubtitle.Text = currStock.subtitle;
            boxPublisher.Text = currStock.publisher;
            boxDescription.Text = currStock.description;
            boxComment.Text = currStock.comments;
            boxPrice.Text = "$" + String.Format("{0:0.00}", currStock.price);
            boxSubject.Text = currStock.subject;
            boxCatalogues.Text = currStock.catalogue;
            boxInitials.Text = currStock.initials;
            boxSales.Text = currStock.sales;
            boxBookID.Text = currStock.bookID;
            boxDateEntered.Text = currStock.dateEntered;
        }

        /*Precondition:
         Postcondition: Closes the application when exit button is clicked */
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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

                string storageLocation = fileManager.getExportStorageFilePath() + fileName;

                //Create the textfile and write the newstock information into it
                using (FileStream stream = File.Create(storageLocation))
                {
                    StreamWriter sw = new StreamWriter(stream);

                    foreach (Stock s in allNewStock)
                    {
                        sw.WriteLine("-1" + "|\"" + s.quantity + "\"|\"" + s.note + "\"|\"" + s.author + "\"|\"" + s.title + "\"|\"" + s.subtitle + "\"|\"" + s.publisher + "\"|\"" + s.description +
                            "\"|\"" + s.comments + "\"|\"" + "" + "\"|\"$" + s.price + "\"|\"" + s.subject + "\"|\"" + s.catalogue + "\"|\"" + s.initials + "\"|\"" + s.sales + "\"|\"" + s.bookID + "\"|\"" + s.dateEntered + "\"");

                        //Set id to negative so doesn't conflict and it gets a new ID when inserted into main table
                        s.stockID = -1;
                    }

                    sw.Close();
                }

                dbManager.insertStock(allNewStock);

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

        /*Precondition:
         Postcondition: Opens folder browser for user to select where they want the export files to be stored */
        private void btnSetExportLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "Select storage location";

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowser.SelectedPath;

                fileManager.setExportStorageLocationFile(folderBrowser.SelectedPath);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            List<string> filepaths = fileManager.getAllImportFilePaths();

            if (filepaths.Count > 0)
            {
                foreach (string s in filepaths)
                {
                    List<Stock> newStock = fileManager.importFromCSV(s);

                    int firstEntryID = newStock[0].stockID;

                    dbManager.deleteStockFromIDForward(firstEntryID);

                    dbManager.insertStock(newStock);

                    //Delete the now used file so it doesn't get repeated
                    fileManager.deleteFile(s);
                }

                MessageBox.Show("Update complete");
            }
            else
            {
                MessageBox.Show("No files to update from");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (foundStock != null)
            {
                if (foundStock.Count != 0)
                {
                    dataGridView1.Rows.Clear();

                    string selectedSort = comboBox1.SelectedItem.ToString();

                    switch (selectedSort)
                    {
                        case "Quantity":
                            foundStock = foundStock.OrderBy(x => x.quantity).ToList();
                            break;
                        case "Author":
                            foundStock = foundStock.OrderBy(x => x.author).ToList();
                            break;
                        case "Title":
                            foundStock = foundStock.OrderBy(x => x.title).ToList();
                            break;
                        case "Price":
                            foundStock = foundStock.OrderBy(x => x.price).ToList();
                            break;
                    }

                    foreach (Stock s in foundStock)
                    {
                        dataGridView1.Rows.Add(s.quantity, s.author, s.title, s.subject, "$" + String.Format("{0:0.00}", s.price), s.bookID);
                    }
                }
            }
        }

        private void btnSetStockImport_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "Select storage location";

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowser.SelectedPath;

                fileManager.setImportStorageLocationFile(folderBrowser.SelectedPath);
            }
        }
    }
}
