using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDelay : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;
    public SideScroll cameraScroll;
    public SlowProjectile slow;
    public FastProjectile fast;
    public Shooting shoot;

    public float delayBeforeStart = 2f;

    void Start()
    {
        StartCoroutine(DelayedStart());
        
    }

    private IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(delayBeforeStart);
        player.GetComponent<Movement>().EnableMovement();
        boss.GetComponent<BossMovement>().EnableMovement();
        cameraScroll.EnableMovement();
        slow.EnableMovement();
        fast.EnableMovement();
        shoot.EnableShooting();

    }

}