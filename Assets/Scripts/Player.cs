using System;
using UnityEngine;
namespace ZarinkinProject
{
    public struct PlayerData
    {
        public string PlayerName;
        public int PlayerHealth;
        public bool PlayerDead;
        public SVector3 PlayerPosition;
    }

    public sealed class Player : Unit
    {
        PlayerData SinglePlayerData = new PlayerData();
        private ISaveData<PlayerData> _saveData;

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
            _heath = 100;
            anim = gameObject.GetComponent<Animator>();

          
            SinglePlayerData.PlayerHealth = _heath;
            SinglePlayerData.PlayerDead = _isDead;
            SinglePlayerData.PlayerName = gameObject.name;

            //_saveData = new JSONData();
            //_saveData = new StreamData<PlayerData>();
            _saveData = new XMLData();
           // _saveData.SaveData(SinglePlayerData);



           // GoodBonus.AddPoints += UpdatePoints;
            //BadBonus.OnCaughtPlayer += ControlSpeed;
        }

        public override void Move(float x, float y, float z)
        {

            _isGrounded = Physics.Raycast(transform.position, Vector3.down, _playerHeight / 4 /*+ 0.5f*/);
            Debug.DrawRay(transform.position, Vector3.down * (_playerHeight / 4 /*+ 0.5f*/), Color.red);

            Input(x,z);
            ControlDrag();

            SinglePlayerData.PlayerPosition = _transform.position;
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


        public override void SavePlayer()
        {
            _saveData.SaveData(SinglePlayerData);
            PlayerData newPlayerData = _saveData.Load();

            Debug.Log(newPlayerData.PlayerName);
            Debug.Log(newPlayerData.PlayerPosition);
            Debug.Log(newPlayerData.PlayerDead);
            Debug.Log(newPlayerData.PlayerHealth);
        }
    }




}