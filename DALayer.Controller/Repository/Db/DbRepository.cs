using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using IStor.DAL.Helper;
using IStor.DAL.Model.Repository;

namespace IStor.DAL.Controller
{
    public class DapperRepository<T> : IRepository<T> where T : class
    {
        private readonly IDbConnection _db;
        private readonly Type _type;
        public DapperRepository(IDbConnection connection)
        {
            _db = connection;
            _type = typeof(T);
        }

        public bool Delete(int id)
        {
            var pattern = $"DELETE FROM {_type.Name} WHERE {FieldsHelper.GetPrimaryKeyField(_type)}={id}";
            var rowsAffected = _db.Execute(pattern);
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T GetEntry(int id)
        {
            var pattern = $"SELECT * FROM {_type.Name} WHERE ID={id}";
            return _db.Query<T>(pattern).SingleOrDefault();
        }

        public IEnumerable<T> GetList(string service)
        {
            var pattern = $"SELECT * FROM [{_type.Name}] WHERE {FieldsHelper.GetPrimaryKeyField(_type)} like '%{service}%'";
            return _db.Query<T>(pattern);
        }

        public bool Insert(T item)
        {
            var pattern =
                $"INSERT INTO [{_type.Name}]({FieldsHelper.GetPrimaryKeyField(_type)}) VALUES (@{FieldsHelper.GetPrimaryKeyField(_type)})";
            var rowsAffected = _db.Execute(pattern, item);
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool Update(T item,int id)
        {
            int rowsAffected = this._db.Execute($"UPDATE [{_type.Name}] SET {FieldsHelper.GetPrimaryKeyField(_type)} WHERE {FieldsHelper.GetPrimaryKeyField(_type)} = {id}" , item);
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
    }
}
