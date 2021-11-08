using Football.TeamViewer.Domain;
using Microsoft.EntityFrameworkCore;
using GameEntity = Football.TeamViewer.Persistence.Models.Game;

namespace Football.TeamViewer.Persistence
{
    public class TeamViewerDatabaseContext : DbContext
    {
        public TeamViewerDatabaseContext(DbContextOptions<TeamViewerDatabaseContext> options)
            : base(options) {}
        
        public DbSet<GameEntity> Games { get; }
        
        public DbSet<Coach> Coaches { get; }

        public DbSet<Player> Players { get; }
        
        public DbSet<Team> Teams { get; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(TeamViewerDatabaseContext).Assembly);
        }
    }
}