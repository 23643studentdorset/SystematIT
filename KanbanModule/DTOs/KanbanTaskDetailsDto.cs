using DataModel;
using Infrastucture.Identity.DTOs;

namespace KanbanModule.DTOs
{
    public class KanbanTaskDetailsDto
    {
        public int KanbanTaskId { get; set; }

        public UserDto Reporter { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Status TaskStatus { get; set; }

        public DepartmentDto Department { get; set; }

        public StoreDto? Store { get; set; }

        public UserDto Assignee { get; set; }

        public DateTime? LastModifiedOn { get; set; }

        public UserDto? LastModifiedBy { get; set; }

        public List<CommentDto> Comments { get; set; }
    }
}
