using Infrastucture.Identity.Interfaces;
using Infrastucture.Identity.DTOs;
using Infrastucture.DataAccess.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using Infrastucture.Helpers;
using DataModel;

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
        public async Task<object?> Login(AuthRequest request)
        {           
            try
            {
                
                var user = await _userRepository.FindByCondition(x => x.Email == request.Email);

                if (user != null && PasswordEncryption.IsValidPassword(request.Password, user.Password, user.Salt))
                { 
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_iconfiguration["JWT:Key"]));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokenOptions = new JwtSecurityToken(
                        issuer: _iconfiguration["JWT:Issuer"],
                        audience: _iconfiguration["JWT:Audience"],
                        claims: GetClaimsForToken(user),
                        expires: DateTime.Now.AddMinutes(60),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    return new { Token = tokenString,
                                 User = user.UserId,
                        user.FirstName,
                        user.LastName,
                        user.Email};
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

        private List<Claim> GetClaimsForToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(IdentitySettings.ClaimEmail, user.Email),
                new Claim(IdentitySettings.ClaimUserId, user.UserId.ToString()),
                new Claim(IdentitySettings.ClaimCompanyId, user.CompanyId.ToString()),
            };

            foreach (var userRole in user.UserRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole.Role.Name));
            }

            return claims;
        }
    }
}
