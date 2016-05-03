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
    public partial class ConfirmExportToDeskForm : Form
    {
        private StockForm form;

        public ConfirmExportToDeskForm(StockForm form)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.form = form;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            confirmedExport();
        }

        //Only allow numbers in the texbox
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /*Precondition:
        Postcondition: Listens for keypresses no matter which control has focus */
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
            }
            if (keyData == Keys.Enter)
            {
                confirmedExport();
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void confirmedExport()
        {
            if (textBox1.Text != "")
            {
                int numExport = Convert.ToInt32(textBox1.Text);
                form.startExport(numExport);
            }

            this.Close();
        }
    }
}
