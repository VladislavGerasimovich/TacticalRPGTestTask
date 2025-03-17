using UnityEngine;

namespace GridLayout
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class TileView : MonoBehaviour
    {
        [SerializeField] private Color _baseColor;
        [SerializeField] private Color _offsetColor;
        [SerializeField] private SpriteRenderer _highlight;
        [SerializeField] private SpriteRenderer _itemIcon;

        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Init(bool isOffset)
        {
            _spriteRenderer.color = isOffset ? _baseColor : _offsetColor;
        }

        public void OnHighlight(Sprite icon)
        {
            _highlight.enabled = true;
            _itemIcon.sprite = icon;
        }

        public void OffHighlight()
        {
            _highlight.enabled = false;
            _itemIcon.sprite = null;
        }
    }
}