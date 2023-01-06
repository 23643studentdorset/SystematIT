using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanModule.DTOs
{
    public class DeleteStoreRequest
    {
        [Required]
        [MaxLength(50)]
        public int StoreId { get; set; }

        [Required]
        [MaxLength(50)]
        public int userId { get; set; } 
    }
}
