namespace Hard_To_Find
{
    partial class FileExportForm
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
            this.btnABEExport = new System.Windows.Forms.Button();
            this.btnHTFExport = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.checkAddHeaders = new System.Windows.Forms.CheckBox();
            this.btnExportEmails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnABEExport
            // 
            this.btnABEExport.Location = new System.Drawing.Point(61, 72);
            this.btnABEExport.Name = "btnABEExport";
            this.btnABEExport.Size = new System.Drawing.Size(149, 37);
            this.btnABEExport.TabIndex = 0;
            this.btnABEExport.Text = "ABEInternetExport";
            this.btnABEExport.UseVisualStyleBackColor = true;
            this.btnABEExport.Click += new System.EventHandler(this.btnABEExport_Click);
            // 
            // btnHTFExport
            // 
            this.btnHTFExport.Location = new System.Drawing.Point(61, 115);
            this.btnHTFExport.Name = "btnHTFExport";
            this.btnHTFExport.Size = new System.Drawing.Size(149, 37);
            this.btnHTFExport.TabIndex = 1;
            this.btnHTFExport.Text = "HTFInternetExport";
            this.btnHTFExport.UseVisualStyleBackColor = true;
            this.btnHTFExport.Click += new System.EventHandler(this.btnHTFExport_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Location = new System.Drawing.Point(61, 294);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(149, 37);
            this.btnMainMenu.TabIndex = 2;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // checkAddHeaders
            // 
            this.checkAddHeaders.AutoSize = true;
            this.checkAddHeaders.Checked = true;
            this.checkAddHeaders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAddHeaders.Location = new System.Drawing.Point(61, 33);
            this.checkAddHeaders.Name = "checkAddHeaders";
            this.checkAddHeaders.Size = new System.Drawing.Size(120, 17);
            this.checkAddHeaders.TabIndex = 3;
            this.checkAddHeaders.Text = "Add Headers To file";
            this.checkAddHeaders.UseVisualStyleBackColor = true;
            // 
            // btnExportEmails
            // 
            this.btnExportEmails.Location = new System.Drawing.Point(61, 158);
            this.btnExportEmails.Name = "btnExportEmails";
            this.btnExportEmails.Size = new System.Drawing.Size(149, 33);
            this.btnExportEmails.TabIndex = 4;
            this.btnExportEmails.Text = "Export Email CSV";
            this.btnExportEmails.UseVisualStyleBackColor = true;
            this.btnExportEmails.Click += new System.EventHandler(this.btnExportEmails_Click);
            // 
            // FileExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 343);
            this.Controls.Add(this.btnExportEmails);
            this.Controls.Add(this.checkAddHeaders);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnHTFExport);
            this.Controls.Add(this.btnABEExport);
            this.Name = "FileExportForm";
            this.Text = "File Export";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnABEExport;
        private System.Windows.Forms.Button btnHTFExport;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.CheckBox checkAddHeaders;
        private System.Windows.Forms.Button btnExportEmails;
    }
}