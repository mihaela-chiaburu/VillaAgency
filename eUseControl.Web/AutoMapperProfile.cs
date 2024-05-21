using AutoMapper;
using eUseControl.Domain.Entities.User;
using eUseControl.Web.Models;

namespace eUseControl.Web
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserLogin, ULoginData>();
            CreateMap<UserRegister, URegisterData>();
        }
    }
}
