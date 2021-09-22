namespace TennisTests
{
    using System.Collections.Generic;
    using NUnit.Framework;
    using TennisGame;

    public class GameTests
    {
        private TennisStrategySpy _strategySpy;
        private Game _game;

        [SetUp]
        public void Setup()
        {
            _strategySpy = new TennisStrategySpy();
            _game = new Game(_strategySpy);
        }

        [Test]
        public void GetScore_GivenStrategyAndNewGame_CallsConvertGameScoreWith0to0()
        {
            var score = _game.Score;

            var expectedConvertGameScoreCall = (0, 0);
            
            Assert.That(_strategySpy.ConvertGameScoreCalls, Has.One.Items);
            Assert.That(_strategySpy.ConvertGameScoreCalls[0], Is.EqualTo(expectedConvertGameScoreCall));
        }
        
        [Test]
        public void GetScore_AfterPlayer1ScoreIncremented_CallsConvertGameScoreWith1to0()
        {
            _game.IncrementPlayer1Score();
            var score = _game.Score;

            var expectedConvertGameScoreCall = (1, 0);
            
            Assert.That(_strategySpy.ConvertGameScoreCalls, Has.One.Items);
            Assert.That(_strategySpy.ConvertGameScoreCalls[0], Is.EqualTo(expectedConvertGameScoreCall));
        }
        
        [Test]
        public void GetScore_AfterPlayer2ScoreIncremented_CallsConvertGameScoreWith0to1()
        {
            _game.IncrementPlayer2Score();
            var score = _game.Score;

            var expectedConvertGameScoreCall = (0, 1);
            
            Assert.That(_strategySpy.ConvertGameScoreCalls, Has.One.Items);
            Assert.That(_strategySpy.ConvertGameScoreCalls[0], Is.EqualTo(expectedConvertGameScoreCall));
        }
        
        [Test]
        public void GetScore_GivenStrategy_ReturnsStrategyScore()
        {
            _strategySpy.Score = "Love-all";
            
            Assert.That(_game.Score, Is.EqualTo("Love-all"));
        }

        private class TennisStrategySpy : ITennisScoreStrategy
        {
            public string Score { get; set; }
            
            public List<(int, int)> ConvertGameScoreCalls { get; }

            public TennisStrategySpy()
            {
                Score = null;
                ConvertGameScoreCalls = new List<(int, int)>();
            }
            
            public string ConvertIndividualGameScore(int score)
            {
                return null;
            }

            public string ConvertGameScore((int, int) score)
            {
                ConvertGameScoreCalls.Add(score);
                return Score;
            }
        }
    }
}