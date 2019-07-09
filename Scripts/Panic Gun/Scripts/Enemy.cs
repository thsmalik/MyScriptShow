using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int HP;
    private Transform PlayerTransform;
    [SerializeField] private float speed;
    private GameObject playerr;
    private EnemySpawner spdmanager;
    public Health healthh;
    void Start()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerr = GameObject.FindGameObjectWithTag("Player");
        healthh = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        spdmanager = FindObjectOfType<EnemySpawner>();
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, PlayerTransform.position, (speed + spdmanager.spdmultiplyCount) * Time.deltaTime);
        
        RotateTowardsPlayer();
        if (HP <= 0)
        {
            Die();
        }
        if (Vector2.Distance(transform.position, PlayerTransform.position) < .3f)
        {
            healthh.health -= 1;
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int DMG)
    {
        HP -= DMG;
    }
    public void Die()
    {
        Destroy(gameObject);
    }
    private void RotateTowardsPlayer()
    {
        Vector2 direction = PlayerTransform.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 5 * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Gun")
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    public void AddSpeed(float amount)
    {
        speed += amount;
        
    }
}
