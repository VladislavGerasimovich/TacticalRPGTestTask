using ConstructionPanel.Items;
using System.Collections.Generic;
using UnityEngine;

namespace ConstructionPanel
{
    [RequireComponent(typeof(AllItemsView))]
    public class ItemsContainer : MonoBehaviour
    {
        [SerializeField] private List<Item> _items;
        [SerializeField] private ItemView _itemViewPrefab;

        private AllItemsView _allItemsView;

        private void Awake()
        {
            _allItemsView = GetComponent<AllItemsView>();
        }

        public void Init()
        {
            Fill();
        }

        public Item GetItemByType(string type)
        {
            foreach (Item item in _items)
            {
                if(item.Type == type)
                {
                    return item;
                }
            }

            return null;
        }

        private void Fill()
        {
            foreach (Item item in _items)
            {
                ItemView itemView = Instantiate(_itemViewPrefab, transform);
                itemView.Init(item.Icon);
                _allItemsView.Init(itemView);
                ItemType itemType = itemView.GetComponent<ItemType>();
                itemType.Init(item.Type);
            }
        }
    }
}