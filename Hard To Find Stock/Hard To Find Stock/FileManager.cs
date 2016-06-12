using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Hard_To_Find_Stock
{
    class FileManager
    {
        const string EXPORT_STORAGE_FILE_NAME = "ExportFileStorageLocation.txt";
        const string IMPORT_STORAGE_FILE_NAME = "ImportFileStorageLocation.txt";
        const int STOCK_ARRAY_LENGTH = 16;

        public FileManager()
        {
        }

        /*Precondition:
         Postcondition: Returns true if the file that contains the file & folder storage location exists */
        public bool checkForStorageLocation()
        {
            bool haveStorageLocation = false;

            if (File.Exists(EXPORT_STORAGE_FILE_NAME))
                haveStorageLocation = true;

            return haveStorageLocation;
        }

         /*Precondition:
         Postcondition: Updates text file with new storage location */
        public void setExportStorageLocationFile(string newStorageFilePath)
        {
            using (FileStream fs = File.Create(EXPORT_STORAGE_FILE_NAME))
            {
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(newStorageFilePath);
                sw.Close();
            }
        }

        /*Precondition:
        Postcondition: Updates text file with new storage location */
        public void setImportStorageLocationFile(string newStorageFilePath)
        {
            using (FileStream fs = File.Create(IMPORT_STORAGE_FILE_NAME))
            {
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(newStorageFilePath);
                sw.Close();
            }
        }

        /*Precondition:
         Postcondition: Returns a string containing the path where the storage folders are */
        public string getExportStorageFilePath()
        {
            //Open file from passed in path
            StreamReader file = new StreamReader(EXPORT_STORAGE_FILE_NAME);

            string storageFilePath = "";
            string line;

            //Read through and get the storage path, file should only contain 1 line
            while ((line = file.ReadLine()) != null)
            {
                storageFilePath = line;
            }

            file.Close();

            return storageFilePath;
        }

        /*Precondition:
         Postcondition: Returns a string containing the path where the storage folders are */
        public string getImportStorageFilePath()
        {
            //Open file from passed in path
            StreamReader file = new StreamReader(IMPORT_STORAGE_FILE_NAME);

            string storageFilePath = "";
            string line;

            //Read through and get the storage path, file should only contain 1 line
            while ((line = file.ReadLine()) != null)
            {
                storageFilePath = line;
            }

            file.Close();

            return storageFilePath;
        }

        /*Precondition:
         Postcondition: Returns a list of strings of all of the import file paths */
        public List<string> getAllImportFilePaths()
        {
            List<string> allFilePaths = new List<string>();

            //Get info about the import files folder
            DirectoryInfo dImportFiles = new DirectoryInfo(getImportStorageFilePath());

            //Loop over all the files in the Import Files folder and store it's filepath
            foreach (var file in dImportFiles.GetFiles())
            {
                allFilePaths.Add(file.FullName);
            }

            //Return filepath
            return allFilePaths;
        }

        /*Precondition:
         Postcondition: Imports data in from CSV files, based on the type passed in */
        public List<Stock> importFromCSV(string filePath)
        {
            List<Stock> importedObjects = new List<Stock>();

            int currArrayLength = 0;
            currArrayLength = STOCK_ARRAY_LENGTH;

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

                //Split on | instead of comma because Order entries could contain commas in comments
                string[] splitObject = unquoted.Split('|');

                //Check if current line contains all of the columns
                if (splitObject.Length < currArrayLength)
                {
                    //If previous line had a new line character in it
                    if (newLineCharacter)
                    {
                        //Check that it wasn't a second new line character by seeing if it's columns + the previous lines columns = the number needed
                        if ((splitObject.Length + previousLine.Length - 1) == currArrayLength)
                        {
                            //Go through and combined the lines into 1
                            string[] combinedLines = new string[currArrayLength];
                            int combinedLineIndex = 0;

                            for (int i = 0; i < previousLine.Length; i++)
                            {
                                combinedLines[combinedLineIndex] = previousLine[i];
                                combinedLineIndex++;
                            }

                            for (int i = 0; i < splitObject.Length; i++)
                            {
                                if (i == 0)
                                {
                                    combinedLineIndex--;
                                    combinedLines[combinedLineIndex] = combinedLines[combinedLineIndex] + ", " + splitObject[i];
                                }
                                else
                                {
                                    combinedLines[combinedLineIndex] = splitObject[i];
                                }
                                combinedLineIndex++;
                            }

                            //Pull out all of the columns
                            Stock completedObject = formImportObjectFromArray(combinedLines);
                            importedObjects.Add(completedObject);

                            //Reset values
                            newLineCharacter = false;
                            previousLine = new string[1];
                        }
                        else
                        {
                            if (splitObject.Length == 1)
                            {
                                int previousLineLength = previousLine.Length;
                                previousLine[previousLineLength - 1] = previousLine[previousLineLength - 1] + " " + splitObject[0];
                            }
                            else
                            {
                                //Go through and combined the lines into 1
                                string[] combinedLines = new string[previousLine.Length + splitObject.Length - 1];
                                int combinedLineIndex = 0;

                                for (int i = 0; i < previousLine.Length; i++)
                                {
                                    combinedLines[combinedLineIndex] = previousLine[i];
                                    combinedLineIndex++;
                                }

                                for (int i = 0; i < splitObject.Length; i++)
                                {
                                    if (i == 0)
                                    {
                                        combinedLineIndex--;
                                        combinedLines[combinedLineIndex] = combinedLines[combinedLineIndex] + ", " + splitObject[i];
                                    }
                                    else
                                    {
                                        combinedLines[combinedLineIndex] = splitObject[i];
                                    }
                                    combinedLineIndex++;
                                }

                                if (combinedLines.Length == currArrayLength)
                                {
                                    Stock completedObject = formImportObjectFromArray(combinedLines);
                                    importedObjects.Add(completedObject);

                                    //Reset values
                                    newLineCharacter = false;
                                    previousLine = new string[1];
                                }

                            }
                        }
                    }
                    else     //Was the first new line character and need to search for the rest of the line
                    {
                        //Update values to start searching for the rest of the line
                        newLineCharacter = true;
                        previousLine = splitObject;
                    }
                }
                else     //Else a normal line
                {
                    Stock completedObject = formImportObjectFromArray(splitObject);
                    importedObjects.Add(completedObject);
                }
            }
            //Close text file
            file.Close();

            return importedObjects;
        }

        //TODO fix up array indexes
        private Stock formImportObjectFromArray(string[] splitObject)
        {
            //Pull out all of the columns
            int stockID = Convert.ToInt32(splitObject[0]);
            int quantity;

            if (splitObject[1] == "")
                quantity = 0;
            else
                quantity = Convert.ToInt32(splitObject[1]);

            string note = splitObject[2];
            string author = splitObject[3];
            string title = splitObject[4];
            string subtitle = splitObject[5];
            string publisher = splitObject[6];
            string description = splitObject[7];
            string comments = splitObject[8];
            string priceString = splitObject[9];
            double price = 0.00;
            if (priceString != "")
            {
                if(priceString[0] == '$')
                    price = Convert.ToDouble(priceString.Substring(1));
                else
                    price = Convert.ToDouble(priceString);
            }
            string subject = splitObject[10];
            string catalogue = splitObject[11];
            string initials = splitObject[12];
            string sales = splitObject[13];
            string bookID = splitObject[14];
            string enteredBy = splitObject[15];

            //Create a new stock entry from it and insert into list
            Stock newStock = new Stock(stockID, quantity, note, author, title, subtitle, publisher, description, comments, price, subject, catalogue, initials, sales, bookID, enteredBy);

            return newStock;
        }

        /*Precondition: 
          Postcondition: Deletes the file in the given filepath */
        public void deleteFile(string filePath)
        {
            File.Delete(filePath);
        }

        /*Precondition: 
          Postcondition: Checks for OneDrive directory and gets the latest file and copies it to current program directory */
        public string copyFileFromOneDrive()
        {
            string updatedFileName = "";

            //Get OneDrive directory
            string oneDrivePath = @"%USERPROFILE%\SkyDrive\HTF_Backups";
            string oneDrivePathFinal = Environment.ExpandEnvironmentVariables(oneDrivePath);
            
            //Check directory exists
            if (Directory.Exists(oneDrivePathFinal))
            {
                //Get the directories of the files
                DirectoryInfo dOneDrive = new DirectoryInfo(oneDrivePathFinal);

                //Get fine newest file
                int numFiles = 0;
                int indexNewestFile = 0;
                DateTime currNewest = DateTime.Now;

                //Loop over all the files in each directory
                foreach (var file in dOneDrive.GetFiles())
                {
                    if (numFiles == 0)
                    {
                        currNewest = file.LastWriteTimeUtc;
                    }
                    else
                    {
                        if (file.LastWriteTimeUtc > currNewest)
                            indexNewestFile = numFiles;
                    }

                    numFiles++;
                }

                //Copy over newest file
                int fileIndexer = 0;
                foreach (var file in dOneDrive.GetFiles())
                {
                    if (fileIndexer == indexNewestFile)
                    {
                        file.CopyTo(Environment.CurrentDirectory + @"\HardToFindDB.sqlite", true);
                        updatedFileName = file.Name;
                    }

                    fileIndexer++;
                }
            }

            //Return name of file or blank if it couldn't copy over
            return updatedFileName;
        }
    }
}
