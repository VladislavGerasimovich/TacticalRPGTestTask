using ConstructionPanel.Interfaces;
using UnityEngine;

namespace ConstructionPanel.Items
{
    public class ItemType : MonoBehaviour, IItemType
    {
        public string Type { get; private set; }

        public void Init(string type)
        {
            Type = type;
        }
    }
}