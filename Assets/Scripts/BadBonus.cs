using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZarinkinProject
{
    public class BadBonus : Bonus, IRotation, IFly
    {

        private float _heightFly;
        private float _rotationSpeed;

       

        private void Awake()
        {
            _heightFly = Random.Range(0f, 3f);
            _rotationSpeed = Random.Range(10f, 30f);

        }

        public void Fly()
        {
            _transform.position = new Vector3(_transform.position.x,Mathf.PingPong(Time.time, _heightFly), _transform.position.z);
        }

        public void IRotation()
        {
            _transform.Rotate(Vector3.up * (Time.deltaTime * _rotationSpeed), Space.World) ;
        }

        public override void Update()
        {
            Fly();
            IRotation();
        }

        protected override void Interaction()
        {
            
        }
    }
}

