using BinaryPlate.Application.Common.Models;
using MediatR;
using planningpoker.Application.IRepository;
using planningpoker.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace planningpoker.Application.Features.Users.Commands.AddUser;
public class AddUserCommand : IRequest<Envelope<User>>
{
    public string Username { get; set; }
    public Guid RoleId { get; set; }
    public Guid GameId { get; set; }
}
public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Envelope<User>>
{
    private readonly IUserRepository _repository;

    public AddUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Envelope<User>> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.AddUser(request, cancellationToken);


        return Envelope<User>.Result.Ok(user);
    }
}