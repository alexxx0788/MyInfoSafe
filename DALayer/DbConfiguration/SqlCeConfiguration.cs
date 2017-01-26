using System.Data.SqlServerCe;

namespace DALayer.API.DbConfiguration
{
    public class SqlCeConfiguration
    {
        public const string DataBaseName = "info_base.sdf";
        public static SqlCeConnection GetConnectString(string pass)
        {
            var path = @"D:\GIT\MyInfoSafe\db\INFODb.sdf";
            var lConnString = "DataSource=\'" + path + "\'; Password=\'" + pass + "\'";
            return new SqlCeConnection(lConnString);
        }
    }
}
