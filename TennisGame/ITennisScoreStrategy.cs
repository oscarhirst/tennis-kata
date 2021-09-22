namespace TennisGame
{
    public interface ITennisScoreStrategy
    {
        public string ConvertIndividualGameScore(int score);
        
        public string ConvertGameScore((int, int) score);
    }
}