using System;
using System.Net;
using System.Windows.Forms;
using System.IO;
using MyInfoSafe.Forms.Bank;
using MyInfoSafe.Forms.InfoForm;
using MyInfoSafe.Forms.Service;
using MyInfoSafe.Model;
using MyInfoSafe.Yandex;
using MyInfoSafe.DataBase;
using System.Net.Mail;
using Form = System.Windows.Forms.Form;

namespace MyInfoSafe.forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void enter_Click(object sender, EventArgs e)
        {
            var lPassword = password.Text;
            Config.Constants.DBPassword = lPassword;
            if (services.Checked)
            {
                ShowInfoForm();
                Model.Form.mSelectedForm = Config.Constants.Forms.services;
            }
            else
            {
                ShowBankForm();
                Model.Form.mSelectedForm = Config.Constants.Forms.bank;
            }

        }

        private void ShowInfoForm()
        {
            Result res = DBAction.IsValidPassword();
            if (res.mCode > 0)
            {
                Hide();
                var lInfoForm = new ServiceForm();
                lInfoForm.Show();
            }
            else
            {
                MessageBox.Show(res.mMessage);
                password.Text = string.Empty;
            }
            
        }

        private void ShowBankForm()
        {
            var lResult = DBAction.IsValidPassword();
            if (lResult.mCode > 0)
            {
                Hide();
                var lBankForm = new BankForm();
                lBankForm.Show();
            }
            else
            {
                MessageBox.Show(lResult.mMessage);
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
