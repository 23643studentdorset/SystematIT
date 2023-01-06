using System.ComponentModel.DataAnnotations;

namespace KanbanModule.DTOs
{
    public class UpdateStoreRequest
    {
        [Required]
        [MaxLength(50)]
        public int StoreId { get; set; }

        [Required]
        [MaxLength(50)]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
