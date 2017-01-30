using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using ShepherdCoAPI.Helper;
using ShepherdCoAPI.Shared.Repository;

namespace ShepherdCoAPI.Repository
{
    public class DapperRepository<T> : IRepository<T> where T : class
    {
        protected readonly IDbConnection Db;
        private readonly Type _type;

        public DapperRepository(IDbConnection connection)
        {
            Db = connection;
            _type = typeof(T);
        }

        public virtual bool Delete(int id)
        {
            var pattern = $"DELETE FROM {_type.Name} WHERE {FieldsHelper.GetDeleteByField(_type)}={id}";
            var rowsAffected = Db.Execute(pattern);
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

        public virtual T GetEntry(int id)
        {
            var pattern = $"SELECT * FROM [{_type.Name}] WHERE UserID={id}";
            return Db.Query<T>(pattern).SingleOrDefault();
        }

        public virtual IEnumerable<T> GetList()
        {
            var pattern = $"SELECT * FROM [{_type.Name}]";
            return Db.Query<T>(pattern);
        }

        public virtual bool Insert(T item)
        {
            var pattern =
                $"INSERT INTO [{_type.Name}]({FieldsHelper.GetFieldsForInsert(_type, ",")}) VALUES (@{FieldsHelper.GetFieldsForInsert(_type, ", @")})";
            var rowsAffected = Db.Execute(pattern, item);
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public virtual bool Update(T item, int id)
        {
            var pattern =
                $"UPDATE [{_type.Name}] SET {FieldsHelper.GetFieldsForUpdate(_type)} WHERE {FieldsHelper.GetSearchByField(_type)} = {id}";
            int rowsAffected = Db.Execute(pattern, item);
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
    }
}
