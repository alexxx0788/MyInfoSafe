namespace IStorage.WFA.Forms.Service.Actions
{
    partial class Update
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
            this.label4 = new System.Windows.Forms.Label();
            this.advanced_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pwd_txt = new System.Windows.Forms.TextBox();
            this.Login = new System.Windows.Forms.Label();
            this.login_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.service_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.edit = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 10F);
            this.label4.Location = new System.Drawing.Point(14, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "Details";
            // 
            // advanced_txt
            // 
            this.advanced_txt.Location = new System.Drawing.Point(18, 237);
            this.advanced_txt.Multiline = true;
            this.advanced_txt.Name = "advanced_txt";
            this.advanced_txt.Size = new System.Drawing.Size(219, 143);
            this.advanced_txt.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 10F);
            this.label2.Location = new System.Drawing.Point(14, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "Password";
            // 
            // pwd_txt
            // 
            this.pwd_txt.Location = new System.Drawing.Point(18, 178);
            this.pwd_txt.Name = "pwd_txt";
            this.pwd_txt.Size = new System.Drawing.Size(219, 20);
            this.pwd_txt.TabIndex = 3;
            // 
            // Login
            // 
            this.Login.AutoSize = true;
            this.Login.Font = new System.Drawing.Font("Cambria", 10F);
            this.Login.Location = new System.Drawing.Point(14, 105);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(42, 16);
            this.Login.TabIndex = 23;
            this.Login.Text = "Login";
            // 
            // login_txt
            // 
            this.login_txt.Location = new System.Drawing.Point(18, 130);
            this.login_txt.Name = "login_txt";
            this.login_txt.Size = new System.Drawing.Size(219, 20);
            this.login_txt.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 10F);
            this.label1.Location = new System.Drawing.Point(14, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "Service";
            // 
            // service_txt
            // 
            this.service_txt.Location = new System.Drawing.Point(18, 76);
            this.service_txt.Name = "service_txt";
            this.service_txt.Size = new System.Drawing.Size(219, 20);
            this.service_txt.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 15F);
            this.label3.Location = new System.Drawing.Point(68, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Update Form";
            // 
            // edit
            // 
            this.edit.BackColor = System.Drawing.Color.White;
            this.edit.Font = new System.Drawing.Font("Cambria", 10F);
            this.edit.Location = new System.Drawing.Point(18, 403);
            this.edit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(84, 25);
            this.edit.TabIndex = 26;
            this.edit.Text = "Update";
            this.edit.UseVisualStyleBackColor = false;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.Color.White;
            this.delete.Font = new System.Drawing.Font("Cambria", 10F);
            this.delete.Location = new System.Drawing.Point(152, 403);
            this.delete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(84, 25);
            this.delete.TabIndex = 27;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(249, 446);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.advanced_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pwd_txt);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.login_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.service_txt);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Update";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Edit_Item_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox advanced_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pwd_txt;
        private System.Windows.Forms.Label Login;
        private System.Windows.Forms.TextBox login_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox service_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button delete;
    }
}