using System;
using System.Windows.Forms;
using MyInfoSafe.Forms.Bank;
using MyInfoSafe.Forms.Service;
using MyInfoSafe.Model;
using MyInfoSafe.DataBase;
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
                    Result lResult= DBAction.ChangeDataBasePassword(old_pwd.Text,new_pwd.Text);
                    if (lResult.mCode < 0)
                    {
                        MessageBox.Show(lResult.mMessage);
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
            if (Model.Form.mSelectedForm == Config.Constants.Forms.services)
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
