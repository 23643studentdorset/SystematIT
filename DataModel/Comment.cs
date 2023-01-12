using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Comment
    {
        public int CommentId { get; set; }

        public int KanbanTaskId { get; set; }

        public KanbanTask KanbanTask { get; set; }

        public string Description { get; set; }
    }
}
