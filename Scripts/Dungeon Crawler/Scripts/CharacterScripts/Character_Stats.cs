using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Character_Stats : MonoBehaviour
    {
        [SerializeField]private float max_HP;
        private float cur_HP;
        [SerializeField] private UnityEngine.UI.Image health;
        // Start is called before the first frame update
        void Start()
        {
            cur_HP = max_HP;
        }

        // Update is called once per frame
        void Update()
        {
            health.fillAmount = 1 / (max_HP / cur_HP);
            if (cur_HP <= 0)
            {
                Die();
            }
        }
        
        void Die()
        {
            Destroy(gameObject);
            UnityEngine.SceneManagement.SceneManager.LoadScene("You Lose");
        }

        public void TakeDamage(float amount)
        {
            cur_HP -= amount;
        }

        public void AddHealth(float amount)
        {
            cur_HP += amount;
        }
    }
}
