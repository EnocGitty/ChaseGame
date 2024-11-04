using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    float bossSpeed = 3f;
    private bool started = false;

    // Update is called once per frame
    void Update()
    {
        if(started)
        {
            transform.position += Vector3.right * bossSpeed * Time.deltaTime;
        }
    }

    public void EnableMovement()
    {
        started = true;
    }
}
