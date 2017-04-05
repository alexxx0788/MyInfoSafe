using System.Diagnostics;
using System.IO;
using MyInfoSafe.Yandex;

namespace IStorage.WFA.Shared
{
    class Common
    {
        public static void CloseForm()
        {
            if (Config.Settings.RewriteDB)
            {
                YandexDiskClient lDIsk = new YandexDiskClient(Config.Settings.YandexToken);
                lDIsk.PUT(Config.Settings.DBFile, Config.Settings.DBFile);
            }
            RemoveFile(Config.Settings.DBFile);
            Process.GetCurrentProcess().Kill();
        }
        public static void RemoveFile(string pFilePath)
        {
            File.Delete(pFilePath);
        }
    }
}