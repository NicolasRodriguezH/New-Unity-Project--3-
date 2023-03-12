using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Array de Obstacles para los prefabs
    [SerializeField] private GameObject[] obstacles;

    public GameObject birdPrefab;
    public float spawnInterval = 1f;
    public float spawnHeightMin = -2f;
    public float spawnHeightMax = 2f;
    
    void Start()
    {
        StartCoroutine(SpawnObstacle());
        StartCoroutine(SpawnBirds());
    }

    private IEnumerator SpawnBirds()
    {
        while (true)
        {
            Vector3 spawnPos = new Vector3(transform.position.x, Random.Range(spawnHeightMin, spawnHeightMax), 0f);
            Instantiate(birdPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private IEnumerator SpawnObstacle() {
        while(true)
        {
            int randomIndex = Random.Range(0, obstacles.Length);
            float minTime = 0.6f;
            float maxTime = 1.8f;
            float randomTime = Random.Range(minTime, maxTime);
            Instantiate(obstacles[randomIndex], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(randomTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Destroy(collision.gameObject);
    }
}
