using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using productAPI.Models;
using productAPI.Product.DllApi;
using productAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace productAPI.Product.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Constructor
        private readonly ProductApi _productApi;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductApi productApi, ILogger<ProductController> logger)
        {
            _productApi = productApi;
            _logger = logger;
        }
        #endregion

        // GET api/<ProductController>/5
        [HttpGet]
        [ProducesResponseType(typeof(ProductApiModel), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> GetProducts(string ids = null)
        {
            try
            {
                List<Guid> itemIds = null;
                if (!string.IsNullOrEmpty(ids))
                {
                    itemIds = ids.Split(',').Select(Guid.Parse).ToList();
                }
                return Ok(await _productApi.GetProductsAsync(ids: itemIds));

            }
            catch (Exception e)
            {
                throw new Exception("Failed to retrieve product(s)", e);
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        [ProducesResponseType(typeof(GenericResultApiModel), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> SaveProducts(List<ProductApiModel> products)
        {
            try
            {
                return Ok(await _productApi.SaveProductsAsync(products));
            }
            catch (Exception e)
            {
                throw new Exception("Failed to add product(s)", e);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
