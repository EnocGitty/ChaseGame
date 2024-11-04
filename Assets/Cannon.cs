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

    void Start()
    {
        StartCoroutine(StartCannon());      
    }


    private IEnumerator StartCannon()
    {
        yield return new WaitForSeconds(interval);
        while (true)
        {
            GameObject selectedCannon = Random.Range(0, 2) == 0 ? cannon1 : cannon2;
            Transform cannonTransform = selectedCannon.transform;
            yield return MoveIn(selectedCannon, Vector3.forward, travelTime);
            yield return Lasering(laserLife, cannonTransform);
            yield return MoveBack(selectedCannon, -Vector3.forward, travelTime);
            yield return new WaitForSeconds(interval);
        }
        
    }

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

    private IEnumerator Lasering(float life, Transform selected)
    {

        Transform cannonTip = selected.transform.Find("CannonTip");
        GameObject laser = Instantiate(laserPrefab, cannonTip.position, Quaternion.Euler(0, 0, -90));
        Transform laserEnd = laser.transform.Find("LaserEnd");
        Vector3 offset = cannonTip.position - laserEnd.position;
        laser.transform.position += offset;
        float timer = 0f;
        float speed = 3f;
        while (timer < life)
        {
            laser.transform.Translate(Vector3.up * speed * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
        Destroy(laser);
    }
}
