using ConstructionPanel.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace ConstructionPanel.Items
{
    public class ItemView : MonoBehaviour, IItemView
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Image _highlight;

        public Sprite Icon { get; private set; }

        public void Init(Sprite icon)
        {
            _icon.sprite = icon;
            Icon = _icon.sprite;
        }

        public void OnHighlight()
        {
            _highlight.enabled = true;
        }

        public void OffHighlight()
        {
            _highlight.enabled = false;
        }
    }
}