using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using MyInfoSafe.Model;

namespace MyInfoSafe.DataBase
{
    public class DBAction
    {
        private static string GetConnectString(string pPassword)
        {
            var lConnectionString = "DataSource=\'" + Config.Constants.DBFile + "\'; Password=\'" + pPassword + "\'";
            return lConnectionString;
        }

        public static Result ChangeDataBasePassword(string pOldPassword, string pNewPassword)
        {
            var lResult = new Result(1, "Password has been changed");
            try
            {
                var lEngine = new SqlCeEngine("Data Source=" + Config.Constants.DBFile + ";Password=" + pOldPassword + ";Persist Security Info=True");
                lEngine.Compact(null);
                lEngine.Compact("Data Source=" + Config.Constants.DBFile + ";Password=" + pNewPassword + ";Persist Security Info=True");
                Config.Constants.DBPassword = pNewPassword;
                Config.Constants.RewriteDB = true;
            }
            catch (Exception ex)
            {
                lResult = new Result(-1, ex.Message);
            }
            return lResult;
        }

        public static int GetProgramVersion()
        {
            var lConnectionString = new SqlCeConnection(GetConnectString(Config.Constants.DBPassword));
            if (lConnectionString.State == ConnectionState.Closed)
            {
                lConnectionString.Open();
            }
            var lSqlQuesry = "select version from users ";
            try
            {
                var lCommand = new SqlCeCommand(lSqlQuesry, lConnectionString);
                lCommand.CommandType = CommandType.Text;
                var lResultSet = lCommand.ExecuteResultSet(ResultSetOptions.Scrollable);
                if (lResultSet.HasRows)
                {
                    while (lResultSet.Read())
                    {
                        return lResultSet.GetInt32(0);
                    }
                }
            }
            finally
            {
                lConnectionString.Close();
            }
            return 0;
        }

        public static Result IsValidPassword()
        {
            var lResult = new Result();
            var lConnectionString = new SqlCeConnection(GetConnectString(Config.Constants.DBPassword));
            try
            {
                try
                {
                    var lEngine = new SqlCeEngine("Data Source=" + Config.Constants.DBFile + ";Password=" + Config.Constants.DBPassword + ";Persist Security Info=True");
                }
                finally
                {
                    lConnectionString.Open();
                    if (Config.Constants.Version != GetProgramVersion())
                        throw new Exception("You need to upgare your version");
                }
            }
            catch (Exception ex)
            {
                lResult = new Result(-1, ex.Message);
            }
            finally
            {
                lConnectionString.Close();
            }
            return lResult;
        }

        /*  public static bool GetUserLogin(string pass)
          {
              bool Result = false;
              SqlCeConnection cn = new SqlCeConnection(GetConnectString(pass));
              if (cn.State == ConnectionState.Closed)
              {
                  cn.Open();
              }
              string sql = "select * from users where login='"+login+"' AND Password='"+pass+"'";
              try
              {
                  SqlCeCommand cmd = new SqlCeCommand(sql, cn);
                  cmd.CommandType = CommandType.Text;
                  SqlCeResultSet rs = cmd.ExecuteResultSet(ResultSetOptions.Scrollable);
                  if (rs.HasRows)
                  {
                      Result = true;
                      /*int ordLastName = rs.GetOrdinal("login");
                      int ordFirstname = rs.GetOrdinal("Password");
                      StringBuilder output = new StringBuilder();
                      rs.ReadFirst();
                      output.AppendLine(rs.GetString(ordFirstname) + "" + rs.GetString(ordLastName));
                      while (rs.Read())
                      {
                      }
                  }
                  else
                  {
                      Result = false;
                  }
 
              }
              catch (Exception ex)
              {
              }
              finally
              {
              cn.Close();
              }
              return Result;
          }*/

