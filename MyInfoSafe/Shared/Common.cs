using System.Diagnostics;
using System.IO;
using MyInfoSafe.Yandex;

namespace MyInfoSafe.Shared
{
    class Common
    {
        public static void CloseForm()
        {
            if (Config.Constants.WriteMode)
            {
                if (Config.Constants.RewriteDB)
                {
                    YandexDiskClient lDIsk = new YandexDiskClient(Config.Constants.YandexToken);
                    lDIsk.PUT(Config.Constants.DBFile, Config.Constants.DBFile);
                }
                //   SaveDuplicate();
            }
            RemoveFile(Config.Constants.DBFile);
            Process.GetCurrentProcess().Kill();
        }

        private static void SaveDuplicate()
        {
            var lDir = new DirectoryInfo(Config.Constants.DbTempDir);
            if (!lDir.Exists)
            {
                lDir = Directory.CreateDirectory(Config.Constants.DbTempDir);
            }
            File.Copy(Config.Constants.DBFile, lDir + "\\" + Config.Constants.DBFile, true);
        }


        public static void RemoveFile(string pFilePath)
        {
            File.Delete(pFilePath);
        }
    }
}