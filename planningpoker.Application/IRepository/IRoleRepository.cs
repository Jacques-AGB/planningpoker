using planningpoker.Application.Features.Roles.Commands.AddRole;
using planningpoker.Application.Responses.Role;
using planningpoker.Domain.Entities;

namespace planningpoker.Application.IRepository;
public interface IRoleRepository
{
    Task<Role> AddRole(AddRoleCommand request, CancellationToken cancellationToken);
    Task<string> DeleteRole(Guid Id, CancellationToken cancellationToken);
    Task<RoleResponse> GetRole(string Id);
    Task<List<RoleResponse>> GetRoles();
}
