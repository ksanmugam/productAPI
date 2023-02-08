using Microsoft.EntityFrameworkCore;
using productAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using productAPI.Entities;
using productAPI.ViewModels;
using productAPI.Models;

namespace productAPI.Product.Services
{
    public class ProductService
    {
        private readonly DatabaseContext _dbContext;

        public ProductService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        internal Task<List<ProductModel>> GetProducts(List<Guid> ids = null)
        {
            var result = GetProductFilters(ids: ids).ToListAsync();
            return result;
        }

        internal IQueryable<ProductModel> GetProductFilters(List<Guid> ids = null)
        {
            IQueryable<ProductModel> filtered = _dbContext.Products.AsNoTracking();

            IQueryable<ProductModel> unfiltered = filtered;

            if (ids != null)
                filtered = filtered.Where(l => ids.Contains(l.Id));


            return filtered;
        }

        internal async Task<GenericResultApiModel> SaveProductsAsync(List<ProductApiModel> products)
        {
            GenericResultApiModel result = new GenericResultApiModel();
            try
            {
                List<ProductModel> arrProducts = new List<ProductModel>();
                foreach (var product in products)
                {
                    var addProduct = new ProductModel(product.Name, product.Description, product.Price);
                    arrProducts.Add(addProduct);
                }

                _dbContext.Products.AddRange(arrProducts);

                await _dbContext.SaveChangesAsync();

                result.Error = "Successfully added product(s)";
                result.Success = true;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Error = "Failed to add product(s)";
            }
            return result;
        }
    }
}
