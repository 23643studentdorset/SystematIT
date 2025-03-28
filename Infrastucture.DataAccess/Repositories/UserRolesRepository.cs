﻿using DataModel;
using Infrastucture.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.DataAccess.Repositories
{
    public class UserRolesRepository : GenericRepository<UserRole>, IUserRolesRepository
    {
        public UserRolesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
