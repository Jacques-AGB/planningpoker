using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace planningpoker.Domain.Entities;
public class User
{
    [Key]
    public Guid Id { get; set; }
    public string Username { get; set; }
    [ForeignKey("Role")]
    public Guid RoleId { get; set; }
    public virtual Role Role { get; set; }
    public Guid GameId { get; set; }
    public virtual Game Game { get; set; }
}
