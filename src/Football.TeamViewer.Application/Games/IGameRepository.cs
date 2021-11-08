using System;
using System.Threading.Tasks;
using Football.TeamViewer.Domain;

namespace Football.TeamViewer.Application.Games
{
    public interface IGameRepository
    {
        Task<Game> Get(Guid id);
    }
}