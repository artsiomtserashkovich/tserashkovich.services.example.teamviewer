using System;
using FluentAssertions;
using NUnit.Framework;

namespace Football.TeamViewer.Domain.Tests
{
    public class Tests
    {
        [TestCase(-1, 0)] 
        [TestCase(1, -2)]
        [TestCase(-2, -3)]
        public void Ctor_InvalidScores_TrowException(int firstTeamScore, int secondTeamScore)
        {
            Action act = () => new GameResult(firstTeamScore, secondTeamScore);

            act.Should().Throw<ArgumentException>();
        }
        
        [TestCase(1, 0, false)] 
        [TestCase(1, 1, true)]
        public void IsDraft_ScoresProvided_ReturnCorrectFlag(
            int firstTeamScore, int secondTeamScore, bool expectedResult)
        {
            new GameResult(firstTeamScore, secondTeamScore).IsDraft.Should().Be(expectedResult);
        }
        
        [TestCase(1, 0, true)] 
        [TestCase(1, 1, false)] 
        [TestCase(1, 2, false)]
        public void IsFirstTeamWin_ScoresProvided_ReturnCorrectFlag(
            int firstTeamScore, int secondTeamScore, bool expectedResult)
        {
            new GameResult(firstTeamScore, secondTeamScore).IsFirstTeamWin.Should().Be(expectedResult);
        }
        
        [TestCase(1, 0, false)] 
        [TestCase(1, 1, false)] 
        [TestCase(1, 2, true)]
        public void IsSecondTeamWin_ScoresProvided_ReturnCorrectFlag(
            int firstTeamScore, int secondTeamScore, bool expectedResult)
        {
            new GameResult(firstTeamScore, secondTeamScore).IsSecondTeamWin.Should().Be(expectedResult);
        }
    }
}