using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShepherdCo.Models;
using ShepherdCoAPI.Model;
using ShepherdCoAPI.Repository;

namespace ShepherdCo.Controllers
{
    public class StockController : ApiController
    {
        // GET api/stock
        public IEnumerable<StockView> Get()
        {
            var conn = @"Data Source=KRKPC000088;Initial Catalog=ShepherdDb;Integrated Security=True;";// move to configuration
            StockRepository stockController = new StockRepository(new SqlConnection(conn));
            var items = stockController.GetList(); // move to configuration
            var list = new List<StockView>();
            foreach (var item in items)
            {
                var currPrice = GetCurrPrice(item.Price);
                var changeDelta = Math.Round(currPrice- item.Price, 3);
                var changeDeltaPersentage = Math.Round(GetPersentage(item.Price,currPrice),3);
                list.Add
                    (
                    new StockView()
                    {
                        Company = item.Company,
                        Price = currPrice,
                        Change = changeDelta,
                        ChangePersentage = changeDeltaPersentage
                    }
                    );
                item.Price = currPrice;
                stockController.Update(item, item.StockId);
            }
            return list;
        }

        private double GetCurrPrice(double price)
        {
            double currPrice = 0;
            while (currPrice == 0)
            {
                Random random = new Random();
                var percentage = random.NextDouble() * (0.1 - (-0.1)) + (-0.1);
                currPrice = Math.Round(price + (percentage * price) / 100, 2);
                return currPrice;
            }
            return currPrice;
        }

        private double GetPersentage(double previusPrice,double currentPrice)
        {
            var diff = currentPrice-previusPrice;
            var persentage = (diff / currentPrice) * 100;
            return persentage;
        }
    }
}
