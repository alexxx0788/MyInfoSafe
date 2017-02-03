using System;
using System.Windows.Forms;
using MyInfoSafe.Forms.Service;
using DALayer.API.Model;
using MyInfoSafe.Forms.Bank;
using MyInfoSafe.Shared;
using Form = System.Windows.Forms.Form;

namespace MyInfoSafe
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void enter_Click(object sender, EventArgs e)
        {
            var pass = password.Text;
            Config.Constants.DBPassword = pass;
            if (services.Checked)
            {
                ShowInfoForm();
                Shared.Form.SelectedForm = Config.Constants.Forms.Services;
            }
            else
            {
                ShowBankForm();
                Shared.Form.SelectedForm = Config.Constants.Forms.Bank;
            }
        }

        private void ShowInfoForm()
        {
            var res = User.IsValidPassword(Config.Constants.DBPassword);
            if (res.Code > 0)
            {
                Hide();
                var infoForm = new ServiceForm();
                infoForm.Show();
            }
            else
            {
                MessageBox.Show(res.Message);
                password.Text = string.Empty;
            }
        }

        private void ShowBankForm()
        {
            var res = User.IsValidPassword(Config.Constants.DBPassword);
            if (res.Code > 0)
            {
                Hide();
                var bankForm = new BankForm();
                bankForm.Show();
            }
            else
            {
                MessageBox.Show(res.Message);
                password.Text = string.Empty;
            }
        }

        private void password_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Config.Constants.DBPassword = password.Text;
                ShowInfoForm();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.RemoveFile(Config.Constants.DBFile);
        }
    }
}