        public static Remind GetRemindItemByID(int pId)
        {
            var lItem = new Remind();
            var lConnection = new SqlCeConnection(GetConnectString(Config.Constants.DBPassword));
            if (lConnection.State == ConnectionState.Closed)
            {
                lConnection.Open();
            }
            var lSqlQuery = "select * from remind where Id=" + pId.ToString();
            try
            {
                var cmd = new SqlCeCommand(lSqlQuery, lConnection);
                cmd.CommandType = CommandType.Text;
                var rs = cmd.ExecuteResultSet(ResultSetOptions.Scrollable);
                if (rs.HasRows)
                {
                    var lEmailAccount = rs.GetOrdinal("emailAccount");
                    var lEmailPassword = rs.GetOrdinal("emailPassword");
                    var lEmailAddress = rs.GetOrdinal("emailAddress");
                    var lSmtpAddress = rs.GetOrdinal("smtpAddress");
                    var lPort = rs.GetOrdinal("port");
                    var lSendTo = rs.GetOrdinal("sendTo");
                    var lCount = rs.GetOrdinal("count");
                    while (rs.Read())
                    {
                        lItem.EmailAccount = rs.GetString(lEmailAccount);
                        lItem.Password = rs.GetString(lEmailPassword);
                        lItem.Address = rs.GetString(lEmailAddress);
                        lItem.Smtp = rs.GetString(lSmtpAddress);
                        lItem.Port = rs.GetInt32(lPort);
                        lItem.ToAddress = rs.GetString(lSendTo);
                        lItem.Count = rs.GetInt32(lCount);
                    }
                }
            }
            catch {}
            finally
            {
                lConnection.Close();
            }
            return lItem;
        }

        public static void UpdateRemindItem(Remind pItem)
        {
            var lConnection = new SqlCeConnection(GetConnectString(Config.Constants.DBPassword));
            if (lConnection.State == ConnectionState.Closed)
            {
                lConnection.Open();
            }
            var sql = "update remind set count='" + pItem.Count.ToString() + "',emailAccount='" + pItem.EmailAccount + "',emailAddress='" + pItem.Address + "',emailPassword='" + pItem.Password + "',port='" + pItem.Port.ToString() + "',sendTo='" + pItem.ToAddress + "',smtpAddress='" + pItem.Smtp + "' where Id=1";
            try
            {
                var lCommand = new SqlCeCommand(sql, lConnection);
                lCommand.CommandType = CommandType.Text;
                lCommand.ExecuteNonQuery();
                Config.Constants.RewriteDB = true;

            }
            catch{}
            finally
            {
                lConnection.Close();
            }
        }


        public static List<Bank> GetBankInfoFromBase(string pSearch)
        {
            Bank.Total = 0;
            Bank.MonthlyIncome = 0;
            var lInfoList = new List<Bank>();
            var lConnection = new SqlCeConnection(GetConnectString(Config.Constants.DBPassword));
            if (lConnection.State == ConnectionState.Closed)
            {
                lConnection.Open();
            }
            var lSqlQuery = "select * from bank ";
            if (pSearch != "")
            {
                lSqlQuery += "where bank like '%" + pSearch + "%'";
                if (!Config.Constants.ShowOldBank)
                    lSqlQuery += " AND type=0";
            }
            else
            {
                if (!Config.Constants.ShowOldBank)
                    lSqlQuery += "where type=0";
            }
            lSqlQuery += " order by fDate asc";
            try
            {
                var lCommand = new SqlCeCommand(lSqlQuery, lConnection);
                lCommand.CommandType = CommandType.Text;
                var lResultSet = lCommand.ExecuteResultSet(ResultSetOptions.Scrollable);
                if (lResultSet.HasRows)
                {
                    var lId = lResultSet.GetOrdinal("id");
                    var lBankName = lResultSet.GetOrdinal("bank");
                    var lSumm = lResultSet.GetOrdinal("summ");
                    var lStartDate = lResultSet.GetOrdinal("sDate");
                    var lEndDate = lResultSet.GetOrdinal("fDate");
                    var lMonth = lResultSet.GetOrdinal("month");
                    var lPersent = lResultSet.GetOrdinal("persent");
                    var lTypeID = lResultSet.GetOrdinal("type");
                    var lComment = lResultSet.GetOrdinal("commentaries");
                    while (lResultSet.Read())
                    {
                        var lBank = new Bank();
                        var lTemp = 0;
                        lTemp = lResultSet.GetInt32(lId);
                        lBank.Id = lTemp;
                        lBank.BankName = lResultSet.GetString(lBankName);
                        lBank.Summ = lResultSet.GetDecimal(lSumm);
                        lBank.StartDate = new DateTime(lResultSet.GetDateTime(lStartDate).Year, lResultSet.GetDateTime(lStartDate).Month, lResultSet.GetDateTime(lStartDate).Day);
                        lBank.EndDate = new DateTime(lResultSet.GetDateTime(lEndDate).Year, lResultSet.GetDateTime(lEndDate).Month, lResultSet.GetDateTime(lEndDate).Day);
                        lBank.Month = lResultSet.GetInt32(lMonth);
                        lBank.Persent = lResultSet.GetDouble(lPersent);
                        lBank.Status = lResultSet.GetInt32(lTypeID);
                        var daysLeft = (lBank.EndDate - DateTime.Today).Days;
                        if (daysLeft>0)
                            lBank.DaysLeft=daysLeft;

                        if (lBank.Status == 0)
                            lBank.Type = "current";
                        else
                            lBank.Type = "old";
                        lBank.Comment = lResultSet.GetString(lComment);

                        if (lBank.Status == 0)
                        {
                            Bank.Total += lBank.Summ;
                            DateTime lDateTime = new DateTime(DateTime.Today.Year, 12,31);
                            var lMonthlyIncome = ((lBank.Summ*Convert.ToDecimal(lBank.Persent)/100)/lDateTime.DayOfYear)*
                                                DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
                            Bank.MonthlyIncome += lMonthlyIncome;
                        }

                        lInfoList.Add(lBank);
                    }
                }
            }
            catch {}
            finally
            {
                lConnection.Close();
            }
            return lInfoList;
        }

