using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    
    public abstract class Gun : MonoBehaviour, IExecute
    {
        protected enum GunType
        {
            MeleeCombat,
            Firearms,
            Grenade
        }

        protected GunType _gun;
        protected GameObject _prefab;
        protected int _ammo;
        protected int _clips;
        protected float _damage;
        protected float _fireRate;
        protected GameObject _player;
        protected float _range;
        protected bool _isActive = false;

        public abstract void Update();
        public abstract void Shoot();

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !_isActive) 
            {
                _player = other.gameObject;
                var transformPlayerBody = _player.transform.Find("Armature").gameObject;

                if (transformPlayerBody != null)
                {
                    var spawnGun = transformPlayerBody.transform.Find("Root/Body_Upper/IK_Arm_Left/GunSpawn");
                    transform.parent = spawnGun.transform;
                    transform.localPosition = Vector3.zero;
                    transform.localEulerAngles = new Vector3(-5.74f, -56f, 14.54f);
         
                    GetComponent<Collider>().isTrigger = false;
                    _isActive = true;
                }
                else Debug.Log("No child with the name 'Gun' attached to the player");
        
            }

        }
    }
}
