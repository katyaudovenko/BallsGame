using UnityEngine;

namespace Model.Infos
{
    [CreateAssetMenu(fileName = "FreezeInfo", menuName = "GamePlay/New FreezeInfo")]
    public class FreezeInfo : ScriptableObject
    {
        [SerializeField] private float freezeTime;
        public float FreezeTime => freezeTime;
    }
}