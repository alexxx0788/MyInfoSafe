using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShepherdCoAPI.Model;
using ShepherdCoAPI.Repository;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var conn = @"Data Source=DESKTOP-TR5K0E8\SQLSERVER;Initial Catalog=ShepherdDb;User ID=sa;Password=test";
           /* UserController user = new UserController(new SqlConnection(conn));
           //// var userDto = new User() {UserId = 1,Balance = 15000,Login = "TestUser"};
            user.Update(userDto,1);*/
            OrderRepository order = new OrderRepository(new SqlConnection(conn));
            var list = order.GetList();
        }
    }
}
