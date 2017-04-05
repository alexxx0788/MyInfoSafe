using System;
using System.Windows.Forms;
using IStorage.DAL.Repository;
using IStorage.WFA.Shared;
using Form = System.Windows.Forms.Form;

namespace IStorage.WFA.Forms.Notes.Action
{
    public partial class Update : Form
    {
        private readonly NotesRepository _repository = new NotesRepository(Config.Settings.ConnectionString);
        public int NoteId;
        public Update(int noteId)
        {
            NoteId = noteId;
            InitializeComponent();
            var note = _repository.FindById(noteId);

            titleTextBox.Text = note.Title;
            noteTextBox.Text = note.Text;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            var title = titleTextBox.Text;
            var text = noteTextBox.Text;
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Title field should not be empty");
            }
            else
            {
                var note = new DAL.Model.Notes
                {
                    Title = title,
                    Text = text
                };
                _repository.Update(note,NoteId);
                Config.Settings.RewriteDB = true;
                Hide();
                var infoForm = new NotesForm();
                infoForm.Show();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Are you sure, you want to remove it?", "Removing Item", MessageBoxButtons.YesNo);
            if (res.ToString() == "Yes")
            {
                _repository.Delete(NoteId);
                Config.Settings.RewriteDB = true;
                Hide();
                var infoItem = new NotesForm();
                infoItem.Show();
            }
            else
            {
                MessageBox.Show("You must select row");
            }
        }

        private void Update_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
            var infoItem = new NotesForm();
            infoItem.Show();
        }
    }
}