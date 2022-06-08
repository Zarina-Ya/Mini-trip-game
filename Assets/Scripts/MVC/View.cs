using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MVC
{
    public class View : MonoBehaviour
    {

        [SerializeField] private Transform _viewTransform;
        [SerializeField] private Collider _viewCollider;
        [SerializeField] private Rigidbody _viewRigidbody;

        public Action<Collider, int, Transform> OnLevelObjectContact { get; set; }
        public Transform ViewTransform { get => _viewTransform;  }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.name);
            Collider levelObject = other;

            OnLevelObjectContact?.Invoke(levelObject, Random.Range(1, 6), levelObject.transform);
        }
    }

}
