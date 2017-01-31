﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShepherdCoAPI.Model;

namespace ShepherdCoAPI.Helper
{
    public static class DummyData
    {
        private const string Chars = "abcdefghijklmnopqrstuvw";
        public static User GetTestUser()
        {
            return new User()
            {
                Balance = 10000,
                Login = "TestUser"
            };
        }
        public static Stock GetTestCompanyStock()
        {
            return new Stock()
            {
                Amount = 100,
                Company = GetTestCompanyName(),
                Price = GetTestStockPrice() 
            };
        }

        public static string GetTestCompanyName()
        {
            var random = new Random();
            return new string(Enumerable.Repeat(Chars, 3)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static double GetTestStockPrice()
        {
            var random = new Random();
            var i = random.Next(2, 200);
            var d = random.Next(10, 99);
            return double.Parse($"{i}.{d}");
        }
    }
}
