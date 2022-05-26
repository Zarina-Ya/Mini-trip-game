using UnityEngine;
namespace ZarinkinProject
{
    public class Main : MonoBehaviour
    {
        private ListExecuteObject _interactiveObject;
        private InputController _inputController;

        [SerializeField] private GameObject _player;
        private void Awake()
        {
            _inputController = new InputController(_player.GetComponent<Unit>());
            _interactiveObject = new ListExecuteObject();

            _interactiveObject.AddExecuteObject(_inputController);
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
    }

}