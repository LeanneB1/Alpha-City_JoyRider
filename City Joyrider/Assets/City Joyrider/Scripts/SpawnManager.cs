using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private float spawnRange = 7;
    private float startDelay = 1;
    private float spawnInterval = 1f;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomObstacle", startDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Car").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnRandomObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRange, spawnRange), 0, 25);
            Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
        }
    }
}
