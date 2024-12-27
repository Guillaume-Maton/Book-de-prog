using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider Slider;
    public Gradient gradient;
    public Image Fill;

    public void SetMaxHealth(int health)
    {
        Slider.maxValue = health;
        Slider.value = health;

        Fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        Slider.value = health;

        Fill.color = gradient.Evaluate(Slider.normalizedValue);
    }
}
