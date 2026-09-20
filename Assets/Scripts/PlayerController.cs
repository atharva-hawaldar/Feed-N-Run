using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 14.0f;
    [SerializeField] private float xRange = 19.0f;
    [SerializeField] private float zRange = 6.0f;

    [SerializeField] private GameObject projectilePrefab;

    private float horizontalInput;
    private float verticalInput;

    public AudioSource walkAudio;

    void Update()
    {
        // Input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);

        // left boundary
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        // right boundary
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // top boundary
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

        // bottom boundary
        if (transform.position.z < -3f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -3f);
        }

        // Walking sound
        if (horizontalInput != 0 || verticalInput != 0)
        {
            if (!walkAudio.isPlaying)
                walkAudio.Play();
        }
        else
        {
            walkAudio.Stop();
        }

        // Projectile spawn
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}