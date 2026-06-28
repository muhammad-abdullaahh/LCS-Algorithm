using System.ComponentModel.DataAnnotations;

namespace LCSPlagiarismChecker.Models
{
    public class CheckRequest
    {
        [Required(ErrorMessage = "Text 1 is required.")]
        [MinLength(20, ErrorMessage = "Text 1 must be at least 20 characters long.")]
        [MaxLength(5000, ErrorMessage = "Text 1 cannot exceed 5000 characters.")]
        public string Text1 { get; set; } = string.Empty;

        [Required(ErrorMessage = "Text 2 is required.")]
        [MinLength(20, ErrorMessage = "Text 2 must be at least 20 characters long.")]
        [MaxLength(5000, ErrorMessage = "Text 2 cannot exceed 5000 characters.")]
        public string Text2 { get; set; } = string.Empty;
    }
}
