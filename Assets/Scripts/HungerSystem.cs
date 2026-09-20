using UnityEngine;

public class HungerSystem : MonoBehaviour
{
    public float currentHunger = 0;
    public float maxHunger = 100;

    public bool isFull = false;

    private HungerBarUI hungerUI;

    void Start()
    {
        // Automatically find HungerBar in children
        hungerUI = GetComponentInChildren<HungerBarUI>();

        if (hungerUI != null)
        {
            hungerUI.SetMaxHunger(maxHunger);
        }
    }

    public void EatFood(float food)
    {
        if (isFull) return;

        currentHunger += food;

        if (currentHunger >= maxHunger)
        {
            currentHunger = maxHunger;
            isFull = true;
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (hungerUI != null)
        {
            hungerUI.UpdateHunger(currentHunger);
        }
    }
}