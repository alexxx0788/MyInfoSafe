using System.Collections.Generic;
using System.Data;
using System.Linq;
using ShepherdCoAPI.Helper;
using ShepherdCoAPI.Model;
using ShepherdCoAPI.Shared.Repository;

namespace ShepherdCoAPI.Repository
{
    public class UserController : DapperRepository<User>
    {
        public UserController(IDbConnection connection) : base(connection)
        {
            if (!base.GetList().Any())
            {
                base.Insert(DummyData.GetTestUser());
            }
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
