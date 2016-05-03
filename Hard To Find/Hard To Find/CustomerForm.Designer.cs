namespace Hard_To_Find
{
    partial class CustomerForm
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
            this.boxSearchLastName = new System.Windows.Forms.TextBox();
            this.boxSearchFirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.boxSearchCustID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnNewCustomer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkExactName = new System.Windows.Forms.CheckBox();
            this.boxSearchEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.boxSearchInstiution = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boxCustID = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.btnCustomersOrders = new System.Windows.Forms.Button();
            this.boxPayment = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.boxSales = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.boxComments = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.boxEmail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.boxCountry = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.boxPostcode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.boxAddress3 = new System.Windows.Forms.TextBox();
            this.boxAddress2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.boxAddress1 = new System.Windows.Forms.TextBox();
            this.boxInstitution = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.boxLastName = new System.Windows.Forms.TextBox();
            this.boxFirstName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.labResults = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxSearchLastName
            // 
            this.boxSearchLastName.Location = new System.Drawing.Point(77, 82);
            this.boxSearchLastName.Name = "boxSearchLastName";
            this.boxSearchLastName.Size = new System.Drawing.Size(145, 20);
            this.boxSearchLastName.TabIndex = 3;
            // 
            // boxSearchFirstName
            // 
            this.boxSearchFirstName.Location = new System.Drawing.Point(77, 56);
            this.boxSearchFirstName.Name = "boxSearchFirstName";
            this.boxSearchFirstName.Size = new System.Drawing.Size(145, 20);
            this.boxSearchFirstName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Last Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "First Name:";
            // 
            // boxSearchCustID
            // 
            this.boxSearchCustID.Location = new System.Drawing.Point(77, 30);
            this.boxSearchCustID.Name = "boxSearchCustID";
            this.boxSearchCustID.Size = new System.Drawing.Size(82, 20);
            this.boxSearchCustID.TabIndex = 1;
            this.boxSearchCustID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxCustID_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Customer ID:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(77, 193);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(145, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Location = new System.Drawing.Point(880, 538);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(109, 34);
            this.btnMainMenu.TabIndex = 26;
            this.btnMainMenu.Text = "Main M&enu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnNewCustomer
            // 
            this.btnNewCustomer.Location = new System.Drawing.Point(101, 337);
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.Size = new System.Drawing.Size(145, 31);
            this.btnNewCustomer.TabIndex = 8;
            this.btnNewCustomer.Text = "&New Customer";
            this.btnNewCustomer.UseVisualStyleBackColor = true;
            this.btnNewCustomer.Click += new System.EventHandler(this.btnNewCustomer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkExactName);
            this.groupBox1.Controls.Add(this.boxSearchEmail);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.boxSearchInstiution);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.boxSearchCustID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.boxSearchLastName);
            this.groupBox1.Controls.Add(this.boxSearchFirstName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 224);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // checkExactName
            // 
            this.checkExactName.AutoSize = true;
            this.checkExactName.Location = new System.Drawing.Point(77, 160);
            this.checkExactName.Name = "checkExactName";
            this.checkExactName.Size = new System.Drawing.Size(82, 17);
            this.checkExactName.TabIndex = 6;
            this.checkExactName.Text = "Exact name";
            this.checkExactName.UseVisualStyleBackColor = true;
            // 
            // boxSearchEmail
            // 
            this.boxSearchEmail.Location = new System.Drawing.Point(77, 134);
            this.boxSearchEmail.Name = "boxSearchEmail";
            this.boxSearchEmail.Size = new System.Drawing.Size(145, 20);
            this.boxSearchEmail.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Email:";
            // 
            // boxSearchInstiution
            // 
            this.boxSearchInstiution.Location = new System.Drawing.Point(77, 108);
            this.boxSearchInstiution.Name = "boxSearchInstiution";
            this.boxSearchInstiution.Size = new System.Drawing.Size(145, 20);
            this.boxSearchInstiution.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Institution:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridView1.Location = new System.Drawing.Point(265, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(724, 356);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged_1);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "First Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Last Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Address 1";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Address 2";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Country";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Email";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // boxCustID
            // 
            this.boxCustID.Location = new System.Drawing.Point(86, 24);
            this.boxCustID.Name = "boxCustID";
            this.boxCustID.ReadOnly = true;
            this.boxCustID.Size = new System.Drawing.Size(92, 20);
            this.boxCustID.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 27);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 13);
            this.label15.TabIndex = 71;
            this.label15.Text = "Customer ID:";
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Location = new System.Drawing.Point(533, 579);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(145, 34);
            this.btnCreateOrder.TabIndex = 28;
            this.btnCreateOrder.Text = "Create &New Order";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // btnCustomersOrders
            // 
            this.btnCustomersOrders.Location = new System.Drawing.Point(289, 579);
            this.btnCustomersOrders.Name = "btnCustomersOrders";
            this.btnCustomersOrders.Size = new System.Drawing.Size(145, 34);
            this.btnCustomersOrders.TabIndex = 27;
            this.btnCustomersOrders.Text = "View Customers &Orders";
            this.btnCustomersOrders.UseVisualStyleBackColor = true;
            this.btnCustomersOrders.Click += new System.EventHandler(this.btnCustomersOrders_Click);
            // 
            // boxPayment
            // 
            this.boxPayment.Location = new System.Drawing.Point(642, 136);
            this.boxPayment.Name = "boxPayment";
            this.boxPayment.ReadOnly = true;
            this.boxPayment.Size = new System.Drawing.Size(189, 20);
            this.boxPayment.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(585, 139);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 70;
            this.label13.Text = "Payment:";
            // 
            // boxSales
            // 
            this.boxSales.Location = new System.Drawing.Point(642, 110);
            this.boxSales.Name = "boxSales";
            this.boxSales.ReadOnly = true;
            this.boxSales.Size = new System.Drawing.Size(189, 20);
            this.boxSales.TabIndex = 22;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(599, 113);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 13);
            this.label14.TabIndex = 69;
            this.label14.Text = "Sales:";
            // 
            // boxComments
            // 
            this.boxComments.Location = new System.Drawing.Point(642, 29);
            this.boxComments.Multiline = true;
            this.boxComments.Name = "boxComments";
            this.boxComments.ReadOnly = true;
            this.boxComments.Size = new System.Drawing.Size(189, 75);
            this.boxComments.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(576, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 68;
            this.label9.Text = "Comments:";
            // 
            // boxEmail
            // 
            this.boxEmail.Location = new System.Drawing.Point(374, 133);
            this.boxEmail.Name = "boxEmail";
            this.boxEmail.ReadOnly = true;
            this.boxEmail.Size = new System.Drawing.Size(189, 20);
            this.boxEmail.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(332, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 67;
            this.label10.Text = "Email:";
            // 
            // boxCountry
            // 
            this.boxCountry.Location = new System.Drawing.Point(374, 107);
            this.boxCountry.Name = "boxCountry";
            this.boxCountry.ReadOnly = true;
            this.boxCountry.Size = new System.Drawing.Size(190, 20);
            this.boxCountry.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(321, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 66;
            this.label8.Text = "Country:";
            // 
            // boxPostcode
            // 
            this.boxPostcode.Location = new System.Drawing.Point(374, 78);
            this.boxPostcode.Name = "boxPostcode";
            this.boxPostcode.ReadOnly = true;
            this.boxPostcode.Size = new System.Drawing.Size(190, 20);
            this.boxPostcode.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(308, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 65;
            this.label7.Text = "Post Code:";
            // 
            // boxAddress3
            // 
            this.boxAddress3.Location = new System.Drawing.Point(374, 52);
            this.boxAddress3.Name = "boxAddress3";
            this.boxAddress3.ReadOnly = true;
            this.boxAddress3.Size = new System.Drawing.Size(190, 20);
            this.boxAddress3.TabIndex = 17;
            // 
            // boxAddress2
            // 
            this.boxAddress2.Location = new System.Drawing.Point(374, 26);
            this.boxAddress2.Name = "boxAddress2";
            this.boxAddress2.ReadOnly = true;
            this.boxAddress2.Size = new System.Drawing.Size(190, 20);
            this.boxAddress2.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(308, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 62;
            this.label6.Text = "Address3:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(308, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 59;
            this.label11.Text = "Address2:";
            // 
            // boxAddress1
            // 
            this.boxAddress1.Location = new System.Drawing.Point(86, 130);
            this.boxAddress1.Name = "boxAddress1";
            this.boxAddress1.ReadOnly = true;
            this.boxAddress1.Size = new System.Drawing.Size(190, 20);
            this.boxAddress1.TabIndex = 15;
            // 
            // boxInstitution
            // 
            this.boxInstitution.Location = new System.Drawing.Point(86, 104);
            this.boxInstitution.Name = "boxInstitution";
            this.boxInstitution.ReadOnly = true;
            this.boxInstitution.Size = new System.Drawing.Size(190, 20);
            this.boxInstitution.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 56;
            this.label12.Text = "Address1:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 107);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 13);
            this.label16.TabIndex = 54;
            this.label16.Text = "Institution:";
            // 
            // boxLastName
            // 
            this.boxLastName.Location = new System.Drawing.Point(86, 78);
            this.boxLastName.Name = "boxLastName";
            this.boxLastName.ReadOnly = true;
            this.boxLastName.Size = new System.Drawing.Size(190, 20);
            this.boxLastName.TabIndex = 13;
            // 
            // boxFirstName
            // 
            this.boxFirstName.Location = new System.Drawing.Point(86, 52);
            this.boxFirstName.Name = "boxFirstName";
            this.boxFirstName.ReadOnly = true;
            this.boxFirstName.Size = new System.Drawing.Size(190, 20);
            this.boxFirstName.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(880, 451);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 34);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(880, 411);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(109, 34);
            this.btnUpdate.TabIndex = 24;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(20, 81);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(61, 13);
            this.label17.TabIndex = 45;
            this.label17.Text = "Last Name:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 55);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 13);
            this.label18.TabIndex = 43;
            this.label18.Text = "First Name:";
            // 
            // labResults
            // 
            this.labResults.AutoSize = true;
            this.labResults.Location = new System.Drawing.Point(354, 374);
            this.labResults.Name = "labResults";
            this.labResults.Size = new System.Drawing.Size(13, 13);
            this.labResults.TabIndex = 73;
            this.labResults.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(262, 374);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(92, 13);
            this.label19.TabIndex = 72;
            this.label19.Text = "Number of results:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.boxCustID);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.boxPayment);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.boxSales);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.boxComments);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.boxEmail);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.boxCountry);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.boxPostcode);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.boxAddress3);
            this.groupBox2.Controls.Add(this.boxAddress2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.boxAddress1);
            this.groupBox2.Controls.Add(this.boxInstitution);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.boxLastName);
            this.groupBox2.Controls.Add(this.boxFirstName);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(18, 405);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(847, 166);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customer Information";
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 623);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.labResults);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.btnCreateOrder);
            this.Controls.Add(this.btnCustomersOrders);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNewCustomer);
            this.Controls.Add(this.btnMainMenu);
            this.Name = "CustomerForm";
            this.Text = "Customers";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox boxSearchLastName;
        private System.Windows.Forms.TextBox boxSearchFirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox boxSearchCustID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnNewCustomer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.TextBox boxSearchEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox boxSearchInstiution;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkExactName;
        private System.Windows.Forms.TextBox boxCustID;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.Button btnCustomersOrders;
        private System.Windows.Forms.TextBox boxPayment;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox boxSales;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox boxComments;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox boxEmail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox boxCountry;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox boxPostcode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox boxAddress3;
        private System.Windows.Forms.TextBox boxAddress2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox boxAddress1;
        private System.Windows.Forms.TextBox boxInstitution;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox boxLastName;
        private System.Windows.Forms.TextBox boxFirstName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label labResults;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}