using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Healthbar : MonoBehaviour
{
    public Slider healthSlider;
    public GameObject undead;
    public float undeadLife;
    private int health = 100;

    private void Update()
    {
        healthSlider.value = health;
        
    }
    private void Start()
    {
        InvokeRepeating(nameof(HealthDecrease), 1.0f, undeadLife / 10);
    }

    private void HealthDecrease()
    {
        if (health > 0)
        {
            health -= 10;
        }
        else
        {
            Despawn(); 
        }
    }

    private void Despawn()
    {
        Destroy(undead);
    }

}
