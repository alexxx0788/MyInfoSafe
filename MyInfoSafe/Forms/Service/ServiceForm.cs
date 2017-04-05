using System;
using System.Windows.Forms;
using IStorage.DAL.Repository;
using IStorage.WFA.Forms.Money;
using IStorage.WFA.Forms.Notes;
using IStorage.WFA.Forms.Service.Actions;
using IStorage.WFA.Shared;
using Form = System.Windows.Forms.Form;

namespace IStorage.WFA.Forms.Service
{
    public partial class ServiceForm : Form
    {
        private readonly InfoRepository _repository = new InfoRepository(Config.Settings.ConnectionString);

        public ServiceForm()
        {
            InitializeComponent();
            RefreshGrid(string.Empty);
        }


        private void RefreshGrid(string search)
        {
            var lInfoList = string.IsNullOrEmpty(search) ? _repository.GetList() : _repository.GetList(search);
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
            if (grid.SelectedRows.Count > 0)
            {
                int position;
                int.TryParse(grid.SelectedRows[0].Cells[0].Value.ToString(), out position);
                Update update = new Update(position) {InfoId = position};
                this.Hide();
                update.Show();
            }
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
            var res = MessageBox.Show("Are you sure, you want to remove it?", "Removing Item", MessageBoxButtons.YesNo);
            if (res.ToString() == "Yes")
            {
                if (grid.SelectedRows.Count > 0)
                {
                    int position;
                    int.TryParse(grid.SelectedRows[0].Cells[0].Value.ToString(), out position);
                    _repository.Delete(position);
                    Config.Settings.RewriteDB = true;
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

        private void addNew_Click(object sender, EventArgs e)
        {
            Hide();
            var addForm = new Add();
            addForm.Show();
        }

        private void moneyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            var bankInfo = new BankForm();
            bankInfo.Show();
        }

        private void notesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            var notesForm = new NotesForm();
            notesForm.Show();
        }
    }
}