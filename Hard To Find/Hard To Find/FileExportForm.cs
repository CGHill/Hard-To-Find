using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Hard_To_Find
{
    public partial class FileExportForm : Form
    {
        //Globals
        private DatabaseManager dbManager;
        private FileManager fileManager;
        private MainMenu mainMenu;


        //Constructor
        public FileExportForm(MainMenu mainMenu)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.mainMenu = mainMenu;

            setup();
        }

        /*Precondition:
         Postcondition: Setup and initialize everything needed*/
        private void setup()
        {
            dbManager = new DatabaseManager();
            fileManager = new FileManager();
        }

        /*Precondition:
         Postcondition: Creates a text file that contains all stock in stock and stores it in the export files folder */
        private void btnABEExport_Click(object sender, EventArgs e)
        {
            //Change cursor so user has feedback that program is doing something
            Cursor.Current = Cursors.WaitCursor;

            string filePath = fileManager.getStorageFilePath() + @"\Export Files\ABEInternetExport.txt";
            List<Stock> allStockInStock = dbManager.getAllStockInStock();

            using (FileStream fs = File.Create(filePath))
            {
                StreamWriter sw = new StreamWriter(fs);
                
                //Check if user wants the headers added to the file
                if(checkAddHeaders.Checked)
                    sw.WriteLine("stockID~author~title~subtitle~publisher~description~comments~price~subject~catalogue~bookID");

                //Loop over stock writing it to the text file
                foreach (Stock s in allStockInStock)
                {
                    string line = s.stockID.ToString() + "~" + s.author + "~" + s.title + "~" + s.subtitle + "~" + s.publisher + "~" + s.description + "~" + s.comments +
                        "~$" + String.Format("{0:0.00}", s.price) + "~" + s.subject + "~" + s.catalogue + "~" + s.bookID; 
                    sw.WriteLine(line);
                }
                sw.Close();
            }

            //Change cursor back to default
            Cursor.Current = Cursors.Default;

            MessageBox.Show("Completed\nExported file stored at: " + filePath);
        }

        /*Precondition:
         Postcondition: Creates a text file that contains all stock in stock and stores it in the export files folder. This one includes date entered */
        private void btnHTFExport_Click(object sender, EventArgs e)
        {
            //Change cursor so user has feedback that program is doing something
            Cursor.Current = Cursors.WaitCursor;

            string filePath = fileManager.getStorageFilePath() + @"\Export Files\HTFInternetExport.txt";
            List<Stock> allStockInStock = dbManager.getAllStockInStock();

            using (FileStream fs = File.Create(filePath))
            {
                StreamWriter sw = new StreamWriter(fs);

                if (checkAddHeaders.Checked)
                    sw.WriteLine("stockID~author~title~subtitle~publisher~description~comments~price~subject~catalogue~bookID~dateEntered");

                foreach (Stock s in allStockInStock)
                {
                    string line = s.stockID.ToString() + "~" + s.author + "~" + s.title + "~" + s.subtitle + "~" + s.publisher + "~" + s.description + "~" + s.comments +
                        "~$" + String.Format("{0:0.00}", s.price) + "~" + s.subject + "~" + s.catalogue + "~" + s.bookID + "~" + s.dateEntered;
                    sw.WriteLine(line);
                }
                sw.Close();
            }

            //Change cursor back to default
            Cursor.Current = Cursors.Default;

            MessageBox.Show("Completed\nExported file stored at: " + filePath);
        }

        /*Precondition:
         Postcondition: Closes this form and goes back to the main menu */
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            mainMenu.Show();
            mainMenu.Activate();
        }

        /*Precondition:
         Postcondition: Listens for keypress no matter which control has focus*/
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Close form and bring main menu back to front when escape is pressed
            if (keyData == Keys.Escape)
            {
                this.Close();
                mainMenu.Show();
                mainMenu.Activate();
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnExportEmails_Click(object sender, EventArgs e)
        {
            //Setup folder browser
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "Select storage location";

            //Check the user selected something
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowser.SelectedPath;

                //Create file
                string directoryName = Path.Combine(path, "EmailCSV.txt");
                File.Create(directoryName).Dispose();

                //Get all of the emails
                List<string> customerEmails = dbManager.getAllCustomersEmails();

                string customerEmailString = "";

                foreach (string s in customerEmails)
                {
                    //Combine emails to 1 line separated by commas, ignoring empty strings
                    if(s != "")
                        customerEmailString += s + ",";
                }

                //Write to file
                using (var tw = new StreamWriter(directoryName, true))
                {
                    tw.WriteLine(customerEmailString);
                    tw.Close();
                }

                MessageBox.Show("Completed");
            }
        }
    }
}
