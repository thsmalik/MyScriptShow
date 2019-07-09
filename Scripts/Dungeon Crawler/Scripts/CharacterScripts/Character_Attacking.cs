using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Character_Attacking : MonoBehaviour
    {
        private Animator anim;
        [SerializeField]private Transform AttackPos;
        [SerializeField]private float radius;
        [SerializeField] private LayerMask whatIsEnemy;
        private float _attacktimer;
        public float _attackCD;
        [SerializeField]private int DMG;
      
        void Start()
        {
            anim = GetComponent<Animator>();
            _attacktimer = _attackCD;
        }

      
        void Update()
        {
            _attacktimer -= Time.fixedDeltaTime;
            if (Input.GetKeyDown(KeyCode.Space) && _attacktimer <= 0)
            {
                    anim.SetTrigger("Attack");
                    _attacktimer = _attackCD;                             
            }
        }

        void CollisionCheck()
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(AttackPos.position,radius,whatIsEnemy);
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<Enemy.Enemy_Stats>().TakeDamage(DMG);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(AttackPos.position,radius);
        }
    }
}
