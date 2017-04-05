using System;
using System.Windows.Forms;
using IStorage.DAL.Repository;
using IStorage.WFA.Forms.Service;
using IStorage.WFA.Shared;
using Form = System.Windows.Forms.Form;

namespace IStorage.WFA
{
    public partial class Main : Form
    {
        private UsersRepository _userRepo;
        private Form _formToShow;
        public Main()
        {
            InitializeComponent();
        }

        private void enter_Click(object sender, EventArgs e)
        {
            ShowForm(password.Text);
        }

        private void password_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ShowForm(password.Text);
            }
        }

        private void ShowForm(string passwordTxt)
        {
            Config.Settings.DBPassword = passwordTxt;
            _userRepo = new UsersRepository(Config.Settings.ConnectionString);
            if (_userRepo.IsValidPassword(passwordTxt))
            {
                Hide();
                _formToShow = new ServiceForm();
                _formToShow.Show();
            }
            else
            {
                password.Text = string.Empty;
                ErrorMessage.Text = "Wrong password";
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.RemoveFile(Config.Settings.DBFile);
        }
    }
}