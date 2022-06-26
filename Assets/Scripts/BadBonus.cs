using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

using Random = UnityEngine.Random;
namespace ZarinkinProject
{
    public class BadBonus : Bonus, IRotation, IFly
    {
        BonusData SingleBonusData = new BonusData();
        private ISaveData<BonusData> _saveData;



        private float _heightFly;
        private float _rotationSpeed;
        [SerializeField] private float initial_position;

        public /*static*/ event Action<float> OnCaughtPlayer = delegate(float time) { };


        [Header("PostProcess")]
        private PostProcessVolume processVolume;
        private ChromaticAberration chromatic = null;
        [SerializeField] private float _timeStateProccesing = 5f;

        public float TimeStateProccesing { get => _timeStateProccesing; set => _timeStateProccesing = value; }

        private void Awake()
        {
            _transform = transform;
            _heightFly = Random.Range(0, 2f);
            _rotationSpeed = Random.Range(10f, 30f);
            initial_position = _transform.position.y;



            processVolume = GetComponent<PostProcessVolume>();


            SingleBonusData.BonusName = gameObject.name;
            SingleBonusData.BonusType = gameObject.GetType().Name;
            SingleBonusData.BonusPosition = transform.position;
            _saveData = new JSONData();
            //_saveData = new StreamData<BonusData>();
            //_saveData.SaveData(SingleBonusData);

        }



        public void Fly()
        {
            _transform.position = new Vector3(_transform.position.x, initial_position + Mathf.PingPong(Time.time, _heightFly), _transform.position.z);
           // Debug.Log(initial_position + Mathf.PingPong(Time.time, _heightFly));
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
           
            processVolume.profile.TryGetSettings(out chromatic);

            chromatic.enabled.value = true;
            chromatic.intensity.value = 1f;
            OnCaughtPlayer.Invoke(TimeStateProccesing);
            Invoke("ReturnState", TimeStateProccesing);
        }

        private void ReturnState()
        {
            chromatic.enabled.value = false;
        }


        public override void SaveBonus()
        {
            _saveData.SaveData(SingleBonusData);
            //BonusData newBonusData = _saveData.Load();

        }

    }
}

