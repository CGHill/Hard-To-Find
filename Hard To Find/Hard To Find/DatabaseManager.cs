using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;


namespace Hard_To_Find
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
         Postcondition: Drops the Customer table*/
        public void dropCustomerTable()
        {
            dbConnection.Open();

            string deleteCustomersTable = "DROP TABLE IF EXISTS Customer";
            SQLiteCommand deleteCustomersCommand = new SQLiteCommand(deleteCustomersTable, dbConnection);
            deleteCustomersCommand.ExecuteNonQuery();

            dbConnection.Close();
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
         Postcondition: Drops the Orders table*/
        public void dropOrdersTable()
        {
            dbConnection.Open();

            string deleteOrdersTable = "DROP TABLE IF EXISTS Orders";
            SQLiteCommand deleteOrdersCommand = new SQLiteCommand(deleteOrdersTable, dbConnection);
            deleteOrdersCommand.ExecuteNonQuery();

            dbConnection.Close();
        }

        public void dropOrderedStockTable()
        {
            dbConnection.Open();

            string deleteOrdersTable = "DROP TABLE IF EXISTS OrderedStock";
            SQLiteCommand deleteOrdersCommand = new SQLiteCommand(deleteOrdersTable, dbConnection);
            deleteOrdersCommand.ExecuteNonQuery();

            dbConnection.Close();
        }

        /*Precondition:
         Postcondition: Creates the Customers table*/
        public void createCustomerTable()
        {
            dbConnection.Open();

            string createCustomerTable = "CREATE TABLE IF NOT EXISTS Customer(customerID INTEGER PRIMARY KEY AUTOINCREMENT, firstName VARCHAR(100), lastName VARCHAR(100), institution VARCHAR(100)," +
                "address1 VARCHAR(200), address2 VARCHAR(200), address3 VARCHAR(200), country VARCHAR(100), postcode VARCHAR(50), email VARCHAR(100), comments VARCHAR(100), sales VARCHAR(100), payment VARCHAR(100))";

            SQLiteCommand createCustomerTableCommand = new SQLiteCommand(createCustomerTable, dbConnection);
            createCustomerTableCommand.ExecuteNonQuery();

            dbConnection.Close();
        }

        /*Precondition:
         Postcondition: Creates the Stock table*/
        public void createStockTable()
        {
            dbConnection.Open();

            string createStockTable = "CREATE TABLE IF NOT EXISTS Stock(stockID INTEGER PRIMARY KEY AUTOINCREMENT, quantity INTEGER NOT NULL, note VARCHAR(500), author VARCHAR(200), title VARCHAR(200), subtitle VARCHAR(300)," +
                "publisher VARCHAR(200), description VARCHAR(500), comments VARCHAR(400), price VARCHAR(12), subject VARCHAR(500), catalogue VARCHAR(200), sales VARCHAR(150), bookID VARCHAR(100), dateEntered VARCHAR(100))";

            SQLiteCommand createStockTableCommand = new SQLiteCommand(createStockTable, dbConnection);
            createStockTableCommand.ExecuteNonQuery();

            dbConnection.Close();
        }

        /*Precondition:
         Postcondition: Creates the Orders table*/
        public void createOrdersTable()
        {
            dbConnection.Open();

            string createOrdersTable = "CREATE TABLE IF NOT EXISTS Orders(orderID INTEGER PRIMARY KEY AUTOINCREMENT, customerFirstName VARCHAR(100), customerLastName VARCHAR(100), institution VARCHAR(100), postcode VARCHAR(50)," +
                " orderReference VARCHAR(40), progress VARCHAR(100), freightCost VARCHAR(10), invoice INTEGER, invoiceDate VARCHAR(100), comments VARCHAR(200), customerID INTEGER)";

            SQLiteCommand createOrdersTableCommand = new SQLiteCommand(createOrdersTable, dbConnection);
            createOrdersTableCommand.ExecuteNonQuery();

            dbConnection.Close();
        }

        /*Precondition:
         Postcondition: Creates the which keeps track of stock for the orders*/
        public void createOrderedStock()
        {
            dbConnection.Open();

            string createOrderedStockTable = "CREATE TABLE IF NOT EXISTS OrderedStock(orderedStockID INTEGER PRIMARY KEY AUTOINCREMENT, orderID INTEGER, stockID INTEGER, quantity INTEGER, author VARCHAR(200)," +
                " title VARCHAR(200), price VARCHAR(12), bookID VARCHAR(100), discount VARCHAR(12))";

            SQLiteCommand createOrderedStockTableCommand = new SQLiteCommand(createOrderedStockTable, dbConnection);
            createOrderedStockTableCommand.ExecuteNonQuery();

            dbConnection.Close();
        }


        //COLLATE NOCASE = search isn't case sensitive
        //string sql = "SELECT * FROM Customer WHERE firstName = 'david' COLLATE NOCASE";
        //string sql = "SELECT * FROM Customer WHERE customerFirstName LIKE 'da%'";

        /***************** Updating ***************************/

        /*Precondition:
         Postcondition: Updates the passed in customers details, new details already added onto the customer, use the ID to update*/
        public void updateCustomer(Customer customer)
        {
            string updateQuery = "UPDATE Customer SET firstName = '" + customer.firstName + "', lastName = '" + customer.lastName + "', institution = '" + customer.institution + "', address1 = '" + customer.address1 +
                "', address2 = '" + customer.address2 + "', address3 = '" + customer.address3 + "', country = '" + customer.country + "'" + ", postcode = '" + customer.postCode + 
                "', email = '" + customer.email + "', comments = '" + customer.comments + "', sales = '" + customer.sales + "', payment = '" + customer.payment + "' WHERE customerID = " + customer.custID;

            dbConnection.Open();
            SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, dbConnection);
            updateCommand.ExecuteNonQuery();
            dbConnection.Close();
        }

        /*Precondition:
        Postcondition: Updates the passed in stocks details, new details already added onto the stock, use the ID to update*/
        public void updateStock(Stock stock)
        {
            //Apostrophies cause program to crash
            string updateQuery = "UPDATE Stock SET quantity =" + stock.quantity + ", note = '" + stock.note + "', author = '" + stock.author + "', title = '" + stock.title +
                "', subtitle = '" + stock.subtitle + "', publisher = '" + stock.publisher + "', description = '" + stock.description + "', comments = '" + stock.comments +
                "', price = '" + stock.price + "', subject = '" + stock.subject + "', catalogue = '" + stock.catalogue + "', sales = '" + stock.sales + 
                "', bookID = '" + stock.bookID + "', dateEntered = '" + stock.dateEntered + "' WHERE stockID = " + stock.stockID;

            dbConnection.Open();
            SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, dbConnection);
            updateCommand.ExecuteNonQuery();
            dbConnection.Close();
        }


        /***************** Inserting ***************************/

        /*Precondition:
         Postcondition: Insert new customer into the database*/
        public void insertCusomter(Customer newCustomer)
        {
            //Open DB
            dbConnection.Open();

            //Build insert command
            string customerInsert = "INSERT INTO Customer VALUES(null, '" + newCustomer.firstName + "', '" + newCustomer.lastName + "', '" + newCustomer.institution + "', '" + newCustomer.address1 + "', '" + newCustomer.address2 + "', '" +
                newCustomer.address3 + "', '" + newCustomer.country + "', '" + newCustomer.postCode + "', '" +  newCustomer.email + "', '" + newCustomer.comments + "', '" + newCustomer.sales + "', '" + newCustomer.payment + "')";
           
            //Insert new customer
            SQLiteCommand insertCommand = new SQLiteCommand(customerInsert, dbConnection);
            insertCommand.ExecuteNonQuery();

            //Close DB
            dbConnection.Close();
        }

        /*Precondition: 
         Postcondition: Loops through list of customers passed in, and inserts them into SQLite DB*/
        public void insertCustomers(List<Customer> customers, ProgressBar progBar)
        {
            //Open DB and start transcation - transaction hugely increases speed of insert
            dbConnection.Open();
            SQLiteTransaction transaction = dbConnection.BeginTransaction();

            //Loop through all customers
            foreach (Customer c in customers)
            {
                string customerInsert = "";

                //Build insert command. If customer has an ID insert it with that ID if not (new customer) and insert with a new ID using autoincrement from SQLite
                if (c.custID == -1)
                {
                   customerInsert = "INSERT INTO Customer VALUES(null, '" + c.firstName + "', '" + c.lastName + "', '" + c.institution + "', '" + c.address1 +  "', '" + c.address2 + "', '" + 
                       c.address3 + "', '" + c.country + "', '" + c.postCode + "', '" + c.email + "', '" + c.comments + "', '" + c.sales + "', '" + c.payment + "')";
                }
                else
                {
                    customerInsert = "INSERT INTO Customer VALUES(" + c.custID + ", '" + c.firstName + "', '" + c.lastName + "', '" + c.institution + "', '" + c.address1 + "', '" + c.address2 + "', '" + c.address3 + 
                        "', '" + c.country + "', '" + c.postCode + "', '" + c.email + "', '" + c.comments + "', '" + c.sales + "', '" + c.payment + "')";
                }

                SQLiteCommand insertCommand = new SQLiteCommand(customerInsert, dbConnection);
                insertCommand.ExecuteNonQuery();

                //Update UI for user to see progress
                progBar.Increment(1);
            }

            //Commit transaction and close connection
            transaction.Commit();
            dbConnection.Close();
        }

        /*Precondition: 
         Postcondition: Inserts a single new stock into the SQLite database*/
        public void insertStock(Stock newStock)
        {
            //Open DB and start transcation - transaction hugely increases speed of insert
            dbConnection.Open();

            string stockInsert = "";

            //Build insert command
            stockInsert = "INSERT INTO Stock VALUES(null, '" + newStock.quantity + "', '" + newStock.note + "', '" + newStock.author + "', '" + newStock.title + "', '" + newStock.subtitle + "', '" + newStock.publisher
                + "', '" + newStock.description + "', '" + newStock.comments + "', '" + newStock.price + "', '" + newStock.subject + "', '" + newStock.catalogue + "', '" + newStock.sales + "', '" + newStock.bookID +
                "', '" + newStock.dateEntered + "')";
                

            SQLiteCommand insertCommand = new SQLiteCommand(stockInsert, dbConnection);
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
                        + "', '" + s.description + "', '" + s.comments + "', '" + s.price + "', '" + s.subject + "', '" + s.catalogue + "', '" + s.sales + "', '" + s.bookID +
                        "', '" + s.dateEntered + "')";
                }
                else
                {
                    stockInsert = "INSERT INTO Stock VALUES(" + s.stockID + ", '" + s.quantity + "', '" + s.note + "', '" + s.author + "', '" + s.title + "', '" + s.subtitle + "', '" + s.publisher
                        + "', '" + s.description + "', '" + s.comments + "', '" + s.price + "', '" + s.subject + "', '" + s.catalogue + "', '" + s.sales + "', '" + s.bookID +
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

        /*Precondition: 
         Postcondition: Loops through list of stock passed in, and inserts them into SQLite DB*/
        public void insertOrders(List<Order> allOrders, ProgressBar progBar)
        {
            //Open DB and start transcation - transaction hugely increases speed of insert
            dbConnection.Open();
            SQLiteTransaction transaction = dbConnection.BeginTransaction();

            //Loop through all stock
            foreach (Order o in allOrders)
            {
                string orderInsert = "";

                //Build insert command. If order has an ID insert it with that ID if not (new order) and insert with a new ID using autoincrement from SQLite
                if (o.orderID == -1)
                {
                    orderInsert = "INSERT INTO Orders VALUES(null, '" + o.customerFirstName + "', '" + o.customerLastName + "', '" + o.institution + "', '" + o.postcode + "', '" + o.orderReference + "', '" + 
                        o.progress + "', '" + o.freightCost + "', '" + o.invoiceNo + "', '" + o.invoiceDate + "', '" +  o.comments + "', '" + o.customerID + "')";
                }
                else
                {
                    orderInsert = "INSERT INTO Orders VALUES(" + o.orderID + ", '" + o.customerFirstName + "', '" + o.customerLastName + "', '" + o.institution + "', '" + o.postcode + "', '" + o.orderReference +  "', '" + 
                        o.progress + "', '" + o.freightCost + "', '" + o.invoiceNo.ToString() + "', '" + o.invoiceDate + "', '" + o.comments + "', '" + o.customerID + "')";
                }

                SQLiteCommand insertCommand = new SQLiteCommand(orderInsert, dbConnection);
                insertCommand.ExecuteNonQuery();

                //Update UI for user to see progress
                progBar.Increment(1);
            }

            //Commit transaction and close connection
            transaction.Commit();
            dbConnection.Close();
        }

        /*Precondition: 
         Postcondition: Loops through list of stock passed in, and inserts them into SQLite DB*/
        public void insertOrder(Order newOrder)
        {
            //Open DB
            dbConnection.Open();

            
            string orderInsert = "";

            //Build insert command
            orderInsert = "INSERT INTO Orders VALUES(null, '" + newOrder.customerFirstName + "', '" + newOrder.customerLastName + "', '" + newOrder.institution + "', '" + newOrder.postcode + "', '" + 
                newOrder.orderReference + "', '" + newOrder.progress + "', '" + newOrder.freightCost + "', '" + newOrder.invoiceNo + "', '" + newOrder.invoiceDate + "', '" + newOrder.comments + "', '" + 
                newOrder.customerID + "')";
                
            SQLiteCommand insertCommand = new SQLiteCommand(orderInsert, dbConnection);
            insertCommand.ExecuteNonQuery();
            
            dbConnection.Close();
        }

        /*Precondition:
         Postcondition: Loops through all of the OrderedStock and inserts them into SQLite DB, updates user with progress*/
        public void insertOrderedStock(List<OrderedStock> allOrderedStock, ProgressBar progBar)
        {
            //Open DB and start transcation - transaction hugely increases speed of insert
            dbConnection.Open();
            SQLiteTransaction transaction = dbConnection.BeginTransaction();

            //Loop through all orderedStock
            foreach (OrderedStock o in allOrderedStock)
            {
                string orderedStockInsert = "";

                //Build insert command. If OrderedStock has an ID insert it with that ID if not (new orderedSock) and insert with a new ID using autoincrement from SQLite
                if (o.orderedStockID == -1)
                {
                    orderedStockInsert = "INSERT INTO orderedStock VALUES(null, " + o.orderID + ", " + o.stockID + ", " + o.quantity + ", '" + o.author + "', '" + o.title + "', '" +
                        o.price + "', '" + o.bookID + "', '" + o.discount + "')";
                }
                else
                {
                    orderedStockInsert = "INSERT INTO orderedStock VALUES(" + o.orderedStockID + ", " + o.orderID + ", " + o.stockID + ", " + o.quantity + ", '" + o.author + "', '" + o.title + "', '" +
                        o.price + "', '" + o.bookID + "', '" + o.discount + "')";
                }

                SQLiteCommand insertCommand = new SQLiteCommand(orderedStockInsert, dbConnection);
                insertCommand.ExecuteNonQuery();

                //Update UI for user to see progress
                progBar.Increment(1);
            }

            //Commit transaction and close connection
            transaction.Commit();
            dbConnection.Close();
        }


        /*Precondition:
         Postcondition: Loops through OrderedStock and inserts them into SQLite DB, doesn't update progress*/
        public void insertOrderedStock(List<OrderedStock> newOrderedStock)
        {
            //Open DB and start transcation - transaction hugely increases speed of insert
            dbConnection.Open();
            SQLiteTransaction transaction = dbConnection.BeginTransaction();

            //Loop through all stock
            foreach (OrderedStock o in newOrderedStock)
            {
                string orderedStockInsert = "";

                //Build insert command
                orderedStockInsert = "INSERT INTO orderedStock VALUES(null, " + o.orderID + ", " + o.stockID + ", " + o.quantity + ", '" + o.author + "', '" + o.title + "', '" +
                    o.price + "', '" + o.bookID + "', '" + o.discount + "')";
                
                SQLiteCommand insertCommand = new SQLiteCommand(orderedStockInsert, dbConnection);
                insertCommand.ExecuteNonQuery();
            }

            //Commit transaction and close connection
            transaction.Commit();
            dbConnection.Close();
        }

        /***************** Searching ***************************/

        /*Precondition:
         Postcondition: Returns the customer of the passed in ID*/
        public Customer searchCustomers(int custID)
        {
            Customer foundCustomer = null;

            dbConnection.Open();

            //SQL query and command
            string sql = "SELECT * FROM Customer WHERE customerID = " + custID;
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            //Loop over and store results
            while (reader.Read())
            {
                foundCustomer = new Customer(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                    reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10].ToString(), reader[11].ToString(), reader[12].ToString());
            }

            dbConnection.Close();

            //Return results
            return foundCustomer;
        }

        /*Precondition:
         Postcondition: Returns a list of customers from the database whose names are similar to or matching the names passed in */
        public List<Customer> searchCustomers(string firstName, string lastName)
        {
            List<Customer> foundCustomers = new List<Customer>();

            dbConnection.Open();

            //Build up query string depending on what names were passed in
            string searchQuery = "SELECT * FROM Customer WHERE";

            //If a firstname was passed in, include it in the query
            if (firstName != null)
            {
                searchQuery += " firstName LIKE '%" + firstName + "%'";

                //First name & last name passed in, so included in the query
                if(lastName != null)
                    searchQuery += " AND lastName LIKE '%" + lastName + "%'";
            }
            else if(lastName != null) //Last name only passed in, so only search on last name
                searchQuery += " lastName LIKE '%" + lastName + "%'";

            //Execute query
            SQLiteCommand command = new SQLiteCommand(searchQuery, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            //Loop over and store results
            while (reader.Read())
            {
                Customer foundCustomer = new Customer(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                    reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10].ToString(), reader[11].ToString(), reader[12].ToString());

                foundCustomers.Add(foundCustomer);
            }

            dbConnection.Close();

            //Return results
            return foundCustomers;
        }

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
                    reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10].ToString(), reader[11].ToString(), reader[12].ToString(), reader[13].ToString(), reader[14].ToString());
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
                    reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10].ToString(), reader[11].ToString(), reader[12].ToString(), reader[13].ToString(), reader[14].ToString());

                foundStock.Add(currStock);
            }

            dbConnection.Close();

            //Return results
            return foundStock;
        }

        /*Precondition:
         Postcondition: Returns an Order that matches the orderID passed in*/
        public Order searchOrders(int orderID)
        {
            Order foundOrder = null;

            dbConnection.Open();

            //Execute SQL query
            string sql = "SELECT * FROM Orders WHERE orderID = " + orderID;
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            //Loop over and store results
            while (reader.Read())
            {
                foundOrder = new Order(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                    reader[7].ToString(), Convert.ToInt32(reader[8]), reader[9].ToString(), reader[10].ToString(), Convert.ToInt32(reader[11]));
            }

            dbConnection.Close();

            //Return results
            return foundOrder;
        }

        /*Precondition:
         Postcondition: Returns a list of OrderedStock that contains the OrderID passed in*/
        public List<OrderedStock> searchOrderedStock(int orderID)
        {
            List<OrderedStock> foundOrderedStock = new List<OrderedStock>();

            dbConnection.Open();

            //Execute SQL query
            string sql = "SELECT * FROM OrderedStock WHERE orderID = " + orderID;
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            //Loop over and store results
            while (reader.Read())
            {
                OrderedStock newOrderedStock = new OrderedStock(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), Convert.ToInt32(reader[2]), Convert.ToInt32(reader[3]), reader[4].ToString(), 
                    reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString());
                foundOrderedStock.Add(newOrderedStock);
            }

            dbConnection.Close();

            //Return results
            return foundOrderedStock;
        }

        public List<Order> searchCustomersOrders(int custID)
        {
            List<Order> foundOrders = new List<Order>();

            dbConnection.Open();

            //Execute SQL query
            string sql = "SELECT * FROM Orders WHERE customerID = " + custID;
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            //Loop over and store results
            while (reader.Read())
            {
                Order foundOrder = new Order(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                    reader[7].ToString(), Convert.ToInt32(reader[8]), reader[9].ToString(), reader[10].ToString(), Convert.ToInt32(reader[11]));

                foundOrders.Add(foundOrder);
            }

            dbConnection.Close();

            //Return results
            return foundOrders;
        }

        /*Precondition:
         Postcondition: Returns the ID of the next Order to be stored*/
        public int getNextOrderID()
        {
            dbConnection.Open();
            int nextIDValue = 0;

            //Execute SQL query
            string sql = "SELECT MAX(orderID) FROM Orders";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            //Loop over and store results
            while (reader.Read())
            {
                nextIDValue = Convert.ToInt32(reader[0]);
            }

            nextIDValue++;
            dbConnection.Close();

            //Return results
            return nextIDValue;
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
                    reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10].ToString(), reader[11].ToString(), reader[12].ToString(), reader[13].ToString(), reader[14].ToString());

                allStockInStock.Add(nextStock);
            }

            dbConnection.Close();

            return allStockInStock;
        }
    }
}
