using planningpoker.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planningpoker.Domain.Entities;
public class Game
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    [ForeignKey("Rule")]
    public Guid RuleId { get; set; }
    public virtual Rule Rule { get; set; }
    public int MaxPlayers { get; set; }
    public GameStatus Status { get; set; }
    public ICollection<Assignment>? Assignments { get; set; }
}
