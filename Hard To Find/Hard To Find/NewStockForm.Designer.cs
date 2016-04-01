﻿namespace Hard_To_Find
{
    partial class NewStockForm
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
            this.boxDateEntered = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.boxBookID = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.boxSales = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.boxCatalogues = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.boxSubject = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.boxPrice = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.boxComment = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.boxDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.boxPublisher = new System.Windows.Forms.TextBox();
            this.boxSubtitle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.boxTitle = new System.Windows.Forms.TextBox();
            this.boxAuthor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.boxNote = new System.Windows.Forms.TextBox();
            this.boxQuantity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.boxInitials = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(401, 367);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 34);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(84, 367);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 34);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // boxDateEntered
            // 
            this.boxDateEntered.Location = new System.Drawing.Point(379, 229);
            this.boxDateEntered.Name = "boxDateEntered";
            this.boxDateEntered.Size = new System.Drawing.Size(211, 20);
            this.boxDateEntered.TabIndex = 14;
            this.boxDateEntered.Enter += textbox_Enter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(300, 232);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(73, 13);
            this.label16.TabIndex = 102;
            this.label16.Text = "Date Entered:";
            // 
            // boxBookID
            // 
            this.boxBookID.Location = new System.Drawing.Point(379, 204);
            this.boxBookID.Name = "boxBookID";
            this.boxBookID.Size = new System.Drawing.Size(211, 20);
            this.boxBookID.TabIndex = 13;
            this.boxBookID.Enter += textbox_Enter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(324, 207);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 101;
            this.label15.Text = "Book ID:";
            // 
            // boxSales
            // 
            this.boxSales.Location = new System.Drawing.Point(379, 178);
            this.boxSales.Name = "boxSales";
            this.boxSales.Size = new System.Drawing.Size(211, 20);
            this.boxSales.TabIndex = 12;
            this.boxSales.Enter += textbox_Enter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(337, 181);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 13);
            this.label13.TabIndex = 100;
            this.label13.Text = "Sales:";
            // 
            // boxCatalogues
            // 
            this.boxCatalogues.Location = new System.Drawing.Point(379, 151);
            this.boxCatalogues.Name = "boxCatalogues";
            this.boxCatalogues.Size = new System.Drawing.Size(211, 20);
            this.boxCatalogues.TabIndex = 11;
            this.boxCatalogues.Enter += textbox_Enter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(310, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 99;
            this.label9.Text = "Catalogues:";
            // 
            // boxSubject
            // 
            this.boxSubject.Location = new System.Drawing.Point(379, 59);
            this.boxSubject.Multiline = true;
            this.boxSubject.Name = "boxSubject";
            this.boxSubject.Size = new System.Drawing.Size(211, 86);
            this.boxSubject.TabIndex = 10;
            this.boxSubject.Enter += textbox_Enter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(327, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 98;
            this.label10.Text = "Subject:";
            // 
            // boxPrice
            // 
            this.boxPrice.Location = new System.Drawing.Point(379, 26);
            this.boxPrice.Name = "boxPrice";
            this.boxPrice.Size = new System.Drawing.Size(211, 20);
            this.boxPrice.TabIndex = 9;
            this.boxPrice.Leave += new System.EventHandler(this.boxPrice_Leave);
            this.boxPrice.Enter += textbox_Enter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(339, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 97;
            this.label11.Text = "Price:";
            // 
            // boxComment
            // 
            this.boxComment.Location = new System.Drawing.Point(83, 229);
            this.boxComment.Multiline = true;
            this.boxComment.Name = "boxComment";
            this.boxComment.Size = new System.Drawing.Size(211, 23);
            this.boxComment.TabIndex = 7;
            this.boxComment.Enter += textbox_Enter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 96;
            this.label8.Text = "Comment:";
            // 
            // boxDescription
            // 
            this.boxDescription.Location = new System.Drawing.Point(84, 266);
            this.boxDescription.Multiline = true;
            this.boxDescription.Name = "boxDescription";
            this.boxDescription.Size = new System.Drawing.Size(506, 90);
            this.boxDescription.TabIndex = 8;
            this.boxDescription.Enter += textbox_Enter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 269);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 95;
            this.label7.Text = "Description:";
            // 
            // boxPublisher
            // 
            this.boxPublisher.Location = new System.Drawing.Point(83, 204);
            this.boxPublisher.Name = "boxPublisher";
            this.boxPublisher.Size = new System.Drawing.Size(211, 20);
            this.boxPublisher.TabIndex = 6;
            this.boxPublisher.Enter += textbox_Enter;
            // 
            // boxSubtitle
            // 
            this.boxSubtitle.Location = new System.Drawing.Point(83, 178);
            this.boxSubtitle.Name = "boxSubtitle";
            this.boxSubtitle.Size = new System.Drawing.Size(211, 20);
            this.boxSubtitle.TabIndex = 5;
            this.boxSubtitle.Enter += textbox_Enter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 94;
            this.label5.Text = "Publisher:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 93;
            this.label6.Text = "Subtitle:";
            // 
            // boxTitle
            // 
            this.boxTitle.Location = new System.Drawing.Point(84, 133);
            this.boxTitle.Multiline = true;
            this.boxTitle.Name = "boxTitle";
            this.boxTitle.Size = new System.Drawing.Size(211, 39);
            this.boxTitle.TabIndex = 4;
            this.boxTitle.Enter += textbox_Enter;
            // 
            // boxAuthor
            // 
            this.boxAuthor.Location = new System.Drawing.Point(84, 107);
            this.boxAuthor.Name = "boxAuthor";
            this.boxAuthor.Size = new System.Drawing.Size(211, 20);
            this.boxAuthor.TabIndex = 3;
            this.boxAuthor.Enter += textbox_Enter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 92;
            this.label3.Text = "Title:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 91;
            this.label4.Text = "Author:";
            // 
            // boxNote
            // 
            this.boxNote.Location = new System.Drawing.Point(84, 59);
            this.boxNote.Multiline = true;
            this.boxNote.Name = "boxNote";
            this.boxNote.Size = new System.Drawing.Size(211, 44);
            this.boxNote.TabIndex = 2;
            this.boxNote.Enter += textbox_Enter;
            // 
            // boxQuantity
            // 
            this.boxQuantity.Location = new System.Drawing.Point(84, 29);
            this.boxQuantity.Name = "boxQuantity";
            this.boxQuantity.Size = new System.Drawing.Size(211, 20);
            this.boxQuantity.TabIndex = 1;
            this.boxQuantity.Text = "1";
            this.boxQuantity.Enter += textbox_Enter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 90;
            this.label2.Text = "Note:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 89;
            this.label1.Text = "Quantity:";
            // 
            // boxInitials
            // 
            this.boxInitials.Location = new System.Drawing.Point(647, 59);
            this.boxInitials.Name = "boxInitials";
            this.boxInitials.Size = new System.Drawing.Size(211, 20);
            this.boxInitials.TabIndex = 103;
            this.boxInitials.Enter += textbox_Enter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(605, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 104;
            this.label12.Text = "Initials:";
            // 
            // NewStockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 421);
            this.Controls.Add(this.boxInitials);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.boxDateEntered);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.boxBookID);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.boxSales);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.boxCatalogues);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.boxSubject);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.boxPrice);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.boxComment);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.boxDescription);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.boxPublisher);
            this.Controls.Add(this.boxSubtitle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.boxTitle);
            this.Controls.Add(this.boxAuthor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.boxNote);
            this.Controls.Add(this.boxQuantity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "NewStockForm";
            this.Text = "New Stock";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox boxDateEntered;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox boxBookID;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox boxSales;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox boxCatalogues;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox boxSubject;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox boxPrice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox boxComment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox boxDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox boxPublisher;
        private System.Windows.Forms.TextBox boxSubtitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox boxTitle;
        private System.Windows.Forms.TextBox boxAuthor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox boxNote;
        private System.Windows.Forms.TextBox boxQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox boxInitials;
        private System.Windows.Forms.Label label12;

    }
}