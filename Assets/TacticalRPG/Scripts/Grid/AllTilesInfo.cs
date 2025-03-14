using System.Collections.Generic;
using UnityEngine;

namespace Grid
{
    public class AllTilesInfo : MonoBehaviour
    {
        private List<TileInfo> _tilesInfo;

        private void Awake()
        {
            _tilesInfo = new List<TileInfo>();
        }

        public void AddTile(TileView tileView)
        {
            TileInfo tileInfo = tileView.GetComponent<TileInfo>();
            _tilesInfo.Add(tileInfo);
        }
    }
}