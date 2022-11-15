using Dapper;
using DapperDAL.Models;
using DapperDAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDAL.Repository
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
         
        public ProductRepository(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public async Task<int> AddAsync(Product param)
        {
            try
            {
                var dd = new DynamicParameters();
                dd.Add("Name", param.Name);
                dd.Add("CountP", param.CountP);
                dd.Add("Price", param.Price);

                return await ExecuteScalarAsync<int>("dbo.SP_Product_Add", dd);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task<int> DeleteItemAsync(int id)
        {
            try
            {
                var dd = new DynamicParameters();
                dd.Add("@Id", id);
                return await ExecuteScalarAsync<int>("dbo.SP_Product_DeleteItem", dd);
            }
            catch (Exception)
            {

                throw;
            }
         
        }

        public async Task<int> DeleteItemsAsync(List<int> Ids)
        {
            try
            {
                var dd = new DynamicParameters();
                dd.Add("@Ids", Ids); //؟؟؟
                return await ExecuteScalarAsync<int>("dbo.SP_Product_DeleteItems", dd);
            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task<Product> GetAsync(int id)
        {
            try
            {
                var dd = new DynamicParameters();
                dd.Add("@Id", id);
                return await QueryFirstOrDefaultAsync<Product>("dbo.SP_Product_Get", dd);

            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            try
            {
                return await this.QueryListAsync<Product>("dbo.SP_Product_GetAll");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> UpdateAsync(Product Model)
        {
            try
            {
                var dd = new DynamicParameters();
                dd.Add("@Id", Model.Id);
                dd.Add("@Name", Model.Name);
                dd.Add("@CountP", Model.CountP);
                dd.Add("@Price", Model.Price);
                dd.Add("@DateTimeUpdate", Model.DateTimeUpdate);

                return await ExecuteScalarAsync<int>("dbo.SP_Product_Update", dd);

            }
            catch (Exception)
            {

                throw;

            }
        }

        public async Task<int> Update_CountPAsync(Product_CountP Model)
        {
            try
            {
                var dd = new DynamicParameters();
                dd.Add("@Id", Model.Id);
                dd.Add("@CountP", Model.CountP);


                return await ExecuteScalarAsync<int>("dbo.SP_Product_Update_CountP", dd);
            }
            catch (Exception) { throw; }
        }

        public async Task<int> Update_PriceAsync(Product_Price Model)
        {
            try
            {
                var dd = new DynamicParameters();
                dd.Add("@Id", Model.Id);
                dd.Add("@DateTimeUpdate", Model.DateTimeUpdate);
                dd.Add("@Price", Model.Price);

                return await ExecuteScalarAsync<int>("dbo.SP_Product_Update_Price", dd);

            }
            catch (Exception)
            {

                throw;
            }  
        }

       
    }
}
