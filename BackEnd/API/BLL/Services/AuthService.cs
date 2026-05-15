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
    }
}
