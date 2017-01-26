using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DALayer.Controller.Model.Dto;
using DALayer.Controller.Model.Repository;

namespace DALayer.Controller.Controller
{
    public class DapperRepository<T>:IRepository<T> where T : class
    {
        private const string TypeNamespace = "DALayer.Controller.Model.";
        private readonly IDbConnection _db;
        public DapperRepository(string connString)
        {
            _db = new SqlCeConnection(connString);
        }

        public void Delete(int id)
        {
            var tableName = typeof (T);
            var pattern = $"DELETE FROM {tableName.Name} WHERE ID={id}";
            _db.Execute(pattern);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T GetEntry(int id)
        {
            var tableName = typeof(T);
            var pattern = $"SELECT * FROM {tableName.Name} WHERE ID={id}";
            return _db.Query<T>(pattern).SingleOrDefault();
        }

        public IEnumerable<T> GetList()
        {
            throw new NotImplementedException();
        }

        public void Insert(T item)
        {
            var tableName = typeof (T);
            var pattern = $"INSERT {tableName.Name}({GetFields(tableName, ",")}) VALUES (@{GetFields(tableName, ", @")})";
            _db.Execute(pattern, item);
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }

        private string GetFields(Type type, string separator)
        {
            if (type != null)
            {
                PropertyInfo[] fields = type.GetProperties().Where(x => x.CustomAttributes.Any()).ToArray();
                return string.Join(separator, fields.Select(x => x.Name));
            }
            return string.Empty;
        }
    }


}
