using AlaBackEnd.BLL.Services;
using AutoMapper;
using BLL.DTO;
using DAL.Entity;
using DAL.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace BLL.Services
{
    public class UserService
    {
        private readonly UserRepository _user;
        private readonly IMapper _mapper;
        private readonly JwtService _jwtService;

        public UserService(UserRepository user, IMapper mapper, JwtService jwtService)
        {
            _user = user;
            _mapper = mapper;
            _jwtService = jwtService;
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
        public async Task<ServiceResponse> LoginUserAsync(UserLoginDto dto)
        {
            if (dto == null)
            {
                return ServiceResponse.Error("The form is null");
            }

            dto.Email = dto.Email.Trim();

            var user = await _user.GetByEmailAsync(dto.Email);
            if (user == null)
            {
                return ServiceResponse.Error("Invalid email or password");
            }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);
            if (!isPasswordValid)
            {
                return ServiceResponse.Error("Invalid email or password");
            }

            
            var token = _jwtService.GenerateToken(user);

            return ServiceResponse.Success("Login successful", new
            {
                user.Id,
                user.Email,
                Token = token
            });
        }
    }
}
