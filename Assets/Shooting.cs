using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gunTransform;
    public float shotCooldown = 0.2f;
    private float shootTimer = 0f;
    private Animator animator;
    private bool started = false;
    public AudioClip shotSound;
    private AudioSource audioSource;

   void Start()
   {
        animator = GetComponent<Animator>();
        animator.SetBool("IsShooting", false);
        audioSource = GetComponent<AudioSource>();
   }
    void Update()
    {
        if (started)
        {
            shootTimer -= Time.deltaTime;

            if (Input.GetButton("Fire1") && shootTimer <= 0)
            {
                Shoot();
                shootTimer = shotCooldown;
                // bool trigger for animation
                animator.SetBool("IsShooting", true);
            }
            else
            {
                // bool trigger for animation
                animator.SetBool("IsShooting", false);
            }
        }
    }

    public float bulletSpeed = 30f;
    private float bulletLife = 2f;
    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, Quaternion.Euler(0, 0, -90));
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = gunTransform.forward * bulletSpeed;
        audioSource.PlayOneShot(shotSound);
        Destroy(bullet, bulletLife);
    }
    public void EnableShooting()
    {
        started = true;
    }
    public void DisableShooting()
    {
        started = false;
    }
}
