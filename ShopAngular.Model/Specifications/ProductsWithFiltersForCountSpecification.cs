using ShopAngular.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAngular.Model.Specifications
{
    public class ProductsWithFiltersForCountSpecification : Specification<Product>
    {
        public ProductsWithFiltersForCountSpecification(ProductParam param) :
            base(a =>
             (string.IsNullOrEmpty(param.Search) || a.Name.ToLower().Contains(param.Search)) &&
            (!param.BrandId.HasValue || a.ProductBrandId == param.BrandId) &&
            (!param.TypeId.HasValue || a.ProductTypeId == param.TypeId))
        {

        }
    }
}
