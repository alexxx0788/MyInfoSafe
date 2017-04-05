using System.Configuration;

namespace IStorage.WFA.Shared
{
    public static class Config
    {
        public static class Settings
        {
            private static string _dbPassword = string.Empty;
            private static readonly string yandexToken = ConfigurationManager.AppSettings["YandexToken"];
            private static readonly string dbTempDir = ConfigurationManager.AppSettings["DbTempDir"];
            private static string DbFile = ConfigurationManager.AppSettings["DbFile"];
            private const string yandexAppId = "d7aa8a001f1a4a40b6148d91458d8419";
            private static bool rewriteDB = false;


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
            public static string ConnectionString
            {
                get { return $"Data Source={DbFile};Persist Security Info=False;password={DBPassword}"; }
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
            
        }
    }
}