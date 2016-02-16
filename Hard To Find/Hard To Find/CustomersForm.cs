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
    public partial class CustomersForm : Form
    {
        Form1 form1;

        public CustomersForm(Form1 form1)
        {
            this.form1 = form1;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            form1.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            toggleBoxesReadOnly();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
            toggleBoxesReadOnly();
        }


        /*Precondition: None
         Postcondition: Toggles textboxes ReadOnly between true and false so that customer data can be updated */
        private void toggleBoxesReadOnly()
        {
            boxInstitution.ReadOnly = !boxInstitution.ReadOnly;
            boxAddress.ReadOnly = !boxAddress.ReadOnly;
            boxSuburb.ReadOnly = !boxSuburb.ReadOnly;
            boxCity.ReadOnly = !boxCity.ReadOnly;
            boxPostcode.ReadOnly = !boxPostcode.ReadOnly;
            boxCountry.ReadOnly = !boxCountry.ReadOnly;
            boxPhone.ReadOnly = !boxPhone.ReadOnly;
            boxFax.ReadOnly = !boxFax.ReadOnly;
            boxEmail.ReadOnly = !boxEmail.ReadOnly;
            boxComments.ReadOnly = !boxComments.ReadOnly;
            boxSales.ReadOnly = !boxSales.ReadOnly;
            boxPayment.ReadOnly = !boxPayment.ReadOnly;
        }
    }
}
