using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShepherdCoAPI.Model;
using ShepherdCoAPI.Repository;

namespace ShepherdCo.Controllers
{
    public class OrderController : ApiController
    {
        // POST api/balance
        public void Post(dynamic order)
        {
            //var user = new User() {Balance = balance, Login = login, UserId = userId};
            OrderRepository orderRepository = new OrderRepository(new SqlConnection(Helper.connString));
             //move into config
            var stockId = 0;
            int.TryParse(order["stockId"].Value, out stockId);

            orderRepository.Insert(stockId, 1, order["Date"].Value); // move to configuration
        }
    }
}
