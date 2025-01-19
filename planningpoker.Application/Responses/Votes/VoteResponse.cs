namespace planningpoker.Application.Responses.Votes;
public class VoteResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid AssignmentId { get; set; }
    public int Value { get; set; }
}
