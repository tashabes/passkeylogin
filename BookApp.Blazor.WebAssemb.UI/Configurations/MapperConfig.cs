using AutoMapper;
using BookStoreApp.Blazor.WebAssemb.UI.Services.Base;

namespace BookStoreApp.Blazor.WebAssemb.UI.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AuthorDetailsDto, AuthorUpdateDto>().ReverseMap();
            CreateMap<BookDetailsDto, BookUpdateDto>().ReverseMap();
        }
    }
}