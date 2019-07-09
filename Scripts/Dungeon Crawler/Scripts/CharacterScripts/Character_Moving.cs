using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Character_Moving : MonoBehaviour
    {
        //Componenets
        private Rigidbody2D rb;
        private Animator anim;

        //Attributes
        public float speed;
        private float MoveInputX;
        private float MoveInputY;
        private bool facingRight = true;



        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }


        void FixedUpdate()
        {
            Move();
        }

        void Move()
        {
            MoveInputX = Input.GetAxisRaw("Horizontal") * speed;
            MoveInputY = Input.GetAxisRaw("Vertical") * speed;
            if (MoveInputX > 0 || MoveInputX < 0 || MoveInputY > 0 || MoveInputY < 0)
            {
                anim.SetBool("isMoving", true);
            }
            else
            {
                anim.SetBool("isMoving", false);
            }
            rb.velocity = new Vector2(MoveInputX, MoveInputY);

            if (facingRight == false && MoveInputX > 0)
            {
                Flip();
            }
            else if (facingRight == true && MoveInputX < 0)
            {
                Flip();
            }
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
