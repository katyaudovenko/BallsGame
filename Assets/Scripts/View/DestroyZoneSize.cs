using UnityEngine;

namespace View
{
    public class DestroyZoneSize : MonoBehaviour
    {
        [Range(0.001f, 1f)]
        [SerializeField] private float relativeHeight;
        
        private void Start()
        {
            var sizeX = GetWidthByScreen();
            SetWidthByScreen(sizeX);
            var sizeY = GetHeightByScreen();
            SetHeightByScreen(sizeY);
        }

        private void SetWidthByScreen(float destroyZoneSize)
        {
            var localScale = transform.localScale;
            localScale.x = destroyZoneSize;
            transform.localScale = localScale;
        }
        
        private void SetHeightByScreen(double destroyZoneSize)
        {
            var localScale = transform.localScale;
            localScale.y = (float)destroyZoneSize;
            transform.localScale = localScale;
        }

        private float GetWidthByScreen()
        {
            var width = Screen.width;
            var height = Screen.height;
            var leftDownCorner = new Vector2(0, height);
            var rightDownCorner = new Vector2(width, height);
            var worldLeftDownCorner = Camera.main.ScreenToWorldPoint(leftDownCorner);
            var worldRightDownCorner = Camera.main.ScreenToWorldPoint(rightDownCorner);
            var destroyZoneSize = (worldRightDownCorner - worldLeftDownCorner).x;
            return destroyZoneSize;
        }

        private double GetHeightByScreen()
        {
            var height = Screen.height;
            var leftDownCorner = new Vector2(0, height);
            var leftUpCorner = new Vector2(0, 0);
            var worldLeftDownCorner = Camera.main.ScreenToWorldPoint(leftDownCorner);
            var worldLeftUpCorner = Camera.main.ScreenToWorldPoint(leftUpCorner);
            var destroyZoneSize = (worldLeftDownCorner - worldLeftUpCorner).y * relativeHeight;
            return destroyZoneSize;
        }
    }
}