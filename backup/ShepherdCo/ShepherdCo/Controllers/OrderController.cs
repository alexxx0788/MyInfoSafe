using System.Data.SqlClient;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using ShepherdCoAPI.Helper;
using ShepherdCoAPI.Repository;

namespace ShepherdCo.Controllers
{
    public class OrderController : ApiController
    {
        // POST api/balance
        public JsonResult Post(dynamic item)
        {
            var stockId = 0;
            var amount = 0;
            int.TryParse(item["stockId"].Value, out stockId);
            int.TryParse(item["amount"].Value, out amount);
         
            StockRepository stockRepo = new StockRepository(new SqlConnection(Helper.connString));
            var stock = stockRepo.GetEntryById(stockId);
            if (stock.Amount < amount)
            {
                var result = new Responce() {Message = "Not enought stocks to buy",Status = false};
                return new JsonResult() { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                MakeOrder(stockId,amount);
                var result = new Responce() { Message = "Conratulation!!!", Status = true };
                return new JsonResult() { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            
        }

        private void MakeOrder(int stockId,int amount)
        {
            OrderRepository orderRepository = new OrderRepository(new SqlConnection(Helper.connString));
            orderRepository.Insert(1, stockId, amount); // move to configuration
        }
    }
}
