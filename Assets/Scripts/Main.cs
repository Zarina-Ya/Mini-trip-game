using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace ZarinkinProject
{
    public class Main : MonoBehaviour
    {
        private ListExecuteObject _interactiveObject;
        private InputController _inputController;

        [SerializeField] private GameObject _player;


        private Reference _reference;


        private ViewBonus _viewBonus;
        private ViewEndGame _viewEndGame;
        private ViewWin _viewWin;

        private int _bonusCount;


        private CameraController _cameraController;

        private float _processingStateBadBonus = 5f;

        [Header("Количество бонусов для победы")]
        [SerializeField] private int _numberBonusesWin = 3;

        [SerializeField] private Button _restartButton;
        private void Awake()
        {
             StopTime(false);
            _reference = new Reference();
            _inputController = new InputController(_player.GetComponent<Unit>());
            _interactiveObject = new ListExecuteObject();

            _cameraController = new CameraController(_player.transform, _reference.MainCamera.transform);
            //Canvas
            _viewBonus = new ViewBonus(_reference.BonusLabel);
            _viewEndGame = new ViewEndGame(_reference.EndGameLabel);
            _viewWin = new ViewWin(_reference.WinGameLabel);

            _restartButton.onClick.AddListener(RestartGame);
            _restartButton.gameObject.SetActive(false);



            _interactiveObject.AddExecuteObject(_inputController);
            _interactiveObject.AddExecuteObject(_cameraController);



            foreach(var item in _interactiveObject)
            {
                if(item is GoodBonus goodBonus)
                {
                    goodBonus.AddPoints += AddBonus;
                }
                if(item is BadBonus badBonus)
                {
                    badBonus.TimeStateProccesing = _processingStateBadBonus;

                    badBonus.OnCaughtPlayer += CaughtPlayer;

                }
            }
            
        }


        private void RestartGame()
        {
            SceneManager.LoadScene(0);
            
        }

        private void AddBonus(int bonus)
        {
            _bonusCount += bonus;

            if(_bonusCount >= _numberBonusesWin)
            {
                WinCheck();
            }
            else
                _viewBonus.Display(_bonusCount);
        }

        private void CaughtPlayer(float time)
        {
            _player.GetComponent<Player>().ControlSpeed(time);

             Invoke("TestButtonCheck", 7f);
            
        }


        private void WinCheck()
        {
            _viewWin.Display();
            AddButtonRestart();
        }

        void AddButtonRestart()
        {
            _restartButton.gameObject.SetActive(true);
            StopTime(true);
        }
        void TestButtonCheck()
        {
            _viewEndGame.GameOver();
            AddButtonRestart();
        }

        void Update()
        {
            for(int i = 0; i < _interactiveObject.Lenght; i++)
            {
                if(_interactiveObject[i] == null)
                {
                    continue;
                }

                _interactiveObject[i].Update();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                SaveBonusData();
            }

        }

        void SaveBonusData()
        {
            JSONData jSONData = new JSONData();
            jSONData.ClearFile();
            //List<Bonus> arrBonus = new List<Bonus>();
            foreach (var item in _interactiveObject)
            {
                if (item is GoodBonus goodBonus || item is BadBonus badBonus)
                {
                    Bonus bonus = item as Bonus;
                   // arrBonus.Add(bonus);
                    bonus.SaveBonus();
                }
           
            }

    

        }

        void StopTime(bool flag)
        {
            if(flag) Time.timeScale = 0f;
            else Time.timeScale = 1f;
        }

       
    }

    

}