using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Hard_To_Find_Stock
{
    class FileManager
    {
        const string STORAGE_FILE_NAME = "FileStorageLocation.txt";
        const int CUSTOMER_ARRAY_LENGTH = 15;
        const int ORDER_ARRAY_LENGTH = 18;
        const int ORDEREDSTOCK_ARRAY_LENGTH = 19;

        private DatabaseManager dbManager;
        private List<Stock> allStock;

        public FileManager()
        {
            dbManager = new DatabaseManager();
        }

        public bool checkForStorageLocation()
        {
            bool haveStorageLocation = false;

            if (File.Exists(STORAGE_FILE_NAME))
            {
                haveStorageLocation = true;
            }

            return haveStorageLocation;
        }

        public void createStorageLocationFile(string newStorageFilePath)
        {
            string invoiceFolderPath = newStorageFilePath + @"\Invoices";
            string mailingLabelsFolderPath = newStorageFilePath + @"\Mailing Labels";
            string exportFilesFolderPath = newStorageFilePath + @"\Export Files";
            string importFilesFolderPath = newStorageFilePath + @"\Import Files";

            Directory.CreateDirectory(invoiceFolderPath);
            Directory.CreateDirectory(mailingLabelsFolderPath);
            Directory.CreateDirectory(exportFilesFolderPath);
            Directory.CreateDirectory(importFilesFolderPath);

            if (!File.Exists(STORAGE_FILE_NAME))
            {
                using (FileStream fs = File.Create(STORAGE_FILE_NAME))
                {
                    StreamWriter sw = new StreamWriter(fs);

                    sw.WriteLine(newStorageFilePath);
                    sw.Close();
                }
            }
            else
            {
                string oldStoragePath = getStorageFilePath();

                StreamWriter sw = new StreamWriter(STORAGE_FILE_NAME);

                sw.WriteLine(newStorageFilePath);
                sw.Close();

                DirectoryInfo dInvoices = new DirectoryInfo(oldStoragePath + @"\Invoices");
                DirectoryInfo dMailingLabels = new DirectoryInfo(oldStoragePath + @"\Mailing Labels");
                DirectoryInfo dExportFiles = new DirectoryInfo(oldStoragePath + @"\Export Files");
                DirectoryInfo dImportFiles = new DirectoryInfo(oldStoragePath + @"\Import Files");

                foreach (var file in dInvoices.GetFiles())
                {
                    Directory.Move(file.FullName, newStorageFilePath + @"\Invoices\" + file.Name);
                }

                foreach (var file in dMailingLabels.GetFiles())
                {
                    Directory.Move(file.FullName, newStorageFilePath + @"\Mailing Labels\" + file.Name);
                }

                foreach (var file in dExportFiles.GetFiles())
                {
                    Directory.Move(file.FullName, newStorageFilePath + @"\Export Files\" + file.Name);
                }
                foreach (var file in dImportFiles.GetFiles())
                {
                    Directory.Move(file.FullName, newStorageFilePath + @"\Import Files\" + file.Name);
                }

                Directory.Delete(oldStoragePath + @"\Invoices", true);
                Directory.Delete(oldStoragePath + @"\Mailing Labels", true);
                Directory.Delete(oldStoragePath + @"\Export Files", true);
                Directory.Delete(oldStoragePath + @"\Import Files", true);
            }
        }

        public string getStorageFilePath()
        {
            //Open file from passed in path
            StreamReader file = new StreamReader(STORAGE_FILE_NAME);

            string storageFilePath = "";
            string line;

            //Read through the whole file 1 line at a time
            while ((line = file.ReadLine()) != null)
            {
                storageFilePath = line;
            }

            file.Close();

            return storageFilePath;
        }

        public List<string> getAllImportFilePaths()
        {
            List<string> allFilePaths = new List<string>();

            DirectoryInfo dImportFiles = new DirectoryInfo(getStorageFilePath() + @"\Import Files");

            foreach (var file in dImportFiles.GetFiles())
            {
                allFilePaths.Add(file.FullName);
            }

            return allFilePaths;
        }

        /*Precondition: txt file must be formatted as a CSV separated by a | instead of , in order of:
          stockID, quantity, note, author, title, subtitle, publisher, description, comments, location, price, subject, catalogues, weight, sales, bookID, dateEntered
         Postcondition: Opens file browser for user to select a txt file to import stock*/
        public List<Stock> getStockFromFile(string filePath)
        {
            allStock = new List<Stock>();

            //Open file from passed in path
            StreamReader file = new StreamReader(filePath);

            string line;
            string[] previousLine = new string[1];
            bool newLineCharacter = false;

            //Read through the whole file 1 line at a time
            while ((line = file.ReadLine()) != null)
            {
                //Remove double quotations from line for SQL insert
                string unquoted = line.Replace("\"", string.Empty);

                //Check if it contains a single quotation
                if (unquoted.Contains('\''))
                {
                    //Get number of single quotations
                    int numQuotes = unquoted.Split('\'').Length - 1;
                    //int num = removedDashes.Count(c => c == '\'');

                    int previousIndex = 0;

                    //Loop over quotations
                    for (int i = 0; i < numQuotes; i++)
                    {
                        //Insert quotation before existing one because it's an escape character in SQLite
                        int indexOfQuote = unquoted.IndexOf("'", previousIndex);
                        unquoted = unquoted.Insert(indexOfQuote, "'");

                        //Move index after quotation that was just fixed to stop repeating on the same one
                        previousIndex = indexOfQuote + 2;
                    }

                }

                //Split on | instead of comma because Stock entries can contain commas
                string[] splitStock = unquoted.Split('|');

                //Importing from the old Access database contain a lot of new line characters
                //Check if current line contains all of the columns
                if (splitStock.Length < 17)
                {
                    //If previous line had a new line character in it
                    if (newLineCharacter)
                    {
                        //Check that it wasn't a second new line character by seeing if it's columns + the previous lines columns = the number needed
                        if ((splitStock.Length + previousLine.Length - 1) == 17)
                        {
                            //Go through and combined the lines into 1
                            string[] combinedLines = new string[17];
                            int combinedLineIndex = 0;

                            for (int i = 0; i < previousLine.Length; i++)
                            {
                                combinedLines[combinedLineIndex] = previousLine[i];
                                combinedLineIndex++;
                            }

                            for (int i = 0; i < splitStock.Length; i++)
                            {
                                if (i == 0)
                                {
                                    combinedLineIndex--;
                                    combinedLines[combinedLineIndex] = combinedLines[combinedLineIndex] + ", " + splitStock[i];
                                }
                                else
                                {
                                    combinedLines[combinedLineIndex] = splitStock[i];
                                }
                                combinedLineIndex++;
                            }

                            //Pull out all of the columns
                            int stockID = Convert.ToInt32(combinedLines[0]);
                            int quantity;

                            if (combinedLines[1] == "")
                                quantity = 0;
                            else
                                quantity = Convert.ToInt32(combinedLines[1]);

                            string note = combinedLines[2];
                            string author = combinedLines[3];
                            string title = combinedLines[4];
                            string subtitle = combinedLines[5];
                            string publisher = combinedLines[6];
                            string description = combinedLines[7];
                            string comments = combinedLines[8];
                            string price = combinedLines[10];
                            string subject = combinedLines[11];
                            string catalogue = combinedLines[12];
                            string sales = combinedLines[14];
                            string bookID = combinedLines[15];
                            string enteredBy = combinedLines[16];

                            //Create a new stock entry from it and insert into list
                            Stock newStock = new Stock(stockID, quantity, note, author, title, subtitle, publisher, description, comments, price, subject, catalogue, sales, bookID, enteredBy);
                            allStock.Add(newStock);

                            /*this.Invoke((MethodInvoker)delegate
                            {
                                listBox1.Items.Add("StockID: " + stockID.ToString() + " Quantity: " + quantity.ToString() + " Note: " + note + " Author: " + author + " Title: " + title + " Subtitle: " + subtitle
                                + " Publisher: " + publisher + " Description: " + description + " Comments: " + comments + " Price: " + price + " Subject: " + subject + " Catalogue: " + catalogue + " Sales: " + sales
                                + " BookID: " + bookID + " Date Entered: " + enteredBy);
                            });*/

                            //Reset values
                            newLineCharacter = false;
                            previousLine = new string[1];
                        }
                    }
                    else     //Was the first new line character and need to search for the rest of the line
                    {
                        //Update values to start searching for the rest of the line
                        newLineCharacter = true;
                        previousLine = splitStock;
                    }
                }
                else     //Else a normal line
                {
                    //Pull out all of the columns
                    int stockID = Convert.ToInt32(splitStock[0]);
                    int quantity;

                    if (splitStock[1] == "")
                        quantity = 0;
                    else
                        quantity = Convert.ToInt32(splitStock[1]);

                    string note = splitStock[2];
                    string author = splitStock[3];
                    string title = splitStock[4];
                    string subtitle = splitStock[5];
                    string publisher = splitStock[6];
                    string description = splitStock[7];
                    string comments = splitStock[8];
                    string price = splitStock[10];
                    string subject = splitStock[11];
                    string catalogue = splitStock[12];
                    string sales = splitStock[14];
                    string bookID = splitStock[15];
                    string enteredBy = splitStock[16];

                    //Create a newStock entry and insert into list
                    Stock newStock = new Stock(stockID, quantity, note, author, title, subtitle, publisher, description, comments, price, subject, catalogue, sales, bookID, enteredBy);
                    allStock.Add(newStock);
                }
            }
            //Close text file
            file.Close();

            return allStock;
        }
    }
}
