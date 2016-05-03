namespace Hard_To_Find
{
    partial class ImportsForm
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
            this.btnAutoImport = new System.Windows.Forms.Button();
            this.btnManualImport = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnAutoImport
            // 
            this.btnAutoImport.Location = new System.Drawing.Point(60, 43);
            this.btnAutoImport.Name = "btnAutoImport";
            this.btnAutoImport.Size = new System.Drawing.Size(138, 32);
            this.btnAutoImport.TabIndex = 0;
            this.btnAutoImport.Text = "Auto Import New Stock";
            this.btnAutoImport.UseVisualStyleBackColor = true;
            this.btnAutoImport.Click += new System.EventHandler(this.btnAutoImport_Click);
            // 
            // btnManualImport
            // 
            this.btnManualImport.Location = new System.Drawing.Point(60, 81);
            this.btnManualImport.Name = "btnManualImport";
            this.btnManualImport.Size = new System.Drawing.Size(138, 32);
            this.btnManualImport.TabIndex = 1;
            this.btnManualImport.Text = "Manual Import New Stock";
            this.btnManualImport.UseVisualStyleBackColor = true;
            this.btnManualImport.Click += new System.EventHandler(this.btnManualImport_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Location = new System.Drawing.Point(60, 151);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(138, 32);
            this.btnMainMenu.TabIndex = 4;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(-2, 215);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(263, 13);
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Visible = false;
            // 
            // ImportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 227);
            this.Controls.Add(this.btnManualImport);
            this.Controls.Add(this.btnAutoImport);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnMainMenu);
            this.Name = "ImportsForm";
            this.Text = "ImportsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAutoImport;
        private System.Windows.Forms.Button btnManualImport;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}