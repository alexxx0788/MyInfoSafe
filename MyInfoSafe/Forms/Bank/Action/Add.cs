using System;
using System.Windows.Forms;
using DALayer.API.Dto;
using MyInfoSafe.Shared;
using Form = System.Windows.Forms.Form;

namespace MyInfoSafe.Forms.Bank.Action
{
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                var bankLabel = bankTxt.Text;
                var summ = Convert.ToDecimal(monetTxt.Text);
                var comment = comments.Text;
                var bankItem = new BankDto();
                bankItem.BankName = bankLabel;
                bankItem.Summ = summ;
                bankItem.Comment = comment;
                (new DALayer.API.Model.Bank()).InsertItem(bankItem,Config.Constants.DBPassword);
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