        public static void InsertBankItem(Bank pBank)
        {
            var lConnection = new SqlCeConnection(GetConnectString(Config.Constants.DBPassword));
            if (lConnection.State == ConnectionState.Closed)
            {
                lConnection.Open();
            }
            var lSqlQuery = "insert into bank (bank,summ,sDate,fDate,month,persent,type,commentaries) values" +
            "('" + pBank.BankName + "','" + pBank.Summ.ToString() + "','" + pBank.StartDate.Month + "." + pBank.StartDate.Day + "." + pBank.StartDate.Year + "','" + pBank.EndDate.Month + "." + pBank.EndDate.Day + "." + pBank.EndDate.Year + "','" + pBank.Month.ToString() + "','" + pBank.Persent.ToString().Replace(',', '.') + "','" + pBank.Status + "','" + pBank.Comment + "')";
            try
            {
                var lCommand = new SqlCeCommand(lSqlQuery, lConnection);
                lCommand.CommandType = CommandType.Text;
                lCommand.ExecuteNonQuery();
                Config.Constants.RewriteDB = true;

            }
            catch{}
            finally
            {
                lConnection.Close();
            }
        }

        public static void DeleteBankItem(int pId)
        {
            var lConnection = new SqlCeConnection(GetConnectString(Config.Constants.DBPassword));
            if (lConnection.State == ConnectionState.Closed)
            {
                lConnection.Open();
            }
            var lSqlQuery = "delete from bank where id=" + pId;
            try
            {
                var lCommand = new SqlCeCommand(lSqlQuery, lConnection);
                lCommand.CommandType = CommandType.Text;
                lCommand.ExecuteNonQuery();
                Config.Constants.RewriteDB = true;
            }
            catch {}
            finally
            {
                lConnection.Close();
            }

        }

