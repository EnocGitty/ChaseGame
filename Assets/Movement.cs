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
    void Start()
    {
        mainCamera = Camera.main;
        camHeight = mainCamera.orthographicSize;
        camWidth = mainCamera.aspect * camHeight;
        characterHeight = GetComponent<Collider>().bounds.size.y; 
        
      
    }

    public float speed =5f;
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); 
        float moveVertical = Input.GetAxis("Vertical");    

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        Vector3 newPosition = transform.position + movement * speed * Time.deltaTime;

        float clampedX = Mathf.Clamp(newPosition.x, mainCamera.transform.position.x - camWidth, mainCamera.transform.position.x + camWidth);
        float clampedY = Mathf.Clamp(newPosition.y, mainCamera.transform.position.y - camHeight, mainCamera.transform.position.y + camHeight - characterHeight);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    

}

/*

    float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        // Vector3 movement = new Vector3(0.0f, moveVertical, moveHorizontal);

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        Vector3 newPosition = transform.position + movement * speed * Time.deltaTime;

        float clampedX = Mathf.Clamp(newPosition.x, mainCamera.transform.position.x - camWidth, mainCamera.transform.position.x + camWidth);
        float clampedY = Mathf.Clamp(newPosition.y, mainCamera.transform.position.y - camHeight, mainCamera.transform.position.y + camHeight);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

        //transform.Translate(movement * speed * Time.deltaTime);

        */