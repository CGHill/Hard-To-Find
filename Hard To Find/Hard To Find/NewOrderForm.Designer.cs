namespace Hard_To_Find
{
    partial class NewOrderForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNewCustomer = new System.Windows.Forms.Button();
            this.btnFindCustomer = new System.Windows.Forms.Button();
            this.boxCountry = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.boxPostcode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.boxAddress3 = new System.Windows.Forms.TextBox();
            this.boxAddress2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.boxAddress1 = new System.Windows.Forms.TextBox();
            this.boxInstitution = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.boxLastName = new System.Windows.Forms.TextBox();
            this.boxFirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.boxInvoiceDate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.boxFreight = new System.Windows.Forms.TextBox();
            this.boxProgress = new System.Windows.Forms.TextBox();
            this.boxOrderRef = new System.Windows.Forms.TextBox();
            this.boxComments = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.labOrderID = new System.Windows.Forms.Label();
            this.btnSaveOrder = new System.Windows.Forms.Button();
            this.boxInvoiceNo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(693, 530);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 34);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridView1.Location = new System.Drawing.Point(12, 358);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(775, 150);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseUp);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Quantity";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Author";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Title";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Price";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "BookID";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Discount:";
            this.Column6.Name = "Column6";
            // 
            // btnAddBook
            // 
            this.btnAddBook.Location = new System.Drawing.Point(12, 318);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(108, 34);
            this.btnAddBook.TabIndex = 2;
            this.btnAddBook.Text = "Add new book";
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnNewCustomer);
            this.groupBox1.Controls.Add(this.btnFindCustomer);
            this.groupBox1.Controls.Add(this.boxCountry);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.boxPostcode);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.boxAddress3);
            this.groupBox1.Controls.Add(this.boxAddress2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.boxAddress1);
            this.groupBox1.Controls.Add(this.boxInstitution);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.boxLastName);
            this.groupBox1.Controls.Add(this.boxFirstName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(184, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 189);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Information";
            // 
            // btnNewCustomer
            // 
            this.btnNewCustomer.Location = new System.Drawing.Point(335, 150);
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.Size = new System.Drawing.Size(151, 23);
            this.btnNewCustomer.TabIndex = 52;
            this.btnNewCustomer.Text = "New Customer";
            this.btnNewCustomer.UseVisualStyleBackColor = true;
            // 
            // btnFindCustomer
            // 
            this.btnFindCustomer.Location = new System.Drawing.Point(94, 150);
            this.btnFindCustomer.Name = "btnFindCustomer";
            this.btnFindCustomer.Size = new System.Drawing.Size(151, 23);
            this.btnFindCustomer.TabIndex = 51;
            this.btnFindCustomer.Text = "Find Customer";
            this.btnFindCustomer.UseVisualStyleBackColor = true;
            this.btnFindCustomer.Click += new System.EventHandler(this.btnFindCustomer_Click);
            // 
            // boxCountry
            // 
            this.boxCountry.Location = new System.Drawing.Point(341, 107);
            this.boxCountry.Name = "boxCountry";
            this.boxCountry.ReadOnly = true;
            this.boxCountry.Size = new System.Drawing.Size(145, 20);
            this.boxCountry.TabIndex = 50;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(288, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 49;
            this.label8.Text = "Country:";
            // 
            // boxPostcode
            // 
            this.boxPostcode.Location = new System.Drawing.Point(341, 81);
            this.boxPostcode.Name = "boxPostcode";
            this.boxPostcode.ReadOnly = true;
            this.boxPostcode.Size = new System.Drawing.Size(145, 20);
            this.boxPostcode.TabIndex = 48;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(275, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "Post Code:";
            // 
            // boxAddress3
            // 
            this.boxAddress3.Location = new System.Drawing.Point(341, 55);
            this.boxAddress3.Name = "boxAddress3";
            this.boxAddress3.ReadOnly = true;
            this.boxAddress3.Size = new System.Drawing.Size(145, 20);
            this.boxAddress3.TabIndex = 46;
            // 
            // boxAddress2
            // 
            this.boxAddress2.Location = new System.Drawing.Point(341, 29);
            this.boxAddress2.Name = "boxAddress2";
            this.boxAddress2.ReadOnly = true;
            this.boxAddress2.Size = new System.Drawing.Size(145, 20);
            this.boxAddress2.TabIndex = 45;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(281, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Address3:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(281, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "Address2:";
            // 
            // boxAddress1
            // 
            this.boxAddress1.Location = new System.Drawing.Point(100, 107);
            this.boxAddress1.Name = "boxAddress1";
            this.boxAddress1.ReadOnly = true;
            this.boxAddress1.Size = new System.Drawing.Size(145, 20);
            this.boxAddress1.TabIndex = 42;
            // 
            // boxInstitution
            // 
            this.boxInstitution.Location = new System.Drawing.Point(100, 81);
            this.boxInstitution.Name = "boxInstitution";
            this.boxInstitution.ReadOnly = true;
            this.boxInstitution.Size = new System.Drawing.Size(145, 20);
            this.boxInstitution.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Address1:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Institution:";
            // 
            // boxLastName
            // 
            this.boxLastName.Location = new System.Drawing.Point(100, 55);
            this.boxLastName.Name = "boxLastName";
            this.boxLastName.ReadOnly = true;
            this.boxLastName.Size = new System.Drawing.Size(145, 20);
            this.boxLastName.TabIndex = 38;
            // 
            // boxFirstName
            // 
            this.boxFirstName.Location = new System.Drawing.Point(100, 29);
            this.boxFirstName.Name = "boxFirstName";
            this.boxFirstName.ReadOnly = true;
            this.boxFirstName.Size = new System.Drawing.Size(145, 20);
            this.boxFirstName.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Last Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "First Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.boxInvoiceDate);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.boxFreight);
            this.groupBox2.Controls.Add(this.boxProgress);
            this.groupBox2.Controls.Add(this.boxOrderRef);
            this.groupBox2.Controls.Add(this.boxComments);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.labOrderID);
            this.groupBox2.Location = new System.Drawing.Point(184, 207);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(512, 113);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Order Details";
            // 
            // boxInvoiceDate
            // 
            this.boxInvoiceDate.Location = new System.Drawing.Point(103, 81);
            this.boxInvoiceDate.Name = "boxInvoiceDate";
            this.boxInvoiceDate.Size = new System.Drawing.Size(142, 20);
            this.boxInvoiceDate.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "Invoice Date:";
            // 
            // boxFreight
            // 
            this.boxFreight.Location = new System.Drawing.Point(344, 23);
            this.boxFreight.Name = "boxFreight";
            this.boxFreight.Size = new System.Drawing.Size(142, 20);
            this.boxFreight.TabIndex = 5;
            this.boxFreight.Text = "$0.00";
            // 
            // boxProgress
            // 
            this.boxProgress.Location = new System.Drawing.Point(103, 55);
            this.boxProgress.Name = "boxProgress";
            this.boxProgress.Size = new System.Drawing.Size(142, 20);
            this.boxProgress.TabIndex = 3;
            // 
            // boxOrderRef
            // 
            this.boxOrderRef.Location = new System.Drawing.Point(103, 29);
            this.boxOrderRef.Name = "boxOrderRef";
            this.boxOrderRef.Size = new System.Drawing.Size(142, 20);
            this.boxOrderRef.TabIndex = 2;
            // 
            // boxComments
            // 
            this.boxComments.Location = new System.Drawing.Point(344, 53);
            this.boxComments.Multiline = true;
            this.boxComments.Name = "boxComments";
            this.boxComments.Size = new System.Drawing.Size(142, 48);
            this.boxComments.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(279, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Comments:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(296, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Freight:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(46, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Progress:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Order Reference:";
            // 
            // labOrderID
            // 
            this.labOrderID.AutoSize = true;
            this.labOrderID.Location = new System.Drawing.Point(103, 40);
            this.labOrderID.Name = "labOrderID";
            this.labOrderID.Size = new System.Drawing.Size(0, 13);
            this.labOrderID.TabIndex = 23;
            // 
            // btnSaveOrder
            // 
            this.btnSaveOrder.Location = new System.Drawing.Point(12, 530);
            this.btnSaveOrder.Name = "btnSaveOrder";
            this.btnSaveOrder.Size = new System.Drawing.Size(108, 34);
            this.btnSaveOrder.TabIndex = 5;
            this.btnSaveOrder.Text = "Save Order";
            this.btnSaveOrder.UseVisualStyleBackColor = true;
            this.btnSaveOrder.Click += new System.EventHandler(this.btnSaveOrder_Click);
            // 
            // boxInvoiceNo
            // 
            this.boxInvoiceNo.Location = new System.Drawing.Point(65, 41);
            this.boxInvoiceNo.Name = "boxInvoiceNo";
            this.boxInvoiceNo.ReadOnly = true;
            this.boxInvoiceNo.Size = new System.Drawing.Size(97, 20);
            this.boxInvoiceNo.TabIndex = 54;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 44);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 53;
            this.label14.Text = "Invoice:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteRowToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            this.contextMenuStrip1.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // deleteRowToolStripMenuItem
            // 
            this.deleteRowToolStripMenuItem.Name = "deleteRowToolStripMenuItem";
            this.deleteRowToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteRowToolStripMenuItem.Text = "Delete Row";
            // 
            // NewOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 576);
            this.Controls.Add(this.boxInvoiceNo);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnSaveOrder);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAddBook);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnClose);
            this.Name = "NewOrderForm";
            this.Text = "NewOrderForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox boxCountry;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox boxPostcode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox boxAddress3;
        private System.Windows.Forms.TextBox boxAddress2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox boxAddress1;
        private System.Windows.Forms.TextBox boxInstitution;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox boxLastName;
        private System.Windows.Forms.TextBox boxFirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNewCustomer;
        private System.Windows.Forms.Button btnFindCustomer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox boxInvoiceDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox boxFreight;
        private System.Windows.Forms.TextBox boxProgress;
        private System.Windows.Forms.TextBox boxOrderRef;
        private System.Windows.Forms.TextBox boxComments;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label labOrderID;
        private System.Windows.Forms.Button btnSaveOrder;
        private System.Windows.Forms.TextBox boxInvoiceNo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteRowToolStripMenuItem;
    }
}