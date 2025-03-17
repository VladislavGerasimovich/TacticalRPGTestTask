using UnityEngine;

namespace GridLayout.DataStorage
{
    public class GridDataHandler : MonoBehaviour
    {
        private GridData _gridData;

        public void Init(GridData gridData)
        {
            _gridData = gridData;
        }

        public void AddTile(int positionX, int positionY, string type)
        {
            Tile tile = new Tile(positionX, positionY, type);
            Debug.Log(tile + " new tile created");
            _gridData.Add(tile);
        }

        public void RemoveTile(int positionX, int positionY)
        {
            _gridData.Remove(positionX, positionY);
        }
    }
}