using ConstructionPanel;
using ConstructionPanel.Items;
using GridLayout.DataStorage;
using System.Collections.Generic;
using UnityEngine;

namespace GridLayout
{
    public class AllTiles : MonoBehaviour
    {
        [SerializeField] private ItemsContainer _itemsContainer;

        private List<TileInfo> _tilesInfo;
        private GridData _gridData;

        private void Awake()
        {
            _tilesInfo = new List<TileInfo>();
        }

        public void Init(GridData gridData)
        {
            _gridData = gridData;
        }

        public void AddTile(TileView tileView)
        {
            TileInfo tileInfo = tileView.GetComponent<TileInfo>();
            _tilesInfo.Add(tileInfo);
        }

        public void SetStatus()
        {
            for (int i = 0; i < _gridData.Count; i++)
            {
                Tile tile = _gridData.GetTile(i);

                foreach (TileInfo tileInfo in _tilesInfo)
                {
                    if (tileInfo.PositionX == tile.PositionX && tileInfo.PositionY == tile.PositionY)
                    {
                        tileInfo.Set(tile.Type);
                        Item item = _itemsContainer.GetItemByType(tile.Type);
                        TileView tileView = tileInfo.GetComponent<TileView>();
                        tileView.OnHighlight(item.Icon);
                    }
                }
            }
        }
    }
}