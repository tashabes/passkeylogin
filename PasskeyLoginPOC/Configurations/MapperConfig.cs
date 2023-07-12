using AutoMapper;
using PasskeyLoginPOC.API.Data;
using PasskeyLoginPOC.API.Models.User;
using PasskeyLoginPOC.API.Models.Users;

namespace PasskeyLoginPOC.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<UserCreateDto, User>().ReverseMap();
            CreateMap<UserDeleteDto, User>().ReverseMap();
            CreateMap<UserReadOnlyDto, User>().ReverseMap();


            CreateMap<ApiUser, UserDto>().ReverseMap();
        }
    }
}
