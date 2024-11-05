using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossCollision : MonoBehaviour
{
    private float maxHealth = 10f;
    private float currentHealth;
    public Image healthBar;
    public WinScreen WinScreen;
    private Animator animator;
    public AudioClip bossDeathSound;
    private AudioSource audioSource;

    void Start() // initialize health, health bar, audio source, and animator
    {
        currentHealth = maxHealth;
        healthBar.fillAmount = currentHealth/maxHealth;
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
   
    }
    // bullet collision using triggers
    private void OnTriggerEnter(Collider other)
    {   // reads the bullet prefab's tag
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }
    //subtracts dmg taken from current health, calculates healthbar fill amount to display health on screen
    void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        healthBar.fillAmount = currentHealth / maxHealth;
        if(currentHealth<=0) //when health is 0 turn on death function
        {
            Die();
        }
    }
    void Die()
    {   //disable collider so doesnt get loop died
        Collider collider = GetComponent<Collider>();
        collider.enabled = false;
        audioSource.PlayOneShot(bossDeathSound); //death sound
        animator.SetTrigger("Died"); // send trigger for death animation
        StartCoroutine(DeathAnimation()); // lets death animation play before win screen
    }

    private IEnumerator DeathAnimation()
    {
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("b2DeathFallDown1"));
        float animationLength = animator.GetCurrentAnimatorStateInfo(0).length - 0.3f;
        yield return new WaitForSeconds(animationLength);
        WinScreen.Setup();
    }
}
