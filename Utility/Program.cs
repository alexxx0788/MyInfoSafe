using System.Data;
using System.Linq;
using IStor.DAL.Model;
using IStor.DAL.Repository;
using Newtonsoft.Json;

namespace Utility
{
    class Program
    {
        static void Main(string[] args)
        {
            var connOld = @"Data Source=c:\ALEXXX\old\info_base.sdf;Persist Security Info=False;password=alexxx1428";
            var connNew = @"Data Source=c:\ALEXXX\new\info_base.sdf;Persist Security Info=False;password=alexxx1428";
            InfoRepositoryOld repoOld = new InfoRepositoryOld(connOld);
            var list = repoOld.GetList().OrderBy(i=>i.Id);

            InfoRepositoryNew repoNew = new InfoRepositoryNew(connNew);
            foreach (var infoOld in list)
            {
                var obj = new InfoNew()
                {
                    Details = infoOld.advanced,
                    Login = infoOld.login,
                    Password = infoOld.password,
                    Service = infoOld.service
                };
                repoNew.Insert(obj);
            }

        }
    }
}
