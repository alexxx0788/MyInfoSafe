using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using MyInfoSafe.Forms.Service;
using MyInfoSafe.Model;
using MyInfoSafe.forms;
using Form = System.Windows.Forms.Form;

namespace MyInfoSafe.Forms.InfoForm
{
    public partial class GetTokenForm : Form
    {
        public GetTokenForm()
        {
            InitializeComponent();
            var lFile = new FileInfo("C:\\Program Files\\tempDb\\info_base.sdf");
            if (!lFile.Exists)
            {
                linkLabel2.Visible = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(string.Format("https://oauth.yandex.ru/authorize?response_type=token&client_id={0}", Config.Constants.YandexAppId));
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Config.Constants.WriteMode = false;
            File.Copy(@"C:\\Program Files\\tempDb\\info_base.sdf", @"info_base.sdf");
            Hide();
            var lMain = new Main();
            lMain.Show();
        }
    }
}
