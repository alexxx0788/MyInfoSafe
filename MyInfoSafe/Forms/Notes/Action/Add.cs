using System;
using System.Windows.Forms;
using IStorage.DAL.Repository;
using IStorage.WFA.Shared;

namespace IStorage.WFA.Forms.Notes.Action
{
    public partial class Add : Form
    {
        private readonly NotesRepository _repository = new NotesRepository(Config.Settings.ConnectionString);

        public Add()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
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
                _repository.Insert(note);
                Config.Settings.RewriteDB = true;
                Hide();
                var infoForm = new NotesForm();
                infoForm.Show();
            }
        }

        private void Add_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
            var infoForm = new NotesForm();
            infoForm.Show();
        }
    }
}