using System;
using System.Threading.Tasks;
using Football.TeamViewer.Application.Games;
using Football.TeamViewer.Domain;

namespace Football.TeamViewer.Persistence.Repositories
{
    internal class GameRepository : IGameRepository
    {
        private readonly TeamViewerDatabaseContext _databaseContext;

        public GameRepository(TeamViewerDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }


        public async Task<Game> Get(Guid id)
        {
            var game = await _databaseContext.Games.FindAsync(id);

            if (game is null)
            {
                return null;
            }

            var gameResult = game.FirstTeamScore != null && game.SecondTeamScore != null
                ? new GameResult(game.FirstTeamScore.Value, game.SecondTeamScore.Value)
                : null;

            return new Game
            {
                DateTime = game.DateTime,
                FirstTeam = game.FirstTeam,
                SecondTeam = game.SecondTeam,
                Id = game.Id,
                Result = gameResult
            };
        }
    }
}