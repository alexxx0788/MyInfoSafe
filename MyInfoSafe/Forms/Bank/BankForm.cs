using System;
using System.Windows.Forms;
using DALayer.API.Model;
using MyInfoSafe.Forms.Bank.Action;
using MyInfoSafe.forms;
using MyInfoSafe.Forms.Service;
using MyInfoSafe.Shared;
using Form = System.Windows.Forms.Form;

namespace MyInfoSafe.Forms.Bank
{
    public partial class BankForm : Form
    {
        public BankForm()
        {
            InitializeComponent();
            RefreshGrid(string.Empty);
            if (!Config.Constants.WriteMode)
            {
                HideElements();
            }
        }

        private void HideElements()
        {
            addNewToolStripMenuItem.Visible = false;
            optionsToolStripMenuItem.Visible = false;
        }


        private void RefreshGrid (string search)
        {
            var items=(new DALayer.API.Model.Bank()).GetItemsList(search, Config.Constants.DBPassword);
            grid.DataSource = items;
            grid.Columns[0].Visible = false;
            grid.Columns[1].HeaderText = "Currency";
            grid.Columns[1].Width = 130;
            grid.Columns[2].HeaderText = "Amount";
            grid.Columns[2].Width = 130;
            grid.Columns[3].Visible = false;
            grid.Columns[4].Visible = false;
            grid.Columns[5].Visible = false;
            grid.Columns[6].Visible = false;
            grid.Columns[7].Visible = false;
            grid.Columns[8].Visible = false;
        }


        private void InfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.CloseForm();
        }


        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            var lChangePassword = new ChangePassword();
            lChangePassword.Show();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            var lAddNewForm = new Add();
            lAddNewForm.Show();
        }

        private void updateCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count > 0)
            {
                var position = 0;
                int.TryParse(grid.SelectedRows[0].Cells[0].Value.ToString(), out position);
                var updateItem = new Update(position);
                Hide();
                updateItem.Show();
            }
            else
            {
                MessageBox.Show("You must select row");
            }
        }

        private void removeCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var show = MessageBox.Show("Are you sure, you want to remove it?","Removing Item",MessageBoxButtons.YesNo);
            if (show.ToString() == "Yes")
            {
                var position = 0;
                if (grid.SelectedRows.Count > 0)
                {
                    int.TryParse(grid.SelectedRows[0].Cells[0].Value.ToString(), out position);
                    (new DALayer.API.Model.Bank()).RemoveItem(position,Config.Constants.DBPassword);
                    RefreshGrid(string.Empty);
                }
                else
                {
                    MessageBox.Show("You must select row");
                }
            }
        }

        private void remindOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            var lRemindItem = new RemindOption();
            lRemindItem.Show();
        }


        private void serviceFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            var serviceForm = new ServiceForm();
            serviceForm.Show();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Hide();
            var addNewForm = new Add();
            addNewForm.Show();
        }
    }
}
