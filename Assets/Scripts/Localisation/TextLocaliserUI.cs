﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace ZarinkinProject
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextLocaliserUI : MonoBehaviour
    {

        public TextMeshProUGUI textField;
        public LocalisedString localisedString;
   
        void Start()
        {
            textField = GetComponent<TextMeshProUGUI>();
            
            textField.text = localisedString.value;
        }


    }

}