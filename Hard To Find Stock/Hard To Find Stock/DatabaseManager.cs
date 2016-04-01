using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;


namespace Hard_To_Find_Stock
{
    class DatabaseManager
    {
        //Connection to Database file
        private SQLiteConnection dbConnection;

        //Constructor
        public DatabaseManager()
        {
            //Set up connection to DB file
            dbConnection = new SQLiteConnection("Data Source=HardToFindDB.sqlite;Version=3;");
        }

        /*Precondition:
         Postcondition: Creates the initial local DB file to work with in debug folder*/
        public void createDatabaseFile()
        {
            SQLiteConnection.CreateFile("HardToFindDB.sqlite");
        }

        /*Precondition:
         Postcondition: Drops the Stock table*/
        public void dropStockTable()
        {
            dbConnection.Open();

            string deleteStockTable = "DROP TABLE IF EXISTS Stock";
            SQLiteCommand deleteCommand = new SQLiteCommand(deleteStockTable, dbConnection);
            deleteCommand.ExecuteNonQuery();

            dbConnection.Close();
        }

        /*Precondition:
         Postcondition: Drops the Stock table*/
        public void dropNewStockTable()
        {
            dbConnection.Open();

            string deleteStockTable = "DROP TABLE IF EXISTS NewStock";
            SQLiteCommand deleteCommand = new SQLiteCommand(deleteStockTable, dbConnection);
            deleteCommand.ExecuteNonQuery();

            dbConnection.Close();
        }


        /*Precondition:
         Postcondition: Creates the Stock table*/
        public void createStockTable()
        {
            dbConnection.Open();

            string createStockTable = "CREATE TABLE IF NOT EXISTS Stock(stockID INTEGER PRIMARY KEY AUTOINCREMENT, quantity INTEGER NOT NULL, note VARCHAR(500), author VARCHAR(200), title VARCHAR(200), subtitle VARCHAR(300)," +
                "publisher VARCHAR(200), description VARCHAR(500), comments VARCHAR(400), price VARCHAR(12), subject VARCHAR(500), catalogue VARCHAR(200), initials VARCHAR(20), sales VARCHAR(150), bookID VARCHAR(100), dateEntered VARCHAR(100))";

            SQLiteCommand createStockTableCommand = new SQLiteCommand(createStockTable, dbConnection);
            createStockTableCommand.ExecuteNonQuery();

            dbConnection.Close();
        }

        public void createNewStockTable()
        {
            dbConnection.Open();

            string createStockTable = "CREATE TABLE IF NOT EXISTS NewStock(stockID INTEGER PRIMARY KEY AUTOINCREMENT, quantity INTEGER NOT NULL, note VARCHAR(500), author VARCHAR(200), title VARCHAR(200), subtitle VARCHAR(300)," +
                "publisher VARCHAR(200), description VARCHAR(500), comments VARCHAR(400), price VARCHAR(12), subject VARCHAR(500), catalogue VARCHAR(200), initials VARCHAR(20), sales VARCHAR(150), bookID VARCHAR(100), dateEntered VARCHAR(100))";

            SQLiteCommand createStockTableCommand = new SQLiteCommand(createStockTable, dbConnection);
            createStockTableCommand.ExecuteNonQuery();

            dbConnection.Close();
        }

        /***************** Updating ***************************/
        /*Precondition:
        Postcondition: Updates the passed in stocks details, new details already added onto the stock, use the ID to update*/
        public void updateStock(Stock stock)
        {
            //Apostrophies cause program to crash
            string updateQuery = "UPDATE Stock SET quantity =" + stock.quantity + ", note = '" + stock.note + "', author = '" + stock.author + "', title = '" + stock.title +
                "', subtitle = '" + stock.subtitle + "', publisher = '" + stock.publisher + "', description = '" + stock.description + "', comments = '" + stock.comments +
                "', price = '" + stock.price + "', subject = '" + stock.subject + "', catalogue = '" + stock.catalogue + "', initials = '" + stock.initials + "', sales = '" + stock.sales +
                "', bookID = '" + stock.bookID + "', dateEntered = '" + stock.dateEntered + "' WHERE stockID = " + stock.stockID;

            dbConnection.Open();
            SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, dbConnection);
            updateCommand.ExecuteNonQuery();
            dbConnection.Close();
        }

