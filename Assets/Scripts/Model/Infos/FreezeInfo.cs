using UnityEngine;

namespace Model.Infos
{
    [CreateAssetMenu(fileName = "FreezeInfo", menuName = "GamePlay/New FreezeInfo")]
    public class FreezeInfo : ScriptableObject
    {
        public float freezeTime;
    }
}