using System;
using System.Windows.Forms;
using IStorage.DAL.Repository;
using IStorage.WFA.Shared;
using Form = System.Windows.Forms.Form;

namespace IStorage.WFA.Forms.Money.Action
{
    public partial class Add : Form
    {
        private readonly MoneyRepository _repository = new MoneyRepository(Config.Settings.ConnectionString);
        public Add()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                var bankItem = new DAL.Model.Money()
                {
                    Currency = bankTxt.Text,
                    Amount = monetTxt.Text,
                    Details = comments.Text
                };
                _repository.Insert(bankItem);
                Config.Settings.RewriteDB = true;

                Hide();
                var lBankForm = new BankForm();
                lBankForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Add_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            var bankForm = new BankForm();
            bankForm.Show();
        }
    }
}