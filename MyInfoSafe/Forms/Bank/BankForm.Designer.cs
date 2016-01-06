namespace MyInfoSafe.Forms.Bank
{
    partial class BankForm
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
            this.search_txt = new System.Windows.Forms.TextBox();
            this.refresh = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.total = new System.Windows.Forms.Label();
            this.gain = new System.Windows.Forms.Label();
            this.showOld = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateCurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remindMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remindOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(276, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 33);
            this.label3.TabIndex = 1;
            this.label3.Text = "Info Safe (bank)";
            // 
            // search_txt
            // 
            this.search_txt.Location = new System.Drawing.Point(56, 73);
            this.search_txt.Name = "search_txt";
            this.search_txt.Size = new System.Drawing.Size(477, 20);
            this.search_txt.TabIndex = 12;
            this.search_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.search_txt_KeyUp_1);
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(539, 72);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(74, 20);
            this.refresh.TabIndex = 13;
            this.refresh.Text = "Find";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // grid
            // 
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(0, 154);
            this.grid.Name = "grid";
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(727, 244);
            this.grid.TabIndex = 14;
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Location = new System.Drawing.Point(-3, 111);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(27, 13);
            this.total.TabIndex = 15;
            this.total.Text = "total";
            // 
            // gain
            // 
            this.gain.AutoSize = true;
            this.gain.Location = new System.Drawing.Point(-3, 141);
            this.gain.Name = "gain";
            this.gain.Size = new System.Drawing.Size(27, 13);
            this.gain.TabIndex = 16;
            this.gain.Text = "gain";
            // 
            // showOld
            // 
            this.showOld.AutoSize = true;
            this.showOld.Location = new System.Drawing.Point(619, 73);
            this.showOld.Name = "showOld";
            this.showOld.Size = new System.Drawing.Size(67, 17);
            this.showOld.TabIndex = 17;
            this.showOld.Text = "showOld";
            this.showOld.UseVisualStyleBackColor = true;
            this.showOld.CheckedChanged += new System.EventHandler(this.showOld_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionsToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.serviceFormToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(727, 26);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewToolStripMenuItem,
            this.updateCurrentToolStripMenuItem,
            this.removeCurrentToolStripMenuItem,
            this.remindMeToolStripMenuItem});
            this.actionsToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(62, 22);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // addNewToolStripMenuItem
            // 
            this.addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            this.addNewToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.addNewToolStripMenuItem.Text = "Add New";
            this.addNewToolStripMenuItem.Click += new System.EventHandler(this.addNewToolStripMenuItem_Click);
            // 
            // updateCurrentToolStripMenuItem
            // 
            this.updateCurrentToolStripMenuItem.Name = "updateCurrentToolStripMenuItem";
            this.updateCurrentToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.updateCurrentToolStripMenuItem.Text = "Update Current";
            this.updateCurrentToolStripMenuItem.Click += new System.EventHandler(this.updateCurrentToolStripMenuItem_Click);
            // 
            // removeCurrentToolStripMenuItem
            // 
            this.removeCurrentToolStripMenuItem.Name = "removeCurrentToolStripMenuItem";
            this.removeCurrentToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.removeCurrentToolStripMenuItem.Text = "Remove Current";
            this.removeCurrentToolStripMenuItem.Click += new System.EventHandler(this.removeCurrentToolStripMenuItem_Click);
            // 
            // remindMeToolStripMenuItem
            // 
            this.remindMeToolStripMenuItem.Name = "remindMeToolStripMenuItem";
            this.remindMeToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.remindMeToolStripMenuItem.Text = "Remind Me";
            this.remindMeToolStripMenuItem.Click += new System.EventHandler(this.remindMeToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem,
            this.remindOptionsToolStripMenuItem});
            this.optionsToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(64, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // remindOptionsToolStripMenuItem
            // 
            this.remindOptionsToolStripMenuItem.Name = "remindOptionsToolStripMenuItem";
            this.remindOptionsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.remindOptionsToolStripMenuItem.Text = "Remind Options";
            this.remindOptionsToolStripMenuItem.Click += new System.EventHandler(this.remindOptionsToolStripMenuItem_Click);
            // 
            // serviceFormToolStripMenuItem
            // 
            this.serviceFormToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.serviceFormToolStripMenuItem.Name = "serviceFormToolStripMenuItem";
            this.serviceFormToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.serviceFormToolStripMenuItem.Text = "Service Form";
            this.serviceFormToolStripMenuItem.Click += new System.EventHandler(this.serviceFormToolStripMenuItem_Click);
            // 
            // addBtn
            // 
            this.addBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addBtn.Location = new System.Drawing.Point(0, 73);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(50, 20);
            this.addBtn.TabIndex = 20;
            this.addBtn.Text = "+";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // BankForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 397);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.showOld);
            this.Controls.Add(this.gain);
            this.Controls.Add(this.total);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.search_txt);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BankForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deposits";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InfoForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox search_txt;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label total;
        private System.Windows.Forms.Label gain;
        private System.Windows.Forms.CheckBox showOld;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remindOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateCurrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeCurrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remindMeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceFormToolStripMenuItem;
        private System.Windows.Forms.Button addBtn;
    }
}