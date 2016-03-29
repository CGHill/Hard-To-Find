using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Hard_To_Find
{
    public partial class StockForm : Form
    {
        //Variables
        private Form1 form1;
        private DatabaseManager dbManager;
        private List<Stock> allStock;
        private List<Stock> foundStock;
        private FileManager fileManager;

        //Constructor
        public StockForm(Form1 form1)
        {
            this.form1 = form1;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            //Create DB and list to store stock in
            dbManager = new DatabaseManager();
            fileManager = new FileManager();
            allStock = new List<Stock>();
            

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
        }

        /*Precondition: 
         Postcondition: Go back to main menu*/
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            form1.Show();
            form1.TopLevel = true;
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
         Postcondition: Starts search for Stock depending on which text boxes have been filled*/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            startSearch();
        }

        /*Precondition:
         Postcondition: Enables button to view more details about stock */
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnStockDetails.Enabled = true;
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
         Postcondition: Open form to create a new stock entry */
        private void btnNewStock_Click(object sender, EventArgs e)
        {
            NewStockForm nsf = new NewStockForm();
            nsf.Show();
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
            if (boxStockID.Text != "")
            {
                string bookID = boxStockID.Text;

                //Put found stock into list
                Stock found = dbManager.searchStock(bookID, searchAllStock);
                if (found != null)
                {
                    foundStock.Add(found);

                    //Display found stock
                    foreach (Stock s in foundStock)
                    {
                        dataGridView1.Rows.Add(s.quantity, s.author, s.title, s.subtitle, s.price, s.bookID);
                    }
                }
                else
                {
                    dataGridView1.Rows.Add("", "No stock found", "", "", "", "");
                }
            }
            else if (boxAuthor.Text != "" || boxTitle.Text != "" || boxSubject.Text != "") //ID wasn't entered, search if any other fields have been filled
            {
                string author = null;
                string title = null;
                string subject = null;

                //Find out which fields have been entered to be included in the search
                if (boxAuthor.Text != "")
                    author = SQLSyntaxHelper.escapeSingleQuotes(boxAuthor.Text);
                if (boxTitle.Text != "")
                    title = SQLSyntaxHelper.escapeSingleQuotes(boxTitle.Text);
                if (boxSubject.Text != "")
                    subject = SQLSyntaxHelper.escapeSingleQuotes(boxSubject.Text);

                //Search for stock based on the parameters entered
                foundStock = dbManager.searchStock(author, title, subject, searchAllStock);

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
    }
}
