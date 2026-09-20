using UnityEngine;

public class FoxSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject foxPrefab;

    private float spawnPosX = 25f;
    private float topSpawnZ = 8f;
    private float bottomSpawnZ = 4.5f;

    private float spawnInterval = 10f;
    private float minSpawnInterval = 2f;

    private float spawnTimer = 0f;
    private float difficultyTimer = 0f;
    private float difficultyIncreaseTime = 30f;

    void Update()
    {
        spawnTimer += Time.deltaTime;
        difficultyTimer += Time.deltaTime;

        // Spawn fox
        if (spawnTimer >= spawnInterval)
        {
            SpawnFox();
            spawnTimer = 0f;
        }

        // Increase difficulty every 30 seconds
        if (difficultyTimer >= difficultyIncreaseTime)
        {
            spawnInterval -= 1f;

            if (spawnInterval < minSpawnInterval)
                spawnInterval = minSpawnInterval;

            difficultyTimer = 0f;
        }
    }

    void SpawnFox()
    {
        int side = Random.Range(0, 2);

        float xPos = (side == 0) ? -spawnPosX : spawnPosX;
        float zPos = Random.Range(bottomSpawnZ, topSpawnZ);

        Vector3 spawnPos = new Vector3(xPos, 0, zPos);

        Quaternion rotation = (side == 0)
            ? Quaternion.Euler(0, 90, 0)
            : Quaternion.Euler(0, -90, 0);

        Instantiate(foxPrefab, spawnPos, rotation);
    }
}