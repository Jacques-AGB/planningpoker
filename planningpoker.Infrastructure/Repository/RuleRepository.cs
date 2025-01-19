using Microsoft.EntityFrameworkCore;
using planningpoker.Application.Features.Rules.Commands.AddRule;
using planningpoker.Application.IRepository;
using planningpoker.Application.Responses.Rules;
using planningpoker.Domain.Entities;
using planningpoker.Infrastructure.Persistence.PostgreSql;

namespace planningpoker.Infrastructure.Repository;
public class RuleRepository : IRuleRepository
{
    private readonly PostgreSqlApplicationDbContext _context;

    public RuleRepository(PostgreSqlApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Rule> AddRule(AddRuleCommand request, CancellationToken cancellationToken)
    {
        var Rule = new Rule
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,

        };
        _context.Rules.Add(Rule);
        await _context.SaveChangesAsync();
        Console.WriteLine(Rule);

        return Rule;
    }


    public async Task<string> DeleteRule(Guid Id, CancellationToken cancellationToken)
    {
        var Rule = await _context.Rules.FindAsync(Id);
        if (Rule == null)
        {
            string message = $" Rule with Id {Id} doesn't exist";
            throw new ApplicationException(message);
        }
        else
        {
            _context.Rules.Remove(Rule);
            await _context.SaveChangesAsync(cancellationToken);
            return $"Rule with Id '{Id}' has been deleted successfully";
        }
    }

    public async Task<RuleResponse> GetRule(string Id)
    {
        var rule = await _context.Rules.FirstOrDefaultAsync(r => r.Id.ToString() == Id);
        if (rule == null)
        {
            string message = $" Rule with Id {Id} doesn't exist";
            throw new ApplicationException(message);
        }
        var response = new RuleResponse
        {
            Id = rule.Id,
            Name = rule.Name,
            Description = rule.Description,

        };

        return response;
    }

    public async Task<List<RuleResponse>> GetRules()
    {
        var rule = await _context.Rules.Select(rule => new RuleResponse
        {
            Id = rule.Id,
            Name = rule.Name,
            Description = rule.Description
        }).ToListAsync();

        return rule;
    }

}
