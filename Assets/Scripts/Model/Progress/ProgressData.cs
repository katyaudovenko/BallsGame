using System;

namespace Model.Progress
{
    [Serializable]
    public class ProgressData
    {
        public int bestScore;
        public int score;
        public int coins;
        public PlayerStats playerStats;

        public ProgressData()
        {
            playerStats = new PlayerStats();
            
            bestScore = 0;
            score = 0;
            coins = 0;
        }
    }
}