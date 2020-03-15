using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using Dapper.Contrib;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;

namespace Skynet.Data.Internal
{
    public interface IRepository<T>
    {
        void Add(T item);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Remove(int id);
        void Update(T item);
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IConfiguration _config;
        protected readonly IDbConnection _db;

        public Repository(IConfiguration config, IDbConnection db)
        {
            _config = config;
            _db = (SqlConnection)db;
            _db.ConnectionString = _config.GetConnectionString("Skynet");
        }
        public void Add(T item)
        {
            _db.Insert<T>(item);
        }

        public T Get(int id)
        {
            return _db.Get<T>(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _db.GetAll<T>();
        }

        public void Remove(int id)
        {
            _db.Delete(new { Id = id });
        }

        public void Update(T item)
        {
            _db.Update(item);
        }
    }
}
