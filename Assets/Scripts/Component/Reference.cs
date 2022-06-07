using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZarinkinProject
{
    public sealed class Reference
    {

        private GameObject _bonusLabel;
        private GameObject _endGameLabel;
        private GameObject _restartButton;

        private GameObject _winGameLabel;

        private Canvas _canvas;
        private Camera _mainCamera;

        public GameObject BonusLabel { 
            get 
            {
                if( _bonusLabel == null)
                {
                    GameObject bonusPrefab = Resources.Load<GameObject>("UI/PanelBonus");
                    //GameObject bonusPrefab = Resources.Load<GameObject>("UI/TextBonus");
                    _bonusLabel = Object.Instantiate(bonusPrefab,Canvas.transform);
                }
                return _bonusLabel;
                    }
            set => _bonusLabel = value; }

        public GameObject EndGameLabel { get {
                if (_endGameLabel == null)
                {
                    GameObject endGamePrefab = Resources.Load<GameObject>("UI/EndPanel");
                    //GameObject endGamePrefab = Resources.Load<GameObject>("UI/TextEnd");
                    _endGameLabel = Object.Instantiate(endGamePrefab, Canvas.transform);
                }
                return _endGameLabel;
            } set => _endGameLabel = value; 
        }

        public GameObject RestartButton { get {
                if (_restartButton == null)
                {
                    GameObject restartButtonPrefab = Resources.Load<GameObject>("UI/RestartButton");
                    _restartButton = Object.Instantiate(restartButtonPrefab, Canvas.transform);
                }
                return _restartButton; }
            set => _restartButton = value; }

        public Canvas Canvas { get {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;

            } set => _canvas = value; 
        }

        public Camera MainCamera { get
            {
                if(_mainCamera == null)
                    _mainCamera = Camera.main;
                return _mainCamera;
            }

            set => _mainCamera = value; }

        public GameObject WinGameLabel { get
            {
                if (_winGameLabel == null)
                {
                    GameObject winGamePrefab = Resources.Load<GameObject>("UI/WinPanel");
                    //GameObject endGamePrefab = Resources.Load<GameObject>("UI/TextEnd");
                    _winGameLabel = Object.Instantiate(winGamePrefab, Canvas.transform);
                }
                return _winGameLabel;

            }
            set => _winGameLabel = value; }
    }
}
