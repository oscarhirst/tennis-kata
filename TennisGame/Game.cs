namespace TennisGame
{
    public class Game
    {
        private readonly ITennisScoreStrategy _scoreStrategy;

        public string Score => _scoreStrategy.ConvertGameScore((_player1Score, _player2Score));

        private int _player1Score;
        private int _player2Score;
        
        public Game(ITennisScoreStrategy scoreStrategy)
        {
            _scoreStrategy = scoreStrategy;
        }

        public void IncrementPlayer1Score() => _player1Score++;

        public void IncrementPlayer2Score() => _player2Score++;
    }
}