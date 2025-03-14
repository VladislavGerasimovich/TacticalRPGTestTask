using UnityEngine;

namespace Grid
{
    [RequireComponent(typeof(AllTilesInfo))]
    public class Grid : MonoBehaviour
    {
        [SerializeField] private TileView _tilePrefab;
        [SerializeField] private Transform _camera;
        [SerializeField] private int _width;
        [SerializeField] private int _height;
        [SerializeField] private float _cameraOffset;
        [SerializeField] private float _cameraRange;
        [SerializeField] private int _positionDivider;

        private AllTilesInfo _allTilesInfo;

        private void Awake()
        {
            _allTilesInfo = GetComponent<AllTilesInfo>();
        }

        private void Start()
        {
            GenerateGrid();
        }

        private void GenerateGrid()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    TileView spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity);
                    _allTilesInfo.AddTile(spawnedTile);
                    spawnedTile.name = $"Tile {x}/{y}/";

                    bool isOffset =
                        (x % _positionDivider == 0 && y % _positionDivider != 0)
                        || (x % _positionDivider != 0 && y % _positionDivider == 0);

                    spawnedTile.Init(isOffset);
                }
            }

            _camera.position = new Vector3((float)_width/2 - _cameraOffset, (float)_height/2 - _cameraOffset, _cameraRange);
        }
    }
}