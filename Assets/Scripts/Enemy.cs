using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject {
    public class Enemy : Unit
    {
        private void Awake()
        {
            _heath = 10;
        }
        public override void Jump()
        {
            throw new System.NotImplementedException();
        }

        public override void Move(float x, float y, float z)
        {
            throw new System.NotImplementedException();
        }

        public override void SavePlayer()
        {
            throw new System.NotImplementedException();
        }


        public void Hit(int damage)
        {
            _heath -= damage;
            if(_heath <= 0)
                this.gameObject.SetActive(false);
            Debug.Log(_heath);
        }
  

     
    }
}
