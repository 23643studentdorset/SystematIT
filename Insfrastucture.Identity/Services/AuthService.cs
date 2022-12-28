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

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            
        }
        public async Task<object> Login(AuthRequest request)
        {           
            try
            {
                var result = await _userRepository.FindByCondition(x => x.Email == request.Email);
               
                if (result != null && result.Password.Equals(request.Password))
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
                    return new { Token = tokenString,
                                 User = result};
                }else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
