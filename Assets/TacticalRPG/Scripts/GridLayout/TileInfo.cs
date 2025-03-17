using UnityEngine;

namespace GridLayout
{
    public class TileInfo : MonoBehaviour
    {
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public bool IsBusy { get; private set; }
        public string Type { get; private set; }

        public void Init(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }

        public void Set(string type)
        {
            IsBusy = true;
            Type = type;
        }

        public void ResetValues()
        {
            IsBusy = false;
            Type = string.Empty;
        }
    }
}