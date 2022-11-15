using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDAL.Repository.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        // DbConnection Connection ;
        void Begin();
        Task BeginAsync();
        void Commit();
        Task CommitAsync();
        void  Rollback();
        Task RollbackAsync();

        IProductRepository Product { get; }



    }
}
