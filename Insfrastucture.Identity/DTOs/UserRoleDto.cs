using DataModel.Enums;

namespace Infrastucture.Identity.DTOs
{
    public class UserRoleDto
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }

        public RoleKeys RoleName { get; set; }
    }
}
