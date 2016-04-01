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
    public partial class ImportsForm : Form
    {
        //Globals
        private string importFileLocation;
        private FileManager fileManager;
        private DatabaseManager dbManager;
        private bool canImport;
        private MainMenu form1;

        //Constructor
        public ImportsForm(MainMenu form1)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            this.form1 = form1;

            setup();
        }

        /*Precondition: 
          Postcondition: Initializes and checks to see if files can be imported */
        private void setup()
        {
            fileManager = new FileManager();
            dbManager = new DatabaseManager();

            if (!fileManager.checkForStorageLocation())
            {
                importFileLocation = fileManager.getStorageFilePath();

                canImport = false;

                MessageBox.Show("No file storage location set./nCannot import files");
            }
            else
            {
                canImport = true;
            }
        }

        /*Precondition: 
          Postcondition: Reads through all of the import files and stores them into the database */
        private void btnAutoImport_Click(object sender, EventArgs e)
        {
            if (canImport)
            {
                //Get a list of all the import files filepaths
                List<String> allImportFilePaths = fileManager.getAllImportFilePaths();

                //Loop through each filepath
                foreach (string s in allImportFilePaths)
                {
                    //Check if it's a stock file
                    if (s.Contains("Stock"))
                    {
                        //Get a list of stock objects out of the text file
                        List<Stock> newStock = fileManager.getStockFromFile(s);

                        progressBar1.Visible = true;
                        progressBar1.Maximum = newStock.Count;
                        progressBar1.Value = 0;

                        //Insert all of the new stock into the database
                        dbManager.insertStock(newStock, progressBar1);

                        progressBar1.Visible = false;

                        //Delete the now used file so it doesn't get repeated
                        fileManager.deleteFile(s);
                    }
                }

                MessageBox.Show("Completed");
            }
        }

        /*Precondition: 
          Postcondition: Close this form and go back to main menu */
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            form1.Show();
            form1.TopLevel = true;
        }

        /*Precondition:
         Postcondition: Listens for keypresses no matter which control has focus */
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Close form and return to main menu when escape is pressed
            if (keyData == Keys.Escape)
            {
                this.Close();
                form1.Show();
                form1.TopLevel = true;
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
