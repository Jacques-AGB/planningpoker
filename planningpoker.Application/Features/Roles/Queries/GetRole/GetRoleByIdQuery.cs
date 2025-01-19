using BinaryPlate.Application.Common.Models;
using MediatR;
using planningpoker.Application.IRepository;
using planningpoker.Application.Responses.Role;

namespace planningpoker.Application.Features.Roles.Queries.GetRole;
public class GetRoleByIdQuery : IRequest<Envelope<RoleResponse>>
{
    public string Id { get; set; }


    public class GetRoleByIdQueryHandler(IRoleRepository _repository) : IRequestHandler<GetRoleByIdQuery, Envelope<RoleResponse>>
    {
        public async Task<Envelope<RoleResponse>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetRole(request.Id);

            return Envelope<RoleResponse>.Result.Ok(response);
        }
    }
}
