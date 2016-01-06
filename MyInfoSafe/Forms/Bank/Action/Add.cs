using System;
using System.Windows.Forms;
using MyInfoSafe.DataBase;
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
                var lBankLabel = bankTxt.Text;
                var lSumm = Convert.ToDecimal(monetTxt.Text);
                var lStartDate = startDate.Value;
                var lEndDate = endDate.Value;
                var lMonth = Convert.ToInt32(monthTxt.Text);
                var lPersent = persentTxt.Text.Contains(".") ? Convert.ToDouble(persentTxt.Text.Replace(".",",")): Convert.ToDouble(persentTxt.Text);
                var lComment = comments.Text;
                var lType = 0;
                if (isOld.Checked)
                    lType = 1;
                if (lBankLabel == "" || lSumm == 0 || lMonth == 0)
                {
                    MessageBox.Show("Set all required fields");
                }
                else
                {
                    var lBankItem = new Model.Bank();
                    lBankItem.BankName = lBankLabel;
                    lBankItem.Summ = lSumm;
                    lBankItem.StartDate = lStartDate;
                    lBankItem.EndDate = lEndDate;
                    lBankItem.Month = lMonth;
                    lBankItem.Persent = lPersent;
                    lBankItem.Comment = lComment;
                    lBankItem.Status = lType;
                    DBAction.InsertBankItem(lBankItem);
                    Hide();
                    BankForm lBankForm = new BankForm();
                    lBankForm.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Add_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            BankForm lBankForm = new BankForm();
            lBankForm.Show();
        }
    }
}
