using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace ZarinkinProject
{

    public class ViewBonus
    {
        public TMP_Text _bonusLabel;
        //public Text _bonusLabel;
        public ViewBonus(GameObject bonusLabelPrefab)
        {
            _bonusLabel = bonusLabelPrefab.GetComponentInChildren<TMP_Text>();
            //_bonusLabel = bonusLabelPrefab.GetComponent<Text>();
            _bonusLabel.text = string.Empty;

        }

        public void Display(int bonusVal)
        {
            _bonusLabel.text = $"Count Points: {bonusVal}";
        }
    }

}