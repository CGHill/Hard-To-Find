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
        SQLiteConnection dbConnection;

        public DatabaseManager()
        {
            dbConnection = new SQLiteConnection("Data Source=HardToFindDB.sqlite;Version=3;");
        }

        public void createTables()
        {
            dbConnection.Open();

            string deleteCustomersTable = "DROP TABLE IF EXISTS Customer";
            SQLiteCommand deleteCustomersCommand = new SQLiteCommand(deleteCustomersTable, dbConnection);
            deleteCustomersCommand.ExecuteNonQuery();

            string deleteStockTable = "DROP TABLE IF EXISTS Stock";
            SQLiteCommand deleteCommand = new SQLiteCommand(deleteStockTable, dbConnection);
            deleteCommand.ExecuteNonQuery();

            string deleteOrdersable = "DROP TABLE IF EXISTS Orders";
            SQLiteCommand deleteOrdersCommand = new SQLiteCommand(deleteOrdersable, dbConnection);
            deleteOrdersCommand.ExecuteNonQuery();


            string createCustomerTable = "CREATE TABLE IF NOT EXISTS Customer(customerID INTEGER PRIMARY KEY AUTOINCREMENT, firstName VARCHAR(100), lastName VARCHAR(100), institution VARCHAR(100)," +
                "address1 VARCHAR(200), address2 VARCHAR(100), address3 VARCHAR(100), country VARCHAR(100), postcode VARCHAR(100), phone INTEGER, fax INTEGER, email VARCHAR(100), comments VARCHAR(100), sales VARCHAR(100), payment VARCHAR(100))";

            SQLiteCommand createCustomerTableCommand = new SQLiteCommand(createCustomerTable, dbConnection);
            createCustomerTableCommand.ExecuteNonQuery();


            string createStockTable = "CREATE TABLE IF NOT EXISTS Stock(stockID INTEGER PRIMARY KEY AUTOINCREMENT, quantity INTEGER NOT NULL, note VARCHAR(200), author VARCHAR(150), title VARCHAR(200), subtitle VARCHAR(300)," +
                "publisher VARCHAR(200), description VARCHAR(400), comments VARCHAR(500), location VARCHAR(2), price VARCHAR(10), subject VARCHAR(500), catalogue VARCHAR(200), weight VARCHAR(6), sales VARCHAR(150), bookID VARCHAR(100), dateEntered VARCHAR(100))";

            SQLiteCommand createStockTableCommand = new SQLiteCommand(createStockTable, dbConnection);
            createStockTableCommand.ExecuteNonQuery();


            string createOrdersTable = "CREATE TABLE IF NOT EXISTS Orders(orderID INTEGER PRIMARY KEY AUTOINCREMENT, firstName VARCHAR(100), lastName VARCHAR(100), institution VARCHAR(100), postcode VARCHAR(10)," +
                " orderReference VARCHAR(40), catItem VARCHAR(50), author VARCHAR(150), title VARCHAR(200), quantitity INTEGER NOT NULL, price VARCHAR(10), progress VARCHAR(100), discPrice VARCHAR(10)," +
                " invoice INTEGER, invoiceDate VARCHAR(100), comments VARCHAR(200), stockID INTEGER, CustomerID INTEGER)";

            SQLiteCommand createOrdersTableCommand = new SQLiteCommand(createOrdersTable, dbConnection);
            createOrdersTableCommand.ExecuteNonQuery();


            dbConnection.Close();
        }

        public void testDB(ListBox listview)
        {
            dbConnection.Open();
            
            string deleteStockTable = "DROP TABLE IF EXISTS Stock";

            SQLiteCommand deleteCommand = new SQLiteCommand(deleteStockTable, dbConnection);
            deleteCommand.ExecuteNonQuery();

            string deleteOrdersable = "DROP TABLE IF EXISTS Orders";

            SQLiteCommand deleteOrdersCommand = new SQLiteCommand(deleteOrdersable, dbConnection);
            deleteOrdersCommand.ExecuteNonQuery();


            string createCustomerTable = "CREATE TABLE IF NOT EXISTS Customer(customerID INTEGER PRIMARY KEY AUTOINCREMENT, firstName VARCHAR(100), lastName VARCHAR(100), institution VARCHAR(100)," +
                "address1 VARCHAR(200), address2 VARCHAR(100), address3 VARCHAR(100), country VARCHAR(100), postcode VARCHAR(100), phone INTEGER, fax INTEGER, email VARCHAR(100), comments VARCHAR(100), sales VARCHAR(100), payment VARCHAR(100))";

            string createStockTable = "CREATE TABLE IF NOT EXISTS Stock(stockID INTEGER PRIMARY KEY AUTOINCREMENT, quantity INTEGER NOT NULL, note VARCHAR(200), author VARCHAR(150), title VARCHAR(200), subtitle VARCHAR(300)," + 
                "publisher VARCHAR(200), description VARCHAR(400), comments VARCHAR(500), location VARCHAR(2), price VARCHAR(10), subject VARCHAR(500), catalogue VARCHAR(200), weight VARCHAR(6), sales VARCHAR(150), bookID VARCHAR(100), dateEntered VARCHAR(100))";

            //string createCustomerOrdersTable = "CREATE TABLE IF NOT EXISTS CustomerOrder(customerID INTEGER NOT NULL, orderID INTEGER NOT NULL)";

            string createOrdersTable = "CREATE TABLE IF NOT EXISTS Orders(orderID INTEGER PRIMARY KEY AUTOINCREMENT, firstName VARCHAR(100), lastName VARCHAR(100), institution VARCHAR(100), postcode VARCHAR(10)," + 
                " orderReference VARCHAR(40), catItem VARCHAR(50), author VARCHAR(150), title VARCHAR(200), quantitity INTEGER NOT NULL, price VARCHAR(10), progress VARCHAR(100), discPrice VARCHAR(10)," + 
                " invoice INTEGER, invoiceDate VARCHAR(100), comments VARCHAR(200), stockID INTEGER, CustomerID INTEGER)";

            SQLiteCommand createCustomerTableCommand = new SQLiteCommand(createCustomerTable, dbConnection);
            createCustomerTableCommand.ExecuteNonQuery();

            SQLiteCommand createStockTableCommand = new SQLiteCommand(createStockTable, dbConnection);
            createStockTableCommand.ExecuteNonQuery();

            //SQLiteCommand createCustomerOrdersTableCommand = new SQLiteCommand(createCustomerOrdersTable, dbConnection);
            //createCustomerOrdersTableCommand.ExecuteNonQuery();

            SQLiteCommand createOrdersTableCommand = new SQLiteCommand(createOrdersTable, dbConnection);
            createOrdersTableCommand.ExecuteNonQuery();

            dbConnection.Close();

            /*insertCustomer("David", "Yalenezian", "", "426 Indian Head Street","Hanson","MA","USA","02341","","","yalenezian@comcast.net","","30806","V");
            insertCustomer("Michael", "Fleming", "", "6 Yetman Road", "Coolatai", "", "Australia", "NSW 2402", "", "", "", "", "31806", "V");
            insertCustomer("Jared", "Bark", "Bark Frameworks LLC", "21-24 44th Avenue", "Long Island City", "NY", "USA", "11101", "", "", "jbark@barkframeworks.com", "", "30806", "Amex");
            insertCustomer("Amy", "Findlater", "Anthropology Department", "Richardson Building", "Castle Street", "Dunedin", "NZ", "", "", "", "finam126@student.otago.ac.nz", "", "31806", "V");
            insertCustomer("Werner", "Driller", "", "Robertstr. 11", "Bochum", "", "Germany", "44791", "", "", "maxlouis@gmx.de", "", "5906", "MC");*/

            /*insertStock(10, 1, "", "Bunin, Ivan", "Memories and portraits", "", "John Lehmann London 1951", "First English edition 205pp ex libris (pockets and stamps) sl rubbed d/w, excellent", 
                "", "sv", "$8,02", "Bunin Lit Bio Russian", "literature", "", "Jensen", "1a25/4", "April01");

            insertStock(55, 1, "", "KNIGHT, CHARLES R.", "PREHISTORIC MAN- THE GREAT ADVENTURER", "", "Appleton Century Crofts Inc. New York 1949", "First edition 331pp ex libris (pockets and stamps) d/w worn at extremities, excellent, illust.",
                "", "sv", "$14.58", "Anthropology Prehistory Evolution Exploration", "", "700g", "Korey", "1b4/15", "April01");

            insertStock(95, 0, "", "Tozer- Fant, David J.", "A.W. Tozer", "A twentieth century prophet", "Christian Publications Pennsylvania 1964", "First edition 180pp ex libris d/w w. plastic, excellent",
                "", "sv", "$8.019", "Theology Christianity Tozer Bio", "Religion", "", "Bound for Glory Used Christian Books", "1a8/32", "April01");

            insertStock(243, 12, "", "BERIOSOVA- FRANKS, A.H.:", "Svetlana Beriosova", "a biography", "Burke London 1958", "First edition 144pp ex libris (usual cancellation stamps, pockets etc.) excellent, d/w ttay (sl rubbing, tears across rear cover, minor tears at extremities), illust.",
                "", "sv", "$14.58", "Beriosova Bio Ballet Dance", "arts", "600g", "Bakker", "1f1/29", "April01");

            insertStock(288, 22, "", "BUKOWSKI, CHARLES", "Factotum", "", "wh allen london 1981", "first UK edition 205pp VG+ (v sl cocked, spine foot v sl bumped, v faint foxing to half-title and title pages) in VG+ d/w (sl rubbing, spine sl faded with sl creasing to head, faint foxing to flaps, sl crimped top edge of rear flap, v sl wear and creasing to edges)",
                "", "sv", "$65.61", "modern first edition", "modern first edition", "", "Ricci", "wj052", "April01");

            insertStock(5, "", "MILNE, A.A.", "When We Were Very Young", "", "methuen london 1924", "first edition 100pp VG (hinge sl shaky, corners scuffed and bruised, spine sl sunned with some scuffing to head and foot, boards rubbed with some marking and staining, lower corners stained, endpapers sl discolored, owners name in pencil on fep, sl marking to half-title page, lower edge of rear pages sl discolored) lacks d/w",
                "illust. by  e.h. shepard. Very scarce.", "sv", "$1,093.50", "modern first editions childrens", "", "", "Hallgate", "wj021", "April01");*/

            /*insertOrder(1, "David", "Grayling", "R A Gekoski Rare Books", "WC1A 2LP", "", "wj10399001", "HUGHES, TED", "Crow", 1, "$900.00", "Matamata", "$13.20", 1297, "12805", "", "null", "null");
            insertOrder(28379, "Philip", "Murray", "", "", "abe", "", ", ", "", 0, "$0.00", "COMPLETE", "$19.56", 28379, "29/03/2012", "", "null", "7920");
            insertOrder("", "", "Clearwater Books", "DT6 4LU", "L uk", "1c73/14", "SAMUELS, SAMMY AND DAVIS, LEONARD:", "Among The Soho Sinners", 1, "$20.00", "COMPLETE", "$20.00", 2467, "27-3-2000", "", "null", "null");*/

            dbConnection.Open();

            //COLLATE NOCASE = search isn't case sensitive
            //string sql = "SELECT * FROM Customer WHERE firstName = 'david' COLLATE NOCASE";
            //string sql = "SELECT * FROM Customer WHERE customerFirstName LIKE 'da%'";

            //string sql = "SELECT * FROM Stock";
            string sql = "SELECT * FROM Orders";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                /*String customer = "ID: " + reader[0] + " Name: " + reader[1] + " " + reader[2] + " institution: " + reader[3] + " address1: " + reader[4] + " address2: " + reader[5] + " address3 : " + reader[6] +
                                    " country: " + reader[7] + " postcode: " + reader[8] + " phone: " + reader[9] + " fax: " + reader[10] + " email: " + reader[11] + " comments: " + reader[12]
                                    + " sales: " + reader[13] + " payment: " + reader[14];
                listview.Items.Add(customer);*/

                /*String stock = "StockID: " + reader[0] + " quantity: " + reader[1] + " note: " + reader[2] + " author: " + reader[3] + " title: " + reader[4] + " subtitle: " + reader[5] + " publisher: " + reader[6]
                    + " description: " + reader[7] + " comments: " + reader[8] + " location: " + reader[9] + " price: " + reader[10] + " subject: " + reader[11] + " catalogue: " + reader[12] + " weight: " + reader[13] + " sales: " + reader[14]
                    + " bookID: " + reader[15] + " dateEntered: " + reader[16];
                listview.Items.Add(stock);*/

                String order = "OrderID: " + reader[0] + " Customer Name: " + reader[1] + " " + reader[2] + " Instutution: " + reader[3] + " Postcode: " + reader[4] + " Order Ref: " + reader[5] + " CatItem: " + reader[6]
                    + " Author: " + reader[7] + " Title: " + reader[8] + " Quantity: " + reader[9] + " Price: " + reader[10] + " Progress: " + reader[11] + " DiscPrice: " + reader[12] + " InvoiceNo: " + reader[13] + " Invoice Date: " + reader[14]
                    + " Comments: " + reader[15] + " StockID: " + reader[16] + " CustomerID: " + reader[17];
                listview.Items.Add(order);
            }

            dbConnection.Close();
        }

        public void insertCustomer(string firstName, string lastName, string institution, string address1, string address2, string address3, string country, string postcode, string phone, 
            string fax, string email, string comments, string sales, string payment)
        {
            dbConnection.Open();

            string customerInsert = "INSERT INTO Customer VALUES(null, '" + firstName + "', '" + lastName + "', '" + institution + "', '" + address1 +
                "', '" + address2 + "', '" + address3 + "', '" + country + "', '" + postcode + "', '" + phone + "', '" + fax + "', '" + email + "', '" + comments + "', '" + sales + "', '" + payment + "')";
            SQLiteCommand insertCommand = new SQLiteCommand(customerInsert, dbConnection);
            insertCommand.ExecuteNonQuery();

            dbConnection.Close();
        }

        public void insertCustomer(int customerID, string firstName, string lastName, string institution, string address1, string address2, string address3, string country, string postcode, string phone,
            string fax, string email, string comments, string sales, string payment)
        {
            dbConnection.Open();

            string customerInsert = "INSERT INTO Customer VALUES(" + customerID + " , '" + firstName + "', '" + lastName + "', '" + institution + "', '" + address1 +
                "', '" + address2 + "', '" + address3 + "', '" + country + "', '" + postcode + "', '" + phone + "', '" + fax + "', '" + email + "', '" + comments + "', '" + sales + "', '" + payment + "')";
            SQLiteCommand insertCommand = new SQLiteCommand(customerInsert, dbConnection);
            insertCommand.ExecuteNonQuery();

            dbConnection.Close();
        }

        public void insertStock(int stockID, int quantity, string note, string author, string title, string subtitle, string publisher, string description, string comments, string location, string price,
            string subject, string catalogue, string weight, string sales, string bookID, string dateEntered)
        {
            dbConnection.Open();

            string stockInsert = "INSERT INTO Stock VALUES(" + stockID.ToString() + ", '" + quantity.ToString() + "', '" + note + "', '" + author + "', '" + title + "', '" + subtitle +
                "', '" + publisher + "', '" + description + "', '" + comments + "', '" + location + "', '" + price + "', '" + subject + "', '" + catalogue + "', '" + weight + "', '" + sales + "', '" + bookID + "', '" + dateEntered +"')";
            SQLiteCommand insertCommand = new SQLiteCommand(stockInsert, dbConnection);
            insertCommand.ExecuteNonQuery();

            dbConnection.Close();
        }

        public void insertStock(int quantity, string note, string author, string title, string subtitle, string publisher, string description, string comments, string location, string price,
            string subject, string catalogue, string weight, string sales, string bookID, string dateEntered)
        {
            dbConnection.Open();

            string stockInsert = "INSERT INTO Stock VALUES(null, '" + quantity.ToString() + "', '" + note + "', '" + author + "', '" + title + "', '" + subtitle +
                "', '" + publisher + "', '" + description + "', '" + comments + "', '" + location + "', '" + price + "', '" + subject + "', '" + catalogue + "', '" + weight + "', '" + sales + "', '" + bookID + "', '" + dateEntered + "')";
            SQLiteCommand insertCommand = new SQLiteCommand(stockInsert, dbConnection);
            insertCommand.ExecuteNonQuery();

            dbConnection.Close();
        }

        public void insertOrder(int orderID, string firstName, string lastName, string institution, string postcode, string orderReference, string catItem, string author, string title, int quantity, string price,
            string progress, string discPrice, int invoiceNo, string invoiceDate, string comments, string stockID, string customerID)
        {
            dbConnection.Open();

            string orderInsert = "INSERT INTO Orders VALUES(" + orderID.ToString() + ", '" + firstName + "', '" + lastName + "', '" + institution + "', '" + postcode + "', '" + orderReference +
                "', '" + catItem + "', '" + author + "', '" + title + "', '" + quantity.ToString() + "', '" + price + "', '" + progress + "', '" + discPrice + "', '" + invoiceNo.ToString() + "', '" + invoiceDate + "', '" + comments +
                "', '" + stockID + "', '" + customerID + "')";
            SQLiteCommand insertCommand = new SQLiteCommand(orderInsert, dbConnection);
            insertCommand.ExecuteNonQuery();

            dbConnection.Close();
        }

        public void insertOrder(string firstName, string lastName, string institution, string postcode, string orderReference, string catItem, string author, string title, int quantity, string price,
            string progress, string discPrice, int invoiceNo, string invoiceDate, string comments, string stockID, string customerID)
        {
            dbConnection.Open();

            string orderInsert = "INSERT INTO Orders VALUES(null, '" + firstName + "', '" + lastName + "', '" + institution + "', '" + postcode + "', '" + orderReference +
                "', '" + catItem + "', '" + author + "', '" + title + "', '" + quantity.ToString() + "', '" + price + "', '" + progress + "', '" + discPrice + "', '" + invoiceNo.ToString() + "', '" + invoiceDate + "', '" + comments +
                "', '" + stockID + "', '" + customerID + "')";
            SQLiteCommand insertCommand = new SQLiteCommand(orderInsert, dbConnection);
            insertCommand.ExecuteNonQuery();

            dbConnection.Close();
        }

        public void testCustomerDisplay(ListBox listbox)
        {
            dbConnection.Open();

            string sql = "SELECT * FROM Customer";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                String customer = "ID: " + reader[0] + " Name: " + reader[1] + " " + reader[2] + " institution: " + reader[3] + " address1: " + reader[4] + " address2: " + reader[5] + " address3 : " + reader[6] +
                                    " country: " + reader[7] + " postcode: " + reader[8] + " phone: " + reader[9] + " fax: " + reader[10] + " email: " + reader[11] + " comments: " + reader[12]
                                    + " sales: " + reader[13] + " payment: " + reader[14];
                listbox.Items.Add(customer);
            }

            dbConnection.Close();
        }

        public void createDatabaseFile()
        {
            SQLiteConnection.CreateFile("HardToFindDB.sqlite");
        }
    }
}
