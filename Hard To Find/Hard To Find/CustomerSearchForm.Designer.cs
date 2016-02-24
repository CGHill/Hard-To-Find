namespace Hard_To_Find
{
    partial class CustomerSearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.boxLastName = new System.Windows.Forms.TextBox();
            this.boxFirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.boxCustID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCustDetails = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnImportCustomers = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnNewCustomer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // boxLastName
            // 
            this.boxLastName.Location = new System.Drawing.Point(87, 105);
            this.boxLastName.Name = "boxLastName";
            this.boxLastName.Size = new System.Drawing.Size(145, 20);
            this.boxLastName.TabIndex = 3;
            // 
            // boxFirstName
            // 
            this.boxFirstName.Location = new System.Drawing.Point(87, 79);
            this.boxFirstName.Name = "boxFirstName";
            this.boxFirstName.Size = new System.Drawing.Size(145, 20);
            this.boxFirstName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Last Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "First Name:";
            // 
            // boxCustID
            // 
            this.boxCustID.Location = new System.Drawing.Point(87, 53);
            this.boxCustID.Name = "boxCustID";
            this.boxCustID.Size = new System.Drawing.Size(82, 20);
            this.boxCustID.TabIndex = 1;
            this.boxCustID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxCustID_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Customer ID:";
            // 
            // btnCustDetails
            // 
            this.btnCustDetails.Enabled = false;
            this.btnCustDetails.Location = new System.Drawing.Point(516, 349);
            this.btnCustDetails.Name = "btnCustDetails";
            this.btnCustDetails.Size = new System.Drawing.Size(208, 23);
            this.btnCustDetails.TabIndex = 19;
            this.btnCustDetails.Text = "Customer Details";
            this.btnCustDetails.UseVisualStyleBackColor = true;
            this.btnCustDetails.Click += new System.EventHandler(this.btnCustDetails_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(24, 141);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(208, 23);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Location = new System.Drawing.Point(24, 334);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(208, 38);
            this.btnMainMenu.TabIndex = 21;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(321, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(612, 316);
            this.dataGridView1.TabIndex = 22;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "First Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Last Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Email";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // btnImportCustomers
            // 
            this.btnImportCustomers.Location = new System.Drawing.Point(24, 241);
            this.btnImportCustomers.Name = "btnImportCustomers";
            this.btnImportCustomers.Size = new System.Drawing.Size(208, 23);
            this.btnImportCustomers.TabIndex = 23;
            this.btnImportCustomers.Text = "Import Customers";
            this.btnImportCustomers.UseVisualStyleBackColor = true;
            this.btnImportCustomers.Click += new System.EventHandler(this.btnImportCustomers_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(24, 414);
            this.progressBar1.Maximum = 24796;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(909, 23);
            this.progressBar1.TabIndex = 37;
            // 
            // btnNewCustomer
            // 
            this.btnNewCustomer.Location = new System.Drawing.Point(24, 183);
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.Size = new System.Drawing.Size(208, 23);
            this.btnNewCustomer.TabIndex = 38;
            this.btnNewCustomer.Text = "New Customer";
            this.btnNewCustomer.UseVisualStyleBackColor = true;
            this.btnNewCustomer.Click += new System.EventHandler(this.btnNewCustomer_Click);
            // 
            // CustomerSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 449);
            this.Controls.Add(this.btnNewCustomer);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnImportCustomers);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnCustDetails);
            this.Controls.Add(this.boxCustID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.boxLastName);
            this.Controls.Add(this.boxFirstName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CustomerSearchForm";
            this.Text = "CustomerSearchForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox boxLastName;
        private System.Windows.Forms.TextBox boxFirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox boxCustID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCustDetails;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button btnImportCustomers;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnNewCustomer;
    }
}