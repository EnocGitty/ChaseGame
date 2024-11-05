using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastProjectile : MonoBehaviour
{
    public GameObject fpPrefab;
    public Transform[] gunTransforms;
    public float fpCooldown = .3f;
    private float shootTimer = 0f;
    public float fpSpeed = 8f;
    private float fpLife = 2f;
    private bool started = false;

    void Update()
    {
        if (started)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                Shoot();
                shootTimer = fpCooldown;
            }

        }
    }
    

    private void Shoot()
    {
        int randomIndex = Random.Range(0, gunTransforms.Length);
        Transform selectedGun = gunTransforms[randomIndex];
        GameObject bullet = Instantiate(fpPrefab, selectedGun.position, selectedGun.rotation);
        Rigidbody fpRigidbody = bullet.GetComponent<Rigidbody>();
        fpRigidbody.velocity = selectedGun.forward *fpSpeed; 
        Destroy(bullet, fpLife);

    }

    public void EnableMovement()
    {
        started = true;
    }
}
