using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanModule.DTOs
{
    public class CommentDto
    {
        public int CommentId { get; set; }

        public int KanbanTaskId { get; set; }

        public string Description { get; set; }
    }
}
