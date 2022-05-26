using UnityEngine;

namespace ZarinkinProject
{
 
    public class InputController: IExecute
    {
        private readonly Unit _player;

        private float _horizontal;
        private float _vertical;
  

        public InputController(Unit player)
        {
            _player = player;
        }

        public void Update()// можно рдругую реализацию
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
            _player.Move(_horizontal, 0, _vertical);
        }
    }

}