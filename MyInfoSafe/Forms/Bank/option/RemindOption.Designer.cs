namespace MyInfoSafe.Forms.Bank
{
    partial class RemindOption
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
            this.label3 = new System.Windows.Forms.Label();
            this._account = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this._password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._address = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._port = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._addressTo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._count = new System.Windows.Forms.TextBox();
            this.Save = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this._smtp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 33);
            this.label3.TabIndex = 2;
            this.label3.Text = "Remind Options";
            // 
            // _account
            // 
            this._account.Location = new System.Drawing.Point(15, 75);
            this._account.Name = "_account";
            this._account.Size = new System.Drawing.Size(209, 20);
            this._account.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Email Account";
            // 
            // Password
            // 
            this.password.AutoSize = true;
            this.password.Location = new System.Drawing.Point(12, 98);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(81, 13);
            this.password.TabIndex = 5;
            this.password.Text = "Email Password";
            // 
            // _password
            // 
            this._password.Location = new System.Drawing.Point(15, 114);
            this._password.Name = "_password";
            this._password.Size = new System.Drawing.Size(209, 20);
            this._password.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Email Address";
            // 
            // _address
            // 
            this._address.Location = new System.Drawing.Point(15, 153);
            this._address.Name = "_address";
            this._address.Size = new System.Drawing.Size(209, 20);
            this._address.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Port";
            // 
            // _port
            // 
            this._port.Location = new System.Drawing.Point(15, 243);
            this._port.Name = "_port";
            this._port.Size = new System.Drawing.Size(70, 20);
            this._port.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Send to Address";
            // 
            // _addressTo
            // 
            this._addressTo.Location = new System.Drawing.Point(15, 282);
            this._addressTo.Name = "_addressTo";
            this._addressTo.Size = new System.Drawing.Size(209, 20);
            this._addressTo.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Count to Remind";
            // 
            // _count
            // 
            this._count.Location = new System.Drawing.Point(15, 321);
            this._count.Name = "_count";
            this._count.Size = new System.Drawing.Size(70, 20);
            this._count.TabIndex = 14;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(15, 360);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(70, 23);
            this.Save.TabIndex = 15;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Smtp Address";
            // 
            // _smtp
            // 
            this._smtp.Location = new System.Drawing.Point(15, 201);
            this._smtp.Name = "_smtp";
            this._smtp.Size = new System.Drawing.Size(209, 20);
            this._smtp.TabIndex = 17;
            // 
            // RemindOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 396);
            this.Controls.Add(this._smtp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Save);
            this.Controls.Add(this._count);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._addressTo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._port);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._address);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._password);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._account);
            this.Controls.Add(this.label3);
            this.Name = "RemindOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remind Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RemindOption_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _account;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.TextBox _password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _address;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _port;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _addressTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _count;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _smtp;
    }
}