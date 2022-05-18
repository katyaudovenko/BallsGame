using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "DetonateInfo", menuName = "GamePlay/New DetonateInfo")]
    public class DetonateInfo : ScriptableObject
    {
        [SerializeField] private float radius;
        public float Radius => radius;
    }
}