namespace TennisTests
{
    using System;
    using System.ComponentModel;
    using NUnit.Framework;
    using TennisGame;

    public class TennisScoreStrategyTests
    {
        private TennisScoreStrategy _strategy;
        
        [SetUp]
        public void Setup()
        {
            _strategy = new TennisScoreStrategy();
        }

        [Test]
        public void ConvertIndividualGameScore_Given0_ReturnsLove()
        {
            var score = 0;
            
            Assert.That(_strategy.ConvertIndividualGameScore(score), Is.EqualTo("Love"));
        }
        
        [Test]
        public void ConvertIndividualGameScore_Given1_Returns15()
        {
            var score = 1;
            
            Assert.That(_strategy.ConvertIndividualGameScore(score), Is.EqualTo("15"));
        }
        
        [Test]
        public void ConvertIndividualGameScore_Given2_Returns30()
        {
            var score = 2;
            
            Assert.That(_strategy.ConvertIndividualGameScore(score), Is.EqualTo("30"));
        }
        
        [Test]
        public void ConvertIndividualGameScore_Given3_Returns40()
        {
            var score = 3;
            
            Assert.That(_strategy.ConvertIndividualGameScore(score), Is.EqualTo("40"));
        }

        [TestCase(-1)]
        [TestCase(4)]
        [TestCase(10)]
        public void ConvertIndividualGameScore_GivenInvalidScore_ThrowsArgumentException(int invalidScore)
        {
            Assert.That(
                () => _strategy.ConvertIndividualGameScore(invalidScore), 
                Throws.InstanceOf<ArgumentException>());
        }
        
        [Test]
        public void ConvertGameScore_Given00_ReturnsLoveAll()
        {
            var score = (0, 0);
            
            Assert.That(_strategy.ConvertGameScore(score), Is.EqualTo("Love-all"));
        }
        
        [Test]
        public void ConvertGameScore_Given1to0_Returns15Love()
        {
            var score = (1, 0);
            
            Assert.That(_strategy.ConvertGameScore(score), Is.EqualTo("15 : Love"));
        }
        
        [Test]
        public void ConvertGameScore_Given0to1_ReturnsLove15()
        {
            var score = (0, 1);
            
            Assert.That(_strategy.ConvertGameScore(score), Is.EqualTo("Love : 15"));
        }
        
        // ConvertGameScore now uses ConvertIndividualGameScore
        [Test]
        public void ConvertGameScore_Given3to1_Returns40to15()
        {
            var score = (3, 1);
            
            Assert.That(_strategy.ConvertGameScore(score), Is.EqualTo("40 : 15"));
        }
        
        // Guard
        [Test]
        public void ConvertGameScore_Given2to3_Returns30to40()
        {
            var score = (2, 3);
            
            Assert.That(_strategy.ConvertGameScore(score), Is.EqualTo("30 : 40"));
        }
        
        [Test]
        public void ConvertGameScore_Given1to1_Returns15All()
        {
            var score = (1, 1);
            
            Assert.That(_strategy.ConvertGameScore(score), Is.EqualTo("15-all"));
        }
        
        // Guard
        [Test]
        public void ConvertGameScore_Given2to2_Returns30All()
        {
            var score = (2, 2);
            
            Assert.That(_strategy.ConvertGameScore(score), Is.EqualTo("30-all"));
        }
        
        [Test]
        public void ConvertGameScore_Given3to3_ReturnsDeuce()
        {
            var score = (3, 3);
            
            Assert.That(_strategy.ConvertGameScore(score), Is.EqualTo("Deuce"));
        }
        
        // Guard
        [TestCase(-1, 5)]
        [TestCase(5, 2)]
        [TestCase(1, -1)]
        public void ConvertGameScore_GivenInvalidScore_ThrowsArgumentException(int serverScore, int nonServerScore)
        {
            var invalidScore = (serverScore, nonServerScore);
            
            Assert.That(
                () => _strategy.ConvertGameScore(invalidScore), 
                Throws.InstanceOf<ArgumentException>());
        }
    }
}