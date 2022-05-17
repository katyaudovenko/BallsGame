using Extensions;
using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "BallInfo", menuName = "GamePlay/New BallInfo")]
    public class BallInfo : ScriptableObject
    {
        [SerializeField] private int timeLifeHeavyBall;
        public int TimeLifeHeavyBall => timeLifeHeavyBall;
        
        [SerializeField] private float speed;
        public float Speed => speed;
        
        [SerializeField] private int livesCountCompositeBall;
        public int LivesCountCompositeBall => livesCountCompositeBall;

        [SerializeField] private float minScaleBall;
        [SerializeField] private float maxScaleBall;

        public Vector3 BallSize => Vector3.one * Random.Range(minScaleBall, maxScaleBall);

        [SerializeField] private Color[] colors;
        public Color Color => colors.GetRandomItem(color=> color.a * color.b * color.g * color.r);
    }
}