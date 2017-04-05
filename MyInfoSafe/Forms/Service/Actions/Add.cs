using System;
using System.Windows.Forms;
using IStorage.DAL.Model;
using IStorage.DAL.Repository;
using IStorage.WFA.Shared;
using Form = System.Windows.Forms.Form;

namespace IStorage.WFA.Forms.Service.Actions
{
    public partial class Add : Form
    {
        private readonly InfoRepository _repository = new InfoRepository(Config.Settings.ConnectionString);
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
                var infoDto = new Info
                {
                    Service = service,
                    Login = login,
                    Password = password,
                    Details = address
                };
                _repository.Insert(infoDto);
                Config.Settings.RewriteDB = true;
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