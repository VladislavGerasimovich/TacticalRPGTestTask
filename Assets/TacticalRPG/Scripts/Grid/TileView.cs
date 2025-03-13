using UnityEngine;

namespace Grid
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class TileView : MonoBehaviour
    {
        [SerializeField] private Color _baseColor;
        [SerializeField] private Color _offsetColor;
        [SerializeField] private SpriteRenderer _highlight;

        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Init(bool isOffset)
        {
            _spriteRenderer.color = isOffset ? _baseColor : _offsetColor;
        }

        private void OnMouseEnter()
        {
            _highlight.enabled = true;
        }

        private void OnMouseExit()
        {
            _highlight.enabled = false;
        }
    }
}