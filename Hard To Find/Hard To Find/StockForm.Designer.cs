﻿namespace Hard_To_Find
{
    partial class StockForm
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
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnImportStock = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.boxBookID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.boxTitle = new System.Windows.Forms.TextBox();
            this.boxAuthor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.boxSubject = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNewStock = new System.Windows.Forms.Button();
            this.btnStockDetails = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkExactPhrase = new System.Windows.Forms.CheckBox();
            this.rdoInStock = new System.Windows.Forms.RadioButton();
            this.rdoAllStock = new System.Windows.Forms.RadioButton();
            this.labResults = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Location = new System.Drawing.Point(1025, 551);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(140, 40);
            this.btnMainMenu.TabIndex = 13;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnImportStock
            // 
            this.btnImportStock.Location = new System.Drawing.Point(94, 481);
            this.btnImportStock.Name = "btnImportStock";
            this.btnImportStock.Size = new System.Drawing.Size(145, 40);
            this.btnImportStock.TabIndex = 10;
            this.btnImportStock.Text = "Import Stock";
            this.btnImportStock.UseVisualStyleBackColor = true;
            this.btnImportStock.Click += new System.EventHandler(this.btnImportStock_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(-2, 596);
            this.progressBar1.Maximum = 161768;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1183, 14);
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Visible = false;
            // 
            // boxBookID
            // 
            this.boxBookID.Location = new System.Drawing.Point(80, 30);
            this.boxBookID.Name = "boxBookID";
            this.boxBookID.Size = new System.Drawing.Size(92, 20);
            this.boxBookID.TabIndex = 2;
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
            // boxTitle
            // 
            this.boxTitle.Location = new System.Drawing.Point(80, 82);
            this.boxTitle.Name = "boxTitle";
            this.boxTitle.Size = new System.Drawing.Size(145, 20);
            this.boxTitle.TabIndex = 4;
            // 
            // boxAuthor
            // 
            this.boxAuthor.Location = new System.Drawing.Point(80, 56);
            this.boxAuthor.Name = "boxAuthor";
            this.boxAuthor.Size = new System.Drawing.Size(145, 20);
            this.boxAuthor.TabIndex = 3;
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
            // boxSubject
            // 
            this.boxSubject.Location = new System.Drawing.Point(80, 108);
            this.boxSubject.Name = "boxSubject";
            this.boxSubject.Size = new System.Drawing.Size(145, 20);
            this.boxSubject.TabIndex = 5;
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
            this.dataGridView1.Location = new System.Drawing.Point(258, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(907, 509);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
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
            this.Column6.HeaderText = "Subject";
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
            // btnNewStock
            // 
            this.btnNewStock.Location = new System.Drawing.Point(94, 404);
            this.btnNewStock.Name = "btnNewStock";
            this.btnNewStock.Size = new System.Drawing.Size(145, 33);
            this.btnNewStock.TabIndex = 9;
            this.btnNewStock.Text = "&New Stock";
            this.btnNewStock.UseVisualStyleBackColor = true;
            this.btnNewStock.Click += new System.EventHandler(this.btnNewStock_Click);
            // 
            // btnStockDetails
            // 
            this.btnStockDetails.Enabled = false;
            this.btnStockDetails.Location = new System.Drawing.Point(258, 551);
            this.btnStockDetails.Name = "btnStockDetails";
            this.btnStockDetails.Size = new System.Drawing.Size(186, 40);
            this.btnStockDetails.TabIndex = 12;
            this.btnStockDetails.Text = "Stock Details";
            this.btnStockDetails.UseVisualStyleBackColor = true;
            this.btnStockDetails.Click += new System.EventHandler(this.btnStockDetails_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkExactPhrase);
            this.groupBox1.Controls.Add(this.rdoInStock);
            this.groupBox1.Controls.Add(this.rdoAllStock);
            this.groupBox1.Controls.Add(this.boxSubject);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.boxBookID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.boxTitle);
            this.groupBox1.Controls.Add(this.boxAuthor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 59);
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
            this.checkExactPhrase.TabIndex = 8;
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
            // labResults
            // 
            this.labResults.AutoSize = true;
            this.labResults.Location = new System.Drawing.Point(347, 527);
            this.labResults.Name = "labResults";
            this.labResults.Size = new System.Drawing.Size(13, 13);
            this.labResults.TabIndex = 34;
            this.labResults.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(255, 527);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Number of results:";
            // 
            // StockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 610);
            this.Controls.Add(this.labResults);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStockDetails);
            this.Controls.Add(this.btnNewStock);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnImportStock);
            this.Controls.Add(this.btnMainMenu);
            this.Name = "StockForm";
            this.Text = "Stock Search";
            this.Activated += new System.EventHandler(this.StockForm_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnImportStock;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox boxBookID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox boxTitle;
        private System.Windows.Forms.TextBox boxAuthor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox boxSubject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnNewStock;
        private System.Windows.Forms.Button btnStockDetails;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoInStock;
        private System.Windows.Forms.RadioButton rdoAllStock;
        private System.Windows.Forms.Label labResults;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.CheckBox checkExactPhrase;
    }
}