
using ShopAngular.Model.Entities;
using ShopAngular.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopAngular.Model.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetById(int id);
        Task<IReadOnlyList<Product>> GetAll();
        Task<IReadOnlyList<ProductBrand>> GetProductBrand();
        Task<IReadOnlyList<ProductType>> GetProductType();
    }
}
