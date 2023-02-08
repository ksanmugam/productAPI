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
        private readonly ProductService _productService;
        public ProductApi(ProductService productService)
        {
            _productService = productService;
        }

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
    }
}
