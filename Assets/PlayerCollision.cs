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
    public GameOverScreen GameOverScreen;
    private Animator animator;
    public AudioClip deathSound;
    public AudioClip hitSound;
    private AudioSource audioSource;
    public Shooting shoot;
    void Start() //initialize hearts, animator, and audio
    {
        currentHealth = hearts.Length;
        UpdateHearts();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        
    }

    public void TakeDamage(int dmg)
    {
        if(currentHealth > 0) //while health is above 0, play hit sound, calc new hp, update hearts, if hp < 0 die function
        {
            audioSource.PlayOneShot(hitSound); 
            currentHealth-= dmg;
            UpdateHearts();
            if (currentHealth <= 0)
            {
                shoot.DisableShooting();
                Die();
            }
        }
        
    }
    void Die()
    {
        audioSource.PlayOneShot(deathSound);
        animator.SetTrigger("Death");
        StartCoroutine(DeathAnimation());
    }
    private IEnumerator DeathAnimation()
    {
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Die"));
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        GameOverScreen.Setup();
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
