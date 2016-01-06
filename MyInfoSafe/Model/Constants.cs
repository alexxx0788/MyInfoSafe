using System.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;


namespace MyInfoSafe.Model
{
    public static class Config
    {
        public static class Constants
        {
            private static string mDbPassword = string.Empty;
            private static string mYandexToken = ConfigurationManager.AppSettings["YandexToken"];
            private const string mYandexAppId = "d7aa8a001f1a4a40b6148d91458d8419";
            private static bool mRewriteDB = false;
            private const string mDBFile = "info_base.sdf";
            private static bool mShowOldBank = false;
            private static int mVersion = 1;
            private static bool mWriteMode = true;


            public static string DBPassword
            {
                get { return mDbPassword; }
                set { mDbPassword = value; } 
            }
            public static string YandexToken
            {
                get { return mYandexToken; }
            }
            public static string YandexAppId
            {
                get { return mYandexAppId; }
            }
            public static bool RewriteDB
            {
                get { return mRewriteDB; }
                set { mRewriteDB = value; } 
            }
            public static string DBFile
            {
                get { return mDBFile; }
            }
            public enum Forms
            {
                services,
                bank
            }

            public static bool ShowOldBank
            {
                get { return mShowOldBank; }
                set { mShowOldBank = value; } 
            }
            public static int Version 
            {
                get { return mVersion; }
                set { mVersion = value; } 
            }
            public static bool WriteMode
            {
                get { return mWriteMode; }
                set { mWriteMode = value; }
            }
        }
    }
}
