using UnityEngine;

namespace Model.Infos
{
    [CreateAssetMenu(fileName = "HealthInfo", menuName = "GamePlay/New HealthInfo")]
    public class HealthInfo : ScriptableObject
    {
        [SerializeField] private int healthCount;
        public int HealthCount => healthCount;

    }
}