using BinaryPlate.Application.Common.Models;
using MediatR;
using planningpoker.Application.IRepository;
using planningpoker.Application.Responses.Users;

namespace planningpoker.Application.Features.Users.Queries.GetUser;
public class GetUserByIdQuery : IRequest<Envelope<UserResponse>>
{
    public string Id { get; set; }


    public class GetUserByIdQueryHandler(IUserRepository _repository) : IRequestHandler<GetUserByIdQuery, Envelope<UserResponse>>
    {
        public async Task<Envelope<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetUser(request.Id);

            return Envelope<UserResponse>.Result.Ok(response);
        }
    }
}
