using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using MyInfoSafe.Model;
using MyInfoSafe.DataBase;
using System.Net.Mail;
using MyInfoSafe.Forms.Bank.Action;
using MyInfoSafe.forms;
using MyInfoSafe.Forms.Service;
using Form = System.Windows.Forms.Form;

namespace MyInfoSafe.Forms.Bank
{
    public partial class BankForm : Form
    {
        public BankForm()
        {
            InitializeComponent();
            showOld.Checked = Config.Constants.ShowOldBank;
            RefreshGrid(string.Empty);
            if (!Config.Constants.WriteMode)
            {
                HideElements();
            }
        }

        private void HideElements()
        {
            addNewToolStripMenuItem.Visible = false;
            removeCurrentToolStripMenuItem.Visible = false;
            remindMeToolStripMenuItem.Visible = false;
            optionsToolStripMenuItem.Visible = false;
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            var lSearch = search_txt.Text;
            RefreshGrid(lSearch);
        }

        private void RefreshGrid (string pSearch)
        {
            List<Model.Bank> info_lst = new List<Model.Bank>();
            info_lst = DBAction.GetBankInfoFromBase(pSearch);
            grid.DataSource = info_lst;
            grid.Columns[0].Visible = false;
            grid.Columns[5].Width = 60;
            grid.Columns[6].Width = 60;
            grid.Columns[7].Width = 87;
            grid.Columns[8].Visible = false;
            grid.Columns[9].Visible = false;
            grid.Columns[10].Width = 60;

            total.Text = String.Format("Total : {0}", Model.Bank.Total.ToString("0,0.00"));
            gain.Text = String.Format("Monthly income : {0}",Math.Floor(Model.Bank.MonthlyIncome));
        }

        private void search_txt_MouseClick(object sender, MouseEventArgs e)
        {
            search_txt.Text = string.Empty;
        }

        private void InfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.CloseForm();
        }

        private void search_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var lSearch = search_txt.Text;
                RefreshGrid(lSearch);
            }
        }

        private void showOld_CheckedChanged(object sender, EventArgs e)
        {
            Config.Constants.ShowOldBank = showOld.Checked;
            RefreshGrid(search_txt.Text);
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            var lChangePassword = new ChangePassword();
            lChangePassword.Show();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            var lAddNewForm = new Add();
            lAddNewForm.Show();
        }

        private void updateCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lPosition = 0;
            if (grid.SelectedRows.Count > 0)
            {
                int.TryParse(grid.SelectedRows[0].Cells[0].Value.ToString(), out lPosition);
                var lInfo = new Info();
                var lUpdateItem = new Update(lPosition);
                Hide();
                lUpdateItem.Show();
            }
            else
            {
                MessageBox.Show("You must select row");
            }
        }

        private void removeCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lRes = MessageBox.Show("Are you sure, you want to remove it?","Removing Item",MessageBoxButtons.YesNo);
            if (lRes.ToString() == "Yes")
            {
                var position = 0;
                if (grid.SelectedRows.Count > 0)
                {
                    int.TryParse(grid.SelectedRows[0].Cells[0].Value.ToString(), out position);
                    var lInfoForm = new Info();
                    DBAction.DeleteBankItem(position);
                    RefreshGrid(string.Empty);
                }
                else
                {
                    MessageBox.Show("You must select row");
                }
            }
        }

        private void remindOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            var lRemindItem = new RemindOption();
            lRemindItem.Show();
        }

        private void remindMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var lRemindItem = DBAction.GetRemindItemByID(1);
                var lMailMessage = new MailMessage();
                var lSmtpServer = new SmtpClient(lRemindItem.Smtp);
                lMailMessage.From = new MailAddress(lRemindItem.Address);
                lMailMessage.To.Add(lRemindItem.ToAddress);
                lMailMessage.Subject = "Bank reminding email";
                lMailMessage.Body = GenerateEmailBody(lRemindItem.Count);
                lSmtpServer.Port = lRemindItem.Port;
                lSmtpServer.Credentials = new System.Net.NetworkCredential(lRemindItem.EmailAccount, lRemindItem.Password);
                lSmtpServer.EnableSsl = true;
                lSmtpServer.Send(lMailMessage);
                MessageBox.Show("Mail has been sent");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private string GenerateEmailBody(int count)
        {
            var lStringBuilder = new StringBuilder();
            var lDeposits = DBAction.GetBankInfoFromBase(string.Empty);
            var lRemindList = new List<Model.Bank>();
            foreach (var lDeposit in lDeposits)
            {
                if (lRemindList.Count < count)
                {
                    if (lDeposit.Status == 0)
                        lRemindList.Add(lDeposit);
                }
                else
                {
                    break;
                }
            }

            foreach (var lRemindItem in lRemindList)
            {
                lStringBuilder.Append(lRemindItem.BankName + "---"+lRemindItem.Summ+"---"+ lRemindItem.EndDate.ToShortDateString() + "---" + (lRemindItem.EndDate - DateTime.Today).Days+" days left\n");
            }
            return lStringBuilder.ToString();
        }

        private void serviceFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            var lServiceForm = new ServiceForm();
            lServiceForm.Show();
        }

        private void search_txt_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var lSearch = search_txt.Text;
                RefreshGrid(lSearch);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Hide();
            var lAddNewForm = new Add();
            lAddNewForm.Show();
        }
    }
}
