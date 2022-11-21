using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopAngular.Errors;
using ShopAngular.Helpers;
using ShopAngular.Model.Entities;
using ShopAngular.Model.Interfaces;
using ShopAngular.Model.Specifications;
using ShopAngular.Model.ViewModels;
using ShopAngular.ShopAngular.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopAngular.Controllers
{
    public class ProductController : BaseController
    {
        //private readonly IProductRepository _repo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;
        public ProductController(IGenericRepository<Product> productRepo, IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> productTypeRepo,IMapper mapper)
        {
            _productRepo = productRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductVM>>> GetAll([FromQuery]ProductParam param)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(param);
            var countSpec = new ProductsWithFiltersForCountSpecification(param);
            var totalItem = await _productRepo.Count(countSpec);


            var product = await _productRepo.List(spec);
         
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductVM>>(product) ;

            var dataPagination = new Pagination<ProductVM>(param.PageIndex, param.PageSize, totalItem, data);
          
            return Ok(dataPagination);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(spec);
            //var data = new ProductVM()
            //{
            //    Id=product.Id,
            //    Name = product.Name,
            //    Description = product.Description,
            //    Price = product.Price,
            //    PictureUrl = product.PictureUrl,
            //    ProductType = product.ProductType.Name,
            //    ProductBrand = product.ProductBrand.Name,
            //};
            if(product ==null)
            {
                return NotFound(new ApiResponse(404));
            }
            var data = _mapper.Map<Product, ProductVM>(product);
            return Ok(data);
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetBrands()
        {
            var data = await _productBrandRepo.GetAll();
            return Ok(data);
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetTypes()
        {
            var data = await _productTypeRepo.GetAll();
            //var jsonString = JsonSerializer.Serialize(data);

            return Ok(data);
        }
    }
}
