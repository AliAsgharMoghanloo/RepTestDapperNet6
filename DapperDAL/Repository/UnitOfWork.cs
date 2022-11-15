using Dapper;
using DapperDAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDAL.Repository
{
    public class UnitOfWork  : IUnitOfWork
    {
        private readonly DbConnection _connection;  
       // private readonly IDbConnection _connection0; 
        private DbTransaction _transaction;
        public UnitOfWork(DbConnection connection)
        {
            _connection = connection;

            Product = new ProductRepository(_connection.ConnectionString);

        }
        public IProductRepository Product { get; private set; }










        public DbConnection Connection => _connection;

        public DbTransaction Transaction => _transaction;
        public void Begin()
        {
            _transaction = _connection.BeginTransaction();
        }

        public async Task BeginAsync()
        {
            _transaction = await _connection.BeginTransactionAsync();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public async Task CommitAsync()
        {
            await _transaction.CommitAsync();
        }

        public void Dispose()
        {
            if (_transaction != null)
                _transaction.Dispose();

            _transaction = null;
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
        }
    }
}
