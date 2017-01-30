using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShepherdCoAPI.Shared.Attributes;

namespace ShepherdCoAPI.Model
{
    public class Stock
    {
        [SearchBy]
        public int StockId { get; set; }
        [Insert]
        public string Company { get; set; }
        [Insert][Update]
        public double Price { get; set; }
        [Insert]
        public int Amount { get; set; }

    }
}
