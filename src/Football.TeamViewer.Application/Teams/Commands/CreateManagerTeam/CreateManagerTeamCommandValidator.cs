using FluentValidation;

namespace Football.TeamViewer.Application.Teams.Commands.CreateManagerTeam
{
    public class CreateManagerTeamCommandValidator : AbstractValidator<CreateManagerTeamCommand>
    {
        public CreateManagerTeamCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(3, 20);
        }
    }
}