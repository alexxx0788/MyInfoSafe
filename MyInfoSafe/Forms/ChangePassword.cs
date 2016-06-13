using System;
using System.Windows.Forms;
using DALayer.API.Model;
using MyInfoSafe.Forms.Bank;
using MyInfoSafe.Forms.Service;
using MyInfoSafe.Shared;
using Form = System.Windows.Forms.Form;

namespace MyInfoSafe.forms
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (old_pwd.Text == string.Empty || new_pwd.Text == string.Empty)
            {
                MessageBox.Show("Fields must be not empty");
            }
            else
            {
                if (old_pwd.Text == new_pwd.Text)
                {
                    MessageBox.Show("Old and New Password must be different");
                }
                else
                {
                    Result lResult= (new User()).ChangeDataBasePassword(old_pwd.Text,new_pwd.Text);
                    Config.Constants.DBPassword = new_pwd.Text;
                    Config.Constants.RewriteDB = true;
                    if (lResult.Code < 0)
                    {
                        MessageBox.Show(lResult.Message);
                    }
                    else
                    {
                        Hide();
                        var lInfoItem = new ServiceForm();
                        lInfoItem.Show();
                    }
                }
            }
        }

        private void Change_Password_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            if (Shared.Form.SelectedForm == Config.Constants.Forms.Services)
            {
                var lInfoForm = new ServiceForm();
                lInfoForm.Show();
            }
            else
            {
                var lBankInfo = new BankForm();
                lBankInfo.Show();
            }
        }
        
    }
}
