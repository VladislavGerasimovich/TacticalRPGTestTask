using ConstructionPanel.Buttons;
using ConstructionPanel.Interfaces;
using ConstructionPanel.Items;
using Grid;
using System.Collections;
using UnityEngine;

namespace PlayerInputHandler
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private SelectedItem _selectedItem;
        [SerializeField] private ActionButton _placeButton;
        [SerializeField] private ActionButton _deleteButton;

        private TileView _currentTileView;
        private Coroutine _placeItemRoutine;
        private Coroutine _deleteItemRoutine;

        private void OnEnable()
        {
            _placeButton.Click += OnPlaceButtonClick;
            _deleteButton.Click += OnDeleteButtonClick;
        }

        private void OnDisable()
        {
            _placeButton.Click -= OnPlaceButtonClick;
            _deleteButton.Click -= OnDeleteButtonClick;
        }

        private void OnPlaceButtonClick()
        {
            _placeItemRoutine = StartCoroutine(PlaceItemRoutine());
        }

        private void OnDeleteButtonClick()
        {

        }

        private TileView Raycast()
        {
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero, Mathf.Infinity);

            if (hit != false && hit.collider.TryGetComponent(out TileView tileView) == true)
            {
                return tileView;
            }

            return null;
        }

        private IEnumerator PlaceItemRoutine()
        {
            Debug.Log(" place item routine");
            while (enabled)
            {
                TileView tileView = Raycast();

                if (_selectedItem.ItemView != null && tileView != null)
                {
                    bool isTileBusy = CheckTileInfo(tileView);

                    if (isTileBusy == false)
                    {
                        SetTileView(tileView);

                        if (Input.GetKeyDown(KeyCode.Mouse0))
                        {
                            SetTileStatus(_selectedItem.ItemType, tileView);
                            StopCoroutine(_placeItemRoutine);
                            _placeItemRoutine = null;
                            _currentTileView = null;
                        }
                    }
                }

                yield return null;
            }
        }

        private bool CheckTileInfo(TileView tileView)
        {
            TileInfo tileInfo = tileView.GetComponent<TileInfo>();

            return tileInfo.IsBusy;
        }

        private void SetTileStatus(IItemType itemType, TileView tileView)
        {
            TileInfo tileInfo = tileView.GetComponent<TileInfo>();
            tileInfo.Set(itemType.Type);
        }

        private void SetTileView(TileView tileView)
        {
            if(_currentTileView != null && tileView != _currentTileView)
            {
                _currentTileView.OffHighlight();
            }

            _currentTileView = tileView;
            tileView.OnHighlight(_selectedItem.ItemView.Icon);
        }
    }
}