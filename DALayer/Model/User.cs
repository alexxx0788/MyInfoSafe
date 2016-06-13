
using System;
using System.Data.SqlServerCe;
using DALayer.API.DbConfiguration;

namespace DALayer.API.Model
{
    public class User
    {
       
         public Result ChangeDataBasePassword(string pOldPassword, string pNewPassword)
        {
            var lResult = new Result(1, "Password has been changed");
            try
            {
                var lEngine = new SqlCeEngine("Data Source=" + SqlCeConfiguration.DataBaseName + ";Password=" + pOldPassword + ";Persist Security Info=True");
                lEngine.Compact(null);
                lEngine.Compact("Data Source=" + SqlCeConfiguration.DataBaseName + ";Password=" + pNewPassword + ";Persist Security Info=True");
            }
            catch (Exception ex)
            {
                lResult = new Result(-1, ex.Message);
            }
            return lResult;
        }

        public static Result IsValidPassword(string password)
        {
            var result = new Result();
            try
            {
                var connection = SqlCeConfiguration.GetConnectString(password);
            }
            catch (Exception ex)
            {
                result = new Result(-1, ex.Message);
            }
            return result;
        }
    }
}
