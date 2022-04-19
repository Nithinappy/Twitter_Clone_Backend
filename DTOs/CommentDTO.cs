using System.ComponentModel.DataAnnotations;

namespace Twitter_Clone_Backend.DTOs;

public record CommentCreateDTO
{
    [Required]
    [MinLength(3)]
    [MaxLength(60)]
    public string CommentText { get; set; }

}
