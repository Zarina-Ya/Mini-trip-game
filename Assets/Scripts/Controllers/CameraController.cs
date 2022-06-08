using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{


    public class CameraController : IExecute
    {
        [SerializeField] private Transform _player;
        [SerializeField] private Transform _cameraTransform;
        private const float Y_ANGLE_MIN = 0.0f;
        private const float Y_ANGLE_MAX = 50.0f;

      
        public float distance = 5.0f;

        private float currentX = 0.0f;
        private float currentY = 15.0f;
 

        private Vector3 _offset;
        public CameraController(Transform player, Transform mainCamera)
        {

            
            _player = player;
            _cameraTransform = mainCamera;

            //_cameraTransform.LookAt(_player);
            //_offset = _cameraTransform.position - _player.position;
        }
        public void Update()
        {
            //_cameraTransform.position = _player.position + _offset;
            currentX += Input.GetAxis("Mouse X");
            currentY += Input.GetAxis("Mouse Y");

            currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
            LateUpdate();
        }

     

       
      

        private void LateUpdate()
        {
            Vector3 dir = new Vector3(0, 0, -distance);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            //var tmp = new Vector3(_player.position.x, _player.position.y + 2f, _player.position.z);
            _cameraTransform.position = _player.position + rotation * dir;
            _cameraTransform.LookAt(_player.position);
        }
    }
}
