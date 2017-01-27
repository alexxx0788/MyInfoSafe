using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer.Controller.Model.Dto;
using DALayer.Controller.Model.Repository;

namespace DALayer.Controller.Controller
{
    public class InfoController:IRepository<Info>
    {
        private readonly DapperRepository<Info> _dapper;
        public InfoController(IDbConnection connection)
        {
            _dapper = new DapperRepository<Info>(connection);
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Info> GetList(string service)
        {
            return _dapper.GetList(service);
        }

        public Info GetEntry(int id)
        {
            return _dapper.GetEntry(id);
        }

        public bool Insert(Info item)
        {
            return _dapper.Insert(item);
        }

        public bool Update(Info item, int id)
        {
            return _dapper.Update(item, id);
        }

        public bool Delete(int id)
        {
            return _dapper.Delete(id);
        }

    }
}
