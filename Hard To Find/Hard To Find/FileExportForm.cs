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
            string filePath = fileManager.getStorageFilePath() + @"\Export Files\ABEInternetExport.txt";
            List<Stock> allStockInStock = dbManager.getAllStockInStock();

            using (FileStream fs = File.Create(filePath))
            {
                StreamWriter sw = new StreamWriter(fs);

                foreach (Stock s in allStockInStock)
                {
                    string line = s.stockID.ToString() + "~" + s.author + "~" + s.title + "~" + s.subtitle + "~" + s.publisher + "~" + s.description + "~" + s.comments +
                        "~" + s.price + "~" + s.subject + "~" + s.catalogue + "~" + s.bookID; 
                    sw.WriteLine(line);
                }
                sw.Close();
            }

            MessageBox.Show("Completed\nExported file stored at: " + filePath);
        }

        /*Precondition:
         Postcondition: Creates a text file that contains all stock in stock and stores it in the export files folder. This one includes date entered */
        private void btnHTFExport_Click(object sender, EventArgs e)
        {
            string filePath = fileManager.getStorageFilePath() + @"\Export Files\HTFInternetExport.txt";
            List<Stock> allStockInStock = dbManager.getAllStockInStock();

            using (FileStream fs = File.Create(filePath))
            {
                StreamWriter sw = new StreamWriter(fs);

                foreach (Stock s in allStockInStock)
                {
                    string line = s.stockID.ToString() + "~" + s.author + "~" + s.title + "~" + s.subtitle + "~" + s.publisher + "~" + s.description + "~" + s.comments +
                        "~" + s.price + "~" + s.subject + "~" + s.catalogue + "~" + s.bookID + "~" + s.dateEntered;
                    sw.WriteLine(line);
                }
                sw.Close();
            }

            MessageBox.Show("Completed\nExported file stored at: " + filePath);
        }

        /*Precondition:
         Postcondition: Closes this form and goes back to the main menu */
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            mainMenu.Show();
            mainMenu.TopLevel = true;
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
                mainMenu.TopLevel = true;
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
