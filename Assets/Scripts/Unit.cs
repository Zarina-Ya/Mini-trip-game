using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] protected Rigidbody _rb;
        [SerializeField] protected Transform _transform;
        [SerializeField] protected static float _speed =5;
        [SerializeField] protected static int _heath = 100;
        [SerializeField] protected static bool _isDead;

        public abstract void Move(float x, float y, float z);
        public abstract void Jump();
    }

}