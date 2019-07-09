using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

public class HealthPotion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag  == "Player")
        {
            collision.GetComponent<Character_Stats>().AddHealth(10);
            Destroy(gameObject);
        }
    }
}
