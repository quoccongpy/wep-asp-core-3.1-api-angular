using Microsoft.EntityFrameworkCore;
using ShopAngular.Model.Entities;
using ShopAngular.Model.Interfaces;
using ShopAngular.ShopAngular.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopAngular.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopAngularContext _context;
        public ProductRepository(ShopAngularContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<Product>> GetAll()
        {
            return await _context.Products
                .Include(a=>a.ProductBrand)
                .Include(a=>a.ProductType)
                .ToListAsync();
          
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products
                 .Include(a => a.ProductBrand)
                .Include(a => a.ProductType)
                .FirstOrDefaultAsync(a=>a.Id==id);
             
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrand()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductType()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}
