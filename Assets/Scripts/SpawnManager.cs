using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] animalPrefabs;

    [SerializeField] private float spawnRangeX = 10;
    [SerializeField] private float spawnPosZ = 25;

    [SerializeField] private float spawnInterval = 1.5f;
    [SerializeField] private float minSpawnInterval = 0.3f;

    [SerializeField] private float spawnTimer = 0f;

    [SerializeField] private float difficultyTimer = 0f;
    [SerializeField] private float difficultyIncreaseTime = 30f;

    void Update()
    {
        spawnTimer += Time.deltaTime;
        difficultyTimer += Time.deltaTime;

        // Spawn animals
        if (spawnTimer >= spawnInterval)
        {
            SpawnRandomAnimal();
            spawnTimer = 0f;
        }

        // Increase difficulty every 30 seconds
        if (difficultyTimer >= difficultyIncreaseTime)
        {
            spawnInterval -= 0.1f;

            if (spawnInterval < minSpawnInterval)
                spawnInterval = minSpawnInterval;

            difficultyTimer = 0f; // reset timer
        }
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Vector3 spawnPos = new Vector3(
            Random.Range(-spawnRangeX, spawnRangeX),
            0,
            spawnPosZ
        );

        Instantiate(
            animalPrefabs[animalIndex],
            spawnPos,
            animalPrefabs[animalIndex].transform.rotation
        );
    }
}