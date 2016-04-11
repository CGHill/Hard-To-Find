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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnSetImportLocation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAutoImport
            // 
            this.btnAutoImport.Location = new System.Drawing.Point(79, 29);
            this.btnAutoImport.Name = "btnAutoImport";
            this.btnAutoImport.Size = new System.Drawing.Size(138, 32);
            this.btnAutoImport.TabIndex = 0;
            this.btnAutoImport.Text = "Auto Import New Stock";
            this.btnAutoImport.UseVisualStyleBackColor = true;
            this.btnAutoImport.Click += new System.EventHandler(this.btnAutoImport_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(79, 67);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 32);
            this.button2.TabIndex = 1;
            this.button2.Text = "Manual Import New Stock";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(79, 211);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(138, 32);
            this.button3.TabIndex = 2;
            this.button3.Text = "Import From Old Database";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Location = new System.Drawing.Point(79, 285);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(138, 32);
            this.btnMainMenu.TabIndex = 3;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(-3, 347);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(302, 12);
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Visible = false;
            // 
            // btnSetImportLocation
            // 
            this.btnSetImportLocation.Location = new System.Drawing.Point(79, 124);
            this.btnSetImportLocation.Name = "btnSetImportLocation";
            this.btnSetImportLocation.Size = new System.Drawing.Size(138, 32);
            this.btnSetImportLocation.TabIndex = 5;
            this.btnSetImportLocation.Text = "Set Import Location";
            this.btnSetImportLocation.UseVisualStyleBackColor = true;
            this.btnSetImportLocation.Click += new System.EventHandler(this.btnSetImportLocation_Click);
            // 
            // ImportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 357);
            this.Controls.Add(this.btnSetImportLocation);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAutoImport);
            this.Name = "ImportsForm";
            this.Text = "ImportsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAutoImport;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnSetImportLocation;
    }
}