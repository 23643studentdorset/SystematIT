using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    internal class Status
    {
       public int StatusId { get; set; }
       public String Name { get; set; }
       public String Description { get; set; }
       public Boolean Active { get; set; }
       public User CreatedBy { get; set; }
       public DateTime CreatedOn { get; set; }
       public User? ModifiedBy { get; set; }
       public Nullable<DateTime> ModifiedOn { get; set; }
    }
}
