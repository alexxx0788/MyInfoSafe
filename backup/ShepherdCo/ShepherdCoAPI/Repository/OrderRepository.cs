using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using Dapper;
using ShepherdCoAPI.Helper;
using ShepherdCoAPI.Model;
using ShepherdCoAPI.Shared.Repository;

namespace ShepherdCoAPI.Repository
{
    public class OrderRepository : DapperRepository<Order>
    {
        public OrderRepository(IDbConnection connection) : base(connection)
        {
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Order> GetList()
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserId", 1);
            /*  var item = Db.Query<Order,Stock,User>
                  ("GetOrders",
                  param,
                  (f, r) =>
                  {
                      f.User = r;
                      return f;
                  },
              splitOn: "RatingId",
                  commandType: CommandType.StoredProcedure).ToList();*/
            var list = Db.Query<Order, Stock,Order>("GetOrders",
                (order, stock) => 
                { order.Stock = stock;
                    return order;
                },
                param,
                splitOn:"UserId",
                commandType: CommandType.StoredProcedure).ToList();
            return null;
        }
    }
}
