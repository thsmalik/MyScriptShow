using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{    
    public class Enemy_Stats : MonoBehaviour
    {
        private Rigidbody2D rb;
        [SerializeField]private int HP;
        private Animator anim;
        [SerializeField] private GameObject health;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if(HP <= 0)
            {
                Vector2 positionBeforeDying = new Vector2(transform.position.x,transform.position.y);
                int chance = Random.Range(1, 10);
                Debug.Log(chance);
                if(chance >= 8)
                {
                    Instantiate(health,positionBeforeDying,Quaternion.identity);
                }
                Destroy(gameObject);
            }

        }

        public void TakeDamage(int amount)
        {
            HP -= amount;
            anim.SetTrigger("Attacked");
        }
    }
}
