using System;
using System.Windows.Forms;
using DALayer.API.Dto;
using DALayer.API.Model;
using MyInfoSafe.Shared;
using Form = System.Windows.Forms.Form;

namespace MyInfoSafe.Forms.Service.Actions
{
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private void add_new_item_Click(object sender, EventArgs e)
        {
            var service = service_txt.Text;
            var login = login_txt.Text;
            var password = pwd_txt.Text;
            var address = advanced_txt.Text;
            if (service == String.Empty || login == String.Empty || password == String.Empty)
            {
                MessageBox.Show("Set All Required Fields");
            }
            else
            {
                var infoDto = new InfoDto();
                infoDto.Service = service;
                infoDto.Login = login;
                infoDto.Password = password;
                infoDto.Advanced = address;
                var info = new Info();
                info.InsertItem(infoDto, Config.Constants.DBPassword);
                Hide();
                var infoForm = new ServiceForm();
                infoForm.Show();
            }
        }

        private void Add_New_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            var infoForm = new ServiceForm();
            infoForm.Show();
        }
    }
}