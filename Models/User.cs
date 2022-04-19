using Twitter_Clone_Backend.DTOs;

namespace Twitter_Clone_Backend.Models;



public record User
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public UserDTO asDto => new UserDTO
    {

        Id = Id,
        FullName = FullName,
        Email = Email,

    };
}