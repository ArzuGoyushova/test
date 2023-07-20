using AutoMapper;
using WebAPI.DTOs.Category;
using WebAPI.DTOs.Product;
using WebAPI.Extension;
using WebAPI.Models;

namespace WebAPI.Profiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryReturnDto>()
                .ForMember(ds => ds.ImageUrl, map => map.MapFrom(s => "https://localhost:7032/" + s.ImageUrl));
            CreateMap<Category, CategoryInProductReturnDto>();
            CreateMap<Product, ProductReturnDto>()
                .ForMember(ds => ds.Profit, map => map.MapFrom(s => s.SalePrice - s.CostPrice));


            //CreateMap<User, UserReturnDto>()
            //    .ForMember(ds => ds.Age, map => map.MapFrom(s => s.BirthDayDate.DateToInt()));
        }
    }
}
