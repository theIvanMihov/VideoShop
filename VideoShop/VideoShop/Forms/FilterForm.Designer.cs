namespace VideoShop.Forms
{
    partial class FilterForm
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
            this.genreBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.leadName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.yearBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.Border = new System.Windows.Forms.Panel();
            this.close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // genreBox
            // 
            this.genreBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.genreBox.FormattingEnabled = true;
            this.genreBox.Location = new System.Drawing.Point(242, 63);
            this.genreBox.Name = "genreBox";
            this.genreBox.Size = new System.Drawing.Size(252, 25);
            this.genreBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Жанр : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Име на Филма / Сериала";
            // 
            // nameBox
            // 
            this.nameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameBox.Location = new System.Drawing.Point(242, 124);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(253, 16);
            this.nameBox.TabIndex = 12;
            // 
            // leadName
            // 
            this.leadName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.leadName.Location = new System.Drawing.Point(242, 169);
            this.leadName.Name = "leadName";
            this.leadName.Size = new System.Drawing.Size(253, 16);
            this.leadName.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Име на Главния герой";
            // 
            // yearBox
            // 
            this.yearBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.yearBox.Location = new System.Drawing.Point(242, 206);
            this.yearBox.Name = "yearBox";
            this.yearBox.Size = new System.Drawing.Size(253, 16);
            this.yearBox.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Година на създаване";
            // 
            // sendButton
            // 
            this.sendButton.FlatAppearance.BorderSize = 0;
            this.sendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendButton.Location = new System.Drawing.Point(305, 242);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(96, 23);
            this.sendButton.TabIndex = 17;
            this.sendButton.Text = "Запомни";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // Border
            // 
            this.Border.Location = new System.Drawing.Point(0, 0);
            this.Border.Name = "Border";
            this.Border.Size = new System.Drawing.Size(515, 25);
            this.Border.TabIndex = 18;
            this.Border.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Border_MouseDown);
            this.Border.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Border_MouseMove);
            this.Border.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Border_MouseUp);
            // 
            // close
            // 
            this.close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.close.FlatAppearance.BorderSize = 0;
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.Location = new System.Drawing.Point(407, 242);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(96, 23);
            this.close.TabIndex = 19;
            this.close.Text = "Отказ";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // FilterForm
            // 
            this.AcceptButton = this.sendButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.close;
            this.ClientSize = new System.Drawing.Size(513, 277);
            this.Controls.Add(this.close);
            this.Controls.Add(this.Border);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.yearBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.leadName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.genreBox);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FilterForm";
            this.Load += new System.EventHandler(this.FilterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox genreBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox leadName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox yearBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Panel Border;
        private System.Windows.Forms.Button close;
    }
}