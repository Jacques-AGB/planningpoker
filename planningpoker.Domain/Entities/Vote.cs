using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planningpoker.Domain.Entities;
public class Vote
{
    [Key]
    public Guid Id { get; set; }
    [ForeignKey("User")]
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    [ForeignKey("Assignment")]
    public Guid AssignmentId { get; set; }
    public virtual Assignment Assignment { get; set; }
    public int Value { get; set; }

}
