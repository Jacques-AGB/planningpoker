using System.ComponentModel.DataAnnotations;

namespace planningpoker.Domain.Entities;
public class Role
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
}
