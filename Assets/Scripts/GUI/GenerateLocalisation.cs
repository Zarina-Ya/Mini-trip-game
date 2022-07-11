using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace ZarinkinProject {
    public class GenerateLocalisation : EditorWindow
    {
        public string _key;
        public string _EN;
        public string _FR;
        public string _RU;

        private void OnGUI()
        {

            EditorGUILayout.BeginVertical();
            _key = EditorGUILayout.TextField("key", _key);
            _EN = EditorGUILayout.TextField("En", _EN);
            _FR = EditorGUILayout.TextField("Fr", _FR);
            _RU = EditorGUILayout.TextField("Ru", _RU);
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();

            var button = GUILayout.Button("Создать");
            if (button)
            {
                if (_EN.Length == 0 || _FR.Length == 0 || _key.Length == 0 || _RU.Length == 0)
                {

                    Debug.Log("Не все даные заполнены");
                    EditorGUILayout.HelpBox("Не все даные заполнены", MessageType.Warning, false);
                

                }
                else
                {

                    LocalisationData data = new LocalisationData();
                    data._id = _key;
                    data.EN = _EN;
                    data.FR = _FR;
                    data.RU = _RU;
                    LocalisationSystem.Add(_key, _EN, _FR, _RU);
                    var json = JsonUtility.ToJson(data);
                    Debug.Log(json);
                }
            }
            EditorGUILayout.EndVertical();
        }
    }
}
