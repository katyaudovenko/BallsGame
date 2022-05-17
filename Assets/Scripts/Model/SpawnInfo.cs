using UnityEngine;
using View;

namespace Model
{
    [CreateAssetMenu (fileName = "SpawnInfo", menuName = "GamePlay/New SpawnInfo")]
    public class SpawnInfo : ScriptableObject
    {
        [SerializeField] private float timeSpawnDelay;
        public float TimeSpawnDelay => timeSpawnDelay;
        
        [SerializeField] private SpawnConfig[] spawnObjects;
        public SpawnConfig[] SpawnObjects => spawnObjects;

        public float MinPoint => SpawnZoneSize.LeftBorder();
        public float MaxPoint => SpawnZoneSize.RightBorder();
    }
}