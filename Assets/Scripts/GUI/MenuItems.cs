using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace ZarinkinProject
{
    public class MenuItems 
    {
        [MenuItem("ZarinkinProject/Generate Bonuses")]
        static void GenerateBonuses()
        {
            EditorWindow.GetWindow(typeof(GenerateBonuses), false, "Генерация бонусов");
        }
        [MenuItem("ZarinkinProject/Generate Localisation")]
        static void GenerateLocalisation()
        {
            EditorWindow.GetWindow(typeof(GenerateLocalisation), false, "Localisation window");
        }

    }
}