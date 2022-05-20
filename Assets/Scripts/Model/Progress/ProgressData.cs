using System;

namespace Model.Progress
{
    [Serializable]
    public class ProgressData
    {
        public int BestScore;
        public int Score;
        public int Coins;

        public ProgressData()
        {
            BestScore = 0;
            Score = 0;
            Coins = 0;
        }
    }
}