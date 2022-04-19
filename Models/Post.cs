using Twitter_Clone_Backend.DTOs;

namespace Twitter_Clone_Backend.Models;



public record Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int UserId { get; set; }

}