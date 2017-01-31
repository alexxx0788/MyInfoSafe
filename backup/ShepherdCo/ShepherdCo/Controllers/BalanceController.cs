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
            UserRepository userRepository = new UserRepository(new SqlConnection(Helper.connString));
            var user=  userRepository.GetEntryById(1); // move to configuration
            return user.Balance;
        }

        // PUT api/balance
        public void Put(int id,User user)
        {
            //var user = new User() {Balance = balance, Login = login, UserId = userId};
            UserRepository userRepository = new UserRepository(new SqlConnection(Helper.connString));
            userRepository.Update(user, id); // move to configuration
        }
    }
}
