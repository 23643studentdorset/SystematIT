using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    internal class Store
    {
        public int StoreId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Boolean Active { get; set; }
        public User CreateBy { get; set; }
        public DateTime CreateOn { get; set; }
        public User? ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedOn { get; set; }
    }
}
