using System.ComponentModel.DataAnnotations;

namespace KanbanModule.DTOs
{
    public class AddStoreRequest
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

    }
}
