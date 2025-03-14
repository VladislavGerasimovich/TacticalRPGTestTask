using ConstructionPanel.Items;
using Grid;
using UnityEngine;

namespace PlayerInputHandler
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private SelectedItem _selectedItem;

        private void Update()
        {
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero, Mathf.Infinity);

            if (hit != false && hit.collider.TryGetComponent(out TileView tileView) == true)
            {
                if(_selectedItem.ItemView != null)
                {
                    tileView.OnHighlight(_selectedItem.ItemView.Icon);
                }
            }
        }
    }
}