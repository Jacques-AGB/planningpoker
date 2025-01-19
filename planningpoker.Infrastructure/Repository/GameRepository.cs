using Microsoft.EntityFrameworkCore;
using planningpoker.Application.Features.Games.Commands.AddGame;
using planningpoker.Application.IRepository;
using planningpoker.Application.Responses.Game;
using planningpoker.Domain.Entities;
using planningpoker.Infrastructure.Persistence.PostgreSql;

namespace planningpoker.Infrastructure.Repository;
public class GameRepository : IGameRepository
{
    private readonly PostgreSqlApplicationDbContext _context;

    public GameRepository(PostgreSqlApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Game> AddGame(AddGameCommand request, CancellationToken cancellationToken)
    {
        var Game = new Game
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            RuleId = request.RuleId,
            MaxPlayers = request.MaxPlayers,
            Status = request.Status,

        };
        _context.Games.Add(Game);
        await _context.SaveChangesAsync();
        Console.WriteLine(Game);

        return Game;
    }

    public async Task<string> DeleteGame(Guid Id, CancellationToken cancellationToken)
    {
        var Game = await _context.Games.FindAsync(Id);
        if (Game == null)
        {
            string message = $" Game with Id {Id} doesn't exist";
            throw new ApplicationException(message);
        }
        else
        {
            _context.Games.Remove(Game);
            await _context.SaveChangesAsync(cancellationToken);
            return $"Game with Id '{Id}' has been deleted successfully";
        }
    }

    public async Task<GameResponse> GetGame(string Id)
    {
        var game = await _context.Games.FirstOrDefaultAsync(r => r.Id.ToString() == Id);
        if (game == null)
        {
            string message = $" Game with Id {Id} doesn't exist";
            throw new ApplicationException(message);
        }
        var response = new GameResponse
        {
            Id = game.Id,
            Name = game.Name,
            Status = game.Status,
            MaxPlayers = game.MaxPlayers,
            Assignments = game.Assignments,
            RuleId = game.RuleId
        };

        return response;
    }

    public async Task<List<GameResponse>> GetGames()
    {
        var game = await _context.Games.Select(game => new GameResponse
        {
            Id = game.Id,
            Name = game.Name,
            Status = game.Status,
            MaxPlayers = game.MaxPlayers,
            Assignments = game.Assignments,
            RuleId = game.RuleId
        }).ToListAsync();

        return game;
    }

}
