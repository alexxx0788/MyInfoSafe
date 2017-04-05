using System;
using System.Windows.Forms;
using IStorage.DAL.Repository;
using IStorage.WFA.Shared;
using Form = System.Windows.Forms.Form;

namespace IStorage.WFA.Forms.Money.Action
{
    public partial class Update : Form
    {
        public int bankId = 0;
        private readonly MoneyRepository _repository = new MoneyRepository(Config.Settings.ConnectionString);
        public Update(int bankId)
        {
            InitializeComponent();
            this.bankId = bankId;
            var bank = _repository.FindById(bankId);
            bankTxt.Text = bank.Currency;
            moneyTxt.Text = bank.Amount;
            comments.Text = bank.Details;
        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                var bank = new DAL.Model.Money()
                {
                    Id = bankId,
                    Amount = moneyTxt.Text,
                    Currency = bankTxt.Text,
                    Details = comments.Text
                };
                _repository.Update(bank, bankId);
                Config.Settings.RewriteDB = true;
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

        private void button2_Click(object sender, EventArgs e)
        {

            var show = MessageBox.Show("Are you sure, you want to remove it?", "Removing Item", MessageBoxButtons.YesNo);
            if (show.ToString() == "Yes")
            {
                _repository.Delete(bankId);
                Config.Settings.RewriteDB = true;
                var bankForm = new BankForm();
                bankForm.Show();
            }
        }
    }
}