using System;

namespace Model.Progress
{
    [Serializable]
    public class PlayerStats
    {
        public float freezeTimeModificator;
        public float bombRadiusModificator;
        public int coinsModificator;
        
        public int freezeUpgradeCycle;
        public int bombRadiusUpgradeCycle;
        public int coinsUpgradeCycle;

        public PlayerStats()
        {
            freezeTimeModificator = 0;
            bombRadiusModificator = 0;
            coinsModificator = 0;
            
            freezeUpgradeCycle = 1;
            bombRadiusUpgradeCycle = 1;
            coinsUpgradeCycle = 1;
        }
    }
}