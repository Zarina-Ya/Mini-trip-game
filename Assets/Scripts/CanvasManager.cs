
using System;
using TMPro;
using UnityEngine;

namespace ZarinkinProject
{

    public class CanvasManager : MonoBehaviour
    {
        public TMP_Text _text;
        Player _player;
        private void Awake()
        {
            Player.PlayerPoints += UpdateTextLebel;
           // GoodBonus.AddPoints += UpdateTextLebel;
            _text = GetComponentInChildren<TMP_Text>();
        }

        public void UpdateTextLebel(int countPoint)
        {
            _text.text = $"Count Points: {countPoint}";
        }
    }
}
