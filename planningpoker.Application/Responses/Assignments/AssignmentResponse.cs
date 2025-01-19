using planningpoker.Domain.Entities;
using planningpoker.Domain.Enums;

namespace planningpoker.Application.Responses.Assignments;
public class AssignmentResponse
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public ICollection<Vote>? Votes { get; set; }
    public AssignmentStatus Status { get; set; }
}
