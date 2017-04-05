using System.Collections.Generic;
using IStor.DAL.Shared.Helper;
using IStorage.DAL.Model;
using IStorage.DAL.Repository.Db;

namespace IStorage.DAL.Repository
{
    public class InfoRepository : SqlRepository<Info>
    {
        public InfoRepository(string connectionString) : base(connectionString) { }
        public override IEnumerable<Info> GetList(string text)
        {
            using (var dapper = new DapperHelper<Info>(SqlConnectionString))
            {
                var pattern = $"SELECT * FROM [Info] WHERE Service like '{text}%'";
                return dapper.ExecuteQuery(pattern);
            }
        }
    }
}
    