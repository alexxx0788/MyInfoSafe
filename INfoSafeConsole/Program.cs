using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer.Controller.Controller;
using DALayer.Controller.Model;
using DALayer.Controller.Model.Dto;
using Newtonsoft.Json;

namespace InfoSafeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var info = new Info() {Id=1,Details = "details",Login="login", Password = "pass",Service = "service"};
            var path = @"C:\ALEXXX\INFODb.sdf";
            var lConnString = "DataSource=\'" + path + "\'; Password=\'alexxx1428\'";

            InfoController userController = new InfoController(new SqlCeConnection(lConnString));

            var items = userController.GetList("");


        }

    }
}
