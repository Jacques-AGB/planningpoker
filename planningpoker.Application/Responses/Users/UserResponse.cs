namespace planningpoker.Application.Responses.Users;
public class UserResponse
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public Guid RoleId { get; set; }
    public Guid GameId { get; set; }
}
