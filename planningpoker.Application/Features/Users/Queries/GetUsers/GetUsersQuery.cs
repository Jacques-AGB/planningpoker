using BinaryPlate.Application.Common.Models;
using MediatR;
using planningpoker.Application.IRepository;
using planningpoker.Application.Responses.Users;

namespace planningpoker.Application.Features.Users.Queries.GetUsers;
public class GetUsersQuery : IRequest<Envelope<List<UserResponse>>>
{

    public class GetUserQueryHandler(IUserRepository repository) : IRequestHandler<GetUsersQuery, Envelope<List<UserResponse>>>
    {
        public async Task<Envelope<List<UserResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var response = await repository.GetUsers();
            return Envelope<List<UserResponse>>.Result.Ok(response);
        }
    }
}
