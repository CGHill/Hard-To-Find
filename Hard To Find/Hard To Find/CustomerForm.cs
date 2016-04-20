using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hard_To_Find
{
    public partial class CustomerForm : Form
    {
        //Globals
        const int ORDER_ARRAY_LENGTH = 15;
        private MainMenu mainMenu;
        private DatabaseManager dbManager;
        private FileManager fileManager;
        private List<Customer> foundCustomers;
        private List<Customer> allCustomers;

        //Constructor
        public CustomerForm(MainMenu mainMenu)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.mainMenu = mainMenu;

            setup();
        }

        /*Precondition:
         Postcondition: Setup and initialize everything needed */
        private void setup()
        {
            //Intialization of globals
            dbManager = new DatabaseManager();
            fileManager = new FileManager();
            foundCustomers = new List<Customer>();
            allCustomers = new List<Customer>();

            //Set up column widths
            DataGridViewColumn colFirstName = dataGridView1.Columns[0];
            colFirstName.Width = 110;
            DataGridViewColumn colLastName = dataGridView1.Columns[1];
            colLastName.Width = 110;
            DataGridViewColumn colAdd1 = dataGridView1.Columns[2];
            colAdd1.Width = 120;
            DataGridViewColumn colAdd2 = dataGridView1.Columns[3];
            colAdd2.Width = 120;
            DataGridViewColumn colCountry = dataGridView1.Columns[4];
            colCountry.Width = 60;
            DataGridViewColumn colEmail = dataGridView1.Columns[5];
            colEmail.Width = 182;

            //Set focus to first name box
            boxFirstName.Select();

            //Setup event handlers for when enter is pressed while on textboxes
            boxCustID.KeyPress += TextBox_KeyPress_Enter;
            boxFirstName.KeyPress += TextBox_KeyPress_Enter;
            boxLastName.KeyPress += TextBox_KeyPress_Enter;
            boxInstiution.KeyPress += TextBox_KeyPress_Enter;
            boxEmail.KeyPress += TextBox_KeyPress_Enter;
        }

        /*Precondition:
         Postcondition: Return back to the main menu*/
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            mainMenu.Show();
            mainMenu.Activate();
        }

        /*Precondition:
         Postcondition: Listens for keypresses no matter which control has focus */
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Close form and bring main menu to front when escape is pressed
            if (keyData == Keys.Escape)
            {
                this.Close();
                mainMenu.Show();
                mainMenu.Activate();
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /*Precondition:
         Postcondition: Starts a search for customers depending on what search boxes have been filled in*/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            startSearch();
        }

        /*Precondition:
         Postcondition: Only allows numbers to be entered into ID textbox*/
        private void boxCustID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        /*Precondition: Can't be called until something has been selected in datagrid
         Postcondition: Opens up new form to display further customer details*/
        private void btnCustDetails_Click(object sender, EventArgs e)
        {
            int currRow = dataGridView1.CurrentCell.RowIndex;

            Customer customerToDisplay = foundCustomers[currRow];

            CustomerDetailsForm cf = new CustomerDetailsForm(customerToDisplay, this);
            cf.Show();
        }

        /*Precondition: Customer CSV order = ID, first name, last name, institution, address1, address2, address3, country, postcode, phone, fax, email, comments, sales, payment
         Postcondition: Starts the import process to move customers from a csv text file into the SQLite database*/
        private void btnImportCustomers_Click(object sender, EventArgs e)
        {
            //Set up file browser, to search for txt files and default directory of C: drive
            OpenFileDialog dialogBox = new OpenFileDialog();
            dialogBox.Title = "Open Customer txt file";
            dialogBox.Filter = "TXT files|*.txt";
            dialogBox.InitialDirectory = @"C:\";

            //Open the file browser and wait for user to select file
            if (dialogBox.ShowDialog() == DialogResult.OK)
            {
                //Get the path for the file the user clicked on
                string filename = dialogBox.FileName;

                if (filename.Contains("\\Customers.txt"))
                {
                    allCustomers = new List<Customer>();

                    try
                    {
                        allCustomers = fileManager.getCustomersFromFile(filename);

                        progressBar1.Visible = true;
                        progressBar1.Maximum = allCustomers.Count;
                        progressBar1.Value = 0;

                        //TODO find a better place for this?
                        dbManager.dropCustomerTable();
                        dbManager.createCustomerTable();

                        //Insert all of the new orders into the database
                        dbManager.insertCustomers(allCustomers, progressBar1);
                        progressBar1.Visible = false;

                        //Inform user that the process has been finished
                        MessageBox.Show("Finished import");
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Error: File was formatted incorrectly");
                    }
                    catch (IndexOutOfRangeException)
                    {
                        MessageBox.Show("Error: File was formatted incorrectly");
                    }
                }
                else
                {
                    MessageBox.Show("Error: Wrong file selected");
                }
            }
        }


        /*Precondition:
         Postcondition: Open form to create a new customer*/
        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            NewCustomerForm ncf = new NewCustomerForm();
            ncf.Show();
        }

        /*Precondition:
         Postcondition: Starts a search for customers depending on what search boxes have been filled in*/
        private void startSearch()
        {
            //Reset datagrid and foundcustomers so searches don't stack
            foundCustomers = new List<Customer>();
            dataGridView1.Rows.Clear();
            btnCustDetails.Enabled = false;

            

            //Check if an ID has been entered and search on that if it has
            if (boxCustID.Text != "")
            {
                int custID = Convert.ToInt32(boxCustID.Text);

                //Put found customer into list
                foundCustomers.Add(dbManager.searchCustomers(custID));

                //Display found customer
                foreach (Customer c in foundCustomers)
                {
                    if (c != null)
                    {
                        dataGridView1.Rows.Add(c.firstName, c.lastName, c.address1, c.address2, c.country, c.email);
                        dataGridView1.Focus();
                    }
                    else
                    {
                        dataGridView1.Rows.Add("No customer found", "", "", "", "", "");
                        btnCustDetails.Enabled = false;
                    }
                }
            }
            else if (boxFirstName.Text != "" || boxLastName.Text != "" || boxInstiution.Text != "" || boxEmail.Text != "")//Else if ID hasn't been entered check for first and last name
            {
                string firstName = null;
                string lastName = null;
                string instutution = null;
                string email = null;

                //Check if the user wants the name to match exactly what they typed
                bool exactName = checkExactName.Checked;

                //Get names if they have been entered
                if (boxFirstName.Text != "")
                    firstName = SyntaxHelper.escapeSingleQuotes(boxFirstName.Text);
                if (boxLastName.Text != "")
                    lastName = SyntaxHelper.escapeSingleQuotes(boxLastName.Text);
                if (boxInstiution.Text != "")
                    instutution = SyntaxHelper.escapeSingleQuotes(boxInstiution.Text);
                if (boxEmail.Text != "")
                    email = SyntaxHelper.escapeSingleQuotes(boxEmail.Text);

                //Search for customers with names entered
                foundCustomers = dbManager.searchCustomers(firstName, lastName, instutution, email, exactName);

                if (foundCustomers.Count == 0)
                {
                    dataGridView1.Rows.Add("No customer found", "", "", "", "", "");
                    btnCustDetails.Enabled = false;
                }
                else
                {
                    foundCustomers = foundCustomers.OrderBy(x => x.firstName).ToList();

                    //Display found customers
                    foreach (Customer c in foundCustomers)
                    {
                        dataGridView1.Rows.Add(c.firstName, c.lastName, c.address1, c.address2, c.country, c.email);
                    }

                    dataGridView1.Focus();
                }
            }
        }

        /*Precondition:
        Postcondition: Enables details button when entry is selected in datagrid*/
        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            btnCustDetails.Enabled = true;
        }

        /*Precondition:
         Postcondition: Open up form for customer details that was double clicked on*/
        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int currRow = dataGridView1.CurrentCell.RowIndex;

                Customer customerToDisplay = foundCustomers[currRow];

                CustomerDetailsForm cf = new CustomerDetailsForm(customerToDisplay, this);
                cf.Show();
            }
            catch (NullReferenceException)
            {
                //Do nothing, user double clicked on header of datagrid
            }
        }

        /*Precondition:
         Postcondition: Opens up the customer details of the selected customer when enter is pressed on datagridview */
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                int currRow = dataGridView1.CurrentCell.RowIndex;

                Customer customerToDisplay = foundCustomers[currRow];

                CustomerDetailsForm cf = new CustomerDetailsForm(customerToDisplay, this);
                cf.Show();
            }
        }

        /*Precondition:
         Postcondition: Keypress Hanlder for all the textboxes in the form. Starts search when enter is pressed */
        private void TextBox_KeyPress_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                startSearch();

                //Stops the windows noise
                e.Handled = true;
            }
        }

        /*Precondition:
         Postcondition: Updates the datagrid when focus is regained, used after user has updated a customer entry */
        private void CustomerForm_Activated(object sender, EventArgs e)
        {
            startSearch();
        }
    }
}
