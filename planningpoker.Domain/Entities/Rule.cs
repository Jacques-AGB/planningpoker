using System.ComponentModel.DataAnnotations;

namespace planningpoker.Domain.Entities;
public class Rule
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
