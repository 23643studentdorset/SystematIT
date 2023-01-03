using Infrastucture.Identity.Interfaces;
using Infrastucture.Identity.DTOs;
using Infrastucture.DataAccess.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;

namespace Infrastucture.Identity.Services
{
    public class AuthService: IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _iconfiguration;

        public AuthService(IUserRepository userRepository, IConfiguration iConfiguration)
        {
            _userRepository = userRepository;
            _iconfiguration = iConfiguration;
        }
        public async Task<object> Login(AuthRequest request)
        {           
            try
            {
                var result = await _userRepository.FindByCondition(x => x.Email == request.Email);
                var inconmingEncryptedPassword = Convert.ToBase64String(SHA256.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(request.Password + result.Salt))); 
                    
               
                if (result != null && result.Password.Equals(inconmingEncryptedPassword))
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_iconfiguration["JWT:Key"]));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokenOptions = new JwtSecurityToken(
                        issuer: _iconfiguration["JWT:Issuer"],
                        audience: _iconfiguration["JWT:Audience"],
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(60),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    return new { Token = tokenString,
                                 User = result.UserId,
                        result.FirstName,
                        result.LastName,
                        result.Email};
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
