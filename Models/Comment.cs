using Twitter_Clone_Backend.DTOs;

namespace Twitter_Clone_Backend.Models;



public record Comment

{
    public int Id { get; set; }
    public string CommentText { get; set; }
    public int PostId { get; set; }
    public int UserId { get; set; }

}