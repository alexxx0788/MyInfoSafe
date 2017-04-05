using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace IStor.DAL.Shared.Helper
{
    public class DapperHelper<T> : IDisposable where T : class
    {
        private readonly IDbConnection _dapperConnection;
        public DapperHelper(string connectionString)
        {
            _dapperConnection = new SqlCeConnection(connectionString);
        }
        internal int ExecuteScalar(string pattern)
        {
            return ExecuteWithErrorHandling(() => _dapperConnection.ExecuteScalar<int>(pattern));
        }
        internal IEnumerable<T> ExecuteQuery(string pattern)
        {
            return ExecuteWithErrorHandling(() => _dapperConnection.Query<T>(pattern));
        }
        internal bool Execute(string pattern, T item = null)
        {
            var rowsAffected = item == null
                ? ExecuteWithErrorHandling(() => _dapperConnection.Execute(pattern))
                : ExecuteWithErrorHandling(() => _dapperConnection.Execute(pattern, item));
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        internal IEnumerable<T> ExecuteStoredProcedure(DynamicParameters parameters, string storedProcedure)
        {
            return
                ExecuteWithErrorHandling(
                    () =>
                        _dapperConnection.Query<T>(storedProcedure, parameters,
                            commandType: CommandType.StoredProcedure));
        }

        private T ExecuteWithErrorHandling<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (TimeoutException ex)
            {
                throw new Exception("Execution of a query experienced SQL timeout", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception("Execution of a query experienced SQL exception (not a timeout)", ex);
            }
        }
        public void Dispose()
        {
            _dapperConnection.Dispose();
        }
    }
}
