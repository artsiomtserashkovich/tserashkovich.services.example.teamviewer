using System;

namespace Football.TeamViewer.Domain
{
    public class GameResult
    {
        public GameResult(int firstTeamScore, int secondTeamScore)
        {
            FirstTeamScore = firstTeamScore >= 0 
                ? firstTeamScore 
                : throw new ArgumentException("Score cannot be less than 0.", nameof(firstTeamScore));
            
            SecondTeamScore = secondTeamScore >= 0 
                ? secondTeamScore 
                : throw new ArgumentException("Score cannot be less than 0.", nameof(secondTeamScore));
        }
        
        public bool IsDraft => FirstTeamScore == SecondTeamScore;

        public bool IsFirstTeamWin => FirstTeamScore > SecondTeamScore;

        public bool IsSecondTeamWin => SecondTeamScore > FirstTeamScore;
        
        public int FirstTeamScore { get; }
        
        public int SecondTeamScore { get; }
    }
}