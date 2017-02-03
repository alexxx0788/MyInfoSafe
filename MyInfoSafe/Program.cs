using System;
using System.Windows.Forms;
using MyInfoSafe.Forms.InfoForm;
using MyInfoSafe.forms;
using MyInfoSafe.Shared;
using MyInfoSafe.Yandex;

namespace MyInfoSafe
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                // YandexDiskClient disk = new YandexDiskClient(Config.Constants.YandexToken);
                // disk.GET(Config.Constants.DBFile, Config.Constants.DBFile);
                Application.Run(new Main());
            }
            catch
            {
                Application.Run(new GetTokenForm());
            }
        }
    }
}