namespace Hard_To_Find
{
    partial class NewCustomerForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.boxPayment = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.boxSales = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.boxComments = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.boxEmail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
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
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(429, 243);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 34);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(80, 243);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 34);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // boxPayment
            // 
            this.boxPayment.Location = new System.Drawing.Point(348, 203);
            this.boxPayment.Name = "boxPayment";
            this.boxPayment.Size = new System.Drawing.Size(189, 20);
            this.boxPayment.TabIndex = 11;
            this.boxPayment.Enter += textbox_Enter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(291, 206);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 57;
            this.label13.Text = "Payment:";
            // 
            // boxSales
            // 
            this.boxSales.Location = new System.Drawing.Point(348, 177);
            this.boxSales.Name = "boxSales";
            this.boxSales.Size = new System.Drawing.Size(189, 20);
            this.boxSales.TabIndex = 10;
            this.boxSales.Enter += textbox_Enter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(305, 180);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 13);
            this.label14.TabIndex = 56;
            this.label14.Text = "Sales:";
            // 
            // boxComments
            // 
            this.boxComments.Location = new System.Drawing.Point(348, 96);
            this.boxComments.Multiline = true;
            this.boxComments.Name = "boxComments";
            this.boxComments.Size = new System.Drawing.Size(189, 75);
            this.boxComments.TabIndex = 9;
            this.boxComments.Enter += textbox_Enter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(282, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 55;
            this.label9.Text = "Comments:";
            // 
            // boxEmail
            // 
            this.boxEmail.Location = new System.Drawing.Point(348, 70);
            this.boxEmail.Name = "boxEmail";
            this.boxEmail.Size = new System.Drawing.Size(189, 20);
            this.boxEmail.TabIndex = 8;
            this.boxEmail.Enter += textbox_Enter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(306, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 54;
            this.label10.Text = "Email:";
            // 
            // boxCountry
            // 
            this.boxCountry.Location = new System.Drawing.Point(348, 44);
            this.boxCountry.Name = "boxCountry";
            this.boxCountry.Size = new System.Drawing.Size(190, 20);
            this.boxCountry.TabIndex = 7;
            this.boxCountry.Enter += textbox_Enter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(295, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 53;
            this.label8.Text = "Country:";
            // 
            // boxPostcode
            // 
            this.boxPostcode.Location = new System.Drawing.Point(80, 203);
            this.boxPostcode.Name = "boxPostcode";
            this.boxPostcode.Size = new System.Drawing.Size(190, 20);
            this.boxPostcode.TabIndex = 6;
            this.boxPostcode.Enter += textbox_Enter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 52;
            this.label7.Text = "Post Code:";
            // 
            // boxAddress3
            // 
            this.boxAddress3.Location = new System.Drawing.Point(80, 177);
            this.boxAddress3.Name = "boxAddress3";
            this.boxAddress3.Size = new System.Drawing.Size(190, 20);
            this.boxAddress3.TabIndex = 5;
            this.boxAddress3.Enter += textbox_Enter;
            // 
            // boxAddress2
            // 
            this.boxAddress2.Location = new System.Drawing.Point(80, 151);
            this.boxAddress2.Name = "boxAddress2";
            this.boxAddress2.Size = new System.Drawing.Size(190, 20);
            this.boxAddress2.TabIndex = 4;
            this.boxAddress2.Enter += textbox_Enter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "Address3:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "Address2:";
            // 
            // boxAddress1
            // 
            this.boxAddress1.Location = new System.Drawing.Point(80, 122);
            this.boxAddress1.Name = "boxAddress1";
            this.boxAddress1.Size = new System.Drawing.Size(190, 20);
            this.boxAddress1.TabIndex = 3;
            this.boxAddress1.Enter += textbox_Enter;
            // 
            // boxInstitution
            // 
            this.boxInstitution.Location = new System.Drawing.Point(80, 96);
            this.boxInstitution.Name = "boxInstitution";
            this.boxInstitution.Size = new System.Drawing.Size(190, 20);
            this.boxInstitution.TabIndex = 2;
            this.boxInstitution.Enter += textbox_Enter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Address1:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Institution:";
            // 
            // boxLastName
            // 
            this.boxLastName.Location = new System.Drawing.Point(80, 70);
            this.boxLastName.Name = "boxLastName";
            this.boxLastName.Size = new System.Drawing.Size(190, 20);
            this.boxLastName.TabIndex = 1;
            this.boxLastName.Enter += textbox_Enter;
            // 
            // boxFirstName
            // 
            this.boxFirstName.Location = new System.Drawing.Point(80, 44);
            this.boxFirstName.Name = "boxFirstName";
            this.boxFirstName.Size = new System.Drawing.Size(190, 20);
            this.boxFirstName.TabIndex = 0;
            this.boxFirstName.Enter += textbox_Enter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Last Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "First Name:";
            // 
            // NewCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 317);
            this.Controls.Add(this.boxPayment);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.boxSales);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.boxComments);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.boxEmail);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.boxCountry);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.boxPostcode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.boxAddress3);
            this.Controls.Add(this.boxAddress2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.boxAddress1);
            this.Controls.Add(this.boxInstitution);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.boxLastName);
            this.Controls.Add(this.boxFirstName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "NewCustomerForm";
            this.Text = "New Customer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox boxPayment;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox boxSales;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox boxComments;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox boxEmail;
        private System.Windows.Forms.Label label10;
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
    }
}