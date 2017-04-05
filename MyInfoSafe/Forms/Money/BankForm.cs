using System;
using System.Windows.Forms;
using IStorage.DAL.Repository;
using IStorage.WFA.Forms.Money.Action;
using IStorage.WFA.Forms.Notes;
using IStorage.WFA.Forms.Service;
using IStorage.WFA.Shared;
using Form = System.Windows.Forms.Form;

namespace IStorage.WFA.Forms.Money
{
    public partial class BankForm : Form
    {
        private readonly MoneyRepository _repository = new MoneyRepository(Config.Settings.ConnectionString);

        public BankForm()
        {
            InitializeComponent();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            var items = _repository.GetList();
            grid.DataSource = items;
            grid.Columns[0].Visible = false;
            grid.Columns[3].Visible = false;
            grid.Columns[4].Visible = false;
            grid.Columns[1].Width += 25;
            grid.Columns[2].Width += 25;
        }


        private void InfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.CloseForm();
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
            var show = MessageBox.Show("Are you sure, you want to remove it?", "Removing Item", MessageBoxButtons.YesNo);
            if (show.ToString() == "Yes")
            {
                int position;
                if (grid.SelectedRows.Count > 0)
                {
                    int.TryParse(grid.SelectedRows[0].Cells[0].Value.ToString(), out position);
                    _repository.Delete(position);
                    Config.Settings.RewriteDB = true;
                    RefreshGrid();
                }
                else
                {
                    MessageBox.Show("You must select row");
                }
            }
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

        private void grid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (grid.SelectedRows.Count > 0)
            {
                int position;
                int.TryParse(grid.SelectedRows[0].Cells[0].Value.ToString(), out position);
                Update update = new Update(position) { bankId = position };
                this.Hide();
                update.Show();
            }
        }

        private void notesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            var serviceForm = new NotesForm();
            serviceForm.Show();
        }
    }
}