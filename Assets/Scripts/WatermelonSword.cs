using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public class WatermelonSword : Gun
    {
        Transform _positionSpawn;
        private void Awake()
        {
            _positionSpawn = transform.Find("SpawnBullet");
            _damage = 10;
            _range = 15;
        }
        public override void Shoot()
        {
            RaycastHit hit;
            if (Physics.Raycast(_positionSpawn.position, _positionSpawn.forward, out hit, _range))
            {
                if(hit.collider.tag == "Enemy")
                {
                    Debug.Log("AAAAA" + hit.collider.name);

                    hit.collider.GetComponent<Enemy>().Hit(((int)_damage));

                }
              
            }
        }

        public override void Update()
        {
           
            Debug.DrawRay(_positionSpawn.position, _positionSpawn.up, Color.yellow, _range );
            if (Input.GetMouseButtonDown(0) && _isActive)
                Shoot();
        }

    }
}