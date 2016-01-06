using System;
using System.Windows.Forms;
using MyInfoSafe.Model;
using MyInfoSafe.DataBase;
using Form = System.Windows.Forms.Form;

namespace MyInfoSafe.Forms.Service.Action
{
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private void add_new_item_Click(object sender, EventArgs e)
        {
            var lService = service_txt.Text;
            var lLogin = login_txt.Text;
            var lPassword = pwd_txt.Text;
            var lAddress = advanced_txt.Text;
            if (lService == "" || lLogin == "" || lPassword == "")
            {
                MessageBox.Show("Set All Required Fields");
            }
            else
            {
                var lInfo = new Info();
                lInfo.Service=lService;
                lInfo.Login=lLogin;
                lInfo.Password=lPassword;
                lInfo.Advanced=lAddress;
                DBAction.InsertInfoItem(lInfo);
                Hide();
                var lInfoForm = new ServiceForm();
                lInfoForm.Show();

            }
        }

        private void Add_New_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            var lInfoForm = new ServiceForm();
            lInfoForm.Show();
        }

       
    }
}
