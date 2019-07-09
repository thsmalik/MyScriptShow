using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{     
    public class Enemy_AI : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Transform target;
        [SerializeField] private float followDistance;
        private bool facingRight = false;
        private Animator anim;


        void Start()
        {
            anim = GetComponent<Animator>();
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        void Update()
        {

            if (Vector2.Distance(transform.position, target.position) < followDistance && Vector2.Distance(transform.position,target.position) > 0.7f)
            {
                anim.SetBool("IsMoving",true);
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else
            {
                anim.SetBool("IsMoving",false);
            }

            if(Vector2.Distance(transform.position,target.position) < 1f)
            {
                anim.SetTrigger("Attack");
            }

            if (target.transform.position.x < gameObject.transform.position.x && facingRight)
                Flip();
            if (target.transform.position.x > gameObject.transform.position.x && !facingRight)
                Flip();
        }

        void Flip()
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }
    }
}
