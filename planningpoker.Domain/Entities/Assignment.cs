using planningpoker.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace planningpoker.Domain.Entities;
public class Assignment
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Description { get; set; }
    [ForeignKey("Game")]
    public Guid GameId { get; set; }
    public virtual Game Game { get; set; }
    public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>();
    public AssignmentStatus Status { get; set; } = AssignmentStatus.Initial;
}
