using DataModel;
using Infrastucture.Identity.DTOs;

namespace KanbanModule.DTOs
{
    public class KanbanTaskHistoryFilteredDto
    {
        public int TaskHistoryId { get; set; }

        public int KanbanTaskId { get; set; }

        public int VersionId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int TaskStatusStatusId { get; set; }

        public string AssigneeUserFirstName { get; set; }

        public string AssigneeUserLastName { get; set; }

        public string ReporterUserFirstName { get; set; }

        public string ReporterUserLastName { get; set; }

        public DateTime? LastModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
