using Infrastucture.Identity.DTOs;

namespace KanbanModule.DTOs
{
    public class KanbanTaskDto
    {
        public int KanbanTaskId { get; set; }

        public UserDto Reporter { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CurrentVersionId { get; set; }
    }
}
