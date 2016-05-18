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
            //Check to make sure stock table exists
            if (checkForTable("Stock"))
            {
                string note = SyntaxHelper.escapeSingleQuotes(stock.note);
                string author = SyntaxHelper.escapeSingleQuotes(stock.author);
                string title = SyntaxHelper.escapeSingleQuotes(stock.title);
                string subtitle = SyntaxHelper.escapeSingleQuotes(stock.subtitle);
                string publisher = SyntaxHelper.escapeSingleQuotes(stock.publisher);
                string description = SyntaxHelper.escapeSingleQuotes(stock.description);
                string comments = SyntaxHelper.escapeSingleQuotes(stock.comments);
                string subject = SyntaxHelper.escapeSingleQuotes(stock.subject);
                string catalogue = SyntaxHelper.escapeSingleQuotes(stock.catalogue);
                string initials = SyntaxHelper.escapeSingleQuotes(stock.initials);
                string sales = SyntaxHelper.escapeSingleQuotes(stock.sales);
                string bookID = SyntaxHelper.escapeSingleQuotes(stock.bookID);
                string dateEntered = SyntaxHelper.escapeSingleQuotes(stock.dateEntered);

                //Apostrophies cause program to crash
                string updateQuery = "UPDATE Stock SET quantity =" + stock.quantity + ", note = '" + note + "', author = '" + author + "', title = '" + title +
                    "', subtitle = '" + subtitle + "', publisher = '" + publisher + "', description = '" + description + "', comments = '" + comments +
                    "', price = '" + stock.price + "', subject = '" + subject + "', catalogue = '" + catalogue + "', initials = '" + initials + "', sales = '" + sales +
                    "', bookID = '" + bookID + "', dateEntered = '" + dateEntered + "' WHERE stockID = " + stock.stockID;

                dbConnection.Open();
                SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, dbConnection);
                updateCommand.ExecuteNonQuery();
                dbConnection.Close();
            }
        }

        /*Precondition:
        Postcondition: Updates the passed in stocks details, new details already added onto the stock, use the ID to update*/
        public void updateNewStock(Stock stock)
        {
            //Check to make sure newstock table exists
            if (checkForTable("NewStock"))
            {
                string note = SyntaxHelper.escapeSingleQuotes(stock.note);
                string author = SyntaxHelper.escapeSingleQuotes(stock.author);
                string title = SyntaxHelper.escapeSingleQuotes(stock.title);
                string subtitle = SyntaxHelper.escapeSingleQuotes(stock.subtitle);
                string publisher = SyntaxHelper.escapeSingleQuotes(stock.publisher);
                string description = SyntaxHelper.escapeSingleQuotes(stock.description);
                string comments = SyntaxHelper.escapeSingleQuotes(stock.comments);
                string subject = SyntaxHelper.escapeSingleQuotes(stock.subject);
                string catalogue = SyntaxHelper.escapeSingleQuotes(stock.catalogue);
                string initials = SyntaxHelper.escapeSingleQuotes(stock.initials);
                string sales = SyntaxHelper.escapeSingleQuotes(stock.sales);
                string bookID = SyntaxHelper.escapeSingleQuotes(stock.bookID);
                string dateEntered = SyntaxHelper.escapeSingleQuotes(stock.dateEntered);

                //Apostrophies cause program to crash
                string updateQuery = "UPDATE NewStock SET quantity =" + stock.quantity + ", note = '" + note + "', author = '" + author + "', title = '" + title +
                    "', subtitle = '" + subtitle + "', publisher = '" + publisher + "', description = '" + description + "', comments = '" + comments +
                    "', price = '" + stock.price + "', subject = '" + subject + "', catalogue = '" + catalogue + "', initials = '" + initials + "', sales = '" + sales +
                    "', bookID = '" + bookID + "', dateEntered = '" + dateEntered + "' WHERE stockID = " + stock.stockID;

                dbConnection.Open();
                SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, dbConnection);
                updateCommand.ExecuteNonQuery();
                dbConnection.Close();
            }
        }

        /***************** Inserting ***************************/
        public void insertNewStock(Stock newStock)
        {
            //Check to make sure newstock table exists
            if (checkForTable("NewStock"))
            {
                //Open DB and start transcation - transaction hugely increases speed of insert
                dbConnection.Open();

                string note = SyntaxHelper.escapeSingleQuotes(newStock.note);
                string author = SyntaxHelper.escapeSingleQuotes(newStock.author);
                string title = SyntaxHelper.escapeSingleQuotes(newStock.title);
                string subtitle = SyntaxHelper.escapeSingleQuotes(newStock.subtitle);
                string publisher = SyntaxHelper.escapeSingleQuotes(newStock.publisher);
                string description = SyntaxHelper.escapeSingleQuotes(newStock.description);
                string comments = SyntaxHelper.escapeSingleQuotes(newStock.comments);
                string subject = SyntaxHelper.escapeSingleQuotes(newStock.subject);
                string catalogue = SyntaxHelper.escapeSingleQuotes(newStock.catalogue);
                string initials = SyntaxHelper.escapeSingleQuotes(newStock.initials);
                string sales = SyntaxHelper.escapeSingleQuotes(newStock.sales);
                string bookID = SyntaxHelper.escapeSingleQuotes(newStock.bookID);
                string dateEntered = SyntaxHelper.escapeSingleQuotes(newStock.dateEntered);

                //Build insert command
                string stockInsert = "INSERT INTO NewStock VALUES(null, '" + newStock.quantity + "', '" + note + "', '" + author + "', '" + title + "', '" + subtitle + "', '" + publisher
                    + "', '" + description + "', '" + comments + "', '" + newStock.price + "', '" + subject + "', '" + catalogue + "', '" + initials + "', '" + sales + "', '" + bookID +
                    "', '" + dateEntered + "')";


                SQLiteCommand insertCommand = new SQLiteCommand(stockInsert, dbConnection);
                insertCommand.ExecuteNonQuery();

                //Close connection
                dbConnection.Close();
            }
        }



        /*Precondition: 
         Postcondition: Loops through list of stock passed in, and inserts them into SQLite DB*/
        public void insertStock(List<Stock> allStock)
        {
            //Check to make sure stock table exists
            if (checkForTable("Stock"))
            {
                //Open DB and start transcation - transaction hugely increases speed of insert
                dbConnection.Open();
                SQLiteTransaction transaction = dbConnection.BeginTransaction();

                //Loop through all stock
                foreach (Stock s in allStock)
                {
                    string stockInsert = "";

                    string note = SyntaxHelper.escapeSingleQuotes(s.note);
                    string author = SyntaxHelper.escapeSingleQuotes(s.author);
                    string title = SyntaxHelper.escapeSingleQuotes(s.title);
                    string subtitle = SyntaxHelper.escapeSingleQuotes(s.subtitle);
                    string publisher = SyntaxHelper.escapeSingleQuotes(s.publisher);
                    string description = SyntaxHelper.escapeSingleQuotes(s.description);
                    string comments = SyntaxHelper.escapeSingleQuotes(s.comments);
                    string subject = SyntaxHelper.escapeSingleQuotes(s.subject);
                    string catalogue = SyntaxHelper.escapeSingleQuotes(s.catalogue);
                    string initials = SyntaxHelper.escapeSingleQuotes(s.initials);
                    string sales = SyntaxHelper.escapeSingleQuotes(s.sales);
                    string bookID = SyntaxHelper.escapeSingleQuotes(s.bookID);
                    string dateEntered = SyntaxHelper.escapeSingleQuotes(s.dateEntered);


                    if (s.stockID != -1)
                    {
                        //Build insert command
                        stockInsert = "INSERT INTO Stock VALUES(" + s.stockID + ", '" + s.quantity + "', '" + note + "', '" + author + "', '" + title + "', '" + subtitle + "', '" + publisher
                            + "', '" + description + "', '" + comments + "', '" + s.price + "', '" + subject + "', '" + catalogue + "', '" + initials + "', '" + sales + "', '" + bookID +
                            "', '" + dateEntered + "')";
                    }
                    else
                    {
                        //Build insert command
                        stockInsert = "INSERT INTO Stock VALUES(null, '" + s.quantity + "', '" + note + "', '" + author + "', '" + title + "', '" + subtitle + "', '" + publisher
                            + "', '" + description + "', '" + comments + "', '" + s.price + "', '" + subject + "', '" + catalogue + "', '" + initials + "', '" + sales + "', '" + bookID +
                            "', '" + dateEntered + "')";
                    }

                    SQLiteCommand insertCommand = new SQLiteCommand(stockInsert, dbConnection);
                    insertCommand.ExecuteNonQuery();
                }

                //Commit transaction and close connection
                transaction.Commit();
                dbConnection.Close();
            }
        }

        /***************** Searching ***************************/

        /*Precondition:
         Postcondition: Returns stock entry that matches the ID passed in*/
        public Stock searchStock(string bookID, bool searchAllStock)
        {
            Stock foundStock = null;

            //Check to make sure stock table exists
            if (checkForTable("Stock"))
            {
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
                        reader[7].ToString(), reader[8].ToString(), Convert.ToDouble(reader[9]), reader[10].ToString(), reader[11].ToString(), reader[12].ToString(), reader[13].ToString(), reader[14].ToString(), reader[15].ToString());
                }

                dbConnection.Close();
            }

            //Return results
            return foundStock;
        }
        /*Precondition: 
         Postcondition: Returns the stock that has the ID that was passed in */
        public Stock searchStock(int stockID)
        {
            Stock foundStock = null;

            //Check to see if stock table exists
            if (checkForTable("Stock"))
            {
                dbConnection.Open();

                //Execute SQL query
                string sql = "SELECT * FROM Stock WHERE stockID = " + stockID;

                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();

                //Loop over and store results
                while (reader.Read())
                {
                    foundStock = new Stock(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                        reader[7].ToString(), reader[8].ToString(), Convert.ToDouble(reader[9]), reader[10].ToString(), reader[11].ToString(), reader[12].ToString(), reader[13].ToString(), reader[14].ToString(), reader[15].ToString());
                }

                dbConnection.Close();
            }

            //Return results
            return foundStock;
        }



        /*Precondition:
         Postcondition: Returns stock entry that matches the ID passed in*/
        public Stock searchNewStock(string bookID, bool searchAllStock)
        {
            Stock foundStock = null;

            //Check to make sure newstock table exists
            if (checkForTable("NewStock"))
            {
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
                        reader[7].ToString(), reader[8].ToString(), Convert.ToDouble(reader[9]), reader[10].ToString(), reader[11].ToString(), reader[12].ToString(), reader[13].ToString(), reader[14].ToString(), reader[15].ToString());
                }

                dbConnection.Close();
            }

            //Return results
            return foundStock;
        }

        /*Precondition:
         Postcondition: Returns a list of the stock from the database that match the parameters passed in */
        public List<Stock> searchStock(string author, string title, string subject, bool searchAllStock, bool exactPhrase)
        {
            //Create storage for stock that's found
            List<Stock> foundStock = new List<Stock>();

            //Check to see if stock table exists
            if (checkForTable("Stock"))
            {
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

                        if (exactPhrase)
                            searchQuery += " author = '" + splitAuthor[0] + "' AND author = '" + splitAuthor[1] + "'";
                        else
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
                                if (exactPhrase)
                                    searchQuery += " author = '" + s + "'";
                                else
                                    searchQuery += " author LIKE '%" + s + "%'";
                                first = false;
                            }
                            else
                            {
                                if (exactPhrase)
                                    searchQuery += " AND author = '" + s + "'";
                                else
                                    searchQuery += " AND author LIKE '%" + s + "%'";
                            }
                        }

                        //searchQuery += " author LIKE '%" + splitAuthor[0] + "%' AND author LIKE '%" + splitAuthor[1] + "%'";
                    }
                    else
                    {
                        if (exactPhrase)
                            searchQuery += " author = '" + author + "'";
                        else
                            searchQuery += " author LIKE '%" + author + "%'";
                    }

                    addAnds = true;
                }

                //Title included so add that to query
                if (title != null)
                {
                    if (!exactPhrase)
                    {
                        string[] splitTitle = title.Split(' ');

                        foreach (string s in splitTitle)
                        {
                            if (addAnds)
                            {
                                if (exactPhrase)
                                    searchQuery += " AND title = '" + s + "'";
                                else
                                    searchQuery += " AND title LIKE '%" + s + "%'";
                            }
                            else
                            {
                                if (exactPhrase)
                                    searchQuery += " title = '" + s + "'";
                                else
                                    searchQuery += " title LIKE '%" + s + "%'";
                                addAnds = true;
                            }
                        }
                    }
                    else
                    {
                        if (addAnds)
                        {
                            if (exactPhrase)
                                searchQuery += " AND title = '" + title + "'";
                            else
                                searchQuery += " AND title LIKE '%" + title + "%'";
                        }
                        else
                        {
                            if (exactPhrase)
                                searchQuery += " title = '" + title + "'";
                            else
                                searchQuery += " title LIKE '%" + title + "%'";
                            addAnds = true;
                        }
                    }
                }
                //Subject included so add that to query
                if (subject != null)
                {
                    if (addAnds)
                    {
                        searchQuery += " AND subject = '" + subject + "'";
                    }
                    else
                    {
                        searchQuery += " subject LIKE '%" + subject + "%'";
                    }
                }

                //Make search non-case sensitive
                searchQuery += " COLLATE NOCASE";

                if (!searchAllStock)
                    searchQuery += " AND quantity > 0";


                //Execute query
                SQLiteCommand command = new SQLiteCommand(searchQuery, dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();

                //Loop over and store results
                while (reader.Read())
                {
                    Stock currStock = new Stock(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                        reader[7].ToString(), reader[8].ToString(), Convert.ToDouble(reader[9]), reader[10].ToString(), reader[11].ToString(), reader[12].ToString(), reader[13].ToString(), reader[14].ToString(), reader[15].ToString());

                    foundStock.Add(currStock);
                }

                dbConnection.Close();
            }

            //Return results
            return foundStock;
        }

        /*Precondition:
         Postcondition: Returns true if the table name that was entered exists in the database */
        private bool checkForTable(string tableName)
        {
            bool tableExists = false;

            dbConnection.Open();

            string tableQuery = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='" + tableName + "'";
            SQLiteCommand command = new SQLiteCommand(tableQuery, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            int result = 0;

            while (reader.Read())
            {
                result = Convert.ToInt16(reader[0]);
            }

            dbConnection.Close();

            if (result == 1)
                tableExists = true;

            return tableExists;
        }

        /*Precondition:
         Postcondition: Returns a list of all of stock in the newstock table */
        public List<Stock> getAllNewStock()
        {
            List<Stock> allStockInStock = new List<Stock>();

            if (checkForTable("NewStock"))
            {
                dbConnection.Open();

                string sql = "SELECT * FROM NewStock";
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();

                //Loop over and store results
                while (reader.Read())
                {
                    Stock nextStock = new Stock(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                        reader[7].ToString(), reader[8].ToString(), Convert.ToDouble(reader[9]), reader[10].ToString(), reader[11].ToString(), reader[12].ToString(), reader[13].ToString(), reader[14].ToString(), reader[15].ToString());

                    allStockInStock.Add(nextStock);
                }

                dbConnection.Close();
            }

            return allStockInStock;
        }

        /*Precondition:
         Postcondition: Returns a list of all of the stock that has a quantity greater than 0 */
        public List<Stock> getAllStockInStock()
        {
            List<Stock> allStockInStock = new List<Stock>();

            if (checkForTable("Stock"))
            {
                dbConnection.Open();

                string sql = "SELECT * FROM Stock WHERE quantity > 0";
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();

                //Loop over and store results
                while (reader.Read())
                {
                    Stock nextStock = new Stock(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                        reader[7].ToString(), reader[8].ToString(), Convert.ToDouble(reader[9]), reader[10].ToString(), reader[11].ToString(), reader[12].ToString(), reader[13].ToString(), reader[14].ToString(), reader[15].ToString());

                    allStockInStock.Add(nextStock);
                }

                dbConnection.Close();
            }

            return allStockInStock;
        }


        /*Precondition:
         Postcondition: Returns a list of the last 5 stock entered into the database */
        public List<Stock> getLastFiveStockEntries()
        {
            List<Stock> lastFive = new List<Stock>();

            if (checkForTable("Stock"))
            {
                string searchQuery = "SELECT * FROM Stock LIMIT 5 OFFSET (SELECT COUNT(*) FROM Stock)-5;";

                dbConnection.Open();

                //Execute query
                SQLiteCommand command = new SQLiteCommand(searchQuery, dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();

                //Loop over and store results
                while (reader.Read())
                {
                    Stock currStock = new Stock(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                        reader[7].ToString(), reader[8].ToString(), Convert.ToDouble(reader[9]), reader[10].ToString(), reader[11].ToString(), reader[12].ToString(), reader[13].ToString(), reader[14].ToString(), reader[15].ToString());

                    lastFive.Add(currStock);
                }

                dbConnection.Close();
            }

            return lastFive;
        }

        public void deleteStockFromIDForward(int id)
        {
            //Check to make sure stock table exists
            if (checkForTable("Stock"))
            {
                dbConnection.Open();

                string deleteQuery = "DELETE from Stock WHERE stockID >= " + id;

                SQLiteCommand deleteCommand = new SQLiteCommand(deleteQuery, dbConnection);
                deleteCommand.ExecuteNonQuery();

                dbConnection.Close();
            }
        }

        /*Precondition: 
         Postcondition: Returns the last stock that was entered into the database */
        public Stock getLastStock()
        {
            Stock lastStock = null;

            //Check to make sure orders table exists
            if (checkForTable("Stock"))
            {
                dbConnection.Open();
                int lastIDValue = 0;

                //Search for the ID of the last stock entered
                string sql = "SELECT MAX(stockID) FROM Stock";
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();

                //Loop over and store results
                while (reader.Read())
                {
                    lastIDValue = Convert.ToInt32(reader[0]);
                }

                //Select the last stock entry from the database
                string getLastStock = "SELECT * FROM Stock WHERE stockID = " + lastIDValue;
                SQLiteCommand getLastStockCommand = new SQLiteCommand(getLastStock, dbConnection);
                SQLiteDataReader getLastStockReader = getLastStockCommand.ExecuteReader();

                //Loop over and store results
                while (getLastStockReader.Read())
                {
                    lastStock = new Stock(Convert.ToInt32(getLastStockReader[0]), Convert.ToInt32(getLastStockReader[1]), getLastStockReader[2].ToString(), getLastStockReader[3].ToString(), getLastStockReader[4].ToString(), getLastStockReader[5].ToString(), getLastStockReader[6].ToString(),
                        getLastStockReader[7].ToString(), getLastStockReader[8].ToString(), Convert.ToDouble(getLastStockReader[9]), getLastStockReader[10].ToString(), getLastStockReader[11].ToString(), getLastStockReader[12].ToString(), getLastStockReader[13].ToString(), getLastStockReader[14].ToString(), getLastStockReader[15].ToString());
                }
                dbConnection.Close();
            }

            return lastStock;
        }
    }
}
