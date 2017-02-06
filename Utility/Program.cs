using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Model;

namespace Utility
{
    class Program
    {
        static void Main(string[] args)
        {
            var objects = new List<User>()
            {
                new User() {Age =20,Email = "ssdda@sdfsf.ru",FirstName = "firstName",LastName = "lastName",TechnicalDetails = "ddddddd",UserId = 123},
                new User() {Age =20,Email = "ssdda@sdfsf.ru",FirstName = "firstName",LastName = "lastName",TechnicalDetails = "ddddddd",UserId = 123}
            };
            using (TextWriter tw = File.CreateText("D:\\testoutput.csv"))
            {
                foreach (var line in Exporter.ToCsv(objects, ";"))
                {
                    tw.WriteLine(line);
                }
            }
        }
    }
}
