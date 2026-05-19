using AlaBackEnd.BLL.Services;
using BLL.DTO;
using DAL.Entity;
using FitnessCenter.DTOs;

namespace FitnessCenter.Services
{
    public class AuthService
    {
        public string Login(LoginRequest request)
        {
            if (
                request.Email == "admin@gmail.com" &&
                request.Password == "123456"
            )
            {
                return "jwt-token-example";
            }

            throw new Exception("Invalid email or password");
        }
        public string Register(RegisterRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            
            if (request.Email == "admin@gmail.com")
            {
                throw new Exception("User with this email already exists");
            }

            
            return "registration-success";
        }
        

    }
}
