using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Status
    {
       public int StatusId { get; set; }

       public string Name { get; set; }

       public string Description { get; set; }

       public bool Active { get; set; }

       public User CreatedBy { get; set; }

       public DateTime CreatedOn { get; set; }

       public User? ModifiedBy { get; set; }

       public Nullable<DateTime> ModifiedOn { get; set; }

    }
}
