using System;
using System.Data.SqlServerCe;
using System.Windows.Forms;
using IStorage.DAL.Model;
using IStorage.DAL.Repository;
using IStorage.WFA.Forms.Money;
using IStorage.WFA.Forms.Service;
using IStorage.WFA.Shared;
using Form = System.Windows.Forms.Form;

namespace IStorage.WFA.Forms
{
    public partial class ChangePassword : Form
    {
        private readonly UsersRepository _repository = new UsersRepository(Config.Settings.ConnectionString);
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = new Users()
            {
                Login = "alex",
                Password = new_pwd.Text
            };
            _repository.Update(user, 1);

            UpdateDbPassword(new_pwd.Text);

            Hide();
            var lInfoItem = new ServiceForm();
            lInfoItem.Show();
        }

        private void UpdateDbPassword(string newPass)
        {
            var newConnString = Config.Settings.ConnectionString.Replace(Config.Settings.DBPassword, newPass);
            SqlCeEngine engine = new SqlCeEngine(Config.Settings.ConnectionString);
            engine.Compact(newConnString);

            Config.Settings.DBPassword = newPass;
            Config.Settings.RewriteDB = true;
        }

        private void Change_Password_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            var lInfoForm = new ServiceForm();
            lInfoForm.Show();
        }
    }
}