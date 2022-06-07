using System;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public class GoodBonus : Bonus, IFly, IFlicker
    {
        private float _heightFly = 2f;
        [Header("Начальная позация в мире")]
        [SerializeField] private float initial_position;


        [SerializeField] private Material _material;


        public int Point = 1;

        public /*static*/ event Action<int> AddPoints = delegate (int point) { };

        private void Awake()
        {
            _transform = transform;
            initial_position = _transform.position.y;
            _material = GetComponent<Renderer>().material;
        }
        public void Flick()
        {
            _material.color = new Color(_material.color.r, _material .color.g, _material.color.b, Mathf.PingPong(Time.time, 1.0f));  
        }

        public void Fly()
        {
            _transform.position = new Vector3(_transform.position.x, initial_position + Mathf.PingPong(Time.time, _heightFly), _transform.position.z);
            //Debug.Log(initial_position + Mathf.PingPong(Time.time, _heightFly));
        }
    

        public override void Update()
        {
            Fly();
            Flick();
        }

        protected override void Interaction()
        {
            AddPoints.Invoke(Point);
        }
    }
}
