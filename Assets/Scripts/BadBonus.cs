using System;
using System.Collections.Generic;
using UnityEngine;


using Random = UnityEngine.Random;
namespace ZarinkinProject
{
    public class BadBonus : Bonus, IRotation, IFly
    {

        private float _heightFly;
        private float _rotationSpeed;
        [SerializeField] private float initial_position;

        public event Action<string, Color> OnCaughtPlayer = delegate(string name, Color color) { };

        private void Awake()
        {
            _transform = transform;
            _heightFly = Random.Range(0, 2f);
            _rotationSpeed = Random.Range(10f, 30f);
            initial_position = _transform.position.y;
        }

        public void Fly()
        {
            _transform.position = new Vector3(_transform.position.x, initial_position + Mathf.PingPong(Time.time, _heightFly), _transform.position.z);
            Debug.Log(initial_position + Mathf.PingPong(Time.time, _heightFly));
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

        protected override void Interaction()// Реадизация события ответа , на взаимодействие 
        {
            OnCaughtPlayer.Invoke(this.name, _color);
        }
    }
}

