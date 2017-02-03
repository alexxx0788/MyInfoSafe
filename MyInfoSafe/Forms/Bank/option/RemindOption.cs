using System;
using System.Windows.Forms;
using Form = System.Windows.Forms.Form;

namespace MyInfoSafe.Forms.Bank
{
    public partial class RemindOption : Form
    {
        public RemindOption()
        {
            InitializeComponent();
            /*  var lRemindItem = DBAction.GetRemindItemByID(1);
              _account.Text = lRemindItem.EmailAccount;
              _password.Text = lRemindItem.Password;
              _address.Text = lRemindItem.Address;
              _smtp.Text = lRemindItem.Smtp;
              _port.Text = lRemindItem.Port.ToString();
              _addressTo.Text = lRemindItem.ToAddress;
              _count.Text = lRemindItem.Count.ToString();*/
        }

        private void Save_Click(object sender, EventArgs e)
        {
            /*  var lRemindItem = DBAction.GetRemindItemByID(1);
              lRemindItem.EmailAccount = _account.Text;
              lRemindItem.Password = _password.Text;
              lRemindItem.Address = _address.Text;
              lRemindItem.Smtp = _smtp.Text;
              lRemindItem.Port = Convert.ToInt32(_port.Text);
              lRemindItem.ToAddress = _addressTo.Text;
              lRemindItem.Count = Convert.ToInt32(_count.Text);
              DBAction.UpdateRemindItem(lRemindItem);
              CloseFrom();*/
        }

        private void RemindOption_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseFrom();
        }

        private void CloseFrom()
        {
            Hide();
            var lBankForm = new BankForm();
            lBankForm.Show();
        }
    }
}