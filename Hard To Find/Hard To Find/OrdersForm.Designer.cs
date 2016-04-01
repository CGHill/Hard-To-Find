namespace Hard_To_Find
{
    partial class OrdersForm
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
            this.components = new System.ComponentModel.Container();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnImportOrders = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labOrderID = new System.Windows.Forms.Label();
            this.boxOrderSearchID = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.btnImportOrderedStock = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnChangeCustomer = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.boxLastName = new System.Windows.Forms.TextBox();
            this.boxCustID = new System.Windows.Forms.TextBox();
            this.boxCountry = new System.Windows.Forms.TextBox();
            this.boxAdd3 = new System.Windows.Forms.TextBox();
            this.boxAdd2 = new System.Windows.Forms.TextBox();
            this.boxAdd1 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.boxPostcode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.boxInstitution = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.boxFirstName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.boxOrderID = new System.Windows.Forms.TextBox();
            this.boxInvoiceDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.boxFreight = new System.Windows.Forms.TextBox();
            this.boxProgress = new System.Windows.Forms.TextBox();
            this.boxOrderRef = new System.Windows.Forms.TextBox();
            this.boxComments = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCreateInvoice = new System.Windows.Forms.Button();
            this.btnBigMailingLabel = new System.Windows.Forms.Button();
            this.labMailingLabels = new System.Windows.Forms.Label();
            this.btnSmallMailingLabel = new System.Windows.Forms.Button();
            this.btnNewestOrder = new System.Windows.Forms.Button();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Location = new System.Drawing.Point(896, 581);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(127, 39);
            this.btnMainMenu.TabIndex = 32;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnImportOrders
            // 
            this.btnImportOrders.Location = new System.Drawing.Point(68, 509);
            this.btnImportOrders.Name = "btnImportOrders";
            this.btnImportOrders.Size = new System.Drawing.Size(118, 33);
            this.btnImportOrders.TabIndex = 33;
            this.btnImportOrders.Text = "Import Orders";
            this.btnImportOrders.UseVisualStyleBackColor = true;
            this.btnImportOrders.Click += new System.EventHandler(this.btnImportOrders_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(-1, 626);
            this.progressBar1.Maximum = 39193;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1024, 13);
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Visible = false;
            // 
            // labOrderID
            // 
            this.labOrderID.AutoSize = true;
            this.labOrderID.Location = new System.Drawing.Point(12, 75);
            this.labOrderID.Name = "labOrderID";
            this.labOrderID.Size = new System.Drawing.Size(50, 13);
            this.labOrderID.TabIndex = 6;
            this.labOrderID.Text = "Order ID:";
            // 
            // boxOrderSearchID
            // 
            this.boxOrderSearchID.Location = new System.Drawing.Point(68, 72);
            this.boxOrderSearchID.Name = "boxOrderSearchID";
            this.boxOrderSearchID.Size = new System.Drawing.Size(118, 20);
            this.boxOrderSearchID.TabIndex = 1;
            this.boxOrderSearchID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxOrderID_KeyPress);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(68, 111);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(118, 33);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.Location = new System.Drawing.Point(68, 250);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(118, 33);
            this.btnNewOrder.TabIndex = 6;
            this.btnNewOrder.Text = "&New Order";
            this.btnNewOrder.UseVisualStyleBackColor = true;
            this.btnNewOrder.Click += new System.EventHandler(this.btnNewOrder_Click);
            // 
            // btnImportOrderedStock
            // 
            this.btnImportOrderedStock.Location = new System.Drawing.Point(68, 548);
            this.btnImportOrderedStock.Name = "btnImportOrderedStock";
            this.btnImportOrderedStock.Size = new System.Drawing.Size(118, 33);
            this.btnImportOrderedStock.TabIndex = 34;
            this.btnImportOrderedStock.Text = "Import OrderedStock";
            this.btnImportOrderedStock.UseVisualStyleBackColor = true;
            this.btnImportOrderedStock.Click += new System.EventHandler(this.btnImportOrderedStock_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(236, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(787, 569);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Invoice";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(621, 89);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 33);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 393);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Books Ordered:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(621, 49);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(118, 33);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnChangeCustomer);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.boxLastName);
            this.groupBox3.Controls.Add(this.boxCustID);
            this.groupBox3.Controls.Add(this.boxCountry);
            this.groupBox3.Controls.Add(this.boxAdd3);
            this.groupBox3.Controls.Add(this.boxAdd2);
            this.groupBox3.Controls.Add(this.boxAdd1);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.boxPostcode);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.boxInstitution);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.boxFirstName);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(21, 201);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(760, 176);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Customer Details";
            // 
            // btnChangeCustomer
            // 
            this.btnChangeCustomer.Enabled = false;
            this.btnChangeCustomer.Location = new System.Drawing.Point(600, 137);
            this.btnChangeCustomer.Name = "btnChangeCustomer";
            this.btnChangeCustomer.Size = new System.Drawing.Size(118, 33);
            this.btnChangeCustomer.TabIndex = 29;
            this.btnChangeCustomer.Text = "Change Customer";
            this.btnChangeCustomer.UseVisualStyleBackColor = true;
            this.btnChangeCustomer.Visible = false;
            this.btnChangeCustomer.Click += new System.EventHandler(this.btnChangeCustomer_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(36, 91);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(61, 13);
            this.label18.TabIndex = 52;
            this.label18.Text = "Last Name:";
            // 
            // boxLastName
            // 
            this.boxLastName.Location = new System.Drawing.Point(106, 88);
            this.boxLastName.Name = "boxLastName";
            this.boxLastName.ReadOnly = true;
            this.boxLastName.Size = new System.Drawing.Size(142, 20);
            this.boxLastName.TabIndex = 22;
            // 
            // boxCustID
            // 
            this.boxCustID.Location = new System.Drawing.Point(106, 34);
            this.boxCustID.Name = "boxCustID";
            this.boxCustID.ReadOnly = true;
            this.boxCustID.Size = new System.Drawing.Size(84, 20);
            this.boxCustID.TabIndex = 20;
            // 
            // boxCountry
            // 
            this.boxCountry.Location = new System.Drawing.Point(576, 88);
            this.boxCountry.Name = "boxCountry";
            this.boxCountry.ReadOnly = true;
            this.boxCountry.Size = new System.Drawing.Size(142, 20);
            this.boxCountry.TabIndex = 28;
            // 
            // boxAdd3
            // 
            this.boxAdd3.Location = new System.Drawing.Point(576, 62);
            this.boxAdd3.Name = "boxAdd3";
            this.boxAdd3.ReadOnly = true;
            this.boxAdd3.Size = new System.Drawing.Size(142, 20);
            this.boxAdd3.TabIndex = 27;
            // 
            // boxAdd2
            // 
            this.boxAdd2.Location = new System.Drawing.Point(347, 114);
            this.boxAdd2.Name = "boxAdd2";
            this.boxAdd2.ReadOnly = true;
            this.boxAdd2.Size = new System.Drawing.Size(142, 20);
            this.boxAdd2.TabIndex = 26;
            // 
            // boxAdd1
            // 
            this.boxAdd1.Location = new System.Drawing.Point(347, 88);
            this.boxAdd1.Name = "boxAdd1";
            this.boxAdd1.ReadOnly = true;
            this.boxAdd1.Size = new System.Drawing.Size(142, 20);
            this.boxAdd1.TabIndex = 25;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(524, 91);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(46, 13);
            this.label17.TabIndex = 45;
            this.label17.Text = "Country:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(513, 65);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 13);
            this.label16.TabIndex = 43;
            this.label16.Text = "Address 3:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(284, 117);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 13);
            this.label15.TabIndex = 41;
            this.label15.Text = "Address 2:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(284, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 39;
            this.label14.Text = "Address 1:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(286, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 37;
            this.label13.Text = "Postcode:";
            // 
            // boxPostcode
            // 
            this.boxPostcode.Location = new System.Drawing.Point(347, 62);
            this.boxPostcode.Name = "boxPostcode";
            this.boxPostcode.ReadOnly = true;
            this.boxPostcode.Size = new System.Drawing.Size(142, 20);
            this.boxPostcode.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(45, 117);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Institution:";
            // 
            // boxInstitution
            // 
            this.boxInstitution.Location = new System.Drawing.Point(106, 114);
            this.boxInstitution.Name = "boxInstitution";
            this.boxInstitution.ReadOnly = true;
            this.boxInstitution.Size = new System.Drawing.Size(142, 20);
            this.boxInstitution.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(37, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "First Name:";
            // 
            // boxFirstName
            // 
            this.boxFirstName.Location = new System.Drawing.Point(106, 62);
            this.boxFirstName.Name = "boxFirstName";
            this.boxFirstName.ReadOnly = true;
            this.boxFirstName.Size = new System.Drawing.Size(142, 20);
            this.boxFirstName.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Cusomter ID:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.boxOrderID);
            this.groupBox2.Controls.Add(this.boxInvoiceDate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.boxFreight);
            this.groupBox2.Controls.Add(this.boxProgress);
            this.groupBox2.Controls.Add(this.boxOrderRef);
            this.groupBox2.Controls.Add(this.boxComments);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(21, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(512, 176);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Order Details";
            // 
            // boxOrderID
            // 
            this.boxOrderID.Location = new System.Drawing.Point(106, 37);
            this.boxOrderID.Name = "boxOrderID";
            this.boxOrderID.ReadOnly = true;
            this.boxOrderID.Size = new System.Drawing.Size(84, 20);
            this.boxOrderID.TabIndex = 11;
            // 
            // boxInvoiceDate
            // 
            this.boxInvoiceDate.Location = new System.Drawing.Point(106, 119);
            this.boxInvoiceDate.Name = "boxInvoiceDate";
            this.boxInvoiceDate.ReadOnly = true;
            this.boxInvoiceDate.Size = new System.Drawing.Size(142, 20);
            this.boxInvoiceDate.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Invoice Date:";
            // 
            // boxFreight
            // 
            this.boxFreight.Location = new System.Drawing.Point(347, 61);
            this.boxFreight.Name = "boxFreight";
            this.boxFreight.ReadOnly = true;
            this.boxFreight.Size = new System.Drawing.Size(142, 20);
            this.boxFreight.TabIndex = 15;
            this.boxFreight.Leave += new System.EventHandler(this.boxFreight_Leave);
            // 
            // boxProgress
            // 
            this.boxProgress.Location = new System.Drawing.Point(106, 93);
            this.boxProgress.Name = "boxProgress";
            this.boxProgress.ReadOnly = true;
            this.boxProgress.Size = new System.Drawing.Size(142, 20);
            this.boxProgress.TabIndex = 13;
            // 
            // boxOrderRef
            // 
            this.boxOrderRef.Location = new System.Drawing.Point(106, 67);
            this.boxOrderRef.Name = "boxOrderRef";
            this.boxOrderRef.ReadOnly = true;
            this.boxOrderRef.Size = new System.Drawing.Size(142, 20);
            this.boxOrderRef.TabIndex = 12;
            // 
            // boxComments
            // 
            this.boxComments.Location = new System.Drawing.Point(347, 91);
            this.boxComments.Multiline = true;
            this.boxComments.Name = "boxComments";
            this.boxComments.ReadOnly = true;
            this.boxComments.Size = new System.Drawing.Size(142, 48);
            this.boxComments.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(282, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Comments:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(299, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Freight:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Progress:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Order Reference:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "OrderID:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridView1.Location = new System.Drawing.Point(6, 413);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(775, 150);
            this.dataGridView1.TabIndex = 30;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseUp);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Quantity";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Author";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Title";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Price";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "BookID";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Discount";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnCreateInvoice
            // 
            this.btnCreateInvoice.Location = new System.Drawing.Point(68, 327);
            this.btnCreateInvoice.Name = "btnCreateInvoice";
            this.btnCreateInvoice.Size = new System.Drawing.Size(118, 33);
            this.btnCreateInvoice.TabIndex = 7;
            this.btnCreateInvoice.Text = "Create &Invoice";
            this.btnCreateInvoice.UseVisualStyleBackColor = true;
            this.btnCreateInvoice.Click += new System.EventHandler(this.btnCreateInvoice_Click);
            // 
            // btnBigMailingLabel
            // 
            this.btnBigMailingLabel.Location = new System.Drawing.Point(52, 407);
            this.btnBigMailingLabel.Name = "btnBigMailingLabel";
            this.btnBigMailingLabel.Size = new System.Drawing.Size(74, 33);
            this.btnBigMailingLabel.TabIndex = 8;
            this.btnBigMailingLabel.Text = "Big";
            this.btnBigMailingLabel.UseVisualStyleBackColor = true;
            this.btnBigMailingLabel.Click += new System.EventHandler(this.btnBigMailingLabel_Click);
            // 
            // labMailingLabels
            // 
            this.labMailingLabels.AutoSize = true;
            this.labMailingLabels.Location = new System.Drawing.Point(85, 386);
            this.labMailingLabels.Name = "labMailingLabels";
            this.labMailingLabels.Size = new System.Drawing.Size(77, 13);
            this.labMailingLabels.TabIndex = 24;
            this.labMailingLabels.Text = "Mailing Labels:";
            // 
            // btnSmallMailingLabel
            // 
            this.btnSmallMailingLabel.Location = new System.Drawing.Point(132, 407);
            this.btnSmallMailingLabel.Name = "btnSmallMailingLabel";
            this.btnSmallMailingLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSmallMailingLabel.Size = new System.Drawing.Size(74, 33);
            this.btnSmallMailingLabel.TabIndex = 9;
            this.btnSmallMailingLabel.Text = "Small";
            this.btnSmallMailingLabel.UseVisualStyleBackColor = true;
            this.btnSmallMailingLabel.Click += new System.EventHandler(this.btnSmallMailingLabel_Click);
            // 
            // btnNewestOrder
            // 
            this.btnNewestOrder.Location = new System.Drawing.Point(112, 150);
            this.btnNewestOrder.Name = "btnNewestOrder";
            this.btnNewestOrder.Size = new System.Drawing.Size(118, 33);
            this.btnNewestOrder.TabIndex = 5;
            this.btnNewestOrder.Text = "Get Newest Order";
            this.btnNewestOrder.UseVisualStyleBackColor = true;
            this.btnNewestOrder.Click += new System.EventHandler(this.btnNewestOrder_Click);
            // 
            // btnAddBook
            // 
            this.btnAddBook.Enabled = false;
            this.btnAddBook.Location = new System.Drawing.Point(236, 581);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(133, 39);
            this.btnAddBook.TabIndex = 31;
            this.btnAddBook.Text = "Add Book";
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Visible = false;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeBookToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(148, 26);
            this.contextMenuStrip1.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // removeBookToolStripMenuItem
            // 
            this.removeBookToolStripMenuItem.Name = "removeBookToolStripMenuItem";
            this.removeBookToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.removeBookToolStripMenuItem.Text = "Remove Book";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(68, 150);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(41, 33);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(15, 150);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(47, 33);
            this.btnPrev.TabIndex = 3;
            this.btnPrev.Text = "Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // OrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 636);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnAddBook);
            this.Controls.Add(this.btnNewestOrder);
            this.Controls.Add(this.btnSmallMailingLabel);
            this.Controls.Add(this.labMailingLabels);
            this.Controls.Add(this.btnBigMailingLabel);
            this.Controls.Add(this.btnCreateInvoice);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnImportOrderedStock);
            this.Controls.Add(this.btnNewOrder);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.boxOrderSearchID);
            this.Controls.Add(this.labOrderID);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnImportOrders);
            this.Controls.Add(this.btnMainMenu);
            this.Name = "OrdersForm";
            this.Text = "Orders";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnImportOrders;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labOrderID;
        private System.Windows.Forms.TextBox boxOrderSearchID;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.Button btnImportOrderedStock;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox boxComments;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox boxPostcode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox boxInstitution;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox boxFirstName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox boxAdd3;
        private System.Windows.Forms.TextBox boxAdd2;
        private System.Windows.Forms.TextBox boxAdd1;
        private System.Windows.Forms.TextBox boxFreight;
        private System.Windows.Forms.TextBox boxProgress;
        private System.Windows.Forms.TextBox boxOrderRef;
        private System.Windows.Forms.TextBox boxCountry;
        private System.Windows.Forms.TextBox boxInvoiceDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCreateInvoice;
        private System.Windows.Forms.Button btnBigMailingLabel;
        private System.Windows.Forms.Label labMailingLabels;
        private System.Windows.Forms.Button btnSmallMailingLabel;
        private System.Windows.Forms.TextBox boxOrderID;
        private System.Windows.Forms.TextBox boxCustID;
        private System.Windows.Forms.Button btnNewestOrder;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox boxLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeBookToolStripMenuItem;
        private System.Windows.Forms.Button btnChangeCustomer;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
    }
}