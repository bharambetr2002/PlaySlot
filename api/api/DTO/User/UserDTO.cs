namespace api.Models.DTOs.User;

public class CreateUserDTO
{
    public required string UserName { get; set; }
    public required string UserContactNumber { get; set; }
    public required string UserLocation { get; set; }
}
