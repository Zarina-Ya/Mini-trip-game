using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ZarinkinProject
{


    public class ViewWin 
    {
        public TMP_Text _winLabel;
        //public Text _bonusLabel;
        public ViewWin(GameObject winLabelPrefab)
        {
            _winLabel = winLabelPrefab.GetComponentInChildren<TMP_Text>();
            //_bonusLabel = bonusLabelPrefab.GetComponent<Text>();
            _winLabel.text = string.Empty;

        }

        public void Display()
        {
            _winLabel.text = "You have won";
        }
    }
}
