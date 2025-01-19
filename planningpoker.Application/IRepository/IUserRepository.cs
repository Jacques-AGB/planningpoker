using planningpoker.Application.Features.Users.Commands.AddUser;
using planningpoker.Application.Responses.Users;
using planningpoker.Domain.Entities;

namespace planningpoker.Application.IRepository;
public interface IUserRepository
{
    Task<User> AddUser(AddUserCommand request, CancellationToken cancellationToken);
    Task<string> DeleteUser(Guid Id, CancellationToken cancellationToken);
    Task<UserResponse> GetUser(string Id);
    Task<List<UserResponse>> GetUsers();
}
