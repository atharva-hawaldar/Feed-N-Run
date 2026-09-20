using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public float damageAmount = 20;
    private const float healAmount = 20f;
    public float foodAmount = 20;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource eatSound;
    [SerializeField] private AudioSource hitSound;

    private DamageSystem player;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.GetComponent<DamageSystem>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //  HIT PLAYER
        if (other.CompareTag("Player"))
        {
            PlaySound(hitSound);

            if (player != null)
            {
                player.TakeDamage(damageAmount);

                if (GameMode.Instance != null)
                    GameMode.Instance.AddScore(-10);
            }

            Destroy(gameObject);
            return;
        }

        //  FOOD EAT
        if (other.CompareTag("Food"))
        {
            HungerSystem animal = GetComponent<HungerSystem>();

            if (animal != null)
            {
                animal.EatFood(foodAmount);

                if (GameMode.Instance != null)
                    GameMode.Instance.AddScore(10);

                if (animal.isFull)
                {
                    if (player != null)
                        player.TakeHeal(healAmount);

                    if (GameMode.Instance != null)
                        GameMode.Instance.AddScore(20);

                    Destroy(gameObject);
                }
            }

            PlaySound(eatSound);

            Destroy(other.gameObject);
            return;
        }
    }

    void PlaySound(AudioSource source)
    {
        if (source != null && source.clip != null)
        {
            GameObject tempAudio = new GameObject("TempSound");
            AudioSource aSource = tempAudio.AddComponent<AudioSource>();

            aSource.clip = source.clip;
            aSource.volume = source.volume;
            aSource.spatialBlend = 0f; // 2D sound (important)
            aSource.Play();

            Destroy(tempAudio, source.clip.length);
        }
    }
}