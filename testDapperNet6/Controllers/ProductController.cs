using DapperDAL.Models;
using DapperDAL.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace testDapperNet6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IUnitOfWork _UOK;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _UOK = unitOfWork;
        }
        [Route("GetAll")]
        [HttpGet]  
        public async Task<IActionResult> GetAll()
        {
            try
            {
              var list = await _UOK.Product.GetAllAsync();
              if(list!=null && list.Count()>0)
              return Ok(list);
             else
                return NotFound();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        [Route("GetFirst")]
        [HttpGet]
        public async Task<IActionResult> GetFirst([FromQuery]int Id )
        {
            try
            {
                var model = await _UOK.Product.GetAsync(Id);
                if (model != null)
                    return Ok(model);
                else
                    return NotFound();
            }
            catch (Exception)
            {

                throw;
            }
          
        }
        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Product Product)
        {
            try
            {
                var id = await _UOK.Product.AddAsync(Product);
             if (id > 0)
                  return Ok(id);
              else
                  return BadRequest(new { result=id});
            }
            catch (Exception  )
            {
                 throw;
            }
         
        }

        [HttpDelete]
        [Route("DeleteItem")]  
        public async Task<IActionResult> DeleteItem([FromQuery] int Id) 
        {
            try
            {
                //test git 2
                var result = await _UOK.Product.DeleteItemAsync(Id);
                if (result > 0)
                    return Ok(result);
                else
                    return BadRequest(new { result = result });
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpDelete]
        [Route("DeleteItems")]
        public async Task<IActionResult> DeleteItems([FromQuery] List<int> Ids) 
        {
            try
            {
                var result = await _UOK.Product.DeleteItemsAsync(Ids);
                if (result > 0)
                    return Ok(result);
                else
                    return BadRequest(new { result = result });
            }
            catch (Exception)
            {

                throw;
            }

        }


        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Product Model)
        {

            try
            {
                var result = await _UOK.Product.UpdateAsync(Model);
                if (result > 0)
                    return Ok(result);
                else
                    return BadRequest(new { result = result });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("Update_CountP")]
        [HttpPut]
        public async Task<IActionResult> Update_CountP([FromBody] Product_CountP Model)
        {
            try
            {
                var result = await _UOK.Product.Update_CountPAsync(Model);
                if (result > 0)
                    return Ok(result);
                else
                    return BadRequest(new { result = result });

            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("Update_Price")]
        [HttpPut]
        public async Task<IActionResult> Update_Price([FromBody] Product_Price Model)
        {
            try
            {
                var result = await _UOK.Product.Update_PriceAsync(Model);
                if (result > 0)
                    return Ok(result);
                else
                    return BadRequest(new { result = result });
            }
            catch (Exception)
            {

                throw;
            }
        }
         


    }
}
