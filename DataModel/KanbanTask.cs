namespace DataModel
{
    public class KanbanTask
    {
        public int KanbanTaskId { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public int ReporterUserId { get; set; }

        public User Reporter { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CurrentVersionId { get; set; }

        public List<KanbanTaskHistory> Histories { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
