using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Store
    {
        public int StoreId { get; set; }

        public string Name { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public User CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public User? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

    }
}
