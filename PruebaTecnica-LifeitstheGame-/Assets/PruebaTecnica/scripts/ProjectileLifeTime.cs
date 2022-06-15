using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLifeTime : MonoBehaviour
{
    public float maxDistance;
    private Vector3 spawnPosition;
    public float projectileLifeTime;
    private bool maxDistanceReached = false;
    private int count = 0;
    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Rigidbody>().isKinematic)
        {
            checkDistance();
        }

        if (maxDistanceReached)
        {
            StartCoroutine(time());
            maxDistanceReached = false;
        }

        if(count > projectileLifeTime)
        {
            Explosion();
        }
    }

    void checkDistance()
    {
        if(Vector3.Distance(spawnPosition, this.transform.position) > maxDistance){

            GetComponent<Rigidbody>().isKinematic = true;
            maxDistanceReached = true;

        }
    }

    IEnumerator time()
    {
        while (true)
        {
            timeCount();
            yield return new WaitForSeconds(1);
        }
    }

    void timeCount()
    {
        count += 1;
    }

    void Explosion()
    {
        GameObject obj = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(obj, 5);
        Destroy(this.gameObject);
    }


    public void setMaxDistance( float distance )
    {
        maxDistance = distance;
    }

    //Mayor masa en el rigidbody, mayor es la fuerza de atraccion
    public void setAttractorForce(float force)
    {
        GetComponent<Rigidbody>().mass = force;
    }

    public void setProjectileLifeTime(float seconds)
    {
        projectileLifeTime = seconds;
    }

}
