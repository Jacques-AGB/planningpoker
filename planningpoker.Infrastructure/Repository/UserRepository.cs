using Microsoft.EntityFrameworkCore;
using planningpoker.Application.Features.Users.Commands.AddUser;
using planningpoker.Application.IRepository;
using planningpoker.Application.Responses.Users;
using planningpoker.Domain.Entities;
using planningpoker.Infrastructure.Persistence.PostgreSql;

namespace planningpoker.Infrastructure.Repository;
public class UserRepository : IUserRepository
{
    private readonly PostgreSqlApplicationDbContext _context;

    public UserRepository(PostgreSqlApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User> AddUser(AddUserCommand request, CancellationToken cancellationToken)
    {
        var User = new User
        {
            Id = Guid.NewGuid(),
            Username = request.Username,
            GameId = request.GameId,
            RoleId = request.RoleId,


        };
        _context.Users.Add(User);
        await _context.SaveChangesAsync();
        Console.WriteLine(User);

        return User;
    }



    public async Task<string> DeleteUser(Guid Id, CancellationToken cancellationToken)
    {
        var User = await _context.Users.FindAsync(Id);
        if (User == null)
        {
            string message = $" User with Id {Id} doesn't exist";
            throw new ApplicationException(message);
        }
        else
        {
            _context.Users.Remove(User);
            await _context.SaveChangesAsync(cancellationToken);
            return $"User with Id '{Id}' has been deleted successfully";
        }
    }

    public async Task<UserResponse> GetUser(string Id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(r => r.Id.ToString() == Id);
        if (user == null)
        {
            string message = $" User with Id {Id} doesn't exist";
            throw new ApplicationException(message);
        }
        var response = new UserResponse
        {
            Id = user.Id,
            Username = user.Username,
            GameId = user.GameId,
            RoleId = user.RoleId,

        };

        return response;
    }

    public async Task<List<UserResponse>> GetUsers()
    {
        var user = await _context.Users.Select(user => new UserResponse
        {
            Id = user.Id,
            Username = user.Username,
            GameId = user.GameId,
            RoleId = user.RoleId,
        }).ToListAsync();

        return user;
    }

}
