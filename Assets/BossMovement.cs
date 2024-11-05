using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    float bossSpeed = 3f;
    private bool started = false;

    void Update()
    {
        // continually moves boss to the right for scrolling, has start delay
        if(started)
        {
            transform.position += Vector3.right * bossSpeed * Time.deltaTime;
        }
    }

    //used for the startdelay class
    public void EnableMovement()
    {
        started = true;
    }
}
