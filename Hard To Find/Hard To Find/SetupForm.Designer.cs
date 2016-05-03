namespace Hard_To_Find
{
    partial class SetupForm
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
            this.btnImportOrderedStock = new System.Windows.Forms.Button();
            this.btnImportOrders = new System.Windows.Forms.Button();
            this.btnImportStock = new System.Windows.Forms.Button();
            this.btnImportCustomers = new System.Windows.Forms.Button();
            this.btnSetStorageLocation = new System.Windows.Forms.Button();
            this.btnSetImportLocation = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnSetStockExport = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImportOrderedStock
            // 
            this.btnImportOrderedStock.Location = new System.Drawing.Point(67, 181);
            this.btnImportOrderedStock.Name = "btnImportOrderedStock";
            this.btnImportOrderedStock.Size = new System.Drawing.Size(145, 32);
            this.btnImportOrderedStock.TabIndex = 13;
            this.btnImportOrderedStock.Text = "Import OrderedStock";
            this.btnImportOrderedStock.UseVisualStyleBackColor = true;
            this.btnImportOrderedStock.Click += new System.EventHandler(this.btnImportOrderedStock_Click);
            // 
            // btnImportOrders
            // 
            this.btnImportOrders.Location = new System.Drawing.Point(67, 143);
            this.btnImportOrders.Name = "btnImportOrders";
            this.btnImportOrders.Size = new System.Drawing.Size(145, 32);
            this.btnImportOrders.TabIndex = 12;
            this.btnImportOrders.Text = "Import Orders";
            this.btnImportOrders.UseVisualStyleBackColor = true;
            this.btnImportOrders.Click += new System.EventHandler(this.btnImportOrders_Click);
            // 
            // btnImportStock
            // 
            this.btnImportStock.Location = new System.Drawing.Point(67, 105);
            this.btnImportStock.Name = "btnImportStock";
            this.btnImportStock.Size = new System.Drawing.Size(145, 32);
            this.btnImportStock.TabIndex = 11;
            this.btnImportStock.Text = "Import Stock";
            this.btnImportStock.UseVisualStyleBackColor = true;
            this.btnImportStock.Click += new System.EventHandler(this.btnImportStock_Click);
            // 
            // btnImportCustomers
            // 
            this.btnImportCustomers.Location = new System.Drawing.Point(67, 67);
            this.btnImportCustomers.Name = "btnImportCustomers";
            this.btnImportCustomers.Size = new System.Drawing.Size(145, 32);
            this.btnImportCustomers.TabIndex = 9;
            this.btnImportCustomers.Text = "Import Customers";
            this.btnImportCustomers.UseVisualStyleBackColor = true;
            this.btnImportCustomers.Click += new System.EventHandler(this.btnImportCustomers_Click);
            // 
            // btnSetStorageLocation
            // 
            this.btnSetStorageLocation.Location = new System.Drawing.Point(415, 77);
            this.btnSetStorageLocation.Name = "btnSetStorageLocation";
            this.btnSetStorageLocation.Size = new System.Drawing.Size(209, 32);
            this.btnSetStorageLocation.TabIndex = 8;
            this.btnSetStorageLocation.Text = "Set Storage &Location";
            this.btnSetStorageLocation.UseVisualStyleBackColor = true;
            this.btnSetStorageLocation.Click += new System.EventHandler(this.btnSetStorageLocation_Click);
            // 
            // btnSetImportLocation
            // 
            this.btnSetImportLocation.Location = new System.Drawing.Point(415, 162);
            this.btnSetImportLocation.Name = "btnSetImportLocation";
            this.btnSetImportLocation.Size = new System.Drawing.Size(209, 32);
            this.btnSetImportLocation.TabIndex = 9;
            this.btnSetImportLocation.Text = "Set Import Location";
            this.btnSetImportLocation.UseVisualStyleBackColor = true;
            this.btnSetImportLocation.Click += new System.EventHandler(this.btnSetImportLocation_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 26);
            this.label1.TabIndex = 14;
            this.label1.Text = "Used to setup the databases tables from CSV\'s\r\nthat are exported from the old Acc" +
                "ess database.\r";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnImportOrderedStock);
            this.groupBox1.Controls.Add(this.btnImportOrders);
            this.groupBox1.Controls.Add(this.btnImportStock);
            this.groupBox1.Controls.Add(this.btnImportCustomers);
            this.groupBox1.Location = new System.Drawing.Point(46, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 242);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Import tables from old database";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(397, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 52);
            this.label2.TabIndex = 16;
            this.label2.Text = "Used to set the storage location of files created by \r\nthis program.Those files i" +
                "nclude Invoices, Mailing Labels, \r\nSales Reports, Freight Reports,Export Files t" +
                "o upload to \r\nthe website";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(397, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(247, 26);
            this.label3.TabIndex = 17;
            this.label3.Text = "Used to set the location that the program will import\r\nnew catalogued stock from." +
                "";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 363);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(726, 14);
            this.progressBar1.TabIndex = 18;
            this.progressBar1.Visible = false;
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Location = new System.Drawing.Point(225, 323);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(257, 32);
            this.btnMainMenu.TabIndex = 19;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnSetStockExport
            // 
            this.btnSetStockExport.Location = new System.Drawing.Point(415, 230);
            this.btnSetStockExport.Name = "btnSetStockExport";
            this.btnSetStockExport.Size = new System.Drawing.Size(209, 32);
            this.btnSetStockExport.TabIndex = 20;
            this.btnSetStockExport.Text = "Set Stock Export Location";
            this.btnSetStockExport.UseVisualStyleBackColor = true;
            this.btnSetStockExport.Click += new System.EventHandler(this.btnSetStockExport_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(397, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(245, 26);
            this.label4.TabIndex = 21;
            this.label4.Text = "Used to set the location the program will export\r\nthe files that will update the " +
                "desk computers stock.";
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 375);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSetStockExport);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSetImportLocation);
            this.Controls.Add(this.btnSetStorageLocation);
            this.Name = "SetupForm";
            this.Text = "SetupForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImportOrderedStock;
        private System.Windows.Forms.Button btnImportOrders;
        private System.Windows.Forms.Button btnImportStock;
        private System.Windows.Forms.Button btnImportCustomers;
        private System.Windows.Forms.Button btnSetStorageLocation;
        private System.Windows.Forms.Button btnSetImportLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnSetStockExport;
        private System.Windows.Forms.Label label4;
    }
}