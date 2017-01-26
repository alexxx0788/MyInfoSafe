using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer.Controller.Controller;
using DALayer.Controller.Model;
using DALayer.Controller.Model.Dto;

namespace InfoSafeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var info = new Info() {Id=1,Details = "details",Login="login", Password = "pass",Service = "service"};
            var path = @"D:\GIT\MyInfoSafe\db\INFODb.sdf";
            var lConnString = "DataSource=\'" + path + "\'; Password=\'alexxx1428\'";

            DapperRepository<Info> dapper = new DapperRepository<Info>(lConnString);
           // dapper.Insert(new Info() {Details = "det",Login = "login",Password = "password",Service = "service"});
            var i = dapper.GetEntry(2);
        }
    }
}
