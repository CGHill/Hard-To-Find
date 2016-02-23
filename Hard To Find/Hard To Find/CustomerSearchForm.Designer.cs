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
            this.boxCustomerSearchResults = new System.Windows.Forms.ListBox();
            this.btnCustDetails = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // boxLastName
            // 
            this.boxLastName.Location = new System.Drawing.Point(87, 161);
            this.boxLastName.Name = "boxLastName";
            this.boxLastName.Size = new System.Drawing.Size(145, 20);
            this.boxLastName.TabIndex = 14;
            // 
            // boxFirstName
            // 
            this.boxFirstName.Location = new System.Drawing.Point(87, 135);
            this.boxFirstName.Name = "boxFirstName";
            this.boxFirstName.Size = new System.Drawing.Size(145, 20);
            this.boxFirstName.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Last Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "First Name:";
            // 
            // boxCustID
            // 
            this.boxCustID.Location = new System.Drawing.Point(87, 109);
            this.boxCustID.Name = "boxCustID";
            this.boxCustID.Size = new System.Drawing.Size(82, 20);
            this.boxCustID.TabIndex = 16;
            this.boxCustID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxCustID_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Customer ID:";
            // 
            // boxCustomerSearchResults
            // 
            this.boxCustomerSearchResults.FormattingEnabled = true;
            this.boxCustomerSearchResults.HorizontalScrollbar = true;
            this.boxCustomerSearchResults.Location = new System.Drawing.Point(286, 12);
            this.boxCustomerSearchResults.Name = "boxCustomerSearchResults";
            this.boxCustomerSearchResults.Size = new System.Drawing.Size(445, 316);
            this.boxCustomerSearchResults.TabIndex = 18;
            // 
            // btnCustDetails
            // 
            this.btnCustDetails.Enabled = false;
            this.btnCustDetails.Location = new System.Drawing.Point(402, 349);
            this.btnCustDetails.Name = "btnCustDetails";
            this.btnCustDetails.Size = new System.Drawing.Size(208, 23);
            this.btnCustDetails.TabIndex = 19;
            this.btnCustDetails.Text = "Customer Details";
            this.btnCustDetails.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(24, 197);
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
            // CustomerSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 384);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnCustDetails);
            this.Controls.Add(this.boxCustomerSearchResults);
            this.Controls.Add(this.boxCustID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.boxLastName);
            this.Controls.Add(this.boxFirstName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CustomerSearchForm";
            this.Text = "CustomerSearchForm";
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
        private System.Windows.Forms.ListBox boxCustomerSearchResults;
        private System.Windows.Forms.Button btnCustDetails;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnMainMenu;
    }
}