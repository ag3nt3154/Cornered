using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemies;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 3f;
    float nextSpawn = 0.0f;
    private float timenow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-8.4f, 8.4f);
            whereToSpawn = new Vector2(20, 20);
            GameObject clone;
            clone = Instantiate(enemies, whereToSpawn, Quaternion.identity);
            clone.gameObject.SetActive(true);
        }
        if (Time.time - timenow > 5)
        {
            timenow = timenow + 5;
            spawnRate = spawnRate - 0.2f;
            if (spawnRate < 2)
            {
                spawnRate = 2;
            }
        }
    }
}
