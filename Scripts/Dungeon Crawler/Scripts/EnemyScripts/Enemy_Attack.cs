using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Enemy_Attack : MonoBehaviour
    {
        [SerializeField]private float DMG;
        [SerializeField] private Transform AttackPos;
        [SerializeField] private float radius;
        [SerializeField] private LayerMask whatIsPlayer;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void CollisionCheck()
        {
            Collider2D[] player = Physics2D.OverlapCircleAll(AttackPos.position, radius, whatIsPlayer);
            for (int i = 0; i < player.Length; i++)
            {
                player[i].GetComponent<Character.Character_Stats>().TakeDamage(DMG);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(AttackPos.position, radius);
        }
    }
}
