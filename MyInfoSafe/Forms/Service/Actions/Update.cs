using System;
using System.Windows.Forms;
using IStorage.DAL.Model;
using IStorage.DAL.Repository;
using IStorage.WFA.Shared;
using Form = System.Windows.Forms.Form;

namespace IStorage.WFA.Forms.Service.Actions
{
    public partial class Update : Form
    {
        private readonly InfoRepository _repository = new InfoRepository(Config.Settings.ConnectionString);
        public int InfoId;

        public Update(int infoId)
        {
            InitializeComponent();
            this.InfoId = infoId;
            var info = _repository.FindById(infoId);
            service_txt.Text = info.Service;
            login_txt.Text = info.Login;
            pwd_txt.Text = info.Password;
            advanced_txt.Text = info.Details;
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
                var info = new Info
                {
                    Service = service,
                    Login = login,
                    Password = password,
                    Details = text,
                    Id = InfoId
                };
                _repository.Update(info, InfoId);
                Config.Settings.RewriteDB = true;
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

        private void delete_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Are you sure, you want to remove it?", "Removing Item", MessageBoxButtons.YesNo);
            if (res.ToString() == "Yes")
            {
                _repository.Delete(InfoId);
                Config.Settings.RewriteDB = true;
                Hide();
                var infoItem = new ServiceForm();
                infoItem.Show();
            }
            else
            {
                MessageBox.Show("You must select row");
            }
        }
    }
}