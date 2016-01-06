using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyInfoSafe.Forms.Service.Action;
using MyInfoSafe.Model;
using MyInfoSafe.forms;
using MyInfoSafe.DataBase;
using MyInfoSafe.Forms.Bank;
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
            var lSearch = search_txt.Text;
            RefreshGrid(lSearch);
        }

        private void RefreshGrid (string pSearch)
        {
            var lInfoList = new List<Info>();
            lInfoList = DBAction.Service_GetInfoFromBase(pSearch);
            grid.DataSource = lInfoList;
            grid.Columns[0].Visible = false;
            grid.Columns[3].MinimumWidth = 142;
            grid.Columns[4].Visible = false;
        }

        private void search_txt_MouseClick(object sender, MouseEventArgs e)
        {
            search_txt.Text = string.Empty;
        }

        private void grid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
           /* int position = 0;
            if (grid.SelectedRows.Count > 0)
            {
                int.TryParse(grid.SelectedRows[0].Cells[0].Value.ToString(), out position);
                info inf = new info();
                Edit_Item edit_it = new Edit_Item();
                edit_it.lInfoId = position;
                this.Hide();
                edit_it.Show();
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
                var lSearch = search_txt.Text;
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
            var lPosiition = 0;
            if (grid.SelectedRows.Count > 0)
            {
                int.TryParse(grid.SelectedRows[0].Cells[0].Value.ToString(), out lPosiition);
                var lInfo = new Info();
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
            var lRes = MessageBox.Show("Are you sure, you want to remove it?","Removing Item",MessageBoxButtons.YesNo);
            if (lRes.ToString() == "Yes")
            {
                var lPosition = 0;
                if (grid.SelectedRows.Count > 0)
                {
                    int.TryParse(grid.SelectedRows[0].Cells[0].Value.ToString(), out lPosition);
                    var lInfoItem = new Info();
                    DBAction.DeleteInfoItem(lPosition);
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
            var lChangePassword = new ChangePassword();
            lChangePassword.Show();
        }

        private void bankFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            var lBankInfo = new BankForm();
            lBankInfo.Show();
        }

        private void addNew_Click(object sender, EventArgs e)
        {
            Hide();
            var lAddForm = new Add();
            lAddForm.Show();
        }

      
    }
}
