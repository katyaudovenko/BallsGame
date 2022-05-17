using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "FreezeInfo", menuName = "GamePlay/New FreezeInfo")]
    public class FreezeInfo : ScriptableObject
    {
        [SerializeField] private float freezeTime;
        public float FreezeTime => freezeTime;
    }
}