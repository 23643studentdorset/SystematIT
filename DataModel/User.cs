﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class User
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }    

        public string Mobile { get; set; }   

        public string Address { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public DateTime DOB { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public DateTime? DeletedOn  { get; set; }

        public IList<UserRole> UserRoles { get; set; }

    }
}
