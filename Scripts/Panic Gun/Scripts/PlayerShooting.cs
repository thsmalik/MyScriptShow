using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public Transform point;
    public GameObject bullet;
    public GameObject particle;
    public float chargedTimer;
    public int MaxAmmo;
    public float chargeTimer;
    private float shootCD;
    public float shootTimer;
    // Start is called before the first frame update
    void Start()
    {
        shootCD = shootTimer;
        InvokeRepeating("AddingAmmo",1f,3f);
    }

    // Update is called once per frame
    void Update()
    {
        shootCD -= Time.deltaTime;

        Shoot();

        
    }

    void AddingAmmo()
    {
        MaxAmmo += 1;
    }

    void Shoot()
    {        
        if (MaxAmmo <= 0)
        {
            MaxAmmo = 0;
        }
        if (MaxAmmo >= 100)
        {
            MaxAmmo = 100;
        }

        if (chargeTimer >= 2)
        {
            chargeTimer = 2f;
        }
        if (Input.GetKeyUp(KeyCode.Space) && chargeTimer <= 1f && MaxAmmo > 0 && shootCD <= 0 || Input.GetKeyUp(KeyCode.Space) && chargeTimer > 1f && MaxAmmo < 5 && shootCD <= 0)
        {
            Instantiate(bullet, point.position, point.rotation);
            chargeTimer = 0;
            MaxAmmo -= 1;
            shootCD = shootTimer;
            chargedTimer = 0f;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            chargeTimer += Time.deltaTime;
            chargedTimer = 0f;
        }
        if (Input.GetKeyUp(KeyCode.Space) && chargeTimer > 1f && MaxAmmo > 5)
        {
            chargedTimer = chargeTimer;
            GameObject powerBullet = Instantiate(bullet, point.position, point.rotation) as GameObject;
            powerBullet.GetComponent<Bullet>().DMG += (int)chargeTimer * 35;

            powerBullet.transform.localScale = new Vector3(chargeTimer / 2.5f, chargeTimer / 2.5f, chargeTimer / 2.5f);
            MaxAmmo -= (int)chargeTimer * 4;
            chargeTimer = 0f;
            shootCD = shootTimer;

        }
    }
    
}
