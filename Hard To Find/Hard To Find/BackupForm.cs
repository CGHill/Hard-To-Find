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
        }

        /*Precondition:
         Postcondition: Close this form and go back to the main menu */
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            mainMenu.Show();
            mainMenu.TopLevel = true;
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

                //Pass in the selected location
                fileManager.createDatabaseTablesAsCSVFiles(path);

                MessageBox.Show("Backed up to: " + path);
            }
        }
    }
}
