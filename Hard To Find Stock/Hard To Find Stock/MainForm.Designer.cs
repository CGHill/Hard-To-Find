namespace Hard_To_Find_Stock
{
    partial class MainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkExactPhrase = new System.Windows.Forms.CheckBox();
            this.rdoInStock = new System.Windows.Forms.RadioButton();
            this.rdoAllStock = new System.Windows.Forms.RadioButton();
            this.boxSearchSubject = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.boxSearchBookID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.boxSearchTitle = new System.Windows.Forms.TextBox();
            this.boxSearchAuthor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNewStock = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCreateExport = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.labResults = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSetExportLocation = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.boxDescription = new System.Windows.Forms.TextBox();
            this.boxInitials = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.boxDateEntered = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.boxBookID = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.boxSales = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.boxCatalogues = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.boxSubject = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.boxPrice = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.boxComment = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.boxPublisher = new System.Windows.Forms.TextBox();
            this.boxSubtitle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.boxTitle = new System.Windows.Forms.TextBox();
            this.boxAuthor = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.boxNote = new System.Windows.Forms.TextBox();
            this.boxQuantity = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.boxStockID = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnSetStockImport = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkExactPhrase);
            this.groupBox1.Controls.Add(this.rdoInStock);
            this.groupBox1.Controls.Add(this.rdoAllStock);
            this.groupBox1.Controls.Add(this.boxSearchSubject);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.boxSearchBookID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.boxSearchTitle);
            this.groupBox1.Controls.Add(this.boxSearchAuthor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(18, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 268);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // checkExactPhrase
            // 
            this.checkExactPhrase.AutoSize = true;
            this.checkExactPhrase.Location = new System.Drawing.Point(80, 192);
            this.checkExactPhrase.Name = "checkExactPhrase";
            this.checkExactPhrase.Size = new System.Drawing.Size(88, 17);
            this.checkExactPhrase.TabIndex = 7;
            this.checkExactPhrase.Text = "Exact phrase";
            this.checkExactPhrase.UseVisualStyleBackColor = true;
            // 
            // rdoInStock
            // 
            this.rdoInStock.AutoSize = true;
            this.rdoInStock.Checked = true;
            this.rdoInStock.Location = new System.Drawing.Point(80, 146);
            this.rdoInStock.Name = "rdoInStock";
            this.rdoInStock.Size = new System.Drawing.Size(91, 17);
            this.rdoInStock.TabIndex = 6;
            this.rdoInStock.TabStop = true;
            this.rdoInStock.Text = "Have in stock";
            this.rdoInStock.UseVisualStyleBackColor = true;
            // 
            // rdoAllStock
            // 
            this.rdoAllStock.AutoSize = true;
            this.rdoAllStock.Location = new System.Drawing.Point(80, 169);
            this.rdoAllStock.Name = "rdoAllStock";
            this.rdoAllStock.Size = new System.Drawing.Size(67, 17);
            this.rdoAllStock.TabIndex = 7;
            this.rdoAllStock.Text = "All Stock";
            this.rdoAllStock.UseVisualStyleBackColor = true;
            // 
            // boxSearchSubject
            // 
            this.boxSearchSubject.Location = new System.Drawing.Point(80, 108);
            this.boxSearchSubject.Name = "boxSearchSubject";
            this.boxSearchSubject.Size = new System.Drawing.Size(145, 20);
            this.boxSearchSubject.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Subject:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(80, 230);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(145, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // boxSearchBookID
            // 
            this.boxSearchBookID.Location = new System.Drawing.Point(80, 30);
            this.boxSearchBookID.Name = "boxSearchBookID";
            this.boxSearchBookID.Size = new System.Drawing.Size(92, 20);
            this.boxSearchBookID.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Book ID:";
            // 
            // boxSearchTitle
            // 
            this.boxSearchTitle.Location = new System.Drawing.Point(80, 82);
            this.boxSearchTitle.Name = "boxSearchTitle";
            this.boxSearchTitle.Size = new System.Drawing.Size(145, 20);
            this.boxSearchTitle.TabIndex = 4;
            // 
            // boxSearchAuthor
            // 
            this.boxSearchAuthor.Location = new System.Drawing.Point(80, 56);
            this.boxSearchAuthor.Name = "boxSearchAuthor";
            this.boxSearchAuthor.Size = new System.Drawing.Size(145, 20);
            this.boxSearchAuthor.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Title:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Author:";
            // 
            // btnNewStock
            // 
            this.btnNewStock.Location = new System.Drawing.Point(98, 319);
            this.btnNewStock.Name = "btnNewStock";
            this.btnNewStock.Size = new System.Drawing.Size(145, 30);
            this.btnNewStock.TabIndex = 9;
            this.btnNewStock.Text = "&New Stock";
            this.btnNewStock.UseVisualStyleBackColor = true;
            this.btnNewStock.Click += new System.EventHandler(this.btnNewStock_Click);
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
            this.Column6,
            this.Column4,
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(257, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(907, 370);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
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
            // Column6
            // 
            this.Column6.HeaderText = "Subtitle";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.Column5.HeaderText = "Book ID";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnCreateExport
            // 
            this.btnCreateExport.Location = new System.Drawing.Point(16, 16);
            this.btnCreateExport.Name = "btnCreateExport";
            this.btnCreateExport.Size = new System.Drawing.Size(145, 40);
            this.btnCreateExport.TabIndex = 10;
            this.btnCreateExport.Text = "Create Export &File";
            this.btnCreateExport.UseVisualStyleBackColor = true;
            this.btnCreateExport.Click += new System.EventHandler(this.btnCreateExport_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(98, 597);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(145, 40);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // labResults
            // 
            this.labResults.AutoSize = true;
            this.labResults.Location = new System.Drawing.Point(346, 379);
            this.labResults.Name = "labResults";
            this.labResults.Size = new System.Drawing.Size(13, 13);
            this.labResults.TabIndex = 37;
            this.labResults.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(254, 379);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Number of results:";
            // 
            // btnSetExportLocation
            // 
            this.btnSetExportLocation.Location = new System.Drawing.Point(16, 59);
            this.btnSetExportLocation.Name = "btnSetExportLocation";
            this.btnSetExportLocation.Size = new System.Drawing.Size(145, 40);
            this.btnSetExportLocation.TabIndex = 11;
            this.btnSetExportLocation.Text = "Set Export Location";
            this.btnSetExportLocation.UseVisualStyleBackColor = true;
            this.btnSetExportLocation.Click += new System.EventHandler(this.btnSetExportLocation_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(16, 19);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(145, 40);
            this.btnUpdate.TabIndex = 38;
            this.btnUpdate.Text = "Update Database";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.boxDescription);
            this.groupBox2.Controls.Add(this.boxInitials);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.boxDateEntered);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.boxBookID);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.boxSales);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.boxCatalogues);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.boxSubject);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.boxPrice);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.boxComment);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.boxPublisher);
            this.groupBox2.Controls.Add(this.boxSubtitle);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.boxTitle);
            this.groupBox2.Controls.Add(this.boxAuthor);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.boxNote);
            this.groupBox2.Controls.Add(this.boxQuantity);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.boxStockID);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Location = new System.Drawing.Point(257, 414);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(907, 231);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stock information";
            // 
            // boxDescription
            // 
            this.boxDescription.Location = new System.Drawing.Point(357, 128);
            this.boxDescription.Multiline = true;
            this.boxDescription.Name = "boxDescription";
            this.boxDescription.ReadOnly = true;
            this.boxDescription.Size = new System.Drawing.Size(311, 91);
            this.boxDescription.TabIndex = 24;
            // 
            // boxInitials
            // 
            this.boxInitials.Location = new System.Drawing.Point(750, 121);
            this.boxInitials.Name = "boxInitials";
            this.boxInitials.ReadOnly = true;
            this.boxInitials.Size = new System.Drawing.Size(146, 20);
            this.boxInitials.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(705, 124);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 202;
            this.label12.Text = "Initials:";
            // 
            // boxDateEntered
            // 
            this.boxDateEntered.Location = new System.Drawing.Point(750, 199);
            this.boxDateEntered.Name = "boxDateEntered";
            this.boxDateEntered.ReadOnly = true;
            this.boxDateEntered.Size = new System.Drawing.Size(146, 20);
            this.boxDateEntered.TabIndex = 29;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(671, 202);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(73, 13);
            this.label16.TabIndex = 201;
            this.label16.Text = "Date Entered:";
            // 
            // boxBookID
            // 
            this.boxBookID.Location = new System.Drawing.Point(750, 173);
            this.boxBookID.Name = "boxBookID";
            this.boxBookID.ReadOnly = true;
            this.boxBookID.Size = new System.Drawing.Size(146, 20);
            this.boxBookID.TabIndex = 28;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(695, 178);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 200;
            this.label15.Text = "Book ID:";
            // 
            // boxSales
            // 
            this.boxSales.Location = new System.Drawing.Point(750, 147);
            this.boxSales.Name = "boxSales";
            this.boxSales.ReadOnly = true;
            this.boxSales.Size = new System.Drawing.Size(146, 20);
            this.boxSales.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(708, 150);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 13);
            this.label13.TabIndex = 199;
            this.label13.Text = "Sales:";
            // 
            // boxCatalogues
            // 
            this.boxCatalogues.Location = new System.Drawing.Point(357, 100);
            this.boxCatalogues.Name = "boxCatalogues";
            this.boxCatalogues.ReadOnly = true;
            this.boxCatalogues.Size = new System.Drawing.Size(311, 20);
            this.boxCatalogues.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(288, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 198;
            this.label9.Text = "Catalogues:";
            // 
            // boxSubject
            // 
            this.boxSubject.Location = new System.Drawing.Point(750, 22);
            this.boxSubject.Multiline = true;
            this.boxSubject.Name = "boxSubject";
            this.boxSubject.ReadOnly = true;
            this.boxSubject.Size = new System.Drawing.Size(146, 93);
            this.boxSubject.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(698, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 197;
            this.label10.Text = "Subject:";
            // 
            // boxPrice
            // 
            this.boxPrice.Location = new System.Drawing.Point(357, 74);
            this.boxPrice.Name = "boxPrice";
            this.boxPrice.ReadOnly = true;
            this.boxPrice.Size = new System.Drawing.Size(311, 20);
            this.boxPrice.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(317, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 196;
            this.label11.Text = "Price:";
            // 
            // boxComment
            // 
            this.boxComment.Location = new System.Drawing.Point(357, 48);
            this.boxComment.Multiline = true;
            this.boxComment.Name = "boxComment";
            this.boxComment.ReadOnly = true;
            this.boxComment.Size = new System.Drawing.Size(311, 20);
            this.boxComment.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(297, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 195;
            this.label8.Text = "Comment:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(290, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 194;
            this.label7.Text = "Description:";
            // 
            // boxPublisher
            // 
            this.boxPublisher.Location = new System.Drawing.Point(357, 22);
            this.boxPublisher.Multiline = true;
            this.boxPublisher.Name = "boxPublisher";
            this.boxPublisher.ReadOnly = true;
            this.boxPublisher.Size = new System.Drawing.Size(311, 20);
            this.boxPublisher.TabIndex = 20;
            // 
            // boxSubtitle
            // 
            this.boxSubtitle.Location = new System.Drawing.Point(64, 203);
            this.boxSubtitle.Name = "boxSubtitle";
            this.boxSubtitle.ReadOnly = true;
            this.boxSubtitle.Size = new System.Drawing.Size(214, 20);
            this.boxSubtitle.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(298, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 193;
            this.label6.Text = "Publisher:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 206);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 192;
            this.label14.Text = "Subtitle:";
            // 
            // boxTitle
            // 
            this.boxTitle.Location = new System.Drawing.Point(64, 125);
            this.boxTitle.Multiline = true;
            this.boxTitle.Name = "boxTitle";
            this.boxTitle.ReadOnly = true;
            this.boxTitle.Size = new System.Drawing.Size(214, 72);
            this.boxTitle.TabIndex = 18;
            // 
            // boxAuthor
            // 
            this.boxAuthor.Location = new System.Drawing.Point(64, 100);
            this.boxAuthor.Name = "boxAuthor";
            this.boxAuthor.ReadOnly = true;
            this.boxAuthor.Size = new System.Drawing.Size(214, 20);
            this.boxAuthor.TabIndex = 17;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(28, 128);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(30, 13);
            this.label17.TabIndex = 191;
            this.label17.Text = "Title:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(17, 103);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 13);
            this.label18.TabIndex = 190;
            this.label18.Text = "Author:";
            // 
            // boxNote
            // 
            this.boxNote.Location = new System.Drawing.Point(64, 74);
            this.boxNote.Multiline = true;
            this.boxNote.Name = "boxNote";
            this.boxNote.ReadOnly = true;
            this.boxNote.Size = new System.Drawing.Size(214, 20);
            this.boxNote.TabIndex = 16;
            // 
            // boxQuantity
            // 
            this.boxQuantity.Location = new System.Drawing.Point(64, 48);
            this.boxQuantity.Name = "boxQuantity";
            this.boxQuantity.ReadOnly = true;
            this.boxQuantity.Size = new System.Drawing.Size(214, 20);
            this.boxQuantity.TabIndex = 15;
            this.boxQuantity.Text = "1";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(25, 77);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(33, 13);
            this.label19.TabIndex = 189;
            this.label19.Text = "Note:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(9, 51);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(49, 13);
            this.label20.TabIndex = 188;
            this.label20.Text = "Quantity:";
            // 
            // boxStockID
            // 
            this.boxStockID.Location = new System.Drawing.Point(64, 22);
            this.boxStockID.Name = "boxStockID";
            this.boxStockID.ReadOnly = true;
            this.boxStockID.Size = new System.Drawing.Size(214, 20);
            this.boxStockID.TabIndex = 14;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(9, 25);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(52, 13);
            this.label21.TabIndex = 187;
            this.label21.Text = "Stock ID:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(447, 383);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(44, 13);
            this.label22.TabIndex = 41;
            this.label22.Text = "Sort By:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Quantity",
            "Author",
            "Title",
            "Price"});
            this.comboBox1.Location = new System.Drawing.Point(497, 380);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 40;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnSetStockImport
            // 
            this.btnSetStockImport.Location = new System.Drawing.Point(16, 60);
            this.btnSetStockImport.Name = "btnSetStockImport";
            this.btnSetStockImport.Size = new System.Drawing.Size(145, 40);
            this.btnSetStockImport.TabIndex = 42;
            this.btnSetStockImport.Text = "Set Import Location";
            this.btnSetStockImport.UseVisualStyleBackColor = true;
            this.btnSetStockImport.Click += new System.EventHandler(this.btnSetStockImport_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSetExportLocation);
            this.groupBox3.Controls.Add(this.btnCreateExport);
            this.groupBox3.Location = new System.Drawing.Point(82, 355);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(168, 110);
            this.groupBox3.TabIndex = 43;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Stock Export";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSetStockImport);
            this.groupBox4.Controls.Add(this.btnUpdate);
            this.groupBox4.Location = new System.Drawing.Point(82, 471);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(169, 109);
            this.groupBox4.TabIndex = 44;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Stock Import";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 657);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.labResults);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNewStock);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnExit);
            this.Name = "MainForm";
            this.Text = "Stock Form";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoInStock;
        private System.Windows.Forms.RadioButton rdoAllStock;
        private System.Windows.Forms.TextBox boxSearchSubject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox boxSearchBookID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox boxSearchTitle;
        private System.Windows.Forms.TextBox boxSearchAuthor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNewStock;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCreateExport;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label labResults;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSetExportLocation;
        private System.Windows.Forms.CheckBox checkExactPhrase;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox boxDescription;
        private System.Windows.Forms.TextBox boxInitials;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox boxDateEntered;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox boxBookID;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox boxSales;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox boxCatalogues;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox boxSubject;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox boxPrice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox boxComment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox boxPublisher;
        private System.Windows.Forms.TextBox boxSubtitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox boxTitle;
        private System.Windows.Forms.TextBox boxAuthor;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox boxNote;
        private System.Windows.Forms.TextBox boxQuantity;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox boxStockID;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnSetStockImport;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

