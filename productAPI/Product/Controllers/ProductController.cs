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

        #region GET a product / list of products
        /// <summary>
        /// To get a product / list of products
        /// </summary>
        /// <param name="ids">(Optional) Filter products by ids</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ProductApiModel), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> GetProducts(string ids)
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
        #endregion

        #region POST a product / list of products
        /// <summary>
        /// To add a product / list of products
        /// </summary>
        /// <param name="products">Product model to be saved</param>
        /// <returns></returns>
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
        #endregion

        #region NOT IN USE
        #region PUT
        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        #endregion

        #region DELETE
        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        #endregion
        #endregion
    }
}
