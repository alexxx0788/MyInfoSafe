using System;
using System.Data.SqlServerCe;
using System.Linq;
using IStor.DAL.Shared.Helper;
using IStorage.DAL.Model;
using IStorage.DAL.Repository.Db;

namespace IStorage.DAL.Repository
{
    public class UsersRepository : SqlRepository<Users>
    {
        public UsersRepository(string connectionString) : base(connectionString) { }
        public virtual bool IsValidPassword(string password)
        {
            try
            {
                using (var dapper = new DapperHelper<Users>(SqlConnectionString))
                {
                    var pattern = $"SELECT * FROM [Users] WHERE Password='{password}'";
                    var user = dapper.ExecuteQuery(pattern).SingleOrDefault();
                    return user != null;
                }
            }
            catch (SqlCeException ex)
            {
                //logger wrong password
                return false;
            }
        }
    }
}
