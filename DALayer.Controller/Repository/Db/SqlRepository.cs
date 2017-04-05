using System;
using System.Collections.Generic;
using System.Linq;
using IStor.DAL.Repository.Db;
using IStor.DAL.Shared.Helper;
using IStorage.DAL.Shared.Helper;

namespace IStorage.DAL.Repository.Db
{
    public abstract class SqlRepository<T> : IRepository<T> where T : class
    {
        protected readonly string SqlConnectionString;
        private readonly Type _type;

        protected SqlRepository(string connectionString)
        {
            SqlConnectionString = connectionString;
            _type = typeof(T);
        }

        public int Count
        {
            get
            {
                using (var dapper = new DapperHelper<T>(SqlConnectionString))
                {
                    var pattern = $"SELECT COUNT(*) FROM [{_type.Name}]";
                    return dapper.ExecuteScalar(pattern);
                }
            }
        }

        public virtual T FindById(int id)
        {
            using (var dapper = new DapperHelper<T>(SqlConnectionString))
            {
                var pattern = $"SELECT * FROM [{_type.Name}] WHERE {FieldsHelper.GetPrimaryKey(_type)}={id}";
                return dapper.ExecuteQuery(pattern).SingleOrDefault();
            }
        }

        public virtual IEnumerable<T> GetList()
        {
            using (var dapper = new DapperHelper<T>(SqlConnectionString))
            {
                var pattern = $"SELECT * FROM [{_type.Name}]";
                return dapper.ExecuteQuery(pattern);
            }
        }

        public virtual IEnumerable<T> GetList(string text)
        {
            using (var dapper = new DapperHelper<T>(SqlConnectionString))
            {
                var pattern = $"SELECT * FROM [{_type.Name}]";
                return dapper.ExecuteQuery(pattern);
            }
        }
        
        public virtual bool Insert(T item)
        {
            using (var dapper = new DapperHelper<T>(SqlConnectionString))
            {
                var pattern =
                    $"INSERT INTO [{_type.Name}]({FieldsHelper.GetFieldsForInsert(_type, ",")}) VALUES (@{FieldsHelper.GetFieldsForInsert(_type, ", @")})";
                return dapper.Execute(pattern, item);
            }
        }

        public virtual bool Update(T item, int id)
        {
            using (var dapper = new DapperHelper<T>(SqlConnectionString))
            {
                var pattern =
                    $"UPDATE [{_type.Name}] SET {FieldsHelper.GetFieldsForUpdate(_type)} WHERE {FieldsHelper.GetPrimaryKey(_type)} = {id}";
                return dapper.Execute(pattern, item);
            }
        }

        public virtual bool Delete(int id)
        {
            using (var dapper = new DapperHelper<T>(SqlConnectionString))
            {
                var pattern = $"DELETE FROM [{_type.Name}] WHERE {FieldsHelper.GetPrimaryKey(_type)}={id}";
                return dapper.Execute(pattern);
            }
        }
    }
}
