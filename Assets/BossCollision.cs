using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossCollision : MonoBehaviour
{
    private float maxHealth = 300f;
    private float currentHealth;
    public Image healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.fillAmount = currentHealth/maxHealth;
   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }

    void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        healthBar.fillAmount = currentHealth / maxHealth;
        if(currentHealth<=0)
        {
            Destroy(gameObject);
        }
    }
}
