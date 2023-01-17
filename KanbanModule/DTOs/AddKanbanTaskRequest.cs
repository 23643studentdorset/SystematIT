using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanModule.DTOs
{
    public class AddKanbanTaskRequest
    {

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public int StoreId { get; set; }

        [Required]
        public int AssigneeId { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        

    }
}
