using UnityEngine;
using UnityEngine.UI;

public class HungerBarUI : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void SetMaxHunger(float maxHunger)
    {
        slider.maxValue = maxHunger;
        slider.value = 0;
    }

    public void UpdateHunger(float currentHunger)
    {
        slider.value = currentHunger;
    }
}