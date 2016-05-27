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

        /*Precondition:
         Postcondition: Drops the orderedstock table if it exists */
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
                "publisher VARCHAR(200), description VARCHAR(500), comments VARCHAR(400), price REAL, subject VARCHAR(500), catalogue VARCHAR(200), initials VARCHAR(20), sales VARCHAR(150), bookID VARCHAR(100), dateEntered VARCHAR(100))";

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
                " orderReference VARCHAR(40), progress VARCHAR(100), freightCost REAL, invoice INTEGER, invoiceDate DATETIME, comments VARCHAR(200), customerID INTEGER)";

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
                " title VARCHAR(200), price REAL, bookID VARCHAR(100), discount REAL)";

            SQLiteCommand createOrderedStockTableCommand = new SQLiteCommand(createOrderedStockTable, dbConnection);
            createOrderedStockTableCommand.ExecuteNonQuery();

            dbConnection.Close();
        }

        /**********  Random useful code snippits  *********/
        //COLLATE NOCASE = search isn't case sensitive
        //string sql = "SELECT * FROM Customer WHERE firstName = 'david' COLLATE NOCASE";
        //string sql = "SELECT * FROM Customer WHERE customerFirstName LIKE 'da%'";



        /***************** Updating ***************************/

        /*Precondition:
         Postcondition: Updates the passed in customers details, new details already added onto the customer, use the ID to update*/
        public void updateCustomer(Customer customer)
        {
            if (checkForTable("Customer"))
            {
                string firstName = SyntaxHelper.escapeSingleQuotes(customer.firstName);
                string lastName = SyntaxHelper.escapeSingleQuotes(customer.lastName);
                string institution = SyntaxHelper.escapeSingleQuotes(customer.institution);
                string address1 = SyntaxHelper.escapeSingleQuotes(customer.address1);
                string address2 = SyntaxHelper.escapeSingleQuotes(customer.address2);
                string address3 = SyntaxHelper.escapeSingleQuotes(customer.address3);
                string country = SyntaxHelper.escapeSingleQuotes(customer.country);
                string postcode = SyntaxHelper.escapeSingleQuotes(customer.postCode);
                string email = SyntaxHelper.escapeSingleQuotes(customer.email);
                string comments = SyntaxHelper.escapeSingleQuotes(customer.comments);
                string sales = SyntaxHelper.escapeSingleQuotes(customer.sales);
                string payment = SyntaxHelper.escapeSingleQuotes(customer.payment);

                string updateQuery = "UPDATE Customer SET firstName = '" + firstName + "', lastName = '" + lastName + "', institution = '" + institution + "', address1 = '" + address1 +
                    "', address2 = '" + address2 + "', address3 = '" + address3 + "', country = '" + country + "'" + ", postcode = '" + postcode +
                    "', email = '" + email + "', comments = '" + comments + "', sales = '" + sales + "', payment = '" + payment + "' WHERE customerID = " + customer.custID;

                dbConnection.Open();
                SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, dbConnection);
                updateCommand.ExecuteNonQuery();
                dbConnection.Close();
            }
        }

        /*Precondition:
        Postcondition: Updates the passed in stocks details, new details already added onto the stock, use the ID to update*/
        public void updateStock(Stock stock)
        {
            if (checkForTable("Stock"))
            {
                int quantity = stock.quantity;
                string note = SyntaxHelper.escapeSingleQuotes(stock.note);
                string author = SyntaxHelper.escapeSingleQuotes(stock.author);
                string title = SyntaxHelper.escapeSingleQuotes(stock.title);
                string subtitle = SyntaxHelper.escapeSingleQuotes(stock.subtitle);
                string publisher = SyntaxHelper.escapeSingleQuotes(stock.publisher);
                string description = SyntaxHelper.escapeSingleQuotes(stock.description);
                string comments = SyntaxHelper.escapeSingleQuotes(stock.comments);
                double price = stock.price;
                string subject = SyntaxHelper.escapeSingleQuotes(stock.subject);
                string catalogue = SyntaxHelper.escapeSingleQuotes(stock.catalogue);
                string initials = SyntaxHelper.escapeSingleQuotes(stock.initials);
                string sales = SyntaxHelper.escapeSingleQuotes(stock.sales);
                string bookID = SyntaxHelper.escapeSingleQuotes(stock.bookID);
                string dateEntered = SyntaxHelper.escapeSingleQuotes(stock.dateEntered);
                int stockID = stock.stockID;

                //Apostrophies cause program to crash
                string updateQuery = "UPDATE Stock SET quantity =" + quantity + ", note = '" + note + "', author = '" + author + "', title = '" + title +
                    "', subtitle = '" + subtitle + "', publisher = '" + publisher + "', description = '" + description + "', comments = '" + comments +
                    "', price = '" + price + "', subject = '" + subject + "', catalogue = '" + catalogue + "', initials = '" + initials + "', sales = '" + sales +
                    "', bookID = '" + bookID + "', dateEntered = '" + dateEntered + "' WHERE stockID = " + stockID;

                dbConnection.Open();
                SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, dbConnection);
                updateCommand.ExecuteNonQuery();
                dbConnection.Close();
            }
        }

        /*Precondition:
        Postcondition: Updates the passed in order details, new details already added onto the order, use the ID to update*/
        public void updateOrder(Order order)
        {
            if (checkForTable("Orders"))
            {
                string firstName = SyntaxHelper.escapeSingleQuotes(order.firstName);
                string lastName = SyntaxHelper.escapeSingleQuotes(order.lastName);
                string institution = SyntaxHelper.escapeSingleQuotes(order.institution);
                string postcode = SyntaxHelper.escapeSingleQuotes(order.postcode);
                string orderReference = SyntaxHelper.escapeSingleQuotes(order.orderReference);
                string progress = SyntaxHelper.escapeSingleQuotes(order.progress);
                double freightCost = order.freightCost;
                int invoiceNo = order.invoiceNo;
                DateTime invoiceDate = order.invoiceDate;
                string comments = SyntaxHelper.escapeSingleQuotes(order.comments);
                int customerID = order.customerID;
                int orderID = order.orderID;

                //Apostrophies cause program to crash
                string updateQuery = "UPDATE Orders SET customerFirstName = '" + firstName + "', customerLastName = '" + lastName + "', institution = '" + institution +
                    "', postcode = '" + postcode + "', orderReference = '" + orderReference + "', progress = '" + progress + "', freightCost = '" + freightCost +
                    "', invoice = '" + invoiceNo + "', invoiceDate = '" + invoiceDate.ToString("yyyy-MM-dd HH:mm:ss") + "', comments = '" + comments + "', customerID = '" + customerID + "' WHERE orderID = " + orderID;

                dbConnection.Open();
                SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, dbConnection);
                updateCommand.ExecuteNonQuery();
                dbConnection.Close();
            }
        }

        /*Precondition:
        Postcondition: Updates the passed in orderedStock details, new details already added onto the orderedStock, use the ID to update*/
        public void updateOrderedStock(OrderedStock orderedStock)
        {
            if (checkForTable("OrderedStock"))
            {
                int orderID = orderedStock.orderID;
                int stockID = orderedStock.stockID;
                int quantity = orderedStock.quantity;
                string author = SyntaxHelper.escapeSingleQuotes(orderedStock.author);
                string title = SyntaxHelper.escapeSingleQuotes(orderedStock.author);
                double price = orderedStock.price;
                string bookID = SyntaxHelper.escapeSingleQuotes(orderedStock.bookID);
                double discount = orderedStock.discount;
                int orderedStockID = orderedStock.orderedStockID;

                //Apostrophies cause program to crash
                string updateQuery = "UPDATE OrderedStock SET orderID =" + orderID + ", stockID = " + stockID + ", quantity = " + quantity + ", author = '" + author + "', title = '" + title +
                    "', price = '" + price + "', bookID = '" + bookID + "', discount = '" + discount + "' WHERE orderedStockID = " + orderedStockID;

                dbConnection.Open();
                SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, dbConnection);
                updateCommand.ExecuteNonQuery();
                dbConnection.Close();
            }
        }


        /***************** Inserting ***************************/

        /*Precondition:
         Postcondition: Insert new customer into the database*/
        public void insertCustomer(Customer newCustomer)
        {
            //Check to see if customer table exists
            if (checkForTable("Customer"))
            {
                string firstName = SyntaxHelper.escapeSingleQuotes(newCustomer.firstName);
                string lastName = SyntaxHelper.escapeSingleQuotes(newCustomer.lastName);
                string institution = SyntaxHelper.escapeSingleQuotes(newCustomer.institution);
                string address1 = SyntaxHelper.escapeSingleQuotes(newCustomer.address1);
                string address2 = SyntaxHelper.escapeSingleQuotes(newCustomer.address2);
                string address3 = SyntaxHelper.escapeSingleQuotes(newCustomer.address3);
                string country = SyntaxHelper.escapeSingleQuotes(newCustomer.country);
                string postcode = SyntaxHelper.escapeSingleQuotes(newCustomer.postCode);
                string email = SyntaxHelper.escapeSingleQuotes(newCustomer.email);
                string comments = SyntaxHelper.escapeSingleQuotes(newCustomer.comments);
                string sales = SyntaxHelper.escapeSingleQuotes(newCustomer.sales);
                string payment = SyntaxHelper.escapeSingleQuotes(newCustomer.payment);

                //Open DB
                dbConnection.Open();

                //Build insert command
                string customerInsert = "INSERT INTO Customer VALUES(null, '" + firstName + "', '" + lastName + "', '" + institution + "', '" + address1 + "', '" + address2 + "', '" +
                    address3 + "', '" + country + "', '" + postcode + "', '" + email + "', '" + comments + "', '" + sales + "', '" + payment + "')";

                //Insert new customer
                SQLiteCommand insertCommand = new SQLiteCommand(customerInsert, dbConnection);
                insertCommand.ExecuteNonQuery();

                //Close DB
                dbConnection.Close();
            }
        }

        /*Precondition: 
         Postcondition: Loops through list of customers passed in, and inserts them into SQLite DB*/
        public void insertCustomers(List<Customer> customers, ProgressBar progBar)
        {
            //Check to see if customer table exists
            if (checkForTable("Customer"))
            {
                //Open DB and start transcation - transaction hugely increases speed of insert
                dbConnection.Open();
                SQLiteTransaction transaction = dbConnection.BeginTransaction();

                //Loop through all customers
                foreach (Customer c in customers)
                {
                    string firstName = SyntaxHelper.escapeSingleQuotes(c.firstName);
                    string lastName = SyntaxHelper.escapeSingleQuotes(c.lastName);
                    string institution = SyntaxHelper.escapeSingleQuotes(c.institution);
                    string address1 = SyntaxHelper.escapeSingleQuotes(c.address1);
                    string address2 = SyntaxHelper.escapeSingleQuotes(c.address2);
                    string address3 = SyntaxHelper.escapeSingleQuotes(c.address3);
                    string country = SyntaxHelper.escapeSingleQuotes(c.country);
                    string postcode = SyntaxHelper.escapeSingleQuotes(c.postCode);
                    string email = SyntaxHelper.escapeSingleQuotes(c.email);
                    string comments = SyntaxHelper.escapeSingleQuotes(c.comments);
                    string sales = SyntaxHelper.escapeSingleQuotes(c.sales);
                    string payment = SyntaxHelper.escapeSingleQuotes(c.payment);

                    string customerInsert = "";

                    //Build insert command. If customer has an ID insert it with that ID if not (new customer) and insert with a new ID using autoincrement from SQLite
                    if (c.custID == -1)
                    {
                        customerInsert = "INSERT INTO Customer VALUES(null, '" + firstName + "', '" + lastName + "', '" + institution + "', '" + address1 + "', '" + address2 + "', '" +
                            address3 + "', '" + country + "', '" + postcode + "', '" + email + "', '" + comments + "', '" + sales + "', '" + payment + "')";
                    }
                    else
                    {
                        customerInsert = "INSERT INTO Customer VALUES(" + c.custID + ", '" + firstName + "', '" + lastName + "', '" + institution + "', '" + address1 + "', '" + address2 + "', '" + address3 +
                            "', '" + country + "', '" + postcode + "', '" + email + "', '" + comments + "', '" + sales + "', '" + payment + "')";
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
        }

        /*Precondition: 
         Postcondition: Inserts a single new stock into the SQLite database*/
        public void insertStock(Stock newStock)
        {
            //Check to see if stock table exists
            if (checkForTable("Stock"))
            {
                int quantity = newStock.quantity;
                string note = SyntaxHelper.escapeSingleQuotes(newStock.note);
                string author = SyntaxHelper.escapeSingleQuotes(newStock.author);
                string title = SyntaxHelper.escapeSingleQuotes(newStock.title);
                string subtitle = SyntaxHelper.escapeSingleQuotes(newStock.subtitle);
                string publisher = SyntaxHelper.escapeSingleQuotes(newStock.publisher);
                string description = SyntaxHelper.escapeSingleQuotes(newStock.description);
                string comments = SyntaxHelper.escapeSingleQuotes(newStock.comments);
                double price = newStock.price;
                string subject = SyntaxHelper.escapeSingleQuotes(newStock.subject);
                string catalogue = SyntaxHelper.escapeSingleQuotes(newStock.catalogue);
                string initials = SyntaxHelper.escapeSingleQuotes(newStock.initials);
                string sales = SyntaxHelper.escapeSingleQuotes(newStock.sales);
                string bookID = SyntaxHelper.escapeSingleQuotes(newStock.bookID);
                string dateEntered = SyntaxHelper.escapeSingleQuotes(newStock.dateEntered);
                int stockID = newStock.stockID;

                //Open DB and start transcation - transaction hugely increases speed of insert
                dbConnection.Open();

                string stockInsert = "";

                //Build insert command
                stockInsert = "INSERT INTO Stock VALUES(null, '" + quantity + "', '" + note + "', '" + author + "', '" + title + "', '" + subtitle + "', '" + publisher
                    + "', '" + description + "', '" + comments + "', '" + price + "', '" + subject + "', '" + catalogue + "', '" + initials + "', '" + sales + "', '" + bookID +
                    "', '" + dateEntered + "')";


                SQLiteCommand insertCommand = new SQLiteCommand(stockInsert, dbConnection);
                insertCommand.ExecuteNonQuery();

                //Close connection
                dbConnection.Close();
            }
        }

        /*Precondition: 
         Postcondition: Loops through list of stock passed in, and inserts them into SQLite DB*/
        public void insertStock(List<Stock> allStock, ProgressBar progBar)
        {
            //Check to see if stock table exists
            if (checkForTable("Stock"))
            {
                //Open DB and start transcation - transaction hugely increases speed of insert
                dbConnection.Open();
                SQLiteTransaction transaction = dbConnection.BeginTransaction();

                //Loop through all stock
                foreach (Stock s in allStock)
                {
                    string stockInsert = "";

                    int quantity = s.quantity;
                    string note = SyntaxHelper.escapeSingleQuotes(s.note);
                    string author = SyntaxHelper.escapeSingleQuotes(s.author);
                    string title = SyntaxHelper.escapeSingleQuotes(s.title);
                    string subtitle = SyntaxHelper.escapeSingleQuotes(s.subtitle);
                    string publisher = SyntaxHelper.escapeSingleQuotes(s.publisher);
                    string description = SyntaxHelper.escapeSingleQuotes(s.description);
                    string comments = SyntaxHelper.escapeSingleQuotes(s.comments);
                    double price = s.price;
                    string subject = SyntaxHelper.escapeSingleQuotes(s.subject);
                    string catalogue = SyntaxHelper.escapeSingleQuotes(s.catalogue);
                    string initials = SyntaxHelper.escapeSingleQuotes(s.initials);
                    string sales = SyntaxHelper.escapeSingleQuotes(s.sales);
                    string bookID = SyntaxHelper.escapeSingleQuotes(s.bookID);
                    string dateEntered = SyntaxHelper.escapeSingleQuotes(s.dateEntered);
                    int stockID = s.stockID;

                    //Build insert command. If stock has an ID insert it with that ID if not (new stock) and insert with a new ID using autoincrement from SQLite
                    if (s.stockID == -1)
                    {
                        stockInsert = "INSERT INTO Stock VALUES(null, '" + quantity + "', '" + note + "', '" + author + "', '" + title + "', '" + subtitle + "', '" + publisher
                            + "', '" + description + "', '" + comments + "', '" + price + "', '" + subject + "', '" + catalogue + "', '" + initials + "', '" + sales + "', '" + bookID +
                            "', '" + dateEntered + "')";
                    }
                    else
                    {
                        stockInsert = "INSERT INTO Stock VALUES(" + stockID + ", '" + quantity + "', '" + note + "', '" + author + "', '" + title + "', '" + subtitle + "', '" + publisher
                            + "', '" + description + "', '" + comments + "', '" + price + "', '" + subject + "', '" + catalogue + "', '" + initials + "', '" + sales + "', '" + bookID +
                            "', '" + dateEntered + "')";
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
        }

        /*Precondition: 
         Postcondition: Loops through list of stock passed in, and inserts them into SQLite DB*/
        public void insertOrders(List<Order> allOrders, ProgressBar progBar)
        {
            //Check to see if orders table exists
            if (checkForTable("Orders"))
            {
                //Open DB and start transcation - transaction hugely increases speed of insert
                dbConnection.Open();
                SQLiteTransaction transaction = dbConnection.BeginTransaction();

                //Loop through all stock
                foreach (Order o in allOrders)
                {
                    string orderInsert = "";

                    string firstName = SyntaxHelper.escapeSingleQuotes(o.firstName);
                    string lastName = SyntaxHelper.escapeSingleQuotes(o.lastName);
                    string institution = SyntaxHelper.escapeSingleQuotes(o.institution);
                    string postcode = SyntaxHelper.escapeSingleQuotes(o.postcode);
                    string orderReference = SyntaxHelper.escapeSingleQuotes(o.orderReference);
                    string progress = SyntaxHelper.escapeSingleQuotes(o.progress);
                    double freightCost = o.freightCost;
                    int invoiceNo = o.invoiceNo;
                    DateTime invoiceDate = o.invoiceDate;
                    string comments = SyntaxHelper.escapeSingleQuotes(o.comments);
                    int customerID = o.customerID;
                    int orderID = o.orderID;

                    //Build insert command. If order has an ID insert it with that ID if not (new order) and insert with a new ID using autoincrement from SQLite
                    if (o.orderID == -1)
                    {
                        orderInsert = "INSERT INTO Orders VALUES(null, '" + firstName + "', '" + lastName + "', '" + institution + "', '" + postcode + "', '" + orderReference + "', '" +
                            progress + "', '" + freightCost + "', '" + invoiceNo + "', '" + invoiceDate.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + comments + "', '" + customerID + "')";
                    }
                    else
                    {
                        orderInsert = "INSERT INTO Orders VALUES(" + orderID + ", '" + firstName + "', '" + lastName + "', '" + institution + "', '" + postcode + "', '" + orderReference + "', '" +
                            progress + "', '" + freightCost + "', '" + invoiceNo + "', '" + invoiceDate.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + comments + "', '" + customerID + "')";
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
        }

        /*Precondition: 
         Postcondition: Loops through list of stock passed in, and inserts them into SQLite DB*/
        public void insertOrder(Order newOrder)
        {
            //Check to see if orders table exists
            if (checkForTable("Orders"))
            {
                string firstName = SyntaxHelper.escapeSingleQuotes(newOrder.firstName);
                string lastName = SyntaxHelper.escapeSingleQuotes(newOrder.lastName);
                string institution = SyntaxHelper.escapeSingleQuotes(newOrder.institution);
                string postcode = SyntaxHelper.escapeSingleQuotes(newOrder.postcode);
                string orderReference = SyntaxHelper.escapeSingleQuotes(newOrder.orderReference);
                string progress = SyntaxHelper.escapeSingleQuotes(newOrder.progress);
                double freightCost = newOrder.freightCost;
                int invoiceNo = newOrder.invoiceNo;
                DateTime invoiceDate = newOrder.invoiceDate;
                string comments = SyntaxHelper.escapeSingleQuotes(newOrder.comments);
                int customerID = newOrder.customerID;
                int orderID = newOrder.orderID;

                //Open DB
                dbConnection.Open();


                string orderInsert = "";

                //Build insert command
                orderInsert = "INSERT INTO Orders VALUES(null, '" + firstName + "', '" + lastName + "', '" + institution + "', '" + postcode + "', '" +
                    orderReference + "', '" + progress + "', '" + freightCost + "', '" + invoiceNo + "', '" + invoiceDate.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + comments + "', '" +
                    customerID + "')";

                SQLiteCommand insertCommand = new SQLiteCommand(orderInsert, dbConnection);
                insertCommand.ExecuteNonQuery();

                dbConnection.Close();
            }
        }

        /*Precondition:
         Postcondition: Loops through all of the OrderedStock and inserts them into SQLite DB, updates user with progress*/
        public void insertOrderedStock(List<OrderedStock> allOrderedStock, ProgressBar progBar)
        {
            //Check to see if orderedstock table exists
            if (checkForTable("OrderedStock"))
            {
                //Open DB and start transcation - transaction hugely increases speed of insert
                dbConnection.Open();
                SQLiteTransaction transaction = dbConnection.BeginTransaction();

                //Loop through all orderedStock
                foreach (OrderedStock o in allOrderedStock)
                {
                    string orderedStockInsert = "";

                    int orderID = o.orderID;
                    int stockID = o.stockID;
                    int quantity = o.quantity;
                    string author = SyntaxHelper.escapeSingleQuotes(o.author);
                    string title = SyntaxHelper.escapeSingleQuotes(o.author);
                    double price = o.price;
                    string bookID = SyntaxHelper.escapeSingleQuotes(o.bookID);
                    double discount = o.discount;
                    int orderedStockID = o.orderedStockID;

                    //Build insert command. If OrderedStock has an ID insert it with that ID if not (new orderedSock) and insert with a new ID using autoincrement from SQLite
                    if (o.orderedStockID == -1)
                    {
                        orderedStockInsert = "INSERT INTO OrderedStock VALUES(null, " + orderID + ", " + stockID + ", " + quantity + ", '" + author + "', '" + title + "', '" +
                            price + "', '" + bookID + "', '" + discount + "')";
                    }
                    else
                    {
                        orderedStockInsert = "INSERT INTO OrderedStock VALUES(" + orderedStockID + ", " + orderID + ", " + stockID + ", " + quantity + ", '" + author + "', '" + title + "', '" +
                            price + "', '" + bookID + "', '" + discount + "')";
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
        }


        /*Precondition:
         Postcondition: Loops through OrderedStock and inserts them into SQLite DB, doesn't update progress*/
        public void insertOrderedStock(List<OrderedStock> newOrderedStock)
        {
            //Check to see if orderedstock table exists
            if (checkForTable("OrderedStock"))
            {
                //Open DB and start transcation - transaction hugely increases speed of insert
                dbConnection.Open();
                SQLiteTransaction transaction = dbConnection.BeginTransaction();

                //Loop through all stock
                foreach (OrderedStock o in newOrderedStock)
                {
                    string orderedStockInsert = "";

                    int orderID = o.orderID;
                    int stockID = o.stockID;
                    int quantity = o.quantity;
                    string author = SyntaxHelper.escapeSingleQuotes(o.author);
                    string title = SyntaxHelper.escapeSingleQuotes(o.author);
                    double price = o.price;
                    string bookID = SyntaxHelper.escapeSingleQuotes(o.bookID);
                    double discount = o.discount;
                    int orderedStockID = o.orderedStockID;

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

        /***************** Searching ***************************/

        /*Precondition:
         Postcondition: Returns the customer of the passed in ID*/
        public Customer searchCustomers(int custID)
        {
            Customer foundCustomer = null;

            //Check to see if customer table exists
            if (checkForTable("Customer"))
            {
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
            }

            //Return results
            return foundCustomer;
        }

        /*Precondition:
         Postcondition: Returns a list of customers from the database whose names are similar to or matching the names passed in */
        public List<Customer> searchCustomers(string firstName, string lastName, string institution, string email, bool exactName)
        {
            List<Customer> foundCustomers = new List<Customer>();

            //Check to see if customer table exists
            if (checkForTable("Customer"))
            {
                dbConnection.Open();

                firstName = SyntaxHelper.escapeSingleQuotes(firstName);
                lastName = SyntaxHelper.escapeSingleQuotes(lastName);
                institution = SyntaxHelper.escapeSingleQuotes(institution);
                email = SyntaxHelper.escapeSingleQuotes(email);

                bool addAnds = false;

                //Build up query string depending on what names were passed in
                string searchQuery = "SELECT * FROM Customer WHERE";

                //If a firstname was passed in, include it in the query
                if (firstName != null)
                {
                    if (exactName)
                        searchQuery += " firstName = '" + firstName + "'";
                    else
                        searchQuery += " firstName LIKE '%" + firstName + "%'";

                    addAnds = true;
                }
                if (lastName != null)
                {
                    if (addAnds)
                    {
                        if (exactName)
                            searchQuery += " AND lastName = '" + lastName + "'";
                        else
                            searchQuery += " AND lastName LIKE '%" + lastName + "%'";
                    }
                    else
                    {
                        if (exactName)
                            searchQuery += " lastName = '" + lastName + "'";
                        else
                            searchQuery += " lastName LIKE '%" + lastName + "%'";
                    }

                    addAnds = true;
                }
                if (institution != null)
                {
                    if (addAnds)
                    {
                        if (exactName)
                            searchQuery += " AND institution = '" + institution + "'";
                        else
                            searchQuery += " AND institution LIKE '%" + institution + "%'";
                    }
                    else
                    {
                        if (exactName)
                            searchQuery += " institution = '" + institution + "'";
                        else
                            searchQuery += " institution LIKE '%" + institution + "%'";
                    }

                    addAnds = true;
                }
                if (email != null)
                {
                    if (addAnds)
                    {
                        if (exactName)
                            searchQuery += " AND email = '" + email + "'";
                        else
                            searchQuery += " AND email LIKE '%" + email + "%'";
                    }
                    else
                    {
                        if (exactName)
                            searchQuery += " email = '" + email + "'";
                        else
                            searchQuery += " email LIKE '%" + email + "%'";
                    }
                }

                //Make is so search isn't case sensitive
                searchQuery += " COLLATE NOCASE";

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
            }

            //Return results
            return foundCustomers;
        }

        /*Precondition:
         Postcondition: Returns stock entry that matches the ID passed in*/
        public Stock searchStock(string bookID, bool searchAllStock)
        {
            Stock foundStock = null;

            //Check to see if stock table exists
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
         Postcondition: Returns a list of the stock from the database that match the parameters passed in */
        public List<Stock> searchStock(string author, string title, string subject, bool searchAllStock, bool exactPhrase)
        {
            //Create storage for stock that's found
            List<Stock> foundStock = new List<Stock>();

            //Check to see if stock table exists
            if (checkForTable("Stock"))
            {
                author = SyntaxHelper.escapeSingleQuotes(author);
                title = SyntaxHelper.escapeSingleQuotes(title);

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
         Postcondition: Returns an Order that matches the orderID passed in*/
        public Order searchOrders(int orderID)
        {
            Order foundOrder = null;

            //Check to make sure orders table exists
            if (checkForTable("Orders"))
            {
                dbConnection.Open();

                //Execute SQL query
                string sql = "SELECT * FROM Orders WHERE orderID = " + orderID;
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();

                //Loop over and store results
                while (reader.Read())
                {
                    string date = reader[9].ToString();
                    string[] splitOnSpace = date.Split(' ');
                    string[] splitOnSlash = splitOnSpace[0].Split('/');

                    DateTime currDate = new DateTime(Convert.ToInt32(splitOnSlash[2]), Convert.ToInt32(splitOnSlash[1]), Convert.ToInt32(splitOnSlash[0]));

                    foundOrder = new Order(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                        Convert.ToDouble(reader[7]), Convert.ToInt32(reader[8]), currDate, reader[10].ToString(), Convert.ToInt32(reader[11]));
                }

                dbConnection.Close();
            }

            //Return results
            return foundOrder;
        }

        /*Precondition:
         Postcondition: Returns a list of OrderedStock that contains the OrderID passed in*/
        public List<OrderedStock> searchOrderedStock(int orderID)
        {
            List<OrderedStock> foundOrderedStock = new List<OrderedStock>();

            //Check to make sure orderedstock table exists
            if (checkForTable("OrderedStock"))
            {
                dbConnection.Open();

                //Execute SQL query
                string sql = "SELECT * FROM OrderedStock WHERE orderID = " + orderID;
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();

                //Loop over and store results
                while (reader.Read())
                {
                    OrderedStock newOrderedStock = new OrderedStock(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), Convert.ToInt32(reader[2]), Convert.ToInt32(reader[3]), reader[4].ToString(),
                        reader[5].ToString(), Convert.ToDouble(reader[6]), reader[7].ToString(), Convert.ToDouble(reader[8]));
                    foundOrderedStock.Add(newOrderedStock);
                }

                dbConnection.Close();
            }

            //Return results
            return foundOrderedStock;
        }

        /*Precondition:
         Postcondition: Returns list of orders that contains customerID that was passed */
        public List<Order> searchCustomersOrders(int custID)
        {
            List<Order> foundOrders = new List<Order>();

            //Check to make sure orders table exists
            if (checkForTable("Orders"))
            {
                dbConnection.Open();

                //Execute SQL query
                string sql = "SELECT * FROM Orders WHERE customerID = " + custID;
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();

                //Loop over and store results
                while (reader.Read())
                {
                    string date = reader[9].ToString();
                    string[] splitOnSpace = date.Split(' ');
                    string[] splitOnSlash = splitOnSpace[0].Split('/');

                    DateTime currDate = new DateTime(Convert.ToInt32(splitOnSlash[2]), Convert.ToInt32(splitOnSlash[1]), Convert.ToInt32(splitOnSlash[0]));

                    Order foundOrder = new Order(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                        Convert.ToDouble(reader[7]), Convert.ToInt32(reader[8]), currDate, reader[10].ToString(), Convert.ToInt32(reader[11]));

                    foundOrders.Add(foundOrder);
                }

                dbConnection.Close();
            }

            //Return results
            return foundOrders;
        }

        /*Precondition:
         Postcondition: Returns the ID of the next Order to be stored*/
        public int getNextOrderID()
        {
            //Check to make sure orders table exists
            if (checkForTable("Orders"))
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
            else
                return 0;
        }

        /*Precondition:
         Postcondition: Returns the ID of the next Order to be stored*/
        public int getNextCustomerID()
        {
            //Check to make sure customer table exists
            if (checkForTable("Customer"))
            {
                dbConnection.Open();
                int nextIDValue = 0;

                //Execute SQL query
                string sql = "SELECT MAX(customerID) FROM Customer";
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
            else
                return 0;
        }

        /*Precondition:
         Postcondition: Returns a list of all the stock that has a quantity greater than 0*/
        public List<Stock> getAllStockInStock()
        {
            List<Stock> allStockInStock = new List<Stock>();

            //Check to make sure stock table exists
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
         Postcondition: Deletes the OrderedStock from the database*/
        public void deleteOrderedStock(int orderedStockIDToDelete)
        {
            //Check to make sure ordered stock table exists
            if (checkForTable("OrderedStock"))
            {
                dbConnection.Open();

                string deleteQuery = "DELETE from OrderedStock WHERE orderedStockID = " + orderedStockIDToDelete;

                SQLiteCommand deleteCommand = new SQLiteCommand(deleteQuery, dbConnection);
                deleteCommand.ExecuteNonQuery();

                dbConnection.Close();
            }
        }

        /*Precondition:
         Postcondition: Returns a list of all of the customers */
        public List<Customer> getAllCustomers()
        {
            List<Customer> foundCustomers = new List<Customer>();

            //Check to make sure customer table exists
            if (checkForTable("Customer"))
            {
                dbConnection.Open();

                string searchQuery = "SELECT * FROM Customer";
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
            }

            //Return results
            return foundCustomers;
        }

        /*Precondition:
         Postcondition: Returns a list of all the stock */
        public List<Stock> getAllStock()
        {
            List<Stock> foundStock = new List<Stock>();

            //Check to make sure stock table exists
            if (checkForTable("Stock"))
            {
                string searchQuery = "SELECT * FROM Stock";

                dbConnection.Open();

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
         Postcondition: Returns a list of all the orders */
        public List<Order> getAllOrders()
        {
            List<Order> foundOrders = new List<Order>();

            //Check to make sure orders table exists
            if (checkForTable("Orders"))
            {
                dbConnection.Open();

                //Execute SQL query
                string sql = "SELECT * FROM Orders";
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();

                //Loop over and store results
                while (reader.Read())
                {
                    string date = reader[9].ToString();
                    string[] splitOnSpace = date.Split(' ');
                    string[] splitOnSlash = splitOnSpace[0].Split('/');

                    DateTime currDate = new DateTime(Convert.ToInt32(splitOnSlash[2]), Convert.ToInt32(splitOnSlash[1]), Convert.ToInt32(splitOnSlash[0]));

                    Order currOrder = new Order(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                        Convert.ToDouble(reader[7]), Convert.ToInt32(reader[8]), currDate, reader[10].ToString(), Convert.ToInt32(reader[11]));

                    foundOrders.Add(currOrder);
                }

                dbConnection.Close();
            }

            //Return results
            return foundOrders;
        }

        /*Precondition:
         Postcondition: Returns a list of all the ordered stock */
        public List<OrderedStock> getAllOrderedStock()
        {
            List<OrderedStock> foundOrderedStock = new List<OrderedStock>();

            //Check to make sure orderedstock table exists
            if (checkForTable("OrderedStock"))
            {
                dbConnection.Open();

                //Execute SQL query
                string sql = "SELECT * FROM OrderedStock";
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();

                //Loop over and store results
                while (reader.Read())
                {
                    OrderedStock newOrderedStock = new OrderedStock(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), Convert.ToInt32(reader[2]), Convert.ToInt32(reader[3]), reader[4].ToString(),
                        reader[5].ToString(), Convert.ToDouble(reader[6]), reader[7].ToString(), Convert.ToDouble(reader[8]));

                    foundOrderedStock.Add(newOrderedStock);
                }

                dbConnection.Close();
            }

            //Return results
            return foundOrderedStock;
        }

        /*Precondition: month needs to be a number e.g march = "03", year = "2016"
        Postcondition: Returns a list of Orders that were made in the passed in month and year */
        public List<Order> getOrdersByMonth(string month, string year)
        {
            List<Order> foundOrders = new List<Order>();

            //Check to make sure orders table exists
            if (checkForTable("Orders"))
            {
                dbConnection.Open();

                //Days in months needs to be incremented by 1 to get the full range from the database
                int daysInMonth = DateTime.DaysInMonth(Convert.ToInt32(year), Convert.ToInt32(month));
                daysInMonth += 1;


                string day1 = "01";
                string day2 = daysInMonth.ToString();

                //Execute SQL query
                string sql = "SELECT * FROM Orders WHERE invoiceDate BETWEEN '" + year + "-" + month + "-" + day1 + "' AND '" + year + "-" + month + "-" + day2 + "'";
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();

                //Loop over and store results
                while (reader.Read())
                {
                    string date = reader[9].ToString();
                    string[] splitOnSpace = date.Split(' ');
                    string[] splitOnSlash = splitOnSpace[0].Split('/');

                    //Convert date into datetime
                    DateTime currDate = new DateTime(Convert.ToInt32(splitOnSlash[2]), Convert.ToInt32(splitOnSlash[1]), Convert.ToInt32(splitOnSlash[0]));

                    Order foundOrder = new Order(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                        Convert.ToDouble(reader[7]), Convert.ToInt32(reader[8]), currDate, reader[10].ToString(), Convert.ToInt32(reader[11]));

                    foundOrders.Add(foundOrder);
                }

                dbConnection.Close();
            }

            return foundOrders;
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
         Postcondition: Returns a list of the last 5 stock that was entered into the system */
        public List<Stock> getLastFiveStockEntries()
        {
            List<Stock> lastFive = new List<Stock>();

            //Check to make sure stock table exists
            if (checkForTable("Stock"))
            {
                string searchQuery = "SELECT * FROM Stock LIMIT 5 OFFSET (SELECT COUNT(*) FROM Stock)-5";

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

        /*Precondition:
         Postcondition: Returns a list of stock that was entered most recently that is the amount that was passed in */
        public List<Stock> getRecentStock(int amountOfStock)
        {
            List<Stock> mostRecent = new List<Stock>();

            //Check to make sure stock table exists
            if (checkForTable("Stock"))
            {
                string searchQuery = "SELECT * FROM Stock LIMIT " + amountOfStock.ToString() + " OFFSET (SELECT COUNT(*) FROM Stock)-" + amountOfStock.ToString();

                dbConnection.Open();

                //Execute query
                SQLiteCommand command = new SQLiteCommand(searchQuery, dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();

                //Loop over and store results
                while (reader.Read())
                {
                    Stock currStock = new Stock(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                        reader[7].ToString(), reader[8].ToString(), Convert.ToDouble(reader[9]), reader[10].ToString(), reader[11].ToString(), reader[12].ToString(), reader[13].ToString(), reader[14].ToString(), reader[15].ToString());

                    mostRecent.Add(currStock);
                }

                dbConnection.Close();
            }

            return mostRecent;
        }
    }
}
