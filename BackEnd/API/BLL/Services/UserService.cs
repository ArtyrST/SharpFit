using AlaBackEnd.BLL.Services;
using BLL.DTO;
using DAL.Repositories;
using AutoMapper;
using DAL.Entity;

namespace BLL.Services
{
    public class UserService
    {
        private readonly UserRepository _user;
        private readonly IMapper _mapper;
        public UserService(UserRepository user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }
        public async Task<ServiceResponse> RegisterUserAsync(UserRegisterDto dto)
        {
            if (dto == null)
            {
                return ServiceResponse.Error("The form is null");
            }
            if (await _user.IsEmailExistAsync(dto.Email))
            {
                return ServiceResponse.Error("User with this email already exist");
            }
            dto.Email = dto.Email.Trim();

            var entity = _mapper.Map<UserEntity>(dto);
            entity.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            bool res = await _user.CreateAsync(entity);
            if (!res)
            {
                return ServiceResponse.Error("Something wrong with register");
            }
            return ServiceResponse.Success("Success", null);
            

        }
    }
}
