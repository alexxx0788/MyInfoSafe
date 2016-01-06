using System;
using System.Windows.Forms;
using MyInfoSafe.Model;
using MyInfoSafe.DataBase;
using MyInfoSafe.Forms.Bank;
using Form = System.Windows.Forms.Form;

namespace MyInfoSafe.Forms.Bank.Action
{
    public partial class Update : Form
    {
        public int mBankId = 0;
        public Update(int mBankId)
        {
            InitializeComponent();

            if (!Config.Constants.WriteMode)
            {
                button1.Visible = false;
            }

            this.mBankId = mBankId;
            var lBank = DBAction.GetBankInfoFromBaseByID(mBankId);
            bankTxt.Text = lBank.BankName;
            moneyTxt.Text = lBank.Summ.ToString();
            startDate.Value = lBank.StartDate;
            endDate.Value = lBank.EndDate;
            monthTxt.Text = lBank.Month.ToString();
            persentTxt.Text = lBank.Persent.ToString();
            comments.Text = lBank.Comment;
            if (lBank.Status == 1)
            {
                isOld.Checked = true;
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                var lBankLabel = bankTxt.Text;
                var lSumm = Convert.ToDecimal(moneyTxt.Text);
                var lStartDate = startDate.Value;
                var lEndDate = endDate.Value;
                var lMonth = Convert.ToInt32(monthTxt.Text);
                var lPersent = persentTxt.Text.Contains(".") ? Convert.ToDouble(persentTxt.Text.Replace(".", ",")) : Convert.ToDouble(persentTxt.Text);
                var lComment = comments.Text;
                var lIsOld = 0;
                if (isOld.Checked)
                    lIsOld = 1;

                if (lBankLabel == "" || lSumm == 0 || lMonth == 0)
                {
                    MessageBox.Show("Set all required fields");
                }
                else
                {
                    var lBank = new Model.Bank();
                    lBank.Id = this.mBankId;
                    lBank.BankName = lBankLabel;
                    lBank.Summ = lSumm;
                    lBank.StartDate = lStartDate;
                    lBank.EndDate = lEndDate;
                    lBank.Month = lMonth;
                    lBank.Persent = lPersent;
                    lBank.Comment = lComment;
                    lBank.Status = lIsOld;
                    DBAction.UpdateBankItem(lBank);
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

        private void Update_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            BankForm lBankForm = new BankForm();
            lBankForm.Show();
        }

    }
}
