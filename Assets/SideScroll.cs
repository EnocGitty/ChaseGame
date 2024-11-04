using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScroll : MonoBehaviour
{
    public float scrollSpeed = 3f;
    private bool started = false;

    // Update is called once per frame
    void Update()
    {
        if(started)
        {
            transform.position += new Vector3(scrollSpeed * Time.deltaTime, 0, 0);
        }
        
    }

    public void EnableMovement()
    {
        started = true;
    }

}
