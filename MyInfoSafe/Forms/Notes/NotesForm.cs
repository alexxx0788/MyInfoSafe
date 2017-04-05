using System;
using System.Windows.Forms;
using IStorage.DAL.Repository;
using IStorage.WFA.Forms.Money;
using IStorage.WFA.Forms.Service;
using IStorage.WFA.Shared;
using Form = System.Windows.Forms.Form;

namespace IStorage.WFA.Forms.Notes
{
    public partial class NotesForm : Form
    {
        private readonly NotesRepository _repository = new NotesRepository(Config.Settings.ConnectionString);
        public NotesForm()
        {
            InitializeComponent();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            var items = _repository.GetList();
            grid.DataSource = items;
            grid.Columns[0].Visible = false;
            grid.Columns[2].Visible = false;
            grid.Columns[1].Width += 140;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            var lAddForm = new Action.Add();
            lAddForm.Show();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count > 0)
            {
                int lPosiition;
                int.TryParse(grid.SelectedRows[0].Cells[0].Value.ToString(), out lPosiition);
                var lEditItem = new  Action.Update(lPosiition);
                Hide();
                lEditItem.Show();
            }
            else
            {
                MessageBox.Show("You must select row");
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
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
                    RefreshGrid();
                }
                else
                {
                    MessageBox.Show("You must select row");
                }
            }
        }

    

      
        private void NotesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.CloseForm();
        }

        private void grid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (grid.SelectedRows.Count > 0)
            {
                int position;
                int.TryParse(grid.SelectedRows[0].Cells[0].Value.ToString(), out position);
                Action.Update update = new Action.Update(position) { NoteId = position };
                this.Hide();
                update.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            var lAddForm = new Notes.Action.Add();
            lAddForm.Show();
        }

        private void serviceTool_Click(object sender, EventArgs e)
        {
            Hide();
            var form = new ServiceForm();
            form.Show();
        }

        private void moneyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            var form = new BankForm();
            form.Show();
        }
    }
}