        /*Precondition:
        Postcondition: Updates the passed in stocks details, new details already added onto the stock, use the ID to update*/
        public void updateNewStock(Stock stock)
        {
            //Apostrophies cause program to crash
            string updateQuery = "UPDATE NewStock SET quantity =" + stock.quantity + ", note = '" + stock.note + "', author = '" + stock.author + "', title = '" + stock.title +
                "', subtitle = '" + stock.subtitle + "', publisher = '" + stock.publisher + "', description = '" + stock.description + "', comments = '" + stock.comments +
                "', price = '" + stock.price + "', subject = '" + stock.subject + "', catalogue = '" + stock.catalogue + "', initials = '" + stock.initials + "', sales = '" + stock.sales +
                "', bookID = '" + stock.bookID + "', dateEntered = '" + stock.dateEntered + "' WHERE stockID = " + stock.stockID;

            dbConnection.Open();
            SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, dbConnection);
            updateCommand.ExecuteNonQuery();
            dbConnection.Close();
        }

        /***************** Inserting ***************************/
       /*Precondition: 
         Postcondition: Inserts a single new stock into the SQLite database*/
        public void insertStock(Stock newStock)
        {
            //Open DB and start transcation - transaction hugely increases speed of insert
            dbConnection.Open();

            string stockInsert = "";

            //Build insert command
            stockInsert = "INSERT INTO Stock VALUES(null, '" + newStock.quantity + "', '" + newStock.note + "', '" + newStock.author + "', '" + newStock.title + "', '" + newStock.subtitle + "', '" + newStock.publisher
                + "', '" + newStock.description + "', '" + newStock.comments + "', '" + newStock.price + "', '" + newStock.subject + "', '" + newStock.catalogue + "', '" + newStock.initials + "', '" + newStock.sales + "', '" + newStock.bookID +
                "', '" + newStock.dateEntered + "')";
                

            SQLiteCommand insertCommand = new SQLiteCommand(stockInsert, dbConnection);
            insertCommand.ExecuteNonQuery();


            //Build insert command
            stockInsert = "INSERT INTO NewStock VALUES(null, '" + newStock.quantity + "', '" + newStock.note + "', '" + newStock.author + "', '" + newStock.title + "', '" + newStock.subtitle + "', '" + newStock.publisher
                + "', '" + newStock.description + "', '" + newStock.comments + "', '" + newStock.price + "', '" + newStock.subject + "', '" + newStock.catalogue + "', '" + newStock.initials + "', '" + newStock.sales + "', '" + newStock.bookID +
                "', '" + newStock.dateEntered + "')";


            insertCommand = new SQLiteCommand(stockInsert, dbConnection);
            insertCommand.ExecuteNonQuery();

            //Close connection
            dbConnection.Close();
        }

        /*Precondition: 
         Postcondition: Loops through list of stock passed in, and inserts them into SQLite DB*/
        public void insertStock(List<Stock> allStock, ProgressBar progBar)
        {
            //Open DB and start transcation - transaction hugely increases speed of insert
            dbConnection.Open();
            SQLiteTransaction transaction = dbConnection.BeginTransaction();

            //Loop through all stock
            foreach (Stock s in allStock)
            {
                string stockInsert = "";

                //Build insert command. If stock has an ID insert it with that ID if not (new stock) and insert with a new ID using autoincrement from SQLite
                if (s.stockID == -1)
                {
                    stockInsert = "INSERT INTO Stock VALUES(null, '" + s.quantity + "', '" + s.note + "', '" + s.author + "', '" + s.title + "', '" + s.subtitle + "', '" + s.publisher
                        + "', '" + s.description + "', '" + s.comments + "', '" + s.price + "', '" + s.subject + "', '" + s.catalogue + "', '" + s.initials + "', '" + s.sales + "', '" + s.bookID +
                        "', '" + s.dateEntered + "')";
                }
                else
                {
                    stockInsert = "INSERT INTO Stock VALUES(" + s.stockID + ", '" + s.quantity + "', '" + s.note + "', '" + s.author + "', '" + s.title + "', '" + s.subtitle + "', '" + s.publisher
                        + "', '" + s.description + "', '" + s.comments + "', '" + s.price + "', '" + s.subject + "', '" + s.catalogue + "', '" + s.initials + "', '" + s.sales + "', '" + s.bookID +
                        "', '" + s.dateEntered + "')";
                }

                SQLiteCommand insertCommand = new SQLiteCommand(stockInsert, dbConnection);
                insertCommand.ExecuteNonQuery();

                //Update UI for user to see progress
                progBar.Increment(1);
            }

            //Commit transaction and close connection
            transaction.Commit();
            dbConnection.Close();
        }

        /***************** Searching ***************************/

        /*Precondition:
         Postcondition: Returns stock entry that matches the ID passed in*/
        public Stock searchStock(string bookID, bool searchAllStock)
        {
            Stock foundStock = null;

            dbConnection.Open();

            //Execute SQL query
            string sql = "SELECT * FROM Stock WHERE bookID = '" + bookID + "'";
            
            if (!searchAllStock)
                sql += " AND quantity > 0";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            //Loop over and store results
            while (reader.Read())
            {
                foundStock = new Stock(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                    reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10].ToString(), reader[11].ToString(), reader[12].ToString(), reader[13].ToString(), reader[14].ToString(), reader[15].ToString());
            }

            dbConnection.Close();

            //Return results
            return foundStock;
        }

        /*Precondition:
         Postcondition: Returns stock entry that matches the ID passed in*/
        public Stock searchNewStock(string bookID, bool searchAllStock)
        {
            Stock foundStock = null;

            dbConnection.Open();

            //Execute SQL query
            string sql = "SELECT * FROM NewStock WHERE bookID = '" + bookID + "'";

            if (!searchAllStock)
                sql += " AND quantity > 0";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            //Loop over and store results
            while (reader.Read())
            {
                foundStock = new Stock(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                    reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10].ToString(), reader[11].ToString(), reader[12].ToString(), reader[13].ToString(), reader[14].ToString(), reader[15].ToString());
            }

            dbConnection.Close();

            //Return results
            return foundStock;
        }

        /*Precondition:
         Postcondition: Returns a list of the stock from the database that match the parameters passed in */
        public List<Stock> searchStock(string author, string title, string subject, bool searchAllStock)
        {
            //Create storage for stock that's found
            List<Stock> foundStock = new List<Stock>();

            dbConnection.Open();

            //build up a query string based on the parameters passed in
            string searchQuery = "SELECT * FROM Stock WHERE";
            bool addAnds = false;

            //Author included so add that to query
            if (author != null)
            {
                if (author.Contains(','))
                {
                    string[] splitAuthor = author.Split(',');

                    if (splitAuthor[1][0] == ' ')
                        splitAuthor[1] = splitAuthor[1].Remove(0, 1);

                    searchQuery += " author LIKE '%" + splitAuthor[0] + "%' AND author LIKE '%" + splitAuthor[1] + "%'";
                }
                else if (author.Contains(' '))
                {
                    string[] splitAuthor = author.Split(' ');

                    bool first = true;
                    foreach (string s in splitAuthor)
                    {
                        if (first)
                        {
                            searchQuery += " author LIKE '%" + s + "%'";
                            first = false;
                        }
                        else
                            searchQuery += " AND author LIKE '%" + s + "%'";
                    }

                    //searchQuery += " author LIKE '%" + splitAuthor[0] + "%' AND author LIKE '%" + splitAuthor[1] + "%'";
                }
                else
                {
                    searchQuery += " author LIKE '%" + author + "%'";
                }

                addAnds = true;
            }

            //Title included so add that to query
            if (title != null)
            {
                if (addAnds)
                    searchQuery += " AND title LIKE '%" + title + "%'";
                else
                {
                    searchQuery += " title LIKE '%" + title + "%'";
                    addAnds = true;
                }
            }
            //Subject included so add that to query
            if (subject != null)
            {
                if (addAnds)
                    searchQuery += " AND subject LIKE '%" + subject + "%'";
                else
                    searchQuery += " subject LIKE '%" + subject + "%'";
            }

            if (!searchAllStock)
                searchQuery += " AND quantity > 0";

            //Execute query
            SQLiteCommand command = new SQLiteCommand(searchQuery, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            //Loop over and store results
            while (reader.Read())
            {
                Stock currStock = new Stock(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                    reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10].ToString(), reader[11].ToString(), reader[12].ToString(), reader[13].ToString(), reader[14].ToString(), reader[15].ToString());

                foundStock.Add(currStock);
            }

            dbConnection.Close();

            //Return results
            return foundStock;
        }

        public List<Stock> getAllNewStock()
        {
            List<Stock> allStockInStock = new List<Stock>();

            dbConnection.Open();

            string sql = "SELECT * FROM NewStock";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            //Loop over and store results
            while (reader.Read())
            {
                Stock nextStock = new Stock(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                    reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10].ToString(), reader[11].ToString(), reader[12].ToString(), reader[13].ToString(), reader[14].ToString(), reader[15].ToString());

                allStockInStock.Add(nextStock);
            }

            dbConnection.Close();

            return allStockInStock;
        }

        public List<Stock> getAllStockInStock()
        {
            List<Stock> allStockInStock = new List<Stock>();

            dbConnection.Open();

            string sql = "SELECT * FROM Stock WHERE quantity > 0";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            //Loop over and store results
            while (reader.Read())
            {
                Stock nextStock = new Stock(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                    reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10].ToString(), reader[11].ToString(), reader[12].ToString(), reader[13].ToString(), reader[14].ToString(), reader[15].ToString());

                allStockInStock.Add(nextStock);
            }

            dbConnection.Close();

            return allStockInStock;
        }
    }
}
