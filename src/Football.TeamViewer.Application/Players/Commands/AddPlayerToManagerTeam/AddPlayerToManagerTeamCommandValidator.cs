using FluentValidation;

namespace Football.TeamViewer.Application.Players.Commands.AddPlayerToManagerTeam
{
    public class AddPlayerToManagerTeamCommandValidator : AbstractValidator<AddPlayerToManagerTeamCommand>
    {
        public AddPlayerToManagerTeamCommandValidator()
        {
            RuleFor(c => c.FirstName).NotNull().NotEmpty().Length(1, 20);
            RuleFor(c => c.SecondName).NotNull().NotEmpty().Length(1, 20);
            RuleFor(c => c.JerseyNumber).InclusiveBetween(1, 80);
        }
    }
}