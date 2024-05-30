using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp5ByShikshya.Models
{
    public partial class Todo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Title field is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The Title must be between 3 and 100 characters.")]
        public string Title { get; set; } = null!;

        [StringLength(500, ErrorMessage = "The Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        [Display(Name = "Is Completed")]
        public bool IsCompleted { get; set; }
    }
}
