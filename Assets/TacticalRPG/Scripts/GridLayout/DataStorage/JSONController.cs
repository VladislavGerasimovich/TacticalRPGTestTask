using GridLayout;
using System.IO;
using UnityEngine;

namespace GridLayout.DataStorage
{
    public class JSONController : MonoBehaviour
    {
        [SerializeField] private GridDataHandler _gridDataHandler;
        [SerializeField] private AllTiles _allTiles;

        public GridData _gridData;

        private void Awake()
        {
            LoadField();
            _gridDataHandler.Init(_gridData);
            _allTiles.Init(_gridData);
        }

        private void OnDisable()
        {
            SaveField();
        }

        [ContextMenu("Load")]
        public void LoadField()
        {
            _gridData = JsonUtility.FromJson<GridData>(File.ReadAllText(Application.streamingAssetsPath + "/JSON.json"));
        }

        [ContextMenu("Save")]
        public void SaveField()
        {
            File.WriteAllText(Application.streamingAssetsPath + "/JSON.json", JsonUtility.ToJson(_gridData));
        }
    }
}