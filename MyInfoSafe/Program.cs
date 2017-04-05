using System;
using System.Windows.Forms;
using IStorage.WFA.Forms.InfoForm;
using IStorage.WFA.Shared;
using MyInfoSafe.Yandex;

namespace IStorage.WFA
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
                YandexDiskClient disk = new YandexDiskClient(Config.Settings.YandexToken);
                disk.GET(Config.Settings.DBFile, Config.Settings.DBFile);
                Application.Run(new Main());
            }
            catch (Exception ex)
            {
                Application.Run(new GetTokenForm(ex.Message));
            }
        }
    }
}