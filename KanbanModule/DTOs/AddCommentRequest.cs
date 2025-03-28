using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanModule.DTOs
{
    public class AddCommentRequest
    {
        [Required]
        public string Comment { get; set; }

        [Required]
        public int TaskId { get; set; }
    }
}
