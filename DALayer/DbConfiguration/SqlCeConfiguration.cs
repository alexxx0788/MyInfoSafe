using System.Data.SqlServerCe;

namespace DALayer.API.DbConfiguration
{
    public class SqlCeConfiguration
    {
        public const string DataBaseName = "info_base.sdf";
        public static SqlCeConnection GetConnectString(string pass)
        {
            var lConnString = "DataSource=\'" + DataBaseName + "\'; Password=\'" + pass + "\'";
            return new SqlCeConnection(lConnString);
        }
    }
}
