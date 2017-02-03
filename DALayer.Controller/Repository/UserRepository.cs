using System.Collections.Generic;
using System.Data;
using IStor.DAL.Model.Dto;
using IStor.DAL.Model.Repository;

namespace IStor.DAL.Controller
{
    public class UserController : IRepository<User>
    {
        private readonly DapperRepository<User> _dapper;
        public UserController(IDbConnection connection)
        {
            _dapper = new DapperRepository<User>(connection);
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetList(string service)
        {
            return _dapper.GetList(service);
        }

        public User GetEntry(int id)
        {
            return _dapper.GetEntry(id);
        }

        public bool Insert(User item)
        {
            return _dapper.Insert(item);
        }

        public bool Update(User item, int id)
        {
            return _dapper.Update(item, id);
        }

        public bool Delete(int id)
        {
            return _dapper.Delete(id);
        }
    }
}
