using UnityEngine;

namespace Grid
{
    public class TileInfo : MonoBehaviour
    {
        public bool IsBusy { get; private set; }
        public string Type { get; private set; }

        public void Set(string type)
        {
            IsBusy = true;
            Type = type;
        }

        public void ResetValues()
        {
            IsBusy = false;
            Type = string.Empty;
        }
    }
}