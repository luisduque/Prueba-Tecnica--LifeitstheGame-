using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicProjectileLifetime : MonoBehaviour
{
    public bool destroyOnCollision;
    private bool canCount = false;
    public float secondsToDestroy;
    public int count = 0;
    public bool isSimulation;

    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSimulation)
        {
            if (count > secondsToDestroy)
            {
                Explosion();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isSimulation)
        {
            if (destroyOnCollision)
            {
                Explosion();
            }
            else
            {
                StartCoroutine(time());
                Debug.Log("Timer Counting..");
            }
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
}
