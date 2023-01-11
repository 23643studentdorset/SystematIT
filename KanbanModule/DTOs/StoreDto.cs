using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanModule.DTOs
{
    public class StoreDto
    {
        public int StoreId { get; set; }

        public string Name { get; set; }

        public int CompanyId { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public int CreatedByUserId { get; set; }

        public string CreatedByFirstName { get; set; }

        public string CreatedByLastName { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? ModifiedByUserId { get; set; }

        public string ModifiedByFirstName { get; set; }

        public string ModifiedByLastName { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
