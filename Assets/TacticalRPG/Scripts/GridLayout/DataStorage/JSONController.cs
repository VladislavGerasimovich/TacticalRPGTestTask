using System.IO;
using UnityEngine;

namespace GridLayout.DataStorage
{
    public class JSONController : MonoBehaviour
    {
        public GridData _gridData;

        public void Init()
        {
            LoadField();
        }

        public void SaveField()
        {
            File.WriteAllText(Application.streamingAssetsPath + "/JSON.json", JsonUtility.ToJson(_gridData));
        }

        private void LoadField()
        {
            _gridData = JsonUtility.FromJson<GridData>(File.ReadAllText(Application.streamingAssetsPath + "/JSON.json"));
        }
    }
}