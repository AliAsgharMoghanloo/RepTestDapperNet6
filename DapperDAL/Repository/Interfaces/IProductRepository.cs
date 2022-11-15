using DapperDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDAL.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product, int>
    {
        Task<int> UpdateAsync(Product Model);
        Task<int> Update_CountPAsync(Product_CountP Model);
        Task<int> Update_PriceAsync(Product_Price Model);

    }
}
