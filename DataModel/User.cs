using System;
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

        public string SurName { get; set; }

        public string Email { get; set; }    

        public string Mobile { get; set; }   

        public string Address { get; set; }

        public DateTime DOB { get; set; }

    }
}
