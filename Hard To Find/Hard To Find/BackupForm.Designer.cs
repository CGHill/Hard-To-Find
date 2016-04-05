namespace Hard_To_Find
{
    partial class BackupForm
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
            this.btnBackupFile = new System.Windows.Forms.Button();
            this.btnRestoreFile = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnBackupCSV = new System.Windows.Forms.Button();
            this.btnRestoreStock = new System.Windows.Forms.Button();
            this.btnRestoreCustomers = new System.Windows.Forms.Button();
            this.btnRestoreOrders = new System.Windows.Forms.Button();
            this.btnRestoreOrderedStock = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBackupFile
            // 
            this.btnBackupFile.Location = new System.Drawing.Point(6, 28);
            this.btnBackupFile.Name = "btnBackupFile";
            this.btnBackupFile.Size = new System.Drawing.Size(146, 34);
            this.btnBackupFile.TabIndex = 0;
            this.btnBackupFile.Text = "Backup database file";
            this.btnBackupFile.UseVisualStyleBackColor = true;
            this.btnBackupFile.Click += new System.EventHandler(this.btnBackupFile_Click);
            // 
            // btnRestoreFile
            // 
            this.btnRestoreFile.Location = new System.Drawing.Point(6, 26);
            this.btnRestoreFile.Name = "btnRestoreFile";
            this.btnRestoreFile.Size = new System.Drawing.Size(146, 34);
            this.btnRestoreFile.TabIndex = 1;
            this.btnRestoreFile.Text = "Restore from database file";
            this.btnRestoreFile.UseVisualStyleBackColor = true;
            this.btnRestoreFile.Click += new System.EventHandler(this.btnRestoreFile_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Location = new System.Drawing.Point(153, 347);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(127, 34);
            this.btnMainMenu.TabIndex = 2;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnBackupCSV
            // 
            this.btnBackupCSV.Location = new System.Drawing.Point(229, 28);
            this.btnBackupCSV.Name = "btnBackupCSV";
            this.btnBackupCSV.Size = new System.Drawing.Size(151, 34);
            this.btnBackupCSV.TabIndex = 3;
            this.btnBackupCSV.Text = "Backup as CSV files";
            this.btnBackupCSV.UseVisualStyleBackColor = true;
            this.btnBackupCSV.Click += new System.EventHandler(this.btnBackupCSV_Click);
            // 
            // btnRestoreStock
            // 
            this.btnRestoreStock.Location = new System.Drawing.Point(225, 66);
            this.btnRestoreStock.Name = "btnRestoreStock";
            this.btnRestoreStock.Size = new System.Drawing.Size(151, 34);
            this.btnRestoreStock.TabIndex = 4;
            this.btnRestoreStock.Text = "Restore Stock from CSV";
            this.btnRestoreStock.UseVisualStyleBackColor = true;
            this.btnRestoreStock.Click += new System.EventHandler(this.btnRestoreStock_Click);
            // 
            // btnRestoreCustomers
            // 
            this.btnRestoreCustomers.Location = new System.Drawing.Point(225, 26);
            this.btnRestoreCustomers.Name = "btnRestoreCustomers";
            this.btnRestoreCustomers.Size = new System.Drawing.Size(151, 34);
            this.btnRestoreCustomers.TabIndex = 5;
            this.btnRestoreCustomers.Text = "Restore Customers from CSV";
            this.btnRestoreCustomers.UseVisualStyleBackColor = true;
            this.btnRestoreCustomers.Click += new System.EventHandler(this.btnRestoreCustomers_Click);
            // 
            // btnRestoreOrders
            // 
            this.btnRestoreOrders.Location = new System.Drawing.Point(225, 106);
            this.btnRestoreOrders.Name = "btnRestoreOrders";
            this.btnRestoreOrders.Size = new System.Drawing.Size(151, 34);
            this.btnRestoreOrders.TabIndex = 6;
            this.btnRestoreOrders.Text = "Restore Orders from CSV";
            this.btnRestoreOrders.UseVisualStyleBackColor = true;
            this.btnRestoreOrders.Click += new System.EventHandler(this.btnRestoreOrders_Click);
            // 
            // btnRestoreOrderedStock
            // 
            this.btnRestoreOrderedStock.Location = new System.Drawing.Point(225, 146);
            this.btnRestoreOrderedStock.Name = "btnRestoreOrderedStock";
            this.btnRestoreOrderedStock.Size = new System.Drawing.Size(151, 34);
            this.btnRestoreOrderedStock.TabIndex = 7;
            this.btnRestoreOrderedStock.Text = "Restore OrderedStock from CSV";
            this.btnRestoreOrderedStock.UseVisualStyleBackColor = true;
            this.btnRestoreOrderedStock.Click += new System.EventHandler(this.btnRestoreOrderedStock_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBackupFile);
            this.groupBox1.Controls.Add(this.btnBackupCSV);
            this.groupBox1.Location = new System.Drawing.Point(23, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 84);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create backups";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRestoreFile);
            this.groupBox2.Controls.Add(this.btnRestoreOrders);
            this.groupBox2.Controls.Add(this.btnRestoreOrderedStock);
            this.groupBox2.Controls.Add(this.btnRestoreStock);
            this.groupBox2.Controls.Add(this.btnRestoreCustomers);
            this.groupBox2.Location = new System.Drawing.Point(23, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 198);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Restoration";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(-3, 387);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(439, 16);
            this.progressBar1.TabIndex = 10;
            this.progressBar1.Visible = false;
            // 
            // BackupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 401);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnMainMenu);
            this.Name = "BackupForm";
            this.Text = "BackupForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBackupFile;
        private System.Windows.Forms.Button btnRestoreFile;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnBackupCSV;
        private System.Windows.Forms.Button btnRestoreStock;
        private System.Windows.Forms.Button btnRestoreCustomers;
        private System.Windows.Forms.Button btnRestoreOrders;
        private System.Windows.Forms.Button btnRestoreOrderedStock;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}