        public static Bank GetBankInfoFromBaseByID(int pId)
        {
            var lBankItem = new Bank();
            var lConnection = new SqlCeConnection(GetConnectString(Config.Constants.DBPassword));
            if (lConnection.State == ConnectionState.Closed)
            {
                lConnection.Open();
            }
            var lSqlQuery = "select * from bank ";
            if (pId > 0)
            {
                lSqlQuery += "where id=" + pId;
            }
            try
            {
                var lCommand = new SqlCeCommand(lSqlQuery, lConnection);
                lCommand.CommandType = CommandType.Text;
                var lResultSet = lCommand.ExecuteResultSet(ResultSetOptions.Scrollable);
                if (lResultSet.HasRows)
                {
                    var lBankName = lResultSet.GetOrdinal("bank");
                    var lSumm = lResultSet.GetOrdinal("summ");
                    var lStartDate = lResultSet.GetOrdinal("sDate");
                    var lEndDate = lResultSet.GetOrdinal("fDate");
                    var lMonth = lResultSet.GetOrdinal("month");
                    var lPersent = lResultSet.GetOrdinal("persent");
                    var lTypeID = lResultSet.GetOrdinal("type");
                    var lComment = lResultSet.GetOrdinal("commentaries");
                    while (lResultSet.Read())
                    {
                        var lTemp = 0;
                        lBankItem.Id = lTemp;
                        lBankItem.BankName = lResultSet.GetString(lBankName);
                        lBankItem.Summ = lResultSet.GetDecimal(lSumm);
                        lBankItem.StartDate = lResultSet.GetDateTime(lStartDate);
                        lBankItem.EndDate = lResultSet.GetDateTime(lEndDate);
                        lBankItem.Month = lResultSet.GetInt32(lMonth);
                        lBankItem.Persent = lResultSet.GetDouble(lPersent);
                        var lType = lResultSet.GetInt32(lTypeID);
                        if (lType == 0)
                            lBankItem.Type = "current";
                        lBankItem.Type = "old";
                        lBankItem.Status = lType;
                        lBankItem.Comment = lResultSet.GetString(lComment);
                    }
                }
            }
            catch {}
            finally
            {
                lConnection.Close();
            }
            return lBankItem;
        }

        public static void UpdateBankItem(Bank pBank)
        {
            var lConnection = new SqlCeConnection(GetConnectString(Config.Constants.DBPassword));
            if (lConnection.State == ConnectionState.Closed)
            {
                lConnection.Open();
            }
            var sql = "update bank set bank='" + pBank.BankName + "',summ='" + pBank.Summ.ToString() + "',sDate='" + pBank.StartDate.Month + "." + pBank.StartDate.Day + "." + pBank.StartDate.Year + "',fDate='" + pBank.EndDate.Month + "." + pBank.EndDate.Day + "." + pBank.EndDate.Year + "',month='" + pBank.Month.ToString() + "',persent='" + pBank.Persent.ToString().Replace(',', '.') + "',type='" + pBank.Status.ToString() + "',commentaries='" + pBank.Comment.ToString() + "' where id=" + pBank.Id;
            try
            {
                var lCommnad = new SqlCeCommand(sql, lConnection);
                lCommnad.CommandType = CommandType.Text;
                lCommnad.ExecuteNonQuery();
                Config.Constants.RewriteDB = true;

            }
            catch {}
            finally
            {
                lConnection.Close();
            }
        }


        public static List<Info> Service_GetInfoFromBase(string search)
        {
            var lInfo = new List<Info>();
            var lConnection = new SqlCeConnection(GetConnectString(Config.Constants.DBPassword));
            if (lConnection.State == ConnectionState.Closed)
            {
                lConnection.Open();
            }
            var lSqlQuery = "select * from info ";
            if (search != "")
            {
                lSqlQuery += "where service like '%" + search + "%'";
            }
            try
            {
                var lCommand = new SqlCeCommand(lSqlQuery, lConnection);
                lCommand.CommandType = CommandType.Text;
                var lResultSet = lCommand.ExecuteResultSet(ResultSetOptions.Scrollable);
                if (lResultSet.HasRows)
                {
                    var lId = lResultSet.GetOrdinal("id");
                    var lLogin = lResultSet.GetOrdinal("login");
                    var lPassword = lResultSet.GetOrdinal("Password");
                    var lService = lResultSet.GetOrdinal("service");
                    var lAdvanced = lResultSet.GetOrdinal("advanced");
                    while (lResultSet.Read())
                    {
                        var lInfoItem = new Info();
                        var temp = 0;
                        temp=lResultSet.GetInt32(lId);
                        lInfoItem.Id = temp;
                        lInfoItem.Login = lResultSet.GetString(lLogin);
                        lInfoItem.Password = lResultSet.GetString(lPassword);
                        lInfoItem.Service = lResultSet.GetString(lService);
                        lInfoItem.Advanced = lResultSet.GetString(lAdvanced);
                        lInfo.Add(lInfoItem);
                    }
                }
            }
            catch {}
            finally
            {
                lConnection.Close();
            }
            return lInfo;
        }

