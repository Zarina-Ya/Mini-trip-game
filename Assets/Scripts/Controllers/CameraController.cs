using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{


    public class CameraController : IExecute
    {
        [SerializeField] private Transform _player;
        [SerializeField] private Transform _cameraTransform;

        private Vector3 _offset;
        public CameraController(Transform player, Transform mainCamera)
        {
            _player = player;
            _cameraTransform = mainCamera;

            _cameraTransform.LookAt(_player);
            _offset = _cameraTransform.position - _player.position;
        }
        public void Update()
        {
            _cameraTransform.position = _player.position + _offset;
        }
    }
}
