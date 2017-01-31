using System.Data;
using System.Linq;
using ShepherdCoAPI.Helper;
using ShepherdCoAPI.Model;

namespace ShepherdCoAPI.Repository
{
    public class UserRepository : DapperRepository<User>
    {
        public UserRepository(IDbConnection connection) : base(connection)
        {
            if (!base.GetList().Any())
            {
                base.Insert(DummyData.GetTestUser());
            }
        }
    }
}
