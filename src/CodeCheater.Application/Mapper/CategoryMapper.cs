using AutoMapper;
using CodeCheater.Application.RequestValidation;
using CodeCheater.Domain.Models.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeCheater.Application.Mapper
{
    public class CategoryMapper: Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryInsertRequestViewModel>().ReverseMap();
        }
    }
}
