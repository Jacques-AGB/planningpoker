

using Microsoft.EntityFrameworkCore;
using planningpoker.Domain.Entities;
using System.Reflection;

namespace planningpoker.Infrastructure.Persistence.PostgreSql;
public class PostgreSqlApplicationDbContext : DbContext
{
    public PostgreSqlApplicationDbContext(DbContextOptions<PostgreSqlApplicationDbContext> options) 
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Rule> Rules { get; set; }
    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<Vote> Votes { get; set; }



}
