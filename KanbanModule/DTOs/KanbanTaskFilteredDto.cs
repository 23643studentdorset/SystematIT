using Infrastucture.Identity.DTOs;

namespace KanbanModule.DTOs
{
    public class KanbanTaskFilteredDto
    {
        public int KanbanTaskId { get; set; }

        public int ReporterUserId { get; set; }

        public string ReporterUserFirstName { get; set; }

        public string ReporterUserLastName { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CurrentVersionId { get; set; }
    }
}
