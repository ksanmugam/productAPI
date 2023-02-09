using Microsoft.AspNetCore.Mvc;
using productAPI.Entities;
using productAPI.Models;
using productAPI.Product.Services;
using productAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace productAPI.Product.DllApi
{
    public class ProductApi
    {
        #region Constructor
        private readonly ProductService _productService;
        public ProductApi(ProductService productService)
        {
            _productService = productService;
        }
        #endregion

        #region GET
        /// <summary>
        /// To get a product / list of products
        /// </summary>
        /// <param name="ids">(Optional) Filter products by ids</param>
        /// <returns></returns>
        internal Task<List<ProductModel>> GetProductsAsync(List<Guid> ids = null)
        {
            try
            {
                return _productService.GetProducts(ids: ids);
            }
            catch (Exception e)
            {
                throw new Exception("Failed to retrieve product(s)", e);
            }
        }
        #endregion

        #region POST
        /// <summary>
        /// To add a product / list of products
        /// </summary>
        /// <param name="products">Product model to be saved</param>
        /// <returns></returns>
        internal async Task<GenericResultApiModel> SaveProductsAsync(List<ProductApiModel> products)
        {
            if (products != null)
            {
                return await _productService.SaveProductsAsync(products);
            }
            else
            {
                throw new UnauthorizedAccessException();
            }
        }
        #endregion
    }
}
