using AutoMapper;
using BLL.DTO;
using DAL.Entity;


namespace BLL
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            //RegisterUserDto -> UserEntity
            CreateMap<UserRegisterDto, UserEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Password, opt => opt.Ignore());
        }
    }
}
