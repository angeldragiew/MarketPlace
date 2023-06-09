﻿using Application.Models.GenericRepo;
using Application.Models.ImageModels.Dtos;
using Application.Models.ImageModels.Interfaces;
using Dapper;
using Domain.Entities;
using Infrastructure.Repositories.GenericRepository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ImageRepository : GenericRepository<Image>, IImageRepository
    {
        public ImageRepository(IMarketPlaceContext marketPlaceContext)
            : base(marketPlaceContext)
        {
        }

        public async Task<ImageGetDto> GetImageByProductId(int productId)
        {
            var sql = @"SELECT i.Id, i.ImagePublicId AS PublicId 
                        FROM Products AS p 
                        JOIN Images AS i on p.Id = i.ProductId
                        WHERE p.Id= @productId";

            return await Connection.QueryFirstOrDefaultAsync<ImageGetDto>(sql, new { productId }, Transaction);
        }
    }
}
