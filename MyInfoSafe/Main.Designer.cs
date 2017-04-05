namespace IStorage.WFA
{
    partial class Main
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
            this.openBtn = new System.Windows.Forms.Button();
            this.infoSafe = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.ErrorMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openBtn
            // 
            this.openBtn.BackColor = System.Drawing.Color.White;
            this.openBtn.Font = new System.Drawing.Font("Cambria", 12F);
            this.openBtn.ForeColor = System.Drawing.Color.Black;
            this.openBtn.Location = new System.Drawing.Point(10, 119);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(230, 26);
            this.openBtn.TabIndex = 5;
            this.openBtn.Text = "ENTER";
            this.openBtn.UseVisualStyleBackColor = false;
            this.openBtn.Click += new System.EventHandler(this.enter_Click);
            // 
            // infoSafe
            // 
            this.infoSafe.AutoSize = true;
            this.infoSafe.Font = new System.Drawing.Font("Cambria", 18F);
            this.infoSafe.ForeColor = System.Drawing.Color.Black;
            this.infoSafe.Location = new System.Drawing.Point(82, 7);
            this.infoSafe.Name = "infoSafe";
            this.infoSafe.Size = new System.Drawing.Size(91, 28);
            this.infoSafe.TabIndex = 0;
            this.infoSafe.Text = "Storage";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(10, 51);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(230, 20);
            this.password.TabIndex = 2;
            this.password.KeyUp += new System.Windows.Forms.KeyEventHandler(this.password_KeyUp);
            // 
            // ErrorMessage
            // 
            this.ErrorMessage.AutoSize = true;
            this.ErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.ErrorMessage.Location = new System.Drawing.Point(10, 72);
            this.ErrorMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ErrorMessage.Name = "ErrorMessage";
            this.ErrorMessage.Size = new System.Drawing.Size(0, 13);
            this.ErrorMessage.TabIndex = 6;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(249, 174);
            this.Controls.Add(this.ErrorMessage);
            this.Controls.Add(this.infoSafe);
            this.Controls.Add(this.password);
            this.Controls.Add(this.openBtn);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IStorage";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Label infoSafe;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label ErrorMessage;
    }
}

