using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Hard_To_Find
{
    class FileManager
    {
        const string STORAGE_FILE_NAME = "FileStorageLocation.txt";

        public FileManager()
        {
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

            Directory.CreateDirectory(invoiceFolderPath);
            Directory.CreateDirectory(mailingLabelsFolderPath);
            Directory.CreateDirectory(exportFilesFolderPath);

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

                Directory.Delete(oldStoragePath + @"\Invoices", true);
                Directory.Delete(oldStoragePath + @"\Mailing Labels", true);
                Directory.Delete(oldStoragePath + @"\Export Files", true);
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
    }
}
