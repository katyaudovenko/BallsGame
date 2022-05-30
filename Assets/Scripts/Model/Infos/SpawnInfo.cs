using UnityEngine;

namespace Model.Infos
{
    [CreateAssetMenu (fileName = "SpawnInfo", menuName = "GamePlay/New SpawnInfo")]
    public class SpawnInfo : ScriptableObject
    {
        [SerializeField] private float timeSpawnDelay;
        public float TimeSpawnDelay => timeSpawnDelay;
        
        [SerializeField] private SpawnConfig[] spawnObjects;
        public SpawnConfig[] SpawnObjects => spawnObjects;
        
    }
}