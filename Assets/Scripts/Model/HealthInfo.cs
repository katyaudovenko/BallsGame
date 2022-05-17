using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "HealthInfo", menuName = "GamePlay/New HealthInfo")]
    public class HealthInfo : ScriptableObject
    {
        [SerializeField] private int healthCount;
        public int HealthCount => healthCount;

    }
}