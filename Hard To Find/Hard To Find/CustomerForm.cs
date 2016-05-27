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
    public partial class CustomerForm : Form, ICustomerReceiver
    {
        //Globals
        const int ORDER_ARRAY_LENGTH = 15;
        private MainMenu mainMenu;
        private DatabaseManager dbManager;
        private FileManager fileManager;
        private List<Customer> foundCustomers;
        private List<Customer> allCustomers;
        private Customer currCustomer;
        private bool newCustAndHaventRefreshed;


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
            currCustomer = null;
            newCustAndHaventRefreshed = false;

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
            boxSearchFirstName.Select();

            //Setup event handlers for when enter is pressed while on textboxes
            boxSearchCustID.KeyPress += TextBox_KeyPress_Enter;
            boxSearchFirstName.KeyPress += TextBox_KeyPress_Enter;
            boxSearchLastName.KeyPress += TextBox_KeyPress_Enter;
            boxSearchInstiution.KeyPress += TextBox_KeyPress_Enter;
            boxSearchEmail.KeyPress += TextBox_KeyPress_Enter;
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /*Precondition:
         Postcondition: Open form to create a new customer*/
        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            NewCustomerForm ncf = new NewCustomerForm(this);
            ncf.Show();
        }

        /*Precondition:
         Postcondition: Starts a search for customers depending on what search boxes have been filled in*/
        private void startSearch()
        {
            newCustAndHaventRefreshed = true;

            //Reset datagrid and foundcustomers so searches don't stack
            foundCustomers = new List<Customer>();
            dataGridView1.Rows.Clear();
            bool customersFound = false;

            //Check if an ID has been entered and search on that if it has
            if (boxSearchCustID.Text != "")
            {
                int custID = Convert.ToInt32(boxSearchCustID.Text);

                //Put found customer into list
                foundCustomers.Add(dbManager.searchCustomers(custID));

                //Display found customer
                foreach (Customer c in foundCustomers)
                {
                    if (c != null)
                    {
                        //Display number of results to user
                        labResults.Text = foundCustomers.Count.ToString();

                        customersFound = true;
                        dataGridView1.Rows.Add(c.firstName, c.lastName, c.address1, c.address2, c.country, c.email);
                        dataGridView1.Focus();
                    }
                    else
                        labResults.Text = "0";
                }
            }
            //Else if ID hasn't been entered check for other fields to search on
            else if (boxSearchFirstName.Text != "" || boxSearchLastName.Text != "" || boxSearchInstiution.Text != "" || boxSearchEmail.Text != "")
            {
                string firstName = null;
                string lastName = null;
                string instutution = null;
                string email = null;

                //Check if the user wants the name to match exactly what they typed
                bool exactName = checkExactName.Checked;

                //Get fields if they have been entered
                if (boxSearchFirstName.Text != "")
                    firstName = boxSearchFirstName.Text;
                if (boxSearchLastName.Text != "")
                    lastName = boxSearchLastName.Text;
                if (boxSearchInstiution.Text != "")
                    instutution = boxSearchInstiution.Text;
                if (boxSearchEmail.Text != "")
                    email = boxSearchEmail.Text;

                //Search for customers with fields entered
                foundCustomers = dbManager.searchCustomers(firstName, lastName, instutution, email, exactName);

                //display number of results to user
                labResults.Text = foundCustomers.Count.ToString();

                if (foundCustomers.Count > 0)
                {
                    customersFound = true;

                    //Sort customers by first name
                    foundCustomers = foundCustomers.OrderBy(x => x.firstName).ToList();

                    //Display found customers
                    foreach (Customer c in foundCustomers)
                    {
                        dataGridView1.Rows.Add(c.firstName, c.lastName, c.address1, c.address2, c.country, c.email);
                    }

                    dataGridView1.Focus();
                }
            }

            //If there wasn't a customer in the search, display it in the datagrid and clear the textboxes
            if (!customersFound)
            {
                currCustomer = null;

                dataGridView1.Rows.Add("No customer found", "", "", "", "", "");

                boxCustID.Text = "";
                boxFirstName.Text = "";
                boxLastName.Text = "";
                boxInstitution.Text = "";
                boxAddress1.Text = "";
                boxAddress2.Text = "";
                boxAddress3.Text = "";
                boxPostcode.Text = "";
                boxCountry.Text = "";
                boxEmail.Text = "";
                boxComments.Text = "";
                boxSales.Text = "";
                boxPayment.Text = "";
            }
        }

        /*Precondition:
        Postcondition: Enables details button when entry is selected in datagrid*/
        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            if (foundCustomers.Count != 0)
            {
                int currRow = dataGridView1.CurrentCell.RowIndex;

                currCustomer = foundCustomers[currRow];

                if(currCustomer != null)
                    loadUpCustomer();
            }
        }

        /*Precondition:
         Postcondition: Fills text boxes up with the current customers data*/
        public void loadUpCustomer()
        {
            boxCustID.Text = currCustomer.custID.ToString();
            boxFirstName.Text = currCustomer.firstName;
            boxLastName.Text = currCustomer.lastName;
            boxInstitution.Text = currCustomer.institution;
            boxAddress1.Text = currCustomer.address1;
            boxAddress2.Text = currCustomer.address2;
            boxAddress3.Text = currCustomer.address3;
            boxPostcode.Text = currCustomer.postCode;
            boxCountry.Text = currCustomer.country;
            boxEmail.Text = currCustomer.email;
            boxComments.Text = currCustomer.comments;
            boxSales.Text = currCustomer.sales;
            boxPayment.Text = currCustomer.payment;
        }

        /*Precondition: Needs a customer to be selected in datagrid for enter keypress to work
         Postcondition: Opens up the customers orders of the selected customer when enter is pressed on datagridview */
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (currCustomer != null)
                {
                    CustomerOrdersForm cof = new CustomerOrdersForm(currCustomer);
                    cof.Show();
                }
            }
        }

        /*Precondition:
         Postcondition: Keypress Handler for all the textboxes in the form. Starts search when enter is pressed */
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
         Postcondition: Disables datagrid to customer can't be switched, toggles textboxes readonly to allow customers to be edited */
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            toggleBoxesReadOnly();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;

            boxFirstName.Select();
        }

        /*Precondition:
         Postcondition: Toggle to disable editing, update the customers fields to the database */
        private void btnSave_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            int currRow = dataGridView1.CurrentCell.RowIndex;


            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
            toggleBoxesReadOnly();

            //Update all fields
            currCustomer.firstName = boxFirstName.Text;
            currCustomer.lastName = boxLastName.Text;
            currCustomer.institution = boxInstitution.Text;
            currCustomer.address1 = boxAddress1.Text;
            currCustomer.address2 = boxAddress2.Text;
            currCustomer.address3 = boxAddress3.Text;
            currCustomer.postCode = boxPostcode.Text;
            currCustomer.country = boxCountry.Text;
            currCustomer.email = boxEmail.Text;
            currCustomer.comments = boxComments.Text;
            currCustomer.sales = boxSales.Text;
            currCustomer.payment = boxPayment.Text;

            //Send to dbManager to update entry
            dbManager.updateCustomer(currCustomer);

            //Stops from updating datagrid when new customer isn't on the list yet
            if (!newCustAndHaventRefreshed)
            {
                dataGridView1.Rows[currRow].Cells[0].Value = currCustomer.firstName;
                dataGridView1.Rows[currRow].Cells[1].Value = currCustomer.lastName;
                dataGridView1.Rows[currRow].Cells[2].Value = currCustomer.address1;
                dataGridView1.Rows[currRow].Cells[3].Value = currCustomer.address2;
                dataGridView1.Rows[currRow].Cells[4].Value = currCustomer.country;
                dataGridView1.Rows[currRow].Cells[5].Value = currCustomer.email;
            }
        }

        /*Precondition: None
        Postcondition: Toggles textboxes ReadOnly between true and false so that customer data can be updated */
        private void toggleBoxesReadOnly()
        {
            boxFirstName.ReadOnly = !boxFirstName.ReadOnly;
            boxLastName.ReadOnly = !boxLastName.ReadOnly;
            boxInstitution.ReadOnly = !boxInstitution.ReadOnly;
            boxAddress1.ReadOnly = !boxAddress1.ReadOnly;
            boxAddress2.ReadOnly = !boxAddress2.ReadOnly;
            boxAddress3.ReadOnly = !boxAddress3.ReadOnly;
            boxPostcode.ReadOnly = !boxPostcode.ReadOnly;
            boxCountry.ReadOnly = !boxCountry.ReadOnly;
            boxEmail.ReadOnly = !boxEmail.ReadOnly;
            boxComments.ReadOnly = !boxComments.ReadOnly;
            boxSales.ReadOnly = !boxSales.ReadOnly;
            boxPayment.ReadOnly = !boxPayment.ReadOnly;
        }

        /*Precondition: Needs a customer to be selected in datagrid to work
         Postcondition: Opens form to view customers orders */
        private void btnCustomersOrders_Click(object sender, EventArgs e)
        {
            if (currCustomer != null)
            {
                CustomerOrdersForm cof = new CustomerOrdersForm(currCustomer);
                cof.Show();
            }
        }

        /*Precondition: Needs a customer to be selected in datagrid to work
         Postcondition: Opens form to create an order for the selected customer */
        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            if (currCustomer != null)
            {
                NewOrderForm orderForm = new NewOrderForm(null);
                orderForm.addCustomer(currCustomer);
                orderForm.Show();
            }
        }

        /*Precondition: Needs search to be done first and customers to be found
         Postcondition: Opens form to create an order for the selected customer */
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (currCustomer != null)
            {
                CustomerOrdersForm cof = new CustomerOrdersForm(currCustomer);
                cof.Show();
            }
        }

        /*Precondition: 
         Postcondition: New customer was entered into database, load up their details and set to currCustomer */
        public void addCustomer(Customer newCustomer)
        {
            newCustAndHaventRefreshed = true;
            currCustomer = newCustomer;
            loadUpCustomer();
        }
    }
}
