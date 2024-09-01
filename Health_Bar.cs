using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar : MonoBehaviour
{
    public Slider slider;

    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        Debug.Log("Max health set");
    }
    public void SetHealth(int health)
    {
        slider.value = health;
        Debug.Log("Health Changed");
    }
}
