using AutoMapper;
using CodeCheater.Application.RequestValidation;
using CodeCheater.Domain.Models.Baskets;

namespace CodeCheater.Application.Mapper
{
    public class BasketMapper : Profile
    {
        public BasketMapper()
        {
            CreateMap<BasketCart, BasketInsertRequestViewModel>().ReverseMap();
        }
    }
}
