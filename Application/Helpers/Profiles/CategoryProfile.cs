﻿using Application.Models.CategoryModels.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<Category, CategoryGetDto>()
                .ForMember(dest => dest.CategoryId, src => src.MapFrom(src => src.Id));
            CreateMap<CategoryUpdateDto, Category>()
                .ForMember(dest => dest.Id, src => src.MapFrom(src => src.CategoryId));
        }
    }
}
