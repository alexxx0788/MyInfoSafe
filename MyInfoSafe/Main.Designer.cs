namespace MyInfoSafe.forms
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
            this.services = new System.Windows.Forms.RadioButton();
            this.bank = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // openBtn
            // 
            this.openBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.openBtn.Location = new System.Drawing.Point(66, 171);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(114, 26);
            this.openBtn.TabIndex = 5;
            this.openBtn.Text = "Open";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.enter_Click);
            // 
            // infoSafe
            // 
            this.infoSafe.AutoSize = true;
            this.infoSafe.Font = new System.Drawing.Font("Times New Roman", 23F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoSafe.Location = new System.Drawing.Point(59, 20);
            this.infoSafe.Name = "infoSafe";
            this.infoSafe.Size = new System.Drawing.Size(129, 36);
            this.infoSafe.TabIndex = 0;
            this.infoSafe.Text = "Info Safe";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(66, 75);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(114, 20);
            this.password.TabIndex = 2;
            this.password.KeyUp += new System.Windows.Forms.KeyEventHandler(this.password_KeyUp);
            // 
            // services
            // 
            this.services.AutoSize = true;
            this.services.Checked = true;
            this.services.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.services.Location = new System.Drawing.Point(66, 101);
            this.services.Name = "services";
            this.services.Size = new System.Drawing.Size(96, 26);
            this.services.TabIndex = 3;
            this.services.TabStop = true;
            this.services.Text = "accounts";
            this.services.UseVisualStyleBackColor = true;
            // 
            // bank
            // 
            this.bank.AutoSize = true;
            this.bank.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bank.Location = new System.Drawing.Point(66, 133);
            this.bank.Name = "bank";
            this.bank.Size = new System.Drawing.Size(73, 26);
            this.bank.TabIndex = 4;
            this.bank.Text = "banks";
            this.bank.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 211);
            this.Controls.Add(this.bank);
            this.Controls.Add(this.services);
            this.Controls.Add(this.infoSafe);
            this.Controls.Add(this.password);
            this.Controls.Add(this.openBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Label infoSafe;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.RadioButton services;
        private System.Windows.Forms.RadioButton bank;
    }
}

