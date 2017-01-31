using System.Collections.Generic;
using System.Data;
using System.Linq;
using ShepherdCoAPI.Helper;
using ShepherdCoAPI.Model;

namespace ShepherdCoAPI.Repository
{
    public class StockRepository : DapperRepository<Stock>
    {
        public StockRepository(IDbConnection connection) : base(connection)
        {
            
        }
    }
}
