﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using WebAPI.DTOs;
using AutoMapper;
using WebAPI.Controllers;
using WebAPI.Errors;
using Microsoft.AspNetCore.Http;
using WebAPI.Helpers;

namespace Core.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> productsRepo;
        private readonly IGenericRepository<ProductBrand> productsBrandRepo;
        private readonly IGenericRepository<ProductType> productsTypeRepo;
        private readonly IMapper mapper;
        public ProductsController(IGenericRepository<Product> productsRepo,
            IGenericRepository<ProductBrand> productsBrandRepo,
            IGenericRepository<ProductType> productsTypeRepo,
            IMapper mapper)
        {
            this.productsRepo = productsRepo;
            this.productsBrandRepo = productsBrandRepo;
            this.productsTypeRepo = productsTypeRepo;
            this.mapper = mapper;
        }

        [Cached(600)]
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts(
            [FromQuery] ProductSpecParams productParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);
            var countSpec = new ProductWithFiltersFroCountSpecification(productParams);
            var totalItems = await productsRepo.CountAsync(countSpec);
            var products = await productsRepo.ListAsync(spec);
            var data = mapper.
                Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);


            return Ok(new Pagination<ProductToReturnDto>(
                productParams.PageIndex,
                productParams.PageSize,
                totalItems,
                data));
        }

        [Cached(600)]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await productsRepo.GetEntityWithSpec(spec);

            if (product == null)
                return NotFound(new ApiResponse(404));

            return mapper.Map<Product, ProductToReturnDto>(product);  
        }

        [Cached(600)]
        [HttpGet("brands")]
        public async Task<ActionResult<ProductBrand>> GetProductBrands()
        {
            return Ok(await productsBrandRepo.ListAllAsync());
        }

        [Cached(600)]
        [HttpGet("types")]
        public async Task<ActionResult<Product>> GetProductTypes()
        {
            return Ok(await productsTypeRepo.ListAllAsync());
        }

    }
}
