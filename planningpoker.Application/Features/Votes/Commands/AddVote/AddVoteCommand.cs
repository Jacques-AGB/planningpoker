using BinaryPlate.Application.Common.Models;
using MediatR;
using planningpoker.Application.IRepository;
using planningpoker.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace planningpoker.Application.Features.Votes.Commands.AddVote;
public class AddVoteCommand : IRequest<Envelope<Vote>>
{
    public Guid UserId { get; set; }
    public Guid AssignmentId { get; set; }
    public int Value { get; set; }
}
public class AddVoteCommandHandler : IRequestHandler<AddVoteCommand, Envelope<Vote>>
{
    private readonly IVoteRepository _repository;

    public AddVoteCommandHandler(IVoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Envelope<Vote>> Handle(AddVoteCommand request, CancellationToken cancellationToken)
    {
        var Vote = await _repository.AddVote(request, cancellationToken);


        return Envelope<Vote>.Result.Ok(Vote);
    }
}