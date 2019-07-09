using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public int numberofHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

     void Update()
     {
        if(health > numberofHearts)
        {
            health = numberofHearts;
        }
        if(health < 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            } else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numberofHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
            
        }
     }
}
