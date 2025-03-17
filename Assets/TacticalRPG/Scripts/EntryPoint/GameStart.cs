using Bootstrap;
using ConstructionPanel;
using GridLayout;
using GridLayout.DataStorage;
using UnityEngine;

namespace EntryPoint
{
    public class GameStart : MonoBehaviour
    {
        [SerializeField] private GridTiles _gridTiles;
        [SerializeField] private GridDataHandler _gridDataHandler;
        [SerializeField] private AllTiles _allTiles;
        [SerializeField] private ItemsContainer _itemsContainer;

        private JSONController _jsonController;

        private void Start()
        {
            _jsonController = BootstrappedData.Instance.JSONController;
            _jsonController.Init();
            _gridDataHandler.Init(_jsonController._gridData);
            _allTiles.Init(_jsonController._gridData);
            _gridTiles.Init();
            _itemsContainer.Init();
        }

        private void OnDisable()
        {
            _jsonController.SaveField();
        }
    }
}