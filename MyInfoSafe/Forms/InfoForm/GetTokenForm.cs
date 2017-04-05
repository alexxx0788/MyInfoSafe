using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using IStorage.WFA.Shared;
using Form = System.Windows.Forms.Form;

namespace IStorage.WFA.Forms.InfoForm
{
    public partial class GetTokenForm : Form
    {
        public GetTokenForm(string exception)
        {
            InitializeComponent();
            textBox1.Text = exception;
        }

        /*private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(string.Format("https://oauth.yandex.ru/authorize?response_type=token&client_id={0}",
                Config.Settings.YandexAppId));
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            File.Copy(@"C:\\Program Files\\tempDb\\info_base.sdf", @"info_base.sdf");
            Hide();
            var lMain = new Main();
            lMain.Show();
        }*/
    }
}