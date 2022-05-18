using UnityEngine;

namespace View
{
    public class SpawnZoneSize : MonoBehaviour
    {
        [Range(0.001f, 1f)]
        [SerializeField] private float relativeWidth;
        
        public float RightBorder()
        {
            var width = Screen.width;
            var rightUpCorner = new Vector2(width, 0);
            if (Camera.main == null) return 0;
            var worldRightUpCorner = Camera.main.ScreenToWorldPoint(rightUpCorner);
            return worldRightUpCorner.x * relativeWidth;

        }

        public float LeftBorder()
        {
            if (Camera.main == null) return 0;
            var worldLeftDownCorner = Camera.main.ScreenToWorldPoint(Vector2.zero);
            return worldLeftDownCorner.x * relativeWidth;

        }

    }
}