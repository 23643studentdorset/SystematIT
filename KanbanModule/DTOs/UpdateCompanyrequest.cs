using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanModule.DTOs
{
    public class UpdateCompanyRequest
    {
        public int CompanyId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
