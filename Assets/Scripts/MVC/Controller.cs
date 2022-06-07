using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVC
{
    public class Controller
    {
        private Transform _playerTransform;
        private View _triggerView;
        private View _playerView;
        public Controller(View player, View trigger)
        {
            _playerTransform = player.ViewTransform;
            _playerView = player;
            _triggerView = trigger;

            _triggerView.OnLevelObjectContact += ControllerRecieveAction;
        }

        private void ControllerRecieveAction(Collider contactView, int val, Transform transform)
        {
            Debug.Log("Обработчик событий");
            GameObject.Destroy(contactView.gameObject);
        }
       
    }
}





