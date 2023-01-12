namespace DataModel
{
    public class KanbanTask
    {
        public int KanbanTaskId { get; set; }

        public string Title { get; set; }

        public Status TaskStatus { get; set; }

        public Department Department { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public Store? Store { get; set; }

        public User Reporter { get; set; }

        public User Assignee { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Updated { get; set; }

        public string Description { get; set; }

        public string? Notes { get; set; }

        public List<TaskHistory> Histories { get; set; }

        public List<Comment> Comment { get; set; }

    }
}
