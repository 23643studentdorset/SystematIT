using Infrastucture.Identity.DTOs;
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

        public UserDto CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public UserDto? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
