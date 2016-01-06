using System;
using System.Windows.Forms;
using MyInfoSafe.Model;
using MyInfoSafe.DataBase;
using Form = System.Windows.Forms.Form;

namespace MyInfoSafe.Forms.Service.Action
{
    public partial class Update : Form
    {
        public int lInfoId = 0;
        public Update(int lInfoId)
        {
            InitializeComponent();
            if (!Config.Constants.WriteMode)
            {
                edit.Visible = false;
            }
            this.lInfoId = lInfoId;
            var lInfo= DBAction.GetInfoFromBaseByID(lInfoId);
            service_txt.Text = lInfo.Service;
            login_txt.Text = lInfo.Login;
            pwd_txt.Text = lInfo.Password;
            advanced_txt.Text = lInfo.Advanced;
        }

        private void edit_Click(object sender, EventArgs e)
        {
            var lService = service_txt.Text;
            var lLogin = login_txt.Text;
            var lPassword = pwd_txt.Text;
            var advanced = advanced_txt.Text;
            if (lService == string.Empty || lLogin == string.Empty || lPassword == string.Empty)
            {
                MessageBox.Show("Set All Required Fields");
            }
            else
            {
                var lInfo = new Info();
                lInfo.Service = lService;
                lInfo.Login = lLogin;
                lInfo.Password = lPassword;
                lInfo.Advanced = advanced;
                lInfo.Id = lInfoId;
                DBAction.UpdateInfotem(lInfo);
                Hide();
                var lInfoBank = new ServiceForm();
                lInfoBank.Show();
            }
        }

        private void Edit_Item_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            var lInfoItem = new ServiceForm();
            lInfoItem.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
