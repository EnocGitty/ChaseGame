using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject[] hearts;
    private int currentHealth;
    private bool laserImmune = false;
    private float laserImmunityDuration = 3.1f;
    private float laserImmunityTimer;
    void Start()
    {
        currentHealth = hearts.Length;
        UpdateHearts();
        
    }

    public void TakeDamage(int dmg)
    {
        if(currentHealth > 0)
        {
            currentHealth-= dmg;
            UpdateHearts();
        }
    }

    
    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < currentHealth);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Trigger with: " + other.gameObject.name);
        if (other.CompareTag("FastProjectile"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
        else if(other.CompareTag("SlowProjectile"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
        else if(other.CompareTag("Laser"))
        {
            if (!laserImmune)
            {
                TakeDamage(2);
                ActivateImmunity();
            }
            
        }
    }
    private void ActivateImmunity()
    {
        laserImmune = true;
        laserImmunityTimer = laserImmunityDuration;
    }

    void Update()
    {
        if (laserImmune)
        {
            laserImmunityTimer -= Time.deltaTime;
            if (laserImmunityTimer <= 0)
            {
                laserImmune = false;
            }
        }
    }
}
