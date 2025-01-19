using BinaryPlate.Application.Common.Models;
using MediatR;
using planningpoker.Application.IRepository;
using planningpoker.Application.Responses.Role;

namespace planningpoker.Application.Features.Roles.Queries.GetRoles;
public class GetRolesQuery : IRequest<Envelope<List<RoleResponse>>>
{

    public class GetRoleQueryHandler(IRoleRepository repository) : IRequestHandler<GetRolesQuery, Envelope<List<RoleResponse>>>
    {
        public async Task<Envelope<List<RoleResponse>>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var response = await repository.GetRoles();
            return Envelope<List<RoleResponse>>.Result.Ok(response);
        }
    }
}
