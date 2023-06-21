﻿using AutoMapper;
using BookApp.Blazor.Server.UI.Services.Base;

namespace BookApp.Blazor.Server.UI.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AuthorReadOnlyDto, AuthorUpdateDto>().ReverseMap();
        }
    }
}