using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace ZarinkinProject
{
    public class TextLocaliserEditWindow : EditorWindow
    {
        public string key;
        public string valueEN;
        public string valueFR;
        public string valueRU;
        public static void Open(string key)
        {
            TextLocaliserEditWindow window = new TextLocaliserEditWindow();
            window.titleContent = new GUIContent("Localizer window");
            window.ShowUtility();
            window.key = key;
        }

        public void OnGUI()
        {
            key = EditorGUILayout.TextField("KEY: ", key);
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Value: ", GUILayout.MaxWidth(50));
            EditorStyles.textArea.wordWrap = true;
            valueEN = EditorGUILayout.TextArea(valueEN, EditorStyles.textArea, GUILayout.Height(50), GUILayout.Width(50));
            valueFR = EditorGUILayout.TextArea(valueFR, EditorStyles.textArea, GUILayout.Height(50), GUILayout.Width(50));
            valueRU = EditorGUILayout.TextArea(valueRU, EditorStyles.textArea, GUILayout.Height(50), GUILayout.Width(50));


            EditorGUILayout.EndHorizontal();


            if (GUILayout.Button("Add"))
            {
                if(LocalisationSystem.GetLocalisedValue(key) != string.Empty)
                {
                    LocalisationSystem.Replace(key, valueEN, valueFR, valueRU);
                }
                else
                {
                    LocalisationSystem.Add(key, valueEN, valueFR, valueRU);
                }
            }

            minSize = new Vector2(450, 250);
            maxSize = minSize;
        }
    }


    public class TextLocaliserSearchEditWindow : EditorWindow
    {
        public string value;
        public Vector2 scroll;
        public Dictionary<string, string> dictionary;
        public static void Open()
        {
            TextLocaliserSearchEditWindow window = new TextLocaliserSearchEditWindow();
            window.titleContent = new GUIContent("Localizer window");

            Vector2 mouse = GUIUtility.GUIToScreenPoint(Event.current.mousePosition);
            Rect r = new Rect(mouse.x - 450, mouse.y + 10, 10, 10);
            window.ShowAsDropDown(r, new Vector2(500, 300));
        }

        private void OnEnable()
        {
            dictionary = LocalisationSystem.GetDictionaryForEditor();
        }

        public void OnGUI()
        {
            EditorGUILayout.BeginHorizontal("Box");
            EditorGUILayout.LabelField("Search: ", EditorStyles.boldLabel);
            value = EditorGUILayout.TextField(value);
            EditorGUILayout.EndHorizontal();

            GetSearchResult();
        }

        private void GetSearchResult()
        {
            if (value == null) return;
            EditorGUILayout.BeginVertical();
            scroll = EditorGUILayout.BeginScrollView(scroll);
            foreach(KeyValuePair<string, string> element in dictionary)
            {
                if(element.Key.ToLower().Contains(value.ToLower()) || element.Value.ToLower().Contains(value.ToLower()))
                {
                    EditorGUILayout.BeginHorizontal("box");
                    Texture closwIcon = (Texture)Resources.Load("close");

                    GUIContent content = new GUIContent(closwIcon);

                    if(GUILayout.Button(content, GUILayout.MaxWidth(28), GUILayout.MaxHeight(20))){

                        if(EditorUtility.DisplayDialog("Remove key " + element.Key + "?", "This will remove the element from localisation, are you sure?", "Do it"))
                        {
                            LocalisationSystem.Remove(element.Key);
                            LocalisationSystem.Init();
                            dictionary = LocalisationSystem.GetDictionaryForEditor();
                        }
                    }

                    EditorGUILayout.TextField(element.Key);
                    EditorGUILayout.LabelField(element.Value);
                    EditorGUILayout.EndHorizontal();
                }
            }

            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();
        }
    }


    
}


