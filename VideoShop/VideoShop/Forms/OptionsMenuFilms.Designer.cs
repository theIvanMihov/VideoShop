namespace VideoShop
{
    partial class OptionsMenuFilms
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.producerBox = new System.Windows.Forms.TextBox();
            this.leadBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.genreBox = new System.Windows.Forms.ComboBox();
            this.yearBox = new System.Windows.Forms.TextBox();
            this.submitChanges = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.Border = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Продуцент : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Главна роля : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 145);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Име на филма : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 187);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Жанр : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 243);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Година : ";
            // 
            // producerBox
            // 
            this.producerBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.producerBox.Location = new System.Drawing.Point(166, 47);
            this.producerBox.Name = "producerBox";
            this.producerBox.Size = new System.Drawing.Size(142, 16);
            this.producerBox.TabIndex = 5;
            // 
            // leadBox
            // 
            this.leadBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.leadBox.Location = new System.Drawing.Point(166, 99);
            this.leadBox.Name = "leadBox";
            this.leadBox.Size = new System.Drawing.Size(142, 16);
            this.leadBox.TabIndex = 6;
            // 
            // nameBox
            // 
            this.nameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameBox.Location = new System.Drawing.Point(166, 145);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(142, 16);
            this.nameBox.TabIndex = 7;
            // 
            // genreBox
            // 
            this.genreBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.genreBox.FormattingEnabled = true;
            this.genreBox.Location = new System.Drawing.Point(166, 187);
            this.genreBox.Name = "genreBox";
            this.genreBox.Size = new System.Drawing.Size(142, 25);
            this.genreBox.TabIndex = 8;
            // 
            // yearBox
            // 
            this.yearBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.yearBox.Location = new System.Drawing.Point(166, 244);
            this.yearBox.Name = "yearBox";
            this.yearBox.Size = new System.Drawing.Size(142, 16);
            this.yearBox.TabIndex = 9;
            // 
            // submitChanges
            // 
            this.submitChanges.FlatAppearance.BorderSize = 0;
            this.submitChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitChanges.Location = new System.Drawing.Point(112, 315);
            this.submitChanges.Name = "submitChanges";
            this.submitChanges.Size = new System.Drawing.Size(95, 23);
            this.submitChanges.TabIndex = 10;
            this.submitChanges.Text = "Приложи";
            this.submitChanges.UseVisualStyleBackColor = true;
            this.submitChanges.Click += new System.EventHandler(this.submitChanges_Click);
            // 
            // Close
            // 
            this.Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close.FlatAppearance.BorderSize = 0;
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.Location = new System.Drawing.Point(213, 315);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(95, 23);
            this.Close.TabIndex = 11;
            this.Close.Text = "Отказ";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // Border
            // 
            this.Border.Location = new System.Drawing.Point(-2, 0);
            this.Border.Name = "Border";
            this.Border.Size = new System.Drawing.Size(333, 18);
            this.Border.TabIndex = 12;
            this.Border.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Border_MouseDown);
            this.Border.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Border_MouseMove);
            this.Border.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Border_MouseUp);
            // 
            // OptionsMenuFilms
            // 
            this.AcceptButton = this.submitChanges;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Close;
            this.ClientSize = new System.Drawing.Size(328, 350);
            this.Controls.Add(this.Border);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.submitChanges);
            this.Controls.Add(this.yearBox);
            this.Controls.Add(this.genreBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.leadBox);
            this.Controls.Add(this.producerBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OptionsMenuFilms";
            this.Text = "OptionsMenu";
            this.Load += new System.EventHandler(this.OptionsMenuFilms_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox producerBox;
        private System.Windows.Forms.TextBox leadBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.ComboBox genreBox;
        private System.Windows.Forms.TextBox yearBox;
        private System.Windows.Forms.Button submitChanges;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Panel Border;
    }
}