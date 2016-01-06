namespace MyInfoSafe.Forms.Service.Action
{
    partial class Add
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
            this.service_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Login = new System.Windows.Forms.Label();
            this.login_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pwd_txt = new System.Windows.Forms.TextBox();
            this.add_new_item = new System.Windows.Forms.Button();
            this.advanced_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(24, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 33);
            this.label3.TabIndex = 0;
            this.label3.Text = "Add New Account";
            // 
            // service_txt
            // 
            this.service_txt.Location = new System.Drawing.Point(12, 80);
            this.service_txt.Name = "service_txt";
            this.service_txt.Size = new System.Drawing.Size(217, 20);
            this.service_txt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 22);
            this.label1.TabIndex = 8;
            this.label1.Text = "Service";
            // 
            // Login
            // 
            this.Login.AutoSize = true;
            this.Login.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Login.Location = new System.Drawing.Point(8, 103);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(51, 22);
            this.Login.TabIndex = 10;
            this.Login.Text = "Login";
            // 
            // login_txt
            // 
            this.login_txt.Location = new System.Drawing.Point(12, 125);
            this.login_txt.Name = "login_txt";
            this.login_txt.Size = new System.Drawing.Size(217, 20);
            this.login_txt.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 22);
            this.label2.TabIndex = 12;
            this.label2.Text = "Password";
            // 
            // pwd_txt
            // 
            this.pwd_txt.Location = new System.Drawing.Point(12, 173);
            this.pwd_txt.Name = "pwd_txt";
            this.pwd_txt.Size = new System.Drawing.Size(217, 20);
            this.pwd_txt.TabIndex = 3;
            // 
            // add_new_item
            // 
            this.add_new_item.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.add_new_item.Location = new System.Drawing.Point(12, 404);
            this.add_new_item.Name = "add_new_item";
            this.add_new_item.Size = new System.Drawing.Size(217, 23);
            this.add_new_item.TabIndex = 5;
            this.add_new_item.Text = "Add New Account";
            this.add_new_item.UseVisualStyleBackColor = true;
            this.add_new_item.Click += new System.EventHandler(this.add_new_item_Click);
            // 
            // advanced_txt
            // 
            this.advanced_txt.Location = new System.Drawing.Point(12, 232);
            this.advanced_txt.Multiline = true;
            this.advanced_txt.Name = "advanced_txt";
            this.advanced_txt.Size = new System.Drawing.Size(217, 144);
            this.advanced_txt.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(8, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 22);
            this.label4.TabIndex = 15;
            this.label4.Text = "Advanced Info";
            // 
            // Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 446);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.advanced_txt);
            this.Controls.Add(this.add_new_item);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pwd_txt);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.login_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.service_txt);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Add_New_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox service_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Login;
        private System.Windows.Forms.TextBox login_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pwd_txt;
        private System.Windows.Forms.Button add_new_item;
        private System.Windows.Forms.TextBox advanced_txt;
        private System.Windows.Forms.Label label4;


    }
}

