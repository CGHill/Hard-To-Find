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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnABEExport
            // 
            this.btnABEExport.Location = new System.Drawing.Point(61, 43);
            this.btnABEExport.Name = "btnABEExport";
            this.btnABEExport.Size = new System.Drawing.Size(149, 37);
            this.btnABEExport.TabIndex = 0;
            this.btnABEExport.Text = "ABEInternetExport";
            this.btnABEExport.UseVisualStyleBackColor = true;
            this.btnABEExport.Click += new System.EventHandler(this.btnABEExport_Click);
            // 
            // btnHTFExport
            // 
            this.btnHTFExport.Location = new System.Drawing.Point(61, 98);
            this.btnHTFExport.Name = "btnHTFExport";
            this.btnHTFExport.Size = new System.Drawing.Size(149, 37);
            this.btnHTFExport.TabIndex = 1;
            this.btnHTFExport.Text = "HTFInternetExport";
            this.btnHTFExport.UseVisualStyleBackColor = true;
            this.btnHTFExport.Click += new System.EventHandler(this.btnHTFExport_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(61, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "Main Menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FileExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 316);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnHTFExport);
            this.Controls.Add(this.btnABEExport);
            this.Name = "FileExportForm";
            this.Text = "File Export";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnABEExport;
        private System.Windows.Forms.Button btnHTFExport;
        private System.Windows.Forms.Button button1;
    }
}