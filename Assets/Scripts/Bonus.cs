using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZarinkinProject
{
    public struct BonusData
    {
        public string BonusName;
        public string BonusType;
        public SVector3 BonusPosition;

    }

    public abstract class Bonus : MonoBehaviour, IExecute
    {
        

        private bool _isInteractable;
        public Transform _transform;
        protected Color _color;

        public bool IsInteractable { get => _isInteractable; private set
            {
                _isInteractable = value;
                GetComponent<Renderer>().enabled = value;
                GetComponent<Collider>().enabled = value;
            }
        }

       

        private void Start()
        {
            IsInteractable = true;

            _color = Random.ColorHSV();


            if(TryGetComponent(out Renderer renderer))
            {
                renderer.sharedMaterial.color = _color;
            }
         
        }



    

        public void OnTriggerEnter(Collider other)
        {
            if (IsInteractable || other.CompareTag("Player"))
            {
                Interaction();
                IsInteractable = false;
            }
                
        }


        public abstract void Update();
        protected abstract void Interaction();

        public abstract void SaveBonus();
    }
}

