using System.Collections.Generic;

namespace GridLayout.DataStorage
{
    [System.Serializable]
    public class GridData
    {
        public List<Tile> _tiles;

        public int Count => _tiles.Count;

        public void Add(Tile tile)
        {
            _tiles.Add(tile);
        }

        public void Remove(int positionX, int positionY)
        {
            foreach (Tile tile in _tiles)
            {
                if (tile.PositionX == positionX && tile.PositionY == positionY)
                {
                    _tiles.Remove(tile);

                    return;
                }
            }
        }

        public Tile GetTile(int index)
        {
            return _tiles[index];
        }
    }
}