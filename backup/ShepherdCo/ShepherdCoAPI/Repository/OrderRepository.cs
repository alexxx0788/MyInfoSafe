using System;
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
        private Type _type = typeof(Order);
        public OrderRepository(IDbConnection connection) : base(connection)
        {
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(int stockId,int userId,DateTime date)
        {
            var order = new
            {
                StockId = stockId,
                UserId = userId,
                DateTime = date
            };
            var pattern =
                $"INSERT INTO [Order](StockId,UserId,DateTime) VALUES (@StockId,@UserId,@DateTime)";
            var rowsAffected = Db.Execute(pattern, order);
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<Order> GetList(int userId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserId", userId);
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
            return list;
        }
    }
}
