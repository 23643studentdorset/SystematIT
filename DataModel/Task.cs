using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    internal class Task
    {
        public int TaskId { get; set; }
        public String Title { get; set; }
        public Status BoardStatus { get; set; }
        public Department Department { get; set; }
        public Store? Store { get; set; }
        public User Reporter { get; set; }
        public User Assignee { get; set; }
        public DateTime Created { get; set; }
        public Nullable<DateTime> Updated { get; set; }
        public String Description { get; set; }
        public String? Notes { get; set; }
        public List<TaskHistory> Histories { get; set; }
    }
}
