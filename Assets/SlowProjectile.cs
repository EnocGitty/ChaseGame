using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowProjectile : MonoBehaviour
{
    public GameObject spPrefab;
    public Transform[] sgunTransforms;
    public float spCooldown = .7f;
    private float shootTimer = 0f;
    public float spSpeed = 4f;
    private float spLife = 4f;
    private bool started = false;

    void Update()
    {
        if (started)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                Shoot();
                shootTimer = spCooldown;
            }
        }
    }
    

    private void Shoot()
    {
        int randomIndex = Random.Range(0, sgunTransforms.Length);
        Transform selectedGun = sgunTransforms[randomIndex];
        GameObject bullet = Instantiate(spPrefab, selectedGun.position, selectedGun.rotation);
        Rigidbody spRigidbody = bullet.GetComponent<Rigidbody>();
        spRigidbody.velocity = selectedGun.forward * spSpeed; 
        Destroy(bullet, spLife);

    }
    public void EnableMovement()
    {
        started = true;
    }
}
