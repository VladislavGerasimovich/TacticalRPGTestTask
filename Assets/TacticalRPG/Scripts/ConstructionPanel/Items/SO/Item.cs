using UnityEngine;

namespace ConstructionPanel.Items
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Item", order = 51)]
    public class Item : ScriptableObject
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _type;

        public Sprite Icon => _icon;
        public string Type => _type;
    }
}