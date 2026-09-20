using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [SerializeField] private float currentHealth = 100f;
    [SerializeField] private float maxHealth = 100f;

    [SerializeField] private HealthBarUI healthUI;

    public bool isDead = false;


    void Start()
    {
        if (healthUI != null)
        {
            healthUI.SetMaxHealth(maxHealth);
            healthUI.UpdateHealth(currentHealth);
        }

        if (isDead)
        {
            Die();
        }
    }

    public void TakeHeal(float healAmount)
    {
        if (isDead) return;

        currentHealth += healAmount;


        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdateUI();
    }

    public void TakeDamage(float damageAmount)
    {
        if (isDead) return;

        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
            UpdateUI();
            Die();
            GameMode.Instance.GameOver();
            return;
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (healthUI != null)
        {
            healthUI.UpdateHealth(currentHealth);
        }
    }

    private void Die()
    {
        Debug.Log("Game Over");
        Destroy(gameObject);
    }
}