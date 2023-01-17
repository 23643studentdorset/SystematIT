using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanModule.DTOs
{
    public class UpdateKanbanTask
    {
        public int KanbanTaskId {get; set;}

        public string Title {get; set;}

        public int StatusId { get; set;}

        public int DepartmentId { get; set;}

        public int StoreId { get; set;}

        public int AssigneeId { get; set;}

        public string Description {get; set;}




    }
}
