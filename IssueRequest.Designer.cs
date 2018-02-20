namespace Library_Management_System
{
    partial class IssueRequest
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
            this.email_txt = new System.Windows.Forms.TextBox();
            this.title_txt = new System.Windows.Forms.TextBox();
            this.email_lbl = new System.Windows.Forms.Label();
            this.title_lbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // email_txt
            // 
            this.email_txt.Location = new System.Drawing.Point(548, 154);
            this.email_txt.Name = "email_txt";
            this.email_txt.Size = new System.Drawing.Size(100, 20);
            this.email_txt.TabIndex = 0;
            // 
            // title_txt
            // 
            this.title_txt.Location = new System.Drawing.Point(548, 225);
            this.title_txt.Name = "title_txt";
            this.title_txt.Size = new System.Drawing.Size(100, 20);
            this.title_txt.TabIndex = 1;
            // 
            // email_lbl
            // 
            this.email_lbl.AutoSize = true;
            this.email_lbl.Location = new System.Drawing.Point(455, 154);
            this.email_lbl.Name = "email_lbl";
            this.email_lbl.Size = new System.Drawing.Size(32, 13);
            this.email_lbl.TabIndex = 3;
            this.email_lbl.Text = "Email";
            // 
            // title_lbl
            // 
            this.title_lbl.AutoSize = true;
            this.title_lbl.Location = new System.Drawing.Point(460, 232);
            this.title_lbl.Name = "title_lbl";
            this.title_lbl.Size = new System.Drawing.Size(27, 13);
            this.title_lbl.TabIndex = 5;
            this.title_lbl.Text = "Title";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(511, 294);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Request";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(419, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "Request for Issue";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(856, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Logout";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // IssueRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 611);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.title_lbl);
            this.Controls.Add(this.email_lbl);
            this.Controls.Add(this.title_txt);
            this.Controls.Add(this.email_txt);
            this.Name = "IssueRequest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IssueRequest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox email_txt;
        private System.Windows.Forms.TextBox title_txt;
        private System.Windows.Forms.Label email_lbl;
        private System.Windows.Forms.Label title_lbl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}