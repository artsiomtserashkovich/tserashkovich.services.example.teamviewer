using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GameEntity = Football.TeamViewer.Persistence.Models.Game;

namespace Football.TeamViewer.Persistence.Configurations
{
    internal class GameConfiguration : IEntityTypeConfiguration<GameEntity>
    {
        public void Configure(EntityTypeBuilder<GameEntity> builder)
        {
            builder.HasKey(g => g.Id);
            builder.HasOne(g => g.FirstTeam);
            builder.HasOne(g => g.SecondTeam);
        }
    }
}