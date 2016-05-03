using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Hard_To_Find
{
    class FileManager
    {
        //Constants
        public enum IMPORT_TYPE { CUSTOMER, STOCK, ORDERS, ORDEREDSTOCK }
        const string STORAGE_FILE_NAME = "FileStorageLocation.txt";
        const string IMPORT_FILE_STORAGE = "ImportStorageLocation.txt";
        const string STOCK_EXPORT_FILE_STORAGE = "StockExportStorageLocation.txt";
        const int OLD_CUSTOMER_ARRAY_LENGTH = 15;
        const int OLD_ORDER_ARRAY_LENGTH = 18;
        const int OLD_ORDEREDSTOCK_ARRAY_LENGTH = 19;
        const int CUSTOMER_ARRAY_LENGTH = 13;
        const int ORDER_ARRAY_LENGTH = 12;
        const int ORDEREDSTOCK_ARRAY_LENGTH = 9;
        const int STOCK_ARRAY_LENGTH = 16;

        //Globals
        private DatabaseManager dbManager;
        private List<Stock> allStock;
        private List<Customer> allCustomers;
        private List<Order> allOrders;
        private List<OrderedStock> allOrderedStock;

        //Constructor
        public FileManager()
        {
            setup();
        }

        /*Precondition:
         Postcondition: Setup and initialize everything needed*/
        private void setup()
        {
            dbManager = new DatabaseManager();
        }

        /*Precondition:
         Postcondition: Returns true if the file that contains the file & folder storage location exists */
        public bool checkForStorageLocation()
        {
            bool haveStorageLocation = false;

            if (File.Exists(STORAGE_FILE_NAME))
                haveStorageLocation = true;

            return haveStorageLocation;
        }

        public bool haveStorageFolders()
        {
            bool haveFolders = true;

            string folderPath = getStorageFilePath();

            if (!Directory.Exists(folderPath + @"\Invoices"))
                haveFolders = false;
            if (!Directory.Exists(folderPath + @"\Mailing Labels"))
                haveFolders = false;
            if (!Directory.Exists(folderPath + @"\Export Files"))
                haveFolders = false;
            if (!Directory.Exists(folderPath + @"\Sales Reports"))
                haveFolders = false;
            if (!Directory.Exists(folderPath + @"\Freight Reports"))
                haveFolders = false;

            return haveFolders;
        }

        /*Precondition:
         Postcondition: Creates all of the folders to store files in, moves files over if a storage location had previously been set. Updates text file with new storage location */
        public void setStorageLocationFile(string newStorageFilePath)
        {
            //File paths for new folder directories
            string invoiceFolderPath = newStorageFilePath + @"\Invoices";
            string mailingLabelsFolderPath = newStorageFilePath + @"\Mailing Labels";
            string exportFilesFolderPath = newStorageFilePath + @"\Export Files";
            string salesReportsFolderPath = newStorageFilePath + @"\Sales Reports";
            string freightReportsFolderPath = newStorageFilePath + @"\Freight Reports";

            //Create the folders in their new directory
            Directory.CreateDirectory(invoiceFolderPath);
            Directory.CreateDirectory(mailingLabelsFolderPath);
            Directory.CreateDirectory(exportFilesFolderPath);
            Directory.CreateDirectory(salesReportsFolderPath);
            Directory.CreateDirectory(freightReportsFolderPath);

            //If the storage loaction hasn't previously been set then create the file with the new storage location
            if (!File.Exists(STORAGE_FILE_NAME))
            {
                using (FileStream fs = File.Create(STORAGE_FILE_NAME))
                {
                    StreamWriter sw = new StreamWriter(fs);

                    sw.WriteLine(newStorageFilePath);
                    sw.Close();
                }
            }
            //Else storage location has been set previously and the files need transferred over
            else
            {
                //Keep track of old storage location
                string oldStoragePath = getStorageFilePath();

                //Store the new file storage location
                StreamWriter sw = new StreamWriter(STORAGE_FILE_NAME);

                sw.WriteLine(newStorageFilePath);
                sw.Close();

                //Get the directories of the old files
                DirectoryInfo dInvoices = new DirectoryInfo(oldStoragePath + @"\Invoices");
                DirectoryInfo dMailingLabels = new DirectoryInfo(oldStoragePath + @"\Mailing Labels");
                DirectoryInfo dExportFiles = new DirectoryInfo(oldStoragePath + @"\Export Files");
                DirectoryInfo dSalesReports = new DirectoryInfo(oldStoragePath + @"\Sales Reports");
                DirectoryInfo dFreightReports = new DirectoryInfo(oldStoragePath + @"\Freight Reports");


                //Loop over all the files in each directory and move them to the new location
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
                foreach (var file in dSalesReports.GetFiles())
                {
                    Directory.Move(file.FullName, newStorageFilePath + @"\Sales Reports\" + file.Name);
                }
                foreach (var file in dFreightReports.GetFiles())
                {
                    Directory.Move(file.FullName, newStorageFilePath + @"\Freight Reports\" + file.Name);
                }

                //Delete the old, now empty folders
                Directory.Delete(oldStoragePath + @"\Invoices", true);
                Directory.Delete(oldStoragePath + @"\Mailing Labels", true);
                Directory.Delete(oldStoragePath + @"\Export Files", true);
                Directory.Delete(oldStoragePath + @"\Sales Reports", true);
                Directory.Delete(oldStoragePath + @"\Freight Reports", true);
            }
        }

        /*Precondition:
         Postcondition: Returns a string containing the path where the storage folders are */
        public string getStorageFilePath()
        {
            //Open file from passed in path
            StreamReader file = new StreamReader(STORAGE_FILE_NAME);

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
         Postcondition: Returns true if the file that contains the file & folder storage location exists */
        public bool checkForImportStorageLocation()
        {
            bool haveStorageLocation = false;

            if (File.Exists(IMPORT_FILE_STORAGE))
                haveStorageLocation = true;

            return haveStorageLocation;
        }

        /*Precondition:
         Postcondition: Sets the import file location */
        public void setImportStorageLocationFile(string newStorageFilePath)
        {
            //Create or overwrite the file to contain the storage location of imports folder
            using (FileStream fs = File.Create(IMPORT_FILE_STORAGE))
            {
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(newStorageFilePath);
                sw.Close();
            }
        }

        /*Precondition:
         Postcondition: Sets the import file location */
        public void setStockExportStorageLocationFile(string newStorageFilePath)
        {
            //Create or overwrite the file to contain the storage location of imports folder
            using (FileStream fs = File.Create(STOCK_EXPORT_FILE_STORAGE))
            {
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(newStorageFilePath);
                sw.Close();
            }
        }

        /*Precondition:
         Postcondition: Returns a string containing the path where the storage folders are */
        public string getImportStorageFilePath()
        {
            //Open file from passed in path
            StreamReader file = new StreamReader(IMPORT_FILE_STORAGE);

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
        public string getStockExportStorageFilePath()
        {
            //Open file from passed in path
            StreamReader file = new StreamReader(STOCK_EXPORT_FILE_STORAGE);

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
        public List<Object> importFromCSV(string filePath, IMPORT_TYPE type)
        {
            List<Object> importedObjects = new List<Object>();
       
            int currArrayLength = 0;

            //Set the right array length for the import type
            switch (type)
            {
                case IMPORT_TYPE.CUSTOMER:
                    currArrayLength = CUSTOMER_ARRAY_LENGTH;
                    break;
                case IMPORT_TYPE.STOCK:
                    currArrayLength = STOCK_ARRAY_LENGTH;
                    break;
                case IMPORT_TYPE.ORDERS:
                    currArrayLength = ORDER_ARRAY_LENGTH;
                    break;
                case IMPORT_TYPE.ORDEREDSTOCK:
                    currArrayLength = ORDEREDSTOCK_ARRAY_LENGTH;
                    break;
            }

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
                            Object completedObject = formImportObjectFromArray(combinedLines, type);
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
                                    Object completedObject = formImportObjectFromArray(combinedLines, type);
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
                    Object completedObject = formImportObjectFromArray(splitObject, type);
                    importedObjects.Add(completedObject);
                }
            }
            //Close text file
            file.Close();

            return importedObjects;
        }

        //TODO fix up array indexes
        private Object formImportObjectFromArray(string[] splitObject, IMPORT_TYPE type)
        {
            Object completedObject = null;

            //Turn object passed in, into the proper formed type
            switch (type)
            {
                case IMPORT_TYPE.CUSTOMER:
                    {
                        int custID = Convert.ToInt32(splitObject[0]);
                        string custFirstName = splitObject[1];
                        string custLastName = splitObject[2];
                        string custInstitution = splitObject[3];
                        string custAddress1 = splitObject[4];
                        string custAddress2 = splitObject[5];
                        string custAddress3 = splitObject[6];
                        string custCountry = splitObject[7];
                        string custPostCode = splitObject[8];
                        string custEmail = splitObject[9];
                        string custComments = splitObject[10];
                        string custSales = splitObject[11];
                        string custPayment = splitObject[12];

                        //Create new customer and insert into list
                        Customer newCust = new Customer(custID, custFirstName, custLastName, custInstitution, custAddress1, custAddress2, custAddress3, custCountry, custPostCode, custEmail, custComments, custSales, custPayment);
                        completedObject = newCust;
                    }
                    break;
                case IMPORT_TYPE.STOCK:
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
                        double price = Convert.ToDouble(priceString.Substring(1));
                        string subject = splitObject[10];
                        string catalogue = splitObject[11];
                        string initials = splitObject[12];
                        string sales = splitObject[13];
                        string bookID = splitObject[14];
                        string enteredBy = splitObject[15];

                        //Create a new stock entry from it and insert into list
                        Stock newStock = new Stock(stockID, quantity, note, author, title, subtitle, publisher, description, comments, price, subject, catalogue, initials, sales, bookID, enteredBy);
                        completedObject = newStock;
                    }
                    break;
                case IMPORT_TYPE.ORDERS:
                    {
                        int orderID = Convert.ToInt32(splitObject[0]);
                        string customerFirstName = splitObject[1];
                        string customerLastName = splitObject[2];
                        string institution = splitObject[3];
                        string postcode = splitObject[4];
                        string orderReference = splitObject[5];
                        string progress = splitObject[6];
                        string freightCostString = splitObject[7];
                        double freightCost = Convert.ToDouble(freightCostString.Substring(1));

                        int invoiceNo;
                        if (splitObject[8] == "")
                            invoiceNo = -1;
                        else
                            invoiceNo = Convert.ToInt32(splitObject[8]);

                        string stringDate = splitObject[9];
                        string[] splitOnSpaceDate = stringDate.Split(' ');
                        string[] splitDate = splitOnSpaceDate[0].Split('/');

                        DateTime invoiceDate = new DateTime(1, 1, 1);

                        invoiceDate = new DateTime(Convert.ToInt32(splitDate[2]), Convert.ToInt32(splitDate[1]), Convert.ToInt32(splitDate[0]));

                        string comment = splitObject[10];

                        int customerID;
                        if (splitObject[11] == "")
                            customerID = -1;
                        else
                            customerID = Convert.ToInt32(splitObject[11]);

                        //Create a new order entry from it and insert into list
                        Order newOrder = new Order(orderID, customerFirstName, customerLastName, institution, postcode, orderReference, progress, freightCost, invoiceNo, invoiceDate, comment, customerID);
                        completedObject = newOrder;
                    }
                    break;
                case IMPORT_TYPE.ORDEREDSTOCK:
                    {
                        int orderedStockID = Convert.ToInt32(splitObject[0]);
                        int orderedStockOrderID = Convert.ToInt32(splitObject[1]);

                        int stockID;
                        if (splitObject[2] == "")
                            stockID = -1;
                        else
                            stockID = Convert.ToInt32(splitObject[2]);

                        int quantity;
                        if (splitObject[3] == "")
                            quantity = 0;
                        else
                            quantity = Convert.ToInt32(splitObject[3]);
                        string author = splitObject[4];
                        string title = splitObject[5];
                        string priceString = splitObject[6];
                        double price = 0.00;
                        if(priceString != "")
                            price = Convert.ToDouble(priceString.Substring(1));
                        string bookID = splitObject[7];
                        string discountString = splitObject[8];
                        double discount = 0.00;
                        if (discountString != "")
                            discount = Convert.ToDouble(discountString.Substring(1));

                        //Create a new order entry from it and insert into list
                        OrderedStock newOrderedStock = new OrderedStock(orderedStockID, orderedStockOrderID, stockID, quantity, author, title, price, bookID, discount);
                        completedObject = newOrderedStock;
                    }
                    break;
            }

            return completedObject;
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
                            string priceString = combinedLines[10];
                            double price = 0.00;
                            if (priceString != "")
                            {
                                if(priceString[0] == '$')
                                    price = Convert.ToDouble(priceString.Substring(1));
                                else
                                    price = Convert.ToDouble(priceString);
                            }
                            string subject = combinedLines[11];
                            string catalogue = combinedLines[12];
                            string initials = combinedLines[13];
                            string sales = combinedLines[14];
                            string bookID = combinedLines[15];
                            string enteredBy = combinedLines[16];

                            //Create a new stock entry from it and insert into list
                            Stock newStock = new Stock(stockID, quantity, note, author, title, subtitle, publisher, description, comments, price, subject, catalogue, initials,sales, bookID, enteredBy);
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
                    string priceString = splitStock[10];
                    double price = 0.00;
                    if(priceString != "")
                        price = Convert.ToDouble(priceString.Substring(1));
                    string subject = splitStock[11];
                    string catalogue = splitStock[12];
                    string initials = splitStock[13];
                    string sales = splitStock[14];
                    string bookID = splitStock[15];
                    string enteredBy = splitStock[16];

                    //Create a newStock entry and insert into list
                    Stock newStock = new Stock(stockID, quantity, note, author, title, subtitle, publisher, description, comments, price, subject, catalogue, initials, sales, bookID, enteredBy);
                    allStock.Add(newStock);
                }
            }
            //Close text file
            file.Close();

            return allStock;
        }

        /*Precondition: txt file must be formatted as a CSV separated by a | instead of , in order of:
          customerID, firstName, lastName, institute, address1, address2, address3, country, postcode, phone, fax, email, comments, sales, payment
         Postcondition: Opens file browser for user to select a txt file to import customers*/
        public List<Customer> getCustomersFromFile(string filePath)
        {
            allCustomers = new List<Customer>();

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
                string[] splitOrder = unquoted.Split('|');

                //Importing from the old Access database contain a lot of new line characters
                //Check if current line contains all of the columns
                if (splitOrder.Length < OLD_CUSTOMER_ARRAY_LENGTH)
                {
                    //If previous line had a new line character in it
                    if (newLineCharacter)
                    {
                        //Check that it wasn't a second new line character by seeing if it's columns + the previous lines columns = the number needed
                        if ((splitOrder.Length + previousLine.Length - 1) == OLD_CUSTOMER_ARRAY_LENGTH)
                        {
                            //Go through and combined the lines into 1
                            string[] combinedLines = new string[OLD_CUSTOMER_ARRAY_LENGTH];
                            int combinedLineIndex = 0;

                            for (int i = 0; i < previousLine.Length; i++)
                            {
                                combinedLines[combinedLineIndex] = previousLine[i];
                                combinedLineIndex++;
                            }

                            for (int i = 0; i < splitOrder.Length; i++)
                            {
                                if (i == 0)
                                {
                                    combinedLineIndex--;
                                    combinedLines[combinedLineIndex] = combinedLines[combinedLineIndex] + ", " + splitOrder[i];
                                }
                                else
                                {
                                    combinedLines[combinedLineIndex] = splitOrder[i];
                                }
                                combinedLineIndex++;
                            }

                            //Pull out all of the columns
                            storeCustomer(combinedLines);

                            //Reset values
                            newLineCharacter = false;
                            previousLine = new string[1];
                        }
                        else
                        {
                            if (splitOrder.Length == 1)
                            {
                                int previousLineLength = previousLine.Length;
                                previousLine[previousLineLength - 1] = previousLine[previousLineLength - 1] + " " + splitOrder[0];
                            }
                            else
                            {
                                //Go through and combined the lines into 1
                                string[] combinedLines = new string[previousLine.Length + splitOrder.Length - 1];
                                int combinedLineIndex = 0;

                                for (int i = 0; i < previousLine.Length; i++)
                                {
                                    combinedLines[combinedLineIndex] = previousLine[i];
                                    combinedLineIndex++;
                                }

                                for (int i = 0; i < splitOrder.Length; i++)
                                {
                                    if (i == 0)
                                    {
                                        combinedLineIndex--;
                                        combinedLines[combinedLineIndex] = combinedLines[combinedLineIndex] + ", " + splitOrder[i];
                                    }
                                    else
                                    {
                                        combinedLines[combinedLineIndex] = splitOrder[i];
                                    }
                                    combinedLineIndex++;
                                }

                                if (combinedLines.Length == OLD_CUSTOMER_ARRAY_LENGTH)
                                {
                                    storeCustomer(combinedLines);

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
                        previousLine = splitOrder;
                    }
                }
                else     //Else a normal line
                {
                    storeCustomer(splitOrder);
                }
            }
            //Close text file
            file.Close();

            return allCustomers;
        }


        /*Precondition: The array needs to be in the correct order of [customerID, firstName, lastName, institute, address1, address2, address3, country, postcode, phone, fax, email, comments, sales, payment]
         Postcondition: Turns the string array of customer details into a customer object and stores it */
        private void storeCustomer(string[] splitCustomer)
        {
            int custID = Convert.ToInt32(splitCustomer[0]);
            string custFirstName = splitCustomer[1];
            string custLastName = splitCustomer[2];
            string custInstitution = splitCustomer[3];
            string custAddress1 = splitCustomer[4];
            string custAddress2 = splitCustomer[5];
            string custAddress3 = splitCustomer[6];
            string custCountry = splitCustomer[7];
            string custPostCode = splitCustomer[8];
            string custEmail = splitCustomer[11];
            string custComments = splitCustomer[12];
            string custSales = splitCustomer[13];
            string custPayment = splitCustomer[14];

            //Create new customer and insert into list
            Customer newCust = new Customer(custID, custFirstName, custLastName, custInstitution, custAddress1, custAddress2, custAddress3, custCountry, custPostCode, custEmail, custComments, custSales, custPayment);
            allCustomers.Add(newCust);
        }


        /*Precondition: txt file must be formatted as a CSV separated by a | instead of , in order of:
          orderID, customerFirstName, customerLastName, institution, postcode, orderReference, catItem, author, title, quantity, price, progress, discprice, invoiceNo, invoiceDate, comments, stockID, customerID
         Postcondition: Opens file browser for user to select a txt file to import orders */
        public List<Order> getOrdersFromFile(string filePath)
        {
            allOrders = new List<Order>();

            //Open file from passed in path
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);

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

                //Split on | instead of comma because Order entries could contain commas in comments
                string[] splitOrder = unquoted.Split('|');

                //Importing from the old Access database contain a lot of new line characters
                //Check if current line contains all of the columns
                if (splitOrder.Length < OLD_ORDER_ARRAY_LENGTH)
                {
                    //If previous line had a new line character in it
                    if (newLineCharacter)
                    {
                        //Check that it wasn't a second new line character by seeing if it's columns + the previous lines columns = the number needed
                        if ((splitOrder.Length + previousLine.Length - 1) == OLD_ORDER_ARRAY_LENGTH)
                        {
                            //Go through and combined the lines into 1
                            string[] combinedLines = new string[OLD_ORDER_ARRAY_LENGTH];
                            int combinedLineIndex = 0;

                            for (int i = 0; i < previousLine.Length; i++)
                            {
                                combinedLines[combinedLineIndex] = previousLine[i];
                                combinedLineIndex++;
                            }

                            for (int i = 0; i < splitOrder.Length; i++)
                            {
                                if (i == 0)
                                {
                                    combinedLineIndex--;
                                    combinedLines[combinedLineIndex] = combinedLines[combinedLineIndex] + ", " + splitOrder[i];
                                }
                                else
                                {
                                    combinedLines[combinedLineIndex] = splitOrder[i];
                                }
                                combinedLineIndex++;
                            }

                            //Pull out all of the columns
                            storeOrder(combinedLines);

                            //Reset values
                            newLineCharacter = false;
                            previousLine = new string[1];
                        }
                        else
                        {
                            if (splitOrder.Length == 1)
                            {
                                int previousLineLength = previousLine.Length;
                                previousLine[previousLineLength - 1] = previousLine[previousLineLength - 1] + " " + splitOrder[0];
                            }
                            else
                            {
                                //Go through and combined the lines into 1
                                string[] combinedLines = new string[previousLine.Length + splitOrder.Length - 1];
                                int combinedLineIndex = 0;

                                for (int i = 0; i < previousLine.Length; i++)
                                {
                                    combinedLines[combinedLineIndex] = previousLine[i];
                                    combinedLineIndex++;
                                }

                                for (int i = 0; i < splitOrder.Length; i++)
                                {
                                    if (i == 0)
                                    {
                                        combinedLineIndex--;
                                        combinedLines[combinedLineIndex] = combinedLines[combinedLineIndex] + ", " + splitOrder[i];
                                    }
                                    else
                                    {
                                        combinedLines[combinedLineIndex] = splitOrder[i];
                                    }
                                    combinedLineIndex++;
                                }

                                if (combinedLines.Length == OLD_ORDER_ARRAY_LENGTH)
                                {
                                    storeOrder(combinedLines);

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
                        previousLine = splitOrder;
                    }
                }
                else     //Else a normal line
                {
                    storeOrder(splitOrder);
                }
            }
            //Close text file
            file.Close();

            return allOrders;
        }

        /*Precondition: The array needs to be in the correct order of:
          [orderID, customerFirstName, customerLastName, institution, postcode, orderReference, catItem, author, title, quantity, price, progress, discprice, invoiceNo, invoiceDate, comments, stockID, customerID]
         Postcondition: Turns the string array of customer details into a customer object and stores it */
        private void storeOrder(string[] splitOrder)
        {
            int orderID = Convert.ToInt32(splitOrder[0]);
            string customerFirstName = splitOrder[1];
            string customerLastName = splitOrder[2];
            string institution = splitOrder[3];
            string postcode = splitOrder[4];
            string orderReference = splitOrder[5];
            string progress = splitOrder[11];
            string freightCostString = splitOrder[12];
            double freightCost = 0.00;
            if(freightCostString != "")
                freightCost = Convert.ToDouble(freightCostString.Substring(1));

            int invoiceNo;
            if (splitOrder[13] == "")
                invoiceNo = -1;
            else
                invoiceNo = Convert.ToInt32(splitOrder[13]);

            DateTime invoiceDate;
            try
            {
                string stringDate = splitOrder[14];
                string[] splitDate;
                if(stringDate.Contains('-'))
                    splitDate = stringDate.Split('-');
                else
                    splitDate = stringDate.Split('/');

                invoiceDate = new DateTime(Convert.ToInt32(splitDate[2]), Convert.ToInt32(splitDate[1]), Convert.ToInt32(splitDate[0]));
            }
            catch (IndexOutOfRangeException)
            {
                invoiceDate = new DateTime(1,1,1);
            }
            string comments = splitOrder[15];

            int customerID;
            if (splitOrder[17] == "")
                customerID = -1;
            else
                customerID = Convert.ToInt32(splitOrder[17]);

            //Create a new order entry from it and insert into list
            Order newOrder = new Order(orderID, customerFirstName, customerLastName, institution, postcode, orderReference, progress, freightCost, invoiceNo, invoiceDate, comments, customerID);
            allOrders.Add(newOrder);
        }

        /*Precondition: txt file must be formatted as a CSV separated by a | instead of , in order of:
          orderedStockID, orderID, stockID, quantity, author, title, subtitle, publisher, description, comment, location, price, subject, catalogue, weight, sales, bookID, enteredBy, discount
         Postcondition: Opens file browser for user to select a txt file to import ordered stock */
        public List<OrderedStock> getOrderedStockFromFile(string filePath)
        {
            allOrderedStock = new List<OrderedStock>();

            //Open file from passed in path
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);

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

                //Split on | instead of comma because Order entries could contain commas in comments
                string[] splitOrder = unquoted.Split('|');

                //Importing from the old Access database contain a lot of new line characters
                //Check if current line contains all of the columns
                if (splitOrder.Length < OLD_ORDEREDSTOCK_ARRAY_LENGTH)
                {
                    //If previous line had a new line character in it
                    if (newLineCharacter)
                    {
                        //Check that it wasn't a second new line character by seeing if it's columns + the previous lines columns = the number needed
                        if ((splitOrder.Length + previousLine.Length - 1) == OLD_ORDEREDSTOCK_ARRAY_LENGTH)
                        {
                            //Go through and combined the lines into 1
                            string[] combinedLines = new string[OLD_ORDEREDSTOCK_ARRAY_LENGTH];
                            int combinedLineIndex = 0;

                            for (int i = 0; i < previousLine.Length; i++)
                            {
                                combinedLines[combinedLineIndex] = previousLine[i];
                                combinedLineIndex++;
                            }

                            for (int i = 0; i < splitOrder.Length; i++)
                            {
                                if (i == 0)
                                {
                                    combinedLineIndex--;
                                    combinedLines[combinedLineIndex] = combinedLines[combinedLineIndex] + ", " + splitOrder[i];
                                }
                                else
                                {
                                    combinedLines[combinedLineIndex] = splitOrder[i];
                                }
                                combinedLineIndex++;
                            }

                            //Pull out all of the columns
                            storeOrderedStock(combinedLines);

                            //Reset values
                            newLineCharacter = false;
                            previousLine = new string[1];
                        }
                        else
                        {
                            if (splitOrder.Length == 1)
                            {
                                int previousLineLength = previousLine.Length;
                                previousLine[previousLineLength - 1] = previousLine[previousLineLength - 1] + " " + splitOrder[0];
                            }
                            else
                            {
                                //Go through and combined the lines into 1
                                string[] combinedLines = new string[previousLine.Length + splitOrder.Length - 1];
                                int combinedLineIndex = 0;

                                for (int i = 0; i < previousLine.Length; i++)
                                {
                                    combinedLines[combinedLineIndex] = previousLine[i];
                                    combinedLineIndex++;
                                }

                                for (int i = 0; i < splitOrder.Length; i++)
                                {
                                    if (i == 0)
                                    {
                                        combinedLineIndex--;
                                        combinedLines[combinedLineIndex] = combinedLines[combinedLineIndex] + ", " + splitOrder[i];
                                    }
                                    else
                                    {
                                        combinedLines[combinedLineIndex] = splitOrder[i];
                                    }
                                    combinedLineIndex++;
                                }

                                if (combinedLines.Length == OLD_ORDEREDSTOCK_ARRAY_LENGTH)
                                {
                                    storeOrderedStock(combinedLines);

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
                        previousLine = splitOrder;
                    }
                }
                else     //Else a normal line
                {
                    storeOrderedStock(splitOrder);
                }
            }
            //Close text file
            file.Close();

            return allOrderedStock;
        }

        /*Precondition: The array needs to be in the correct order of:
           [orderedStockID, orderID, stockID, quantity, author, title, subtitle, publisher, description, comment, location, price, subject, catalogue, weight, sales, bookID, enteredBy, discount]
          Postcondition: Turns the string array of customer details into a customer object and stores it */
        private void storeOrderedStock(string[] splitOrderedStock)
        {
            int orderedStockID = Convert.ToInt32(splitOrderedStock[0]);
            int orderID = Convert.ToInt32(splitOrderedStock[1]);

            int stockID;
            if (splitOrderedStock[2] == "")
                stockID = -1;
            else
                stockID = Convert.ToInt32(splitOrderedStock[2]);

            int quantity;
            if (splitOrderedStock[3] == "")
                quantity = 0;
            else
                quantity = Convert.ToInt32(splitOrderedStock[3]);
            string author = splitOrderedStock[4];
            string title = splitOrderedStock[5];
            string priceString = splitOrderedStock[11];
            double price = 0.00;
            if (priceString != "")
                price = Convert.ToDouble(priceString.Substring(1));
            string bookID = splitOrderedStock[16];
            string discountString = splitOrderedStock[18];
            double discount = 0.00;
            if(discountString != "")
                discount = Convert.ToDouble(discountString.Substring(1));

            //Create a new order entry from it and insert into list
            OrderedStock newOrderedStock = new OrderedStock(orderedStockID, orderID, stockID, quantity, author, title, price, bookID, discount);
            allOrderedStock.Add(newOrderedStock);
        }

        /*Precondition: 
          Postcondition: Deletes the file in the given filepath */
        public void deleteFile(string filePath)
        {
            File.Delete(filePath);
        }

        /*Precondition: 
         Postcondition: Copies the sqlite database file into the selected location */
        public void copyDatabaseFile(string filePath)
        {
            if (File.Exists("HardToFindDB.sqlite"))
            {
                File.Copy("HardToFindDB.sqlite", filePath + @"\HardToFindDB.sqlite");
            }
        }

        /*Precondition: 
         Postcondition: Checks that the file has the correct name then copies it into the directory to be used for the rest of the program */
        public bool restoreDatabaseFile(string filePath)
        {
            if (filePath.Contains("HardToFindDB.sqlite"))
            {
                File.Copy(filePath, Environment.CurrentDirectory + @"\HardToFindDB.sqlite", true);
                return true;
            }
            else
            {
                return false;
            }
        }

        /*Precondition: 
         Postcondition: Takes each table in the database and stores them as a csv text file in the given filepath */
        public void createDatabaseTablesAsCSVFiles(string storagePath)
        {
            /*******************  Create and store customer CSV ***********************/
            string customerFileName = @"\Customers.txt";

            List<Customer> allCustomers = dbManager.getAllCustomers();

            if (allCustomers.Count > 0)
            {
                //Create the textfile and write the newstock information into it
                using (FileStream stream = File.Create(storagePath + customerFileName))
                {
                    StreamWriter sw = new StreamWriter(stream);

                    foreach (Customer c in allCustomers)
                    {
                        string lineToCheck = c.custID + "|\"" + c.firstName + "\"|\"" + c.lastName + "\"|\"" + c.institution + "\"|\"" + c.address1 + "\"|\"" + c.address2 + "\"|\"" + c.address3 + "\"|\""
                            + c.country + "\"|\"" + c.postCode + "\"|\"" + c.email + "\"|\"" + c.comments + "\"|\"" + c.sales + "\"|\"" + c.payment + "\"";

                        //The code below checks to see if there are any empty fields that are just quotations and removes the quotations
                        string[] splitToCheckForEmpty = lineToCheck.Split('|');
                        string lineToWrite = "";

                        for (int i = 0; i < splitToCheckForEmpty.Length; i++)
                        {
                            if (i != splitToCheckForEmpty.Length - 1)
                            {
                                if (splitToCheckForEmpty[i].Contains("\"\""))
                                    lineToWrite += "|";
                                else
                                    lineToWrite += splitToCheckForEmpty[i] + "|";
                            }
                            else
                            {
                                if (!splitToCheckForEmpty[i].Contains("\"\""))
                                    lineToWrite += splitToCheckForEmpty[i];
                            }
                        }

                        sw.WriteLine(lineToWrite);
                    }

                    sw.Close();
                }
            }

            /*******************  Create and store stock CSV ***********************/
            string stockFileName = @"\Stock.txt";

            List<Stock> allStock = dbManager.getAllStock();

            if (allStock.Count > 0)
            {
                //Create the textfile and write the newstock information into it
                using (FileStream stream = File.Create(storagePath + stockFileName))
                {
                    StreamWriter sw = new StreamWriter(stream);

                    foreach (Stock s in allStock)
                    {
                        string lineToCheck = s.stockID + "|" + s.quantity + "|\"" + s.note + "\"|\"" + s.author + "\"|\"" + s.title + "\"|\"" + s.subtitle + "\"|\"" + s.publisher + "\"|\"" + s.description + "\"|\"" + s.comments
                            + "\"|\"$" + String.Format("{0:0.00}", s.price) +"\"|\"" + s.subject + "\"|\"" + s.catalogue + "\"|\"" + s.initials + "\"|\"" + s.sales + "\"|\"" + s.bookID + "\"|\"" + s.dateEntered + "\"";

                        //The code below checks to see if there are any empty fields that are just quotations and removes the quotations
                        string[] splitToCheckForEmpty = lineToCheck.Split('|');
                        string lineToWrite = "";

                        for (int i = 0; i < splitToCheckForEmpty.Length; i++)
                        {
                            if (i != splitToCheckForEmpty.Length - 1)
                            {
                                if (splitToCheckForEmpty[i].Contains("\"\""))
                                    lineToWrite += "|";
                                else
                                    lineToWrite += splitToCheckForEmpty[i] + "|";
                            }
                            else
                            {
                                if (!splitToCheckForEmpty[i].Contains("\"\""))
                                    lineToWrite += splitToCheckForEmpty[i];
                            }
                        }

                        sw.WriteLine(lineToWrite);
                    }

                    sw.Close();
                }
            }

            /*******************  Create and store orders CSV ***********************/
            string ordersFileName = @"\Orders.txt";

            List<Order> allOrders = dbManager.getAllOrders();

            if (allOrders.Count > 0)
            {
                //Create the textfile and write the newstock information into it
                using (FileStream stream = File.Create(storagePath + ordersFileName))
                {
                    StreamWriter sw = new StreamWriter(stream);

                    foreach (Order o in allOrders)
                    {
                        string lineToCheck = o.orderID + "|\"" + o.firstName + "\"|\"" + o.lastName + "\"|\"" + o.institution + "\"|\"" + o.postcode + "\"|\"" + o.orderReference + "\"|\"" + o.progress +
                            "\"|\"$" + String.Format("{0:0.00}", o.freightCost) + "\"|" + o.invoiceNo + "|\"" + o.invoiceDate + "\"|\"" + o.comments + "\"|" + o.customerID;

                        //The code below checks to see if there are any empty fields that are just quotations and removes the quotations
                        string[] splitToCheckForEmpty = lineToCheck.Split('|');
                        string lineToWrite = "";

                        for (int i = 0; i < splitToCheckForEmpty.Length; i++)
                        {
                            if (i != splitToCheckForEmpty.Length - 1)
                            {
                                if (splitToCheckForEmpty[i].Contains("\"\""))
                                    lineToWrite += "|";
                                else
                                    lineToWrite += splitToCheckForEmpty[i] + "|";
                            }
                            else
                            {
                                if (!splitToCheckForEmpty[i].Contains("\"\""))
                                    lineToWrite += splitToCheckForEmpty[i];
                            }
                        }

                        sw.WriteLine(lineToWrite);
                    }

                    sw.Close();
                }
            }

            /*******************  Create and store orderedStock CSV ***********************/
            string orderedStockFileName = @"\OrderedStock.txt";

            List<OrderedStock> allOrderedStock = dbManager.getAllOrderedStock();

            if (allOrderedStock.Count > 0)
            {
                //Create the textfile and write the newstock information into it
                using (FileStream stream = File.Create(storagePath + orderedStockFileName))
                {
                    StreamWriter sw = new StreamWriter(stream);

                    foreach (OrderedStock os in allOrderedStock)
                    {
                        string lineToCheck = os.orderedStockID + "|" + os.orderID + "|" + os.stockID + "|" + os.quantity + "|\"" + os.author + "\"|\"" + os.title + "\"|\"$" + String.Format("{0:0.00}", os.price) + "\"|\""
                            + os.bookID + "\"|\"$" + String.Format("{0:0.00}", os.discount) + "\"";

                        //The code below checks to see if there are any empty fields that are just quotations and removes the quotations
                        string[] splitToCheckForEmpty = lineToCheck.Split('|');
                        string lineToWrite = "";

                        for (int i = 0; i < splitToCheckForEmpty.Length; i++)
                        {
                            if (i != splitToCheckForEmpty.Length - 1)
                            {
                                if (splitToCheckForEmpty[i].Contains("\"\""))
                                    lineToWrite += "|";
                                else
                                    lineToWrite += splitToCheckForEmpty[i] + "|";
                            }
                            else
                            {
                                if (!splitToCheckForEmpty[i].Contains("\"\""))
                                    lineToWrite += splitToCheckForEmpty[i];
                            }
                        }

                        sw.WriteLine(lineToWrite);
                    }

                    sw.Close();
                }
            }
        }

        public void writeStockExportToDeskPCFile(int numToExport)
        {
            string storagePath = getStockExportStorageFilePath();
            string fileName = @"\Stock" + getTimestamp(DateTime.Now) + ".txt";

            List<Stock> mostRecent = dbManager.getRecentStock(numToExport);

            using (FileStream stream = File.Create(storagePath + fileName))
            {
                StreamWriter sw = new StreamWriter(stream);
                foreach (Stock s in mostRecent)
                {
                    string lineToCheck = s.stockID + "|" + s.quantity + "|\"" + s.note + "\"|\"" + s.author + "\"|\"" + s.title + "\"|\"" + s.subtitle + "\"|\"" + s.publisher + "\"|\"" + s.description + "\"|\"" + s.comments
                           + "\"|\"" + s.price + "\"|\"" + s.subject + "\"|\"" + s.catalogue + "\"|\"" + s.initials + "\"|\"" + s.sales + "\"|\"" + s.bookID + "\"|\"" + s.dateEntered + "\"";

                    //The code below checks to see if there are any empty fields that are just quotations and removes the quotations
                    string[] splitToCheckForEmpty = lineToCheck.Split('|');
                    string lineToWrite = "";

                    for (int i = 0; i < splitToCheckForEmpty.Length; i++)
                    {
                        if (i != splitToCheckForEmpty.Length - 1)
                        {
                            if (splitToCheckForEmpty[i].Contains("\"\""))
                                lineToWrite += "|";
                            else
                                lineToWrite += splitToCheckForEmpty[i] + "|";
                        }
                        else
                        {
                            if (!splitToCheckForEmpty[i].Contains("\"\""))
                                lineToWrite += splitToCheckForEmpty[i];
                        }
                    }

                    sw.WriteLine(lineToWrite);
                }
                sw.Close();
            }
        }

        /*Precondition:
        Postcondition: Returns a timestamp of current year,month, day and time */
        private static string getTimestamp(DateTime value)
        {

            return value.ToString("yyyyMMddHHmmssfff");
        }
    }
}
