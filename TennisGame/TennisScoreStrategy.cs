using System;

namespace TennisGame
{
    public class TennisScoreStrategy : ITennisScoreStrategy
    {
        public string ConvertIndividualGameScore(int score)
        {
            switch (score)
            {
                case 0:
                    return "Love";
                case 1:
                    return "15";
                case 2:
                    return "30";
                case 3:
                    return "40";
                default:
                    throw new ArgumentException();
            }
        }

        public string ConvertGameScore((int, int) score)
        {
            var serverNumericScore = score.Item1;
            var nonServerNumericScore = score.Item2;

            var serverScore = ConvertIndividualGameScore(serverNumericScore);

            if (serverNumericScore == nonServerNumericScore)
            {
                if (serverScore == "40")
                {
                    return "Deuce";
                }
                
                return $"{serverScore}-all";
            }

            var nonServerScore = ConvertIndividualGameScore(nonServerNumericScore);

            return $"{serverScore} : {nonServerScore}";
        }
    }
}