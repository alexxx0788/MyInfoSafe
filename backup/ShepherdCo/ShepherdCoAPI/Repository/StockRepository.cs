using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShepherdCoAPI.Helper;
using ShepherdCoAPI.Model;
using ShepherdCoAPI.Shared.Repository;

namespace ShepherdCoAPI.Repository
{
    public class StockRepository : DapperRepository<Stock>
    {
        public StockRepository(IDbConnection connection) : base(connection)
        {
            List<string> companies = new List<string>();
            if (!base.GetList().Any())
            {
                while(companies.Count<10)
                {
                    var stock = DummyData.GetTestCompanyStock();
                    if (!companies.Contains(stock.Company))
                    {
                        base.Insert(stock);
                        companies.Add(stock.Company);
                    }
                }
            }
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
