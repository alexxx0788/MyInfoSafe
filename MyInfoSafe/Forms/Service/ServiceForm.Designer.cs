namespace MyInfoSafe.Forms.Service
{
    partial class ServiceForm
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
            this.grid = new System.Windows.Forms.DataGridView();
            this.refresh = new System.Windows.Forms.Button();
            this.search_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateCurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(-1, 97);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.Size = new System.Drawing.Size(402, 347);
            this.grid.TabIndex = 6;
            this.grid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_RowEnter);
            // 
            // refresh
            // 
            this.refresh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.refresh.Location = new System.Drawing.Point(320, 69);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(81, 23);
            this.refresh.TabIndex = 5;
            this.refresh.Text = "Find";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // search_txt
            // 
            this.search_txt.Location = new System.Drawing.Point(36, 71);
            this.search_txt.Name = "search_txt";
            this.search_txt.Size = new System.Drawing.Size(278, 20);
            this.search_txt.TabIndex = 4;
            this.search_txt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.search_txt_MouseClick);
            this.search_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.search_txt_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(109, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 33);
            this.label3.TabIndex = 0;
            this.label3.Text = "Info Safe (accounts)";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionToolStripMenuItem,
            this.optionToolStripMenuItem,
            this.bankFormToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(403, 26);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewToolStripMenuItem,
            this.updateCurrentToolStripMenuItem,
            this.removeCurrentToolStripMenuItem});
            this.actionToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(57, 22);
            this.actionToolStripMenuItem.Text = "Action";
            // 
            // addNewToolStripMenuItem
            // 
            this.addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            this.addNewToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.addNewToolStripMenuItem.Text = "Add Account";
            this.addNewToolStripMenuItem.Click += new System.EventHandler(this.addNewToolStripMenuItem_Click);
            // 
            // updateCurrentToolStripMenuItem
            // 
            this.updateCurrentToolStripMenuItem.Name = "updateCurrentToolStripMenuItem";
            this.updateCurrentToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.updateCurrentToolStripMenuItem.Text = "Update Account";
            this.updateCurrentToolStripMenuItem.Click += new System.EventHandler(this.updateCurrentToolStripMenuItem_Click);
            // 
            // removeCurrentToolStripMenuItem
            // 
            this.removeCurrentToolStripMenuItem.Name = "removeCurrentToolStripMenuItem";
            this.removeCurrentToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.removeCurrentToolStripMenuItem.Text = "Remove Account";
            this.removeCurrentToolStripMenuItem.Click += new System.EventHandler(this.removeCurrentToolStripMenuItem_Click);
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem});
            this.optionToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(59, 22);
            this.optionToolStripMenuItem.Text = "Option";
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // bankFormToolStripMenuItem
            // 
            this.bankFormToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.bankFormToolStripMenuItem.Name = "bankFormToolStripMenuItem";
            this.bankFormToolStripMenuItem.Size = new System.Drawing.Size(84, 22);
            this.bankFormToolStripMenuItem.Text = "Bank Form";
            this.bankFormToolStripMenuItem.Click += new System.EventHandler(this.bankFormToolStripMenuItem_Click);
            // 
            // addNew
            // 
            this.addNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(180)));
            this.addNew.Location = new System.Drawing.Point(0, 71);
            this.addNew.Name = "addNew";
            this.addNew.Size = new System.Drawing.Size(30, 20);
            this.addNew.TabIndex = 9;
            this.addNew.Text = "+";
            this.addNew.UseVisualStyleBackColor = true;
            this.addNew.Click += new System.EventHandler(this.addNew_Click);
            // 
            // ServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 443);
            this.Controls.Add(this.addNew);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.search_txt);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accounts";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InfoForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.TextBox search_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateCurrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeCurrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bankFormToolStripMenuItem;
        private System.Windows.Forms.Button addNew;


    }
}