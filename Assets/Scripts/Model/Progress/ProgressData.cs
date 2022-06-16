using System;

namespace Model.Progress
{
    [Serializable]
    public class ProgressData
    {
        public int bestScore;
        public int score;
        public int coins;

        public ProgressData()
        {
            bestScore = 0;
            score = 0;
            coins = 0;
        }
    }
}