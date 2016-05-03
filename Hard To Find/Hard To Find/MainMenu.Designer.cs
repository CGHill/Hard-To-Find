namespace Hard_To_Find
{
    partial class MainMenu
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
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnFileExports = new System.Windows.Forms.Button();
            this.btnImports = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnSetup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCustomers
            // 
            this.btnCustomers.Location = new System.Drawing.Point(74, 61);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(123, 37);
            this.btnCustomers.TabIndex = 0;
            this.btnCustomers.Text = "&Customers";
            this.btnCustomers.UseVisualStyleBackColor = true;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnStock
            // 
            this.btnStock.Location = new System.Drawing.Point(74, 124);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(123, 37);
            this.btnStock.TabIndex = 1;
            this.btnStock.Text = "&Stock";
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnOrders
            // 
            this.btnOrders.Location = new System.Drawing.Point(74, 191);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(123, 37);
            this.btnOrders.TabIndex = 2;
            this.btnOrders.Text = "&Orders";
            this.btnOrders.UseVisualStyleBackColor = true;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(236, 61);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(123, 37);
            this.btnReports.TabIndex = 3;
            this.btnReports.Text = "&Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(74, 293);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(445, 37);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnFileExports
            // 
            this.btnFileExports.Location = new System.Drawing.Point(236, 124);
            this.btnFileExports.Name = "btnFileExports";
            this.btnFileExports.Size = new System.Drawing.Size(123, 37);
            this.btnFileExports.TabIndex = 4;
            this.btnFileExports.Text = "&File Exports";
            this.btnFileExports.UseVisualStyleBackColor = true;
            this.btnFileExports.Click += new System.EventHandler(this.btnFileExports_Click);
            // 
            // btnImports
            // 
            this.btnImports.Location = new System.Drawing.Point(236, 191);
            this.btnImports.Name = "btnImports";
            this.btnImports.Size = new System.Drawing.Size(123, 37);
            this.btnImports.TabIndex = 6;
            this.btnImports.Text = "&Imports";
            this.btnImports.UseVisualStyleBackColor = true;
            this.btnImports.Click += new System.EventHandler(this.btnImports_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(396, 61);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(123, 37);
            this.btnBackup.TabIndex = 7;
            this.btnBackup.Text = "&Backup";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnSetup
            // 
            this.btnSetup.Location = new System.Drawing.Point(396, 124);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(123, 37);
            this.btnSetup.TabIndex = 9;
            this.btnSetup.Text = "Setup";
            this.btnSetup.UseVisualStyleBackColor = true;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 366);
            this.Controls.Add(this.btnSetup);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnImports);
            this.Controls.Add(this.btnFileExports);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnOrders);
            this.Controls.Add(this.btnStock);
            this.Controls.Add(this.btnCustomers);
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnFileExports;
        private System.Windows.Forms.Button btnImports;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnSetup;
    }
}

