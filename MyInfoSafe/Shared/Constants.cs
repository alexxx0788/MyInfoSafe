using System.Configuration;

namespace MyInfoSafe.Shared
{
    public static class Config
    {
        public static class Constants
        {
            private static string _dbPassword = string.Empty;
            private static readonly string yandexToken = ConfigurationManager.AppSettings["YandexToken"];
            private static readonly string dbTempDir = ConfigurationManager.AppSettings["DbTempDir"];
            private static string DbFile = "info_base.sdf";
            private const string yandexAppId = "d7aa8a001f1a4a40b6148d91458d8419";
            private static bool rewriteDB = true;
            private static int version = 1;
            private static bool writeMode = true;

            static Constants()
            {
                ShowOldBank = false;
            }
            public static string DBFile
            {
                get { return DbFile; }
            }
            public static string DbTempDir
            {
                get { return dbTempDir; }
            }
            public static string DBPassword
            {
                get { return _dbPassword; }
                set { _dbPassword = value; }
            }
            public static string YandexToken
            {
                get { return yandexToken; }
            }
            public static string YandexAppId
            {
                get { return yandexAppId; }
            }
            public static bool RewriteDB
            {
                get { return rewriteDB; }
                set { rewriteDB = value; }
            }
            public enum Forms
            {
                Services,
                Bank
            }

            public static bool ShowOldBank { get; set; }

            public static int Version
            {
                get { return version; }
                set { version = value; }
            }
            public static bool WriteMode
            {
                get { return writeMode; }
                set { writeMode = value; }
            }
        }
    }
}
