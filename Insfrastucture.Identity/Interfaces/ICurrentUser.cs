using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Identity.Interfaces
{
    public interface ICurrentUser
    {
        int UserId { get; }

        string Email { get; }

        int CompanyId { get; }
    }
}
