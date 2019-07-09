using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int DMG;
    public GameObject particle;
    public PlayerShooting player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Gun").GetComponent<PlayerShooting>();
        Destroy(gameObject, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.right * 10 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if(enemy!= null)
        {
            GameObject particless = Instantiate(particle, transform.position, Quaternion.identity);
            if(player.chargeTimer > 1f)
            {
                particless.transform.localScale = new Vector3(player.chargedTimer * 2 , player.chargedTimer * 2 , player.chargedTimer * 2);
            }
            Destroy(particless, 3f);
            enemy.TakeDamage(DMG);
        }
        if (player.chargedTimer <= 1.3f)
        {
            Destroy(gameObject);
        } else
        {
            Destroy(gameObject, 4f);
        }
    }
}
