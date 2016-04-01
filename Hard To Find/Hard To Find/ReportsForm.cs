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
    public partial class ReportsForm : Form
    {
        MainMenu form1;

        public ReportsForm(MainMenu form1)
        {
            this.form1 = form1;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        /*Precondition:
         Postcondition: Close this form and return to main menu*/
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            form1.Show();
            form1.TopLevel = true;
        }

        /*Precondition:
         Postcondition: Listens for keypresses no matter which control has focus */
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                form1.Show();
                form1.TopLevel = true;
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
