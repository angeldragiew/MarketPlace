﻿using Application.Models.ProductModels.Dtos;
using Application.Models.ProductModels.Intefaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<List<ProductGetBaseDto>> GetAllProductsForIndexPage()
        {
            return await productService.GetAllForIndex();
        }

        [HttpGet]
        [Route("Inventory")]
        public async Task<List<ProductInventoryGetDto>> GetAllProductsForInventoryPage()
        {
            return await productService.GetAllForInventory();
        }

        [HttpGet]
        [Route("Details/{id}")]
        public async Task<ProductDetailDto> GetProductDetails(int id)
        {
            return await productService.GetDetails(id);
        }

        [HttpGet]
        [Route("Update/{id}")]
        public async Task<ProductUpdatetDto> GetProductForEdit(int id)
        {
            return await productService.GetForUpdate(id);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task GetProductForEdit(int id, ProductUpdatetDto dto)
        {
            ThrowExceptionService.ThrowExceptionWhenIdsDoNotMatch(id, dto.Id);
            await productService.Update(dto);
        }

        [HttpPost]
        public async Task<ProductGetDto> CreateProduct(ProductCreateDto dto)
        {
            return await productService.Create(dto);
        }

        [HttpDelete("{id}")]
        public async Task DeleteProduct(int id)
        {
            await productService.Delete(id);
        }
    }
}
