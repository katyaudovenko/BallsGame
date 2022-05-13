using UnityEngine;

namespace View
{
    public static class SpawnZoneSize
    {
        public static float LeftBorder()
        {
            var worldLeftDownCorner = Camera.main.ScreenToWorldPoint(Vector2.zero);
            return worldLeftDownCorner.x + 0.5f;
        }

        public static float RightBorder()
        {
            var width = Screen.width;
            var rightUpCorner = new Vector2(width, 0);
            var worldRightUpCorner = Camera.main.ScreenToWorldPoint(rightUpCorner);
            return worldRightUpCorner.x - 0.5f;
        }
    }
}