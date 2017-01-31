using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using ShepherdCoAPI.Repository;

namespace ShepherdCo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Order(int id)
        {
            StockRepository stockController = new StockRepository(new SqlConnection(Helper.connString));
            var stock = stockController.GetEntry(id);
            return PartialView("Order", stock);
        }

        public ActionResult Balance(int id)
        {
            UserRepository userController = new UserRepository(new SqlConnection(Helper.connString));
            var user = userController.GetEntry(id);
            return PartialView("Balance", user);
        }

        public ActionResult ViewOrders()
        {
            OrderRepository orderController = new OrderRepository(new SqlConnection(Helper.connString));
            var orders = orderController.GetList(1); //move to config
            return PartialView("ViewOrders", orders);
        }

    }
}
