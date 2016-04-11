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

        public FileManager()
        {
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

         /*Precondition:
         Postcondition: Updates text file with new storage location */
        public void setStorageLocationFile(string newStorageFilePath)
        {
            using (FileStream fs = File.Create(STORAGE_FILE_NAME))
            {
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(newStorageFilePath);
                sw.Close();
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

    }
}
