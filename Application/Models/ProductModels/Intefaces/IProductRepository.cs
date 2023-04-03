﻿using Application.Models.GenericRepo;
using Application.Models.ProductModels.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.ProductModels.Intefaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        List<ProductGetBaseDto> GetAllProductBase();

        ProductDetailDto GetProductDetail(int id);
    }
}