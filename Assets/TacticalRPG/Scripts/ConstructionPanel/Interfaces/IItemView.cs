using UnityEngine;

namespace ConstructionPanel.Interfaces
{
    public interface IItemView
    {
        public Sprite Icon { get; }

        public void OnHighlight();
        public void OffHighlight();
    }
}