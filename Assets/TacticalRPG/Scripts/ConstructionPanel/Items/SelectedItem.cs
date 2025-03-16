using ConstructionPanel.Interfaces;
using UnityEngine;

namespace ConstructionPanel.Items
{
    public class SelectedItem : MonoBehaviour
    {
        public IItemView ItemView { get; private set; }
        public IItemType ItemType { get; private set; }

        public void Set(IItemView itemView, IItemType itemType)
        {
            ItemView = itemView;
            ItemType = itemType;
        }

        public void ResetValues()
        {
            ItemView = null;
            ItemType = null;
        }
    }
}