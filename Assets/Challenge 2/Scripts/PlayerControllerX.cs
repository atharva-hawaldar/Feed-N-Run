using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    public float spawnCooldown = 1.5f; 
    private float lastSpawnTime = 0f;
    // Update is called once per frame
    void Update()
    {
        
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastSpawnTime + spawnCooldown)
        {
            Instantiate(dogPrefab, transform.position , dogPrefab.transform.rotation);
            lastSpawnTime = Time.time;
        }
    }
}
