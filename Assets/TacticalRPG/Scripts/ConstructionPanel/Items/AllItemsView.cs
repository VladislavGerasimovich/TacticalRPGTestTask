using ConstructionPanel.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace ConstructionPanel.Items
{
    [RequireComponent(typeof(SelectedItem))]
    public class AllItemsView : MonoBehaviour
    {
        private List<ItemView> _itemsView;
        private SelectedItem _selectedItem;

        private void Awake()
        {
            _itemsView = new List<ItemView>();
            _selectedItem = GetComponent<SelectedItem>();
        }

        public void Init(ItemView itemView)
        {
            _itemsView.Add(itemView);
            ItemButton itemButton = itemView.GetComponent<ItemButton>();
            itemButton.Click += OnItemButtonClick;
            itemButton.ButtonDisabled += OnButtonDisabled;
        }

        private void OnItemButtonClick(IItemView itemView, IItemType itemType)
        {
            foreach (ItemView item in _itemsView)
            {
                item.OffHighlight();
            }

            itemView.OnHighlight();
            _selectedItem.Set(itemView, itemType);
        }

        private void OnButtonDisabled(ItemButton itemButton)
        {
            itemButton.Click -= OnItemButtonClick;
            itemButton.ButtonDisabled -= OnButtonDisabled;
        }
    }
}