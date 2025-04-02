using AutoMapper;
using ShagunMarriage.Models.DBModels;
using ShagunMarriage.Models.ViewModels;

namespace ShagunMarriage.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserModel, UserViewModel>();
            CreateMap<UserViewModel, UserModel>();
        }
    }
}
