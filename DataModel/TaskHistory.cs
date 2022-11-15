using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    internal class TaskHistory
    {
        public int TaskHistoryId { get; set; }
        public Task Task { get; set; }
        public String HistoryFrom { get; set; }
        public Boolean HistoryTo { get; set; }
        public User CreateBy { get; set; }
        public DateTime CreateOn { get; set; }
      
    }
}
