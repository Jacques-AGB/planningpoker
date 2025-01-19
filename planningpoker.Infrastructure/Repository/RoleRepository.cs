using Microsoft.EntityFrameworkCore;
using planningpoker.Application.Features.Roles.Commands.AddRole;
using planningpoker.Application.IRepository;
using planningpoker.Application.Responses.Role;
using planningpoker.Domain.Entities;
using planningpoker.Infrastructure.Persistence.PostgreSql;

namespace planningpoker.Infrastructure.Repository;
public class RoleRepository : IRoleRepository
{
    private readonly PostgreSqlApplicationDbContext _context;

    public RoleRepository(PostgreSqlApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Role> AddRole(AddRoleCommand request, CancellationToken cancellationToken)
    {
        var Role = new Role
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            

        };
        _context.Roles.Add(Role);
        await _context.SaveChangesAsync();
        Console.WriteLine(Role);

        return Role;
    }

    public async Task<string> DeleteRole(Guid Id, CancellationToken cancellationToken)
    {
        var role = await _context.Roles.FindAsync(Id);
        if (role == null)
        {
            string message = $" Role with Id {Id} doesn't exist";
            throw new ApplicationException(message);
        }
        else
        {
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync(cancellationToken);
            return $"Role with Id '{Id}' has been deleted successfully";
        }
    }

    public async Task<RoleResponse> GetRole(string Id)
    {
        var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id.ToString() == Id);
        if (role == null) {
            string message = $" Role with Id {Id} doesn't exist";
            throw new ApplicationException(message);
        }
        var response = new RoleResponse
        {
            Id = role.Id,
            Name = role.Name,
        };

        return response;
    }

    public async Task<List<RoleResponse>> GetRoles()
    {
        var role = await _context.Roles.Select(role => new RoleResponse
        {
            Id = role.Id,
            Name= role.Name,
        }).ToListAsync();

        return role;
    }


}
