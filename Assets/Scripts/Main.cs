using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

        private int _bonusCount;


        private CameraController _cameraController;

        private float _processingStateBadBonus = 5f;

        [SerializeField] private Button _restartButton;
        private void Awake()
        {
             StopTime(false);
            _reference = new Reference();
            _inputController = new InputController(_player.GetComponent<Unit>());
            _interactiveObject = new ListExecuteObject();


            //Canvas
            _viewBonus = new ViewBonus(_reference.BonusLabel);
            _viewEndGame = new ViewEndGame(_reference.EndGameLabel);
            _restartButton.onClick.AddListener(RestartGame);
            _restartButton.gameObject.SetActive(false);



            _interactiveObject.AddExecuteObject(_inputController);




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
            //_cameraController = new CameraController(_player.transform, _reference.MainCamera.transform);!!!!!!!!!!!!!!!!!!!
        }


        private void RestartGame()
        {
            SceneManager.LoadScene(0);
            
        }

        private void AddBonus(int bonus)
        {
            _bonusCount += bonus;
            _viewBonus.Display(_bonusCount);
        }

        private void CaughtPlayer(float time)
        {
            _player.GetComponent<Player>().ControlSpeed(time);

            // Invoke("TestButtonCheck", 7f);
            TestButtonCheck();
        }

        void TestButtonCheck()
        {
            _viewEndGame.GameOver();
            _restartButton.gameObject.SetActive(true);
            StopTime(true);
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
        }


        void StopTime(bool flag)
        {
            if(flag) Time.timeScale = 0f;
            else Time.timeScale = 1f;
        }
    }

}