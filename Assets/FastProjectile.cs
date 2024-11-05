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
        if (started) //start delay
        {   
            shootTimer -= Time.deltaTime; //attack rate
            if (shootTimer <= 0)
            {
                Shoot();
                shootTimer = fpCooldown;
            }

        }
    }
    

    private void Shoot() //chooses one of 3 guns to shoot from, selects gun, instantiates bullet from gun, moves it forwards
    {
        int randomIndex = Random.Range(0, gunTransforms.Length);
        Transform selectedGun = gunTransforms[randomIndex];
        GameObject bullet = Instantiate(fpPrefab, selectedGun.position, selectedGun.rotation);
        Rigidbody fpRigidbody = bullet.GetComponent<Rigidbody>();
        fpRigidbody.velocity = selectedGun.forward *fpSpeed; 
        Destroy(bullet, fpLife);

    }
    //start delay
    public void EnableMovement()
    {
        started = true;
    }
}
