using System;
using System.Windows.Forms;
using DALayer.API.Dto;
using DALayer.API.Model;
using MyInfoSafe.Shared;
using Form = System.Windows.Forms.Form;

namespace MyInfoSafe.Forms.Service.Actions
{
    public partial class Update : Form
    {
        public int InfoId;

        public Update(int infoId)
        {
            InitializeComponent();
            if (!Config.Constants.WriteMode)
            {
                edit.Visible = false;
            }
            this.InfoId = infoId;
            var infoDto = (new Info()).GetItemById(infoId, Config.Constants.DBPassword);
            service_txt.Text = infoDto.Service;
            login_txt.Text = infoDto.Login;
            pwd_txt.Text = infoDto.Password;
            advanced_txt.Text = infoDto.Advanced;
            (new Info()).UpdateItem(infoDto, Config.Constants.DBPassword);
        }

        private void edit_Click(object sender, EventArgs e)
        {
            var service = service_txt.Text;
            var login = login_txt.Text;
            var password = pwd_txt.Text;
            var text = advanced_txt.Text;
            if (service == string.Empty || login == string.Empty || password == string.Empty)
            {
                MessageBox.Show("Set All Required Fields");
            }
            else
            {
                var info = new InfoDto();
                info.Service = service;
                info.Login = login;
                info.Password = password;
                info.Advanced = text;
                info.Id = InfoId;
                (new Info()).UpdateItem(info, Config.Constants.DBPassword);
                Hide();
                var infoBank = new ServiceForm();
                infoBank.Show();
            }
        }

        private void Edit_Item_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            var infoItem = new ServiceForm();
            infoItem.Show();
        }
    }
}