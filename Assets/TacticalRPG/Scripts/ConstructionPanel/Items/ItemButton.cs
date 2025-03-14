using ConstructionPanel.Interfaces;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ConstructionPanel.Items
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(IItemView))]
    [RequireComponent(typeof(IItemType))]
    public class ItemButton : MonoBehaviour
    {
        private Button _button;
        private IItemView _itemView;
        private IItemType _itemType;

        public event Action<IItemView, IItemType> Click;
        public event Action<ItemButton> ButtonDisabled;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _itemView = GetComponent<ItemView>();
            _itemType = GetComponent<ItemType>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
            ButtonDisabled?.Invoke(this);
        }

        private void OnButtonClick()
        {
            Click?.Invoke(_itemView, _itemType);
        }
    }
}