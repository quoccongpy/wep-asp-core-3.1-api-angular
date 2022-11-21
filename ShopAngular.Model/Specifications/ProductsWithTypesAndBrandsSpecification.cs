using ShopAngular.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAngular.Model.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : Specification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductParam param) :
            base(a=>
            (string.IsNullOrEmpty(param.Search)||a.Name.ToLower().Contains(param.Search))&&
            (!param.BrandId.HasValue || a.ProductBrandId==param.BrandId) &&
            (!param.TypeId.HasValue || a.ProductTypeId == param.TypeId))
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);
            ApplyPaging(param.PageSize * (param.PageIndex - 1), param.PageSize);
            if(!string.IsNullOrEmpty(param.Sort))
            {
                switch (param.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(a => a.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(a => a.Price);
                        break;
                    default:
                        AddOrderBy(a => a.Name);
                        break;
                }

            }
        }
        public ProductsWithTypesAndBrandsSpecification(int id) :base(a=>a.Id ==id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}
