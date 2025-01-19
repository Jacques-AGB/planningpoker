using planningpoker.Domain.Entities;
using planningpoker.Domain.Enums;

namespace planningpoker.Application.Responses.Game;
public class GameResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid RuleId { get; set; }
    public int MaxPlayers { get; set; }
    public GameStatus Status { get; set; }
    public virtual ICollection<Assignment> Assignments { get; set; }
}
