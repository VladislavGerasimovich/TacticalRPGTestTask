using ConstructionPanel.Buttons;
using ConstructionPanel.Items;
using Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace PlayerInputHandler
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerInputController : MonoBehaviour
    {
        [SerializeField] private SelectedItem _selectedItem;
        [SerializeField] private ActionButton _placeButton;
        [SerializeField] private ActionButton _deleteButton;
        [SerializeField] private LayerMask _layerMask;

        private TileView _currentTileView;
        private Coroutine _placeItemRoutine;
        private Coroutine _deleteItemRoutine;
        private TileInfo _tempTileInfo;
        private TileView _tempTileView;

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

        public void OnMouseClick()
        {
            bool isUI = CheckUI();

            if(isUI == true)
            {
                if (_deleteItemRoutine != null)
                {
                    if (_tempTileInfo != null && _tempTileInfo.IsBusy == true)
                    {
                        if (_selectedItem.ItemType.Type == _tempTileInfo.Type)
                        {
                            _tempTileInfo.ResetValues();
                            _tempTileView.OffHighlight();
                            StopCoroutine(_deleteItemRoutine);
                            _deleteItemRoutine = null;
                            _tempTileInfo = null;
                            _tempTileView = null;
                        }
                    }
                }

                if(_placeItemRoutine != null)
                {
                    if(_tempTileInfo != null)
                    {
                        _tempTileInfo.Set(_selectedItem.ItemType.Type);
                        StopCoroutine(_placeItemRoutine);
                        _placeItemRoutine = null;
                        _currentTileView = null;
                        _tempTileInfo = null;
                    }
                }
            }
        }

        private void OnPlaceButtonClick()
        {
            if(_deleteItemRoutine != null)
            {
                StopCoroutine(_deleteItemRoutine);
                _deleteItemRoutine = null;
            }

            if(_placeItemRoutine == null && _selectedItem.ItemView != null)
            {
                _placeItemRoutine = StartCoroutine(PlaceItemRoutine());
            }
        }

        private void OnDeleteButtonClick()
        {
            if(_placeItemRoutine != null)
            {
                StopCoroutine(_placeItemRoutine);
                _placeItemRoutine = null;

                if(_currentTileView != null)
                {
                    _currentTileView.OffHighlight();
                }
            }

            if(_deleteItemRoutine == null)
            {
                _deleteItemRoutine = StartCoroutine(DeleteItemRoutine());
            }
        }

        private TileView Raycast()
        {
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero, Mathf.Infinity);

            if (hit != false && hit.collider.TryGetComponent(out TileView tileView) == true)
            {
                return tileView;
            }

            return null;
        }

        private GameObject PointerRaycast(Vector2 position)
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            List<RaycastResult> resultsData = new List<RaycastResult>();
            pointerData.position = position;
            EventSystem.current.RaycastAll(pointerData, resultsData);

            if (resultsData.Count > 0)
            {
                return resultsData[0].gameObject;
            }

            return null;
        }

        private IEnumerator PlaceItemRoutine()
        {
            while (enabled)
            {
                TileView tileView = GetTile(out TileInfo tileInfo);

                if (tileInfo != null && tileInfo.IsBusy == false)
                {
                    SetTileView(tileView);
                    _tempTileInfo = tileInfo;
                }

                yield return null;
            }
        }

        private IEnumerator DeleteItemRoutine()
        {
            while (enabled)
            {
                TileView tileView = GetTile(out TileInfo tileInfo);
                _tempTileView = tileView;
                _tempTileInfo = tileInfo;

                yield return null;
            }
        }

        private bool CheckUI()
        {
            GameObject raycastResult = PointerRaycast(Mouse.current.position.ReadValue());
            bool isUI = raycastResult == null ? true : false;

            return isUI;
        }

        private TileView GetTile(out TileInfo tileInfo)
        {
            bool isUI = CheckUI();

            if (isUI == true)
            {
                TileView tileView = Raycast();

                if (tileView != null)
                {
                    tileInfo = GetTileInfo(tileView);
                    return tileView;
                }
            }

            tileInfo = null;
            return null;
        }

        private TileInfo GetTileInfo(TileView tileView)
        {
            TileInfo tileInfo = tileView.GetComponent<TileInfo>();
            
            return tileInfo;
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