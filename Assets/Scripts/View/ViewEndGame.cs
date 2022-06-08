using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
namespace ZarinkinProject { 

    public class ViewEndGame 
    {
        public TMP_Text _endGameLabel;
       // public Text _endGameLabel;

        public ViewEndGame(GameObject endGamePrefab)
        {
            _endGameLabel = endGamePrefab.GetComponentInChildren<TMP_Text>();

            _endGameLabel.text = string.Empty;
         

        }

        public void GameOver()
        {
        
            _endGameLabel.text = "Game Over";
        }
    }
}
