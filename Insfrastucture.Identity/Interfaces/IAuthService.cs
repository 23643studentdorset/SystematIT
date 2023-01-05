using DataModel;
using Infrastucture.Identity.DTOs;

namespace Infrastucture.Identity.Interfaces
{
    public interface IAuthService
    {
        Task<object?> Login(AuthRequest user);
    }
}
