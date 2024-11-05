using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject cannon1;
    public GameObject cannon2;
    public GameObject laserPrefab;
    public float moveInSpeed = 3f;
    public float moveBackSpeed = 3f;
    public float travelTime = 2f;
    public float interval = 10f;
    public float laserLife = 3f;
    public AudioClip laserSound;
    private AudioSource audioSource;

    void Start()
    {   //cannons are time based, so coroutine
        StartCoroutine(StartCannon());      
        audioSource = GetComponent<AudioSource>();
    }


    private IEnumerator StartCannon()
    {   //waits for the start delay
        yield return new WaitForSeconds(2f);
        yield return new WaitForSeconds(interval); //waits for predetermined interval
        while (true) //always true, infinite loop
        {
            // randomly sslects cannon
            GameObject selectedCannon = Random.Range(0, 2) == 0 ? cannon1 : cannon2;
            Transform cannonTransform = selectedCannon.transform;
            // move cannon in, fire laser, move cannon back, wait for next interval, repeat
            yield return MoveIn(selectedCannon, Vector3.forward, travelTime);
            yield return Lasering(laserLife, cannonTransform);
            yield return MoveBack(selectedCannon, -Vector3.forward, travelTime);
            yield return new WaitForSeconds(interval);
        }
        
    }
    // move forward for 2 seconds at 3 speed (level moves at 3 speed so this stops the cannon and lets level catch up)
    private IEnumerator MoveIn(GameObject sCannon, Vector3 direction, float tTime)
    {
        float timer = 0f;
        while (timer < tTime)
        {
            sCannon.transform.Translate(direction * moveInSpeed * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
    }
    // move back for 2 seconds out of frame at 3 speed 
    private IEnumerator MoveBack(GameObject sCannon, Vector3 direction, float tTime)
    {
        float timer = 0f;
        while (timer < tTime)
        {
            sCannon.transform.Translate(direction * moveBackSpeed * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
    }
    // plays sound, adjusts the laser object so it properly comes out of the cannon tip connecting to the laser end
    private IEnumerator Lasering(float life, Transform selected)
    {
        audioSource.PlayOneShot(laserSound);
        Transform cannonTip = selected.transform.Find("CannonTip");
        GameObject laser = Instantiate(laserPrefab, cannonTip.position, Quaternion.Euler(0, 0, -90));
        Transform laserEnd = laser.transform.Find("LaserEnd");
        Vector3 offset = cannonTip.position - laserEnd.position;
        laser.transform.position += offset;
        float timer = 0f;
        float speed = 3f;
        while (timer < life)
        {   // move cannon to the right so it keeps up with scrolling 
            laser.transform.Translate(Vector3.up * speed * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
        Destroy(laser);
    }
}
