using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class TaskHistory
    {
        public int TaskHistoryId { get; set; }

        public int KanbanTaskId { get; set; }
        
        public KanbanTask KanbanTask { get; set; }  

        public int VersionId { get; set; }

        public string Title { get; set; }

        public Status TaskStatus { get; set; }

        public Department Department { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public Store? Store { get; set; }

        public User Reporter { get; set; }

        public User Assignee { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Updated { get; set; }

        public string Description { get; set; }

        public User? ModifiedBy { get; set; }

    }
}
