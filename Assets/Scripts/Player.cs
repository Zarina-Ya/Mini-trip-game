using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public sealed class Player : Unit
    {
        private Animator anim;// добавочное 
        private float _turnSpeed = 0.9f;// добавчное



        private void Awake()
        {
            _transform = transform;
            _rb = GetComponent<Rigidbody>();
            _isDead = false;



            anim = gameObject.GetComponent<Animator>();
        }

        public override void Move(float x, float y, float z)
        {
            if (_rb)
            {
                var _moveDirection = _transform.forward * z;
                transform.Rotate(_transform.up * x * _turnSpeed);
                _rb.AddForce(_moveDirection.normalized * _speed, ForceMode.Acceleration);
                anim.SetBool("AnimationPar", _moveDirection != Vector3.zero);
            }
            else Debug.Log("Нет rigidBodty");
        
        }
    }

}