using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    
    
    public Vector2 spawnValues;
    public int enemyCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    private float searchingWait = 1f;



    public float spdmultiplyCount = .5f;

    // Use this for initialization

    bool enemyIsAlive()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <  1)
        {
            return false;
        }
        return true;
    }
    void Start()
    {
        StartCoroutine(SpawnWaves());

    }

    // Update is called once per frame
    void Update()
    {
        if(spdmultiplyCount >= 6f)
        {
            spdmultiplyCount = 6f;
        }
        
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {            
                for (int i = 0; i < enemyCount; i++)
                {
                    Vector2 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y + 5f, spawnValues.y));
                    Instantiate(enemy, spawnPosition, Quaternion.identity);
                    spawnWait = Random.Range(0.4f, 2f);
                    yield return new WaitForSeconds(spawnWait);
                }
            while (enemyIsAlive() == true)
            {
                yield return new WaitForSeconds(searchingWait);
            }
            enemyCount += Random.Range(4,11);
            spdmultiplyCount += .5f;   
            
            Debug.Log("Wave Completed");
            yield return new WaitForSeconds(waveWait);
                 
                        
        }
    }
}
