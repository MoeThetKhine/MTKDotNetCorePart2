﻿namespace MTKDotNetCorePart2.WindowFormsApp
{
    partial class FrmBlog
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            label2 = new Label();
            txtContent = new TextBox();
            label3 = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(274, 96);
            label1.Name = "label1";
            label1.Size = new Size(53, 25);
            label1.TabIndex = 1;
            label1.Text = "Title :";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(419, 96);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(150, 31);
            txtTitle.TabIndex = 2;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(419, 159);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(150, 31);
            txtAuthor.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(274, 159);
            label2.Name = "label2";
            label2.Size = new Size(76, 25);
            label2.TabIndex = 3;
            label2.Text = "Author :";
            // 
            // txtContent
            // 
            txtContent.Location = new Point(419, 218);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(150, 31);
            txtContent.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(274, 218);
            label3.Name = "label3";
            label3.Size = new Size(84, 25);
            label3.TabIndex = 5;
            label3.Text = "Content :";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(26, 35, 126);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(274, 299);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(113, 41);
            btnSave.TabIndex = 7;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(26, 35, 126);
            btnCancel.FlatAppearance.BorderSize = 2;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.FromArgb(26, 35, 126);
            btnCancel.Location = new Point(457, 299);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(113, 41);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // FrmBlog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtContent);
            Controls.Add(label3);
            Controls.Add(txtAuthor);
            Controls.Add(label2);
            Controls.Add(txtTitle);
            Controls.Add(label1);
            Name = "FrmBlog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private Label label2;
        private TextBox txtContent;
        private Label label3;
        private Button btnSave;
        private Button btnCancel;
    }
}