        public static Info GetInfoFromBaseByID(int id)
        {
            var lInfo = new Info();
            var lConnection = new SqlCeConnection(GetConnectString(Config.Constants.DBPassword));
            if (lConnection.State == ConnectionState.Closed)
            {
                lConnection.Open();
            }
            var lSqlQuery = "select * from info ";
            if (id > 0)
            {
                lSqlQuery += "where id="+id;
            }
            try
            {
                var lCommand = new SqlCeCommand(lSqlQuery, lConnection);
                lCommand.CommandType = CommandType.Text;
                SqlCeResultSet rs = lCommand.ExecuteResultSet(ResultSetOptions.Scrollable);
                if (rs.HasRows)
                {
                    var lId = rs.GetOrdinal("id");
                    var lLogin = rs.GetOrdinal("login");
                    var lPasswl = rs.GetOrdinal("Password");
                    var lService = rs.GetOrdinal("service");
                    var lAdvanced = rs.GetOrdinal("advanced");
                    while (rs.Read())
                    {
                        var lInfoItem = new Info();
                        var lTemp = 0;
                        lTemp = rs.GetInt32(lId);
                        lInfoItem.Id = lTemp;
                        lInfoItem.Login = rs.GetString(lLogin);
                        lInfoItem.Password = rs.GetString(lPasswl);
                        lInfoItem.Service = rs.GetString(lService);
                        lInfoItem.Advanced = rs.GetString(lAdvanced);
                        lInfo = lInfoItem;
                    }
                }
            }
            catch {}
            finally
            {
                lConnection.Close();
            }
            return lInfo;
        }

        public static void InsertInfoItem(Info pInfo)
        {
            var lConnection = new SqlCeConnection(GetConnectString(Config.Constants.DBPassword));
            if (lConnection.State == ConnectionState.Closed)
            {
                lConnection.Open();
            }
            var lSqlQuery = "insert into info (service,login,Password,advanced) values"+
            "('" + pInfo.Service + "','" + pInfo.Login + "','" + pInfo.Password + "','" + pInfo.Advanced + "')";
            try
            {
                var lCommand = new SqlCeCommand(lSqlQuery, lConnection);
                lCommand.CommandType = CommandType.Text;
                lCommand.ExecuteNonQuery();
                Config.Constants.RewriteDB = true;

            }
            catch {}
            finally
            {
                lConnection.Close();
            }

        }

        public static void UpdateInfotem(Info pInfo)
        {
            var lConnection = new SqlCeConnection(GetConnectString(Config.Constants.DBPassword));
            if (lConnection.State == ConnectionState.Closed)
            {
                lConnection.Open();
            }
            var lSqlQuery = "update info set service='" + pInfo.Service + "',login='" + pInfo.Login + "',Password='" + pInfo.Password + "',advanced='" + pInfo.Advanced+"' where id="+pInfo.Id;
            try
            {
                var lCommnad = new SqlCeCommand(lSqlQuery, lConnection);
                lCommnad.CommandType = CommandType.Text;
                lCommnad.ExecuteNonQuery();
                Config.Constants.RewriteDB = true;

            }
            catch {}
            finally
            {
                lConnection.Close();
            }
        }

        public static void DeleteInfoItem(int pId)
        {
            var lConnection = new SqlCeConnection(GetConnectString(Config.Constants.DBPassword));
            if (lConnection.State == ConnectionState.Closed)
            {
                lConnection.Open();
            }
            var lSqlQuery = "delete from info where id=" + pId;
            try
            {
                var lCommand = new SqlCeCommand(lSqlQuery, lConnection);
                lCommand.CommandType = CommandType.Text;
                lCommand.ExecuteNonQuery();
                Config.Constants.RewriteDB = true;
            }
            catch {}
            finally
            {
                lConnection.Close();
            }

        }


    }
}
