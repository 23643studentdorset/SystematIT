﻿
namespace DataModel
{
    public class Role
    {
        public int RoleId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IList<UserRole> UserRoles { get; set; }

    }
}
