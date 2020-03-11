using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Skynet.Data.Internal
{
    internal class SqlDataAccess : IDisposable
    {

        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private readonly IConfiguration _config;

        private bool _isClosed = false;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public List<T> LoadData<T, U>(string storedProcedure,
            U parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using IDbConnection connection = new SqlConnection(connectionString);
            List<T> rows = connection.Query<T>(storedProcedure, parameters, 
                commandType: CommandType.StoredProcedure).ToList();

            return rows;
        }

        public void SaveData<T>(string storedProcedure,
            T parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        // Open Connection/ Start Transaction
        public void StartTransaction(string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
            _isClosed = false;
        }

        // Load using the trasaction
        public List<T> LoadDataInTransaction<T, U>(string storedProcedure,
        U parameters)
        {
            List<T> rows = _connection.Query<T>(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure, transaction: _transaction).ToList();

            return rows;
        }

        // Save using the transaction
        public void SaveDataInTransaction<T>(string storedProcedure,
        T parameters)
        {
            _connection.Execute(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure, transaction: _transaction);

        }

        // Close connection/ Stop Transaction

        // If Transaction successful
        public void CommitTransaction()
        {

            _transaction?.Commit();
            _connection?.Close();

            _isClosed = true;
        }

        // If Transaction failed
        public void RollBackTransaction()
        {
            _transaction?.Rollback();

            _isClosed = true;

        }


        // Dispose 
        public void Dispose()
        {
            if (_isClosed == false)
            {
                try
                {
                    CommitTransaction();
                }
                catch
                {
                    // TODO: Log this issue
                }
            }

            _transaction = null;
            _connection = null;

        }
    }
}
