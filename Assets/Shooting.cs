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

   void Start()
   {
        animator = GetComponent<Animator>();
        animator.SetBool("IsShooting", false);
   }
    void Update()
    {
        shootTimer -= Time.deltaTime;

        if (Input.GetButton("Fire1") && shootTimer <= 0)
        {
            Shoot();
            shootTimer = shotCooldown;

            // Set the IsShooting parameter to true
            animator.SetBool("IsShooting", true);
        }
        else
        {
            // Ensure IsShooting is set to false when not shooting
            animator.SetBool("IsShooting", false);
        }
    }

    public float bulletSpeed = 10f;
    private float bulletLife = 2f;
    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, Quaternion.Euler(0, 0, -90));
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = gunTransform.forward * bulletSpeed;
        Destroy(bullet, bulletLife);
    }
}
