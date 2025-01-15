using planningpoker.Domain.Enums;

namespace planningpoker.Application.Requests.AssignmentRequests;
public class AddAssignmentRequest
{
    public string Description { get; set; }
    public AssignmentStatus Status { get; set; }
}
