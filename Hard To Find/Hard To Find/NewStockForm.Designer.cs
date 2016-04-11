namespace Hard_To_Find
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
            this.labEntryCounter = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.boxInitials = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labEntryCounter
            // 
            this.labEntryCounter.AutoSize = true;
            this.labEntryCounter.Location = new System.Drawing.Point(677, 99);
            this.labEntryCounter.Name = "labEntryCounter";
            this.labEntryCounter.Size = new System.Drawing.Size(30, 13);
            this.labEntryCounter.TabIndex = 145;
            this.labEntryCounter.Text = "1 / 1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(637, 99);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 13);
            this.label14.TabIndex = 144;
            this.label14.Text = "Entry:";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(734, 118);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(91, 34);
            this.btnNext.TabIndex = 17;
            this.btnNext.Text = "&Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Enabled = false;
            this.btnPrev.Location = new System.Drawing.Point(637, 118);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(91, 34);
            this.btnPrev.TabIndex = 16;
            this.btnPrev.Text = "&Previous";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // boxInitials
            // 
            this.boxInitials.Location = new System.Drawing.Point(393, 180);
            this.boxInitials.Name = "boxInitials";
            this.boxInitials.Size = new System.Drawing.Size(211, 20);
            this.boxInitials.TabIndex = 12;
            this.boxInitials.Enter += textbox_Enter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(351, 183);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 141;
            this.label12.Text = "Initials:";
            // 
            // boxDateEntered
            // 
            this.boxDateEntered.Location = new System.Drawing.Point(393, 258);
            this.boxDateEntered.Name = "boxDateEntered";
            this.boxDateEntered.Size = new System.Drawing.Size(211, 20);
            this.boxDateEntered.TabIndex = 15;
            this.boxDateEntered.Enter += textbox_Enter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(314, 261);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(73, 13);
            this.label16.TabIndex = 139;
            this.label16.Text = "Date Entered:";
            // 
            // boxBookID
            // 
            this.boxBookID.Location = new System.Drawing.Point(393, 232);
            this.boxBookID.Name = "boxBookID";
            this.boxBookID.Size = new System.Drawing.Size(211, 20);
            this.boxBookID.TabIndex = 14;
            this.boxBookID.Enter += textbox_Enter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(338, 235);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 138;
            this.label15.Text = "Book ID:";
            // 
            // boxSales
            // 
            this.boxSales.Location = new System.Drawing.Point(393, 206);
            this.boxSales.Name = "boxSales";
            this.boxSales.Size = new System.Drawing.Size(211, 20);
            this.boxSales.TabIndex = 13;
            this.boxSales.Enter += textbox_Enter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(351, 209);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 13);
            this.label13.TabIndex = 137;
            this.label13.Text = "Sales:";
            // 
            // boxCatalogues
            // 
            this.boxCatalogues.Location = new System.Drawing.Point(393, 154);
            this.boxCatalogues.Name = "boxCatalogues";
            this.boxCatalogues.Size = new System.Drawing.Size(211, 20);
            this.boxCatalogues.TabIndex = 11;
            this.boxCatalogues.Enter += textbox_Enter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(324, 157);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 136;
            this.label9.Text = "Catalogues:";
            // 
            // boxSubject
            // 
            this.boxSubject.Location = new System.Drawing.Point(393, 76);
            this.boxSubject.Multiline = true;
            this.boxSubject.Name = "boxSubject";
            this.boxSubject.Size = new System.Drawing.Size(211, 72);
            this.boxSubject.TabIndex = 10;
            this.boxSubject.Enter += textbox_Enter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(341, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 135;
            this.label10.Text = "Subject:";
            // 
            // boxPrice
            // 
            this.boxPrice.Location = new System.Drawing.Point(393, 50);
            this.boxPrice.Name = "boxPrice";
            this.boxPrice.Size = new System.Drawing.Size(211, 20);
            this.boxPrice.TabIndex = 9;
            this.boxPrice.Leave += new System.EventHandler(this.boxPrice_Leave);
            this.boxPrice.Enter += textbox_Enter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(353, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 134;
            this.label11.Text = "Price:";
            // 
            // boxComment
            // 
            this.boxComment.Location = new System.Drawing.Point(89, 261);
            this.boxComment.Multiline = true;
            this.boxComment.Name = "boxComment";
            this.boxComment.Size = new System.Drawing.Size(212, 20);
            this.boxComment.TabIndex = 7;
            this.boxComment.Enter += textbox_Enter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 261);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 133;
            this.label8.Text = "Comment:";
            // 
            // boxDescription
            // 
            this.boxDescription.Location = new System.Drawing.Point(89, 287);
            this.boxDescription.Multiline = true;
            this.boxDescription.Name = "boxDescription";
            this.boxDescription.Size = new System.Drawing.Size(515, 90);
            this.boxDescription.TabIndex = 8;
            this.boxDescription.Enter += textbox_Enter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 290);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 132;
            this.label7.Text = "Description:";
            // 
            // boxPublisher
            // 
            this.boxPublisher.Location = new System.Drawing.Point(90, 210);
            this.boxPublisher.Multiline = true;
            this.boxPublisher.Name = "boxPublisher";
            this.boxPublisher.Size = new System.Drawing.Size(211, 45);
            this.boxPublisher.TabIndex = 6;
            this.boxPublisher.Enter += textbox_Enter;
            // 
            // boxSubtitle
            // 
            this.boxSubtitle.Location = new System.Drawing.Point(90, 184);
            this.boxSubtitle.Name = "boxSubtitle";
            this.boxSubtitle.Size = new System.Drawing.Size(211, 20);
            this.boxSubtitle.TabIndex = 5;
            this.boxSubtitle.Enter += textbox_Enter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 131;
            this.label5.Text = "Publisher:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 130;
            this.label6.Text = "Subtitle:";
            // 
            // boxTitle
            // 
            this.boxTitle.Location = new System.Drawing.Point(90, 106);
            this.boxTitle.Multiline = true;
            this.boxTitle.Name = "boxTitle";
            this.boxTitle.Size = new System.Drawing.Size(211, 72);
            this.boxTitle.TabIndex = 4;
            this.boxTitle.Enter += textbox_Enter;
            // 
            // boxAuthor
            // 
            this.boxAuthor.Location = new System.Drawing.Point(90, 80);
            this.boxAuthor.Name = "boxAuthor";
            this.boxAuthor.Size = new System.Drawing.Size(211, 20);
            this.boxAuthor.TabIndex = 3;
            this.boxAuthor.Enter += textbox_Enter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 129;
            this.label3.Text = "Title:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 128;
            this.label4.Text = "Author:";
            // 
            // boxNote
            // 
            this.boxNote.Location = new System.Drawing.Point(89, 54);
            this.boxNote.Multiline = true;
            this.boxNote.Name = "boxNote";
            this.boxNote.Size = new System.Drawing.Size(212, 20);
            this.boxNote.TabIndex = 2;
            this.boxNote.Enter += textbox_Enter;
            // 
            // boxQuantity
            // 
            this.boxQuantity.Location = new System.Drawing.Point(90, 28);
            this.boxQuantity.Name = "boxQuantity";
            this.boxQuantity.Size = new System.Drawing.Size(211, 20);
            this.boxQuantity.TabIndex = 1;
            this.boxQuantity.Text = "1";
            this.boxQuantity.Enter += textbox_Enter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 127;
            this.label2.Text = "Note:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 126;
            this.label1.Text = "Quantity:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(669, 343);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 34);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(669, 290);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 34);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save && Exit";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // NewStockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 422);
            this.Controls.Add(this.labEntryCounter);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
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

        private System.Windows.Forms.Label labEntryCounter;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.TextBox boxInitials;
        private System.Windows.Forms.Label label12;
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
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;


    }
}