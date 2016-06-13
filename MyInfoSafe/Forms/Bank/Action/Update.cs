using System;
using System.Windows.Forms;
using DALayer.API.Dto;
using MyInfoSafe.Forms.Bank;
using MyInfoSafe.Shared;
using Form = System.Windows.Forms.Form;

namespace MyInfoSafe.Forms.Bank.Action
{
    public partial class Update : Form
    {
        public int bankId = 0;
        public Update(int bankId)
        {
            InitializeComponent();
            if (!Config.Constants.WriteMode)
            {
                button1.Visible = false;
            }
            this.bankId = bankId;
            var bank = (new DALayer.API.Model.Bank()).GetItemById(bankId, Config.Constants.DBPassword);
            bankTxt.Text = bank.BankName;
            moneyTxt.Text = bank.Summ.ToString();
            comments.Text = bank.Comment;
        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                var bankLabel = bankTxt.Text;
                var summ = Convert.ToDecimal(moneyTxt.Text);
                var comment = comments.Text;
                    var bank = new BankDto();
                    bank.Id = this.bankId;
                    bank.BankName = bankLabel;
                    bank.Summ = summ;
                    bank.Comment = comment;
                    (new DALayer.API.Model.Bank()).UpdateItem(bank,Config.Constants.DBPassword);
                    Hide();
                    var bankForm = new BankForm();
                    bankForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Update_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            var bankForm = new BankForm();
            bankForm.Show();
        }

    }
}
