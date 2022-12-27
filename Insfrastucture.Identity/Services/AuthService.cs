using Infrastucture.Identity.Interfaces;
using Infrastucture.Identity.DTOs;
using Infrastucture.DataAccess.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Infrastucture.Identity.Services
{
    public class AuthService: IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILoginRepository _loginRepository;

        public AuthService(IUserRepository userRepository, ILoginRepository loginRepository)
        {
            _userRepository = userRepository;
            _loginRepository = loginRepository; 
        }
        public async Task<string> Login(AuthRequest request)
        {
            
            try
            {
                var result = await _userRepository.FindByCondition(x => x.Email == request.Email);
                var result2 = await _loginRepository.FindByCondition(x => x.Password == request.Password);
                if (result != null && result2 != null)
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@2410"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokenOptions = new JwtSecurityToken(
                        issuer: "SystematIT",
                        audience: "https://localhost:7045",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(60),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    return tokenString;
                }else
                {
                    return "NoToken";
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
