using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    public float obstacleSpawnTime = 2f;
    private float timeUntilObstacleSpawn;
    public float obstacleSpeed = 1f; 

    private void Update()
    {
        SpawnLoop();

    }
     private void  SpawnLoop ()
    {
        timeUntilObstacleSpawn = Time.deltaTime;

        if (timeUntilObstacleSpawn >= obstacleSpawnTime)
        {
            spawn();
            timeUntilObstacleSpawn = 0f;

        }
    }
    private void spawn()
    {
        GameObject objectToSpawn = obstaclePrefabs[Random.Range(0,obstaclePrefabs.Length)];
        GameObject spawnObstacle = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        Rigidbody2D obstacleRB = spawnObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.velocity = Vector2.left * obstacleSpeed;
    }


 }
