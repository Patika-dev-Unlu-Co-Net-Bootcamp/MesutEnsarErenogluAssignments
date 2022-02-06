using AutoMapper;
using Domain.Entities;
using Odev4.WebApi.Models.User;

namespace Odev4.WebApi.Mapping
{
    public class UIMappingProfile:Profile
    {
        public UIMappingProfile()
        {
            CreateMap<AppUserRegisterModel, AppUser>().ReverseMap();
        }
    }
}
