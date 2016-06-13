using System;
using System.Windows.Forms;
using DALayer.API.Model;
using MyInfoSafe.forms;
using MyInfoSafe.Forms.Bank;
using MyInfoSafe.Forms.Service.Actions;
using MyInfoSafe.Shared;
using Form = System.Windows.Forms.Form;

namespace MyInfoSafe.Forms.Service
{
    public partial class ServiceForm : Form
    {
        public ServiceForm()
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
            removeCurrentToolStripMenuItem.Visible = false;
            optionToolStripMenuItem.Visible = false;
        }
        
        private void refresh_Click(object sender, EventArgs e)
        {
            var search = searchTxt.Text;
            RefreshGrid(search);
        }

        private void RefreshGrid (string search)
        {
            var info = new Info();
            var lInfoList = info.GetItemsList(search, Config.Constants.DBPassword);
            grid.DataSource = lInfoList;
            grid.Columns[0].Visible = false;
            grid.Columns[3].MinimumWidth = 142;
            grid.Columns[4].Visible = false;
        }

        private void search_txt_MouseClick(object sender, MouseEventArgs e)
        {
            searchTxt.Text = string.Empty;
        }

       private void grid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
           /* int position = 0;
            if (grid.SelectedRows.Count > 0)
            {
                int.TryParse(grid.SelectedRows[0].Cells[0].Value.ToString(), out position);
                var inf = new Info();
                Update update = new Update();
                update.InfoId = position;
                this.Hide();
                update.Show();
            }*/
            
        }

        private void InfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.CloseForm();
        }

        private void search_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var lSearch = searchTxt.Text;
                RefreshGrid(lSearch);
            }
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            var lAddForm = new Add();
            lAddForm.Show();
        }

        private void updateCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count > 0)
            {
                var lPosiition = 0;
                int.TryParse(grid.SelectedRows[0].Cells[0].Value.ToString(), out lPosiition);
                var lEditItem = new Update(lPosiition);
                Hide();
                lEditItem.Show();
            }
            else
            {
                MessageBox.Show("You must select row");
            }
        }

        private void removeCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Are you sure, you want to remove it?","Removing Item",MessageBoxButtons.YesNo);
            if (res.ToString() == "Yes")
            {
                if (grid.SelectedRows.Count > 0)
                {
                    var position = 0;
                    int.TryParse(grid.SelectedRows[0].Cells[0].Value.ToString(), out position);
                    (new Info()).RemoveItem(position,Config.Constants.DBPassword);
                    RefreshGrid(string.Empty);
                }
                else
                {
                    MessageBox.Show("You must select row");
                }
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            var changePassword = new ChangePassword();
            changePassword.Show();
        }

        private void bankFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            var bankInfo = new BankForm();
            bankInfo.Show();
        }

        private void addNew_Click(object sender, EventArgs e)
        {
            Hide();
            var addForm = new Add();
            addForm.Show();
        }

      
    }
}
