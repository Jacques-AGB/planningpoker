using planningpoker.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace planningpoker.Domain.Entities;
public class Assignment
{
    [Key]
    public Guid Id { get; set; }
    public string Description { get; set; }
    public ICollection<Vote> Votes { get; set; }
    public AssignmentStatus Status { get; set; }
}
