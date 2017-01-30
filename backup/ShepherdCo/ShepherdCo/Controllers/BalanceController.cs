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
    public class BalanceController : ApiController
    {
        // GET api/balance
        public double Get()
        {
            var conn = @"Data Source=KRKPC000088;Initial Catalog=ShepherdDb;Integrated Security=True;";// move to configuration
            UserController userController = new UserController(new SqlConnection(conn));
            var user=  userController.GetEntry(1); // move to configuration
            return user.Balance;
        }

        // PUT api/balance
        public void Put(User user)
        {
            var conn = @"Data Source=KRKPC000088;Initial Catalog=ShepherdDb;Integrated Security=True;";// move to configuration
            UserController userController = new UserController(new SqlConnection(conn));
            userController.Update(user,1); // move to configuration
        }
    }
}
