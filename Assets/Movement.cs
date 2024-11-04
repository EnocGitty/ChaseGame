using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera mainCamera;
    private float camHeight;
    private float camWidth;
    private float characterHeight;
    private bool started = false;

    void Start()
    {
        mainCamera = Camera.main;
        // Get cam dimensions
        camHeight = mainCamera.orthographicSize;
        camWidth = mainCamera.aspect * camHeight;
        //Character height based on box collider
        characterHeight = GetComponent<Collider>().bounds.size.y; 
        
      
    }
    public float speed = 5f; 
    
    
    void Update()
    {
        if (started)
        {
            // Key inputs WASD
            float moveHorizontal = Input.GetAxis("Horizontal") + 0.425f; 
            float moveVertical = Input.GetAxis("Vertical");    
            

            // Movement vector 
            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

            // Calculates position based off transform.position, previous movement vector, speed, and time
            Vector3 newPosition = transform.position + movement * speed * Time.deltaTime;

            // Mathf.Clap is (value to be constained, min val, max val)
            float clampedX = Mathf.Clamp(newPosition.x, mainCamera.transform.position.x - camWidth, mainCamera.transform.position.x + camWidth);
            float clampedY = Mathf.Clamp(newPosition.y, mainCamera.transform.position.y - camHeight, mainCamera.transform.position.y + camHeight - characterHeight);
            //change premade transform.position with the update clamped x and y values
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);

        }
    } 
    public void EnableMovement()
    {
        started = true;
    }


}
