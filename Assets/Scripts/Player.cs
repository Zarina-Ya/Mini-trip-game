using System;
using UnityEngine;
namespace ZarinkinProject
{
    public sealed class Player : Unit
    {
        private Animator anim;
        private float _jumpForce = 2f;
        private float _turnSpeed = 0.9f;

        private int _countPoints = 0;

        [Header("Рост персонажа")]
        [SerializeField] private float _playerHeight = 0.5f;

        [Header("Сопротивление")]
        [SerializeField] private float _groundDrag = 6f;
        [SerializeField] private float _airDrag = 2f;

        [Header("Находиться ли персонаж на земле")]
        [SerializeField] private bool _isGrounded;

        [Header("Multi")]
        [SerializeField] private float _moveMulti = 10f;
        [SerializeField] private float _moveAirMulti = 0.4f;

        public static event Action<int> PlayerPoints = delegate (int point) { };

        private Vector3 _moveDirection;

        public int CountPoints { get => _countPoints; set => _countPoints = value; }

        private void Awake()
        {
            _transform = transform;
            _rb = GetComponent<Rigidbody>();
            _isDead = false;

            anim = gameObject.GetComponent<Animator>();


           // GoodBonus.AddPoints += UpdatePoints;
            //BadBonus.OnCaughtPlayer += ControlSpeed;
        }

        public override void Move(float x, float y, float z)
        {

            _isGrounded = Physics.Raycast(transform.position, Vector3.down, _playerHeight / 4 /*+ 0.5f*/);
            Debug.DrawRay(transform.position, Vector3.down * (_playerHeight / 4 /*+ 0.5f*/), Color.red);

            Input(x,z);
            ControlDrag();
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }


        void Input(float x, float z)
        {
            transform.Rotate(_transform.up * x * _turnSpeed);
            _moveDirection = _transform.forward * z;
            anim.SetBool("AnimationPar", _moveDirection != Vector3.zero);
        }

        void MovePlayer()
        {
           if (_isGrounded)
                _rb.AddForce(_moveDirection.normalized * _speed * _moveMulti, ForceMode.Acceleration);
            else if (!_isGrounded)
                _rb.AddForce(_moveDirection.normalized * _speed * _moveAirMulti * _moveMulti, ForceMode.Acceleration);
        }

        void ControlDrag()
        {
            if (_isGrounded)
                _rb.drag = _groundDrag;
           else { _rb.drag = _airDrag; }
        }

        public override void Jump()
        {
            if (_isGrounded)
                _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
        }

        //public void UpdatePoints(int points)
        //{
        //   CountPoints += points;
        //    PlayerPoints.Invoke(CountPoints);
        //}


        public void ControlSpeed(float time)
        {
            _moveMulti /= 2;
            _moveAirMulti /= 2;

            Invoke("ReturnState", time);
        }

        void ReturnState()
        {
            _moveMulti *= 2;
            _moveAirMulti *= 2; 
        }
    }




}