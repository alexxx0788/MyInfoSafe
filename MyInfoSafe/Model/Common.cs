using MyInfoSafe.Yandex;
using System.IO;
using System.Diagnostics;
namespace MyInfoSafe.Model
{
    public class Common
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
                SaveDuplicate();
            }
            RemoveFile(Config.Constants.DBFile);
            Process.GetCurrentProcess().Kill();
        }

        private static void SaveDuplicate()
        {
            var lDir = new DirectoryInfo(@"C:\Program Files\tempDb");
            if (!lDir.Exists)
            {
                var lProgFilesDir = new DirectoryInfo(@"C:\Program Files");
                lProgFilesDir.CreateSubdirectory("tempDb");
            }
            File.Copy(Config.Constants.DBFile, lDir.ToString() + "\\" + Config.Constants.DBFile,true);
        }


        public static void RemoveFile(string pFilePath)
        {
            File.Delete(pFilePath);
        }
    }
}
