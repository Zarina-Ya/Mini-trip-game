using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace ZarinkinProject
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextLocaliserUI : MonoBehaviour
    {

        public TextMeshProUGUI textField;
        public string key;
   
        void Start()
        {
            textField = GetComponent<TextMeshProUGUI>();
            string value = LocalisationSystem.GetLocalisedValue(key);
            textField.text = value;
        }


    }

}