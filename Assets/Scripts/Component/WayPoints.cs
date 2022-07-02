using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace ZarinkinProject
{


#if UNITY_EDITOR
    public class WayPoints : MonoBehaviour
    {
        public List<Transform> _nodes = new List<Transform>();
        public string _directoryName;
        private string _savingPath;
        public string _sceneName;

        public string SavingPath { get => _savingPath; set => _savingPath = value; }
        //private void Awake()
        //{
        //    _sceneName = UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene().name;
        //    _directoryName = "WayPontData";
        //    SavingPath = Path.Combine(Application.dataPath + "/", _directoryName, "BonusMap" + _sceneName + ".xml");

        //}
        private void OnDrawGizmosSelected()
        {
            _sceneName = UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene().name;
            _directoryName = "WayPontData";
            SavingPath = Path.Combine(Application.dataPath + "/", _directoryName, "BonusMap" + _sceneName + ".xml");

        }

    }
}
#endif