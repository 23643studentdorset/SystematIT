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

        public KanbanTask Task { get; set; }

        public string HistoryFrom { get; set; }

        public bool HistoryTo { get; set; }

        public User CreateBy { get; set; }

        public DateTime CreateOn { get; set; }
      
    }
}
