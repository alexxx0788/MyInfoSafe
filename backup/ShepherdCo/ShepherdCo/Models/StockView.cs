using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShepherdCoAPI.Model;

namespace ShepherdCo.Models
{
    public class StockView:Stock
    {
        public double Change { get; set; }
        public double ChangePersentage { get; set; }

    }
}