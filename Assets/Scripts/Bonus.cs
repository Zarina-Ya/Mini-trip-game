using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZarinkinProject
{
    public abstract class Bonus : MonoBehaviour, IExecute
    {
        private bool _isInteractable;
        public Transform _transform;



        private void Awake()
        {
            _transform = transform;
        }


        private void Start()
        {
            _isInteractable = true;
        }




        public bool IsInteractable { get { return _isInteractable; }
            private set
            {
                _isInteractable = value;
                GetComponent<Renderer>().enabled = value;
                GetComponent<Collider>().enabled = value;
            }  
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Interaction();
                _isInteractable = false;
            }
                
        }


        public abstract void Update();
        protected abstract void Interaction();
    }
}

