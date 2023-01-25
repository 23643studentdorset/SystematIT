using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class KanbanTaskHistory
    {
        public int TaskHistoryId { get; set; }

        public int KanbanTaskId { get; set; }
        
        public KanbanTask KanbanTask { get; set; }  

        public int VersionId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Status TaskStatus { get; set; }

        public Department Department { get; set; }

        public Store? Store { get; set; }

        public int AssigneeUserId { get; set; }

        public User Assignee { get; set; }

        public DateTime? LastModifiedOn { get; set; }

        public int? LastModifiedByUserId { get; set; }

        public User? LastModifiedBy { get; set; }
    }
